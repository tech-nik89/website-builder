using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Compiling;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Core.Publishing;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class MainForm {
		
		private bool _CompilerRunning = false;

		private static readonly String _ProjectFilesFilter = String.Format(Strings.ProjectFilesFilter, Project.FileExtension);

		private readonly String _ProductName;

		private Project _CurrentProject;

		private Project CurrentProject {
			get {
				return _CurrentProject;
			}
			set {
				_CurrentProject = value;

				UpdateFormText();
				RefreshLanguageList();
				RefreshPublishMenu();
				_Pages.Project = _CurrentProject;

				if (!String.IsNullOrWhiteSpace(_CurrentProject.ProjectFilePath)
					&& File.Exists(_CurrentProject.ProjectFilePath)) {

					ConfigHelper.AddRecentProject(_CurrentProject.ProjectFilePath);
					ConfigHelper.UpdateRecents(mnuProjectRecents, mnuProjectRecentItem_Click);
				}
			}
		}

		private void mnuProjectRecentItem_Click(String path) {
			OpenProject(path);
		}

		private String GetProductName() {
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			return versionInfo.ProductName;
		}

		private void mnuProjectRecentItem_Click(object sender, EventArgs e) {
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			OpenProject((String)item.Tag);
		}

		private void UpdateFormText() {
			if (_CurrentProject == null) {
				Text = _ProductName;
				return;
			}

			if (String.IsNullOrWhiteSpace(CurrentProject.ProjectFilePath)) {
				Text = _ProductName;
				return;
			}

			StringBuilder builder = new StringBuilder();
			builder.Append(_CurrentProject.ProjectFileName);

			if (CurrentProject.Dirty) {
				builder.Append("*");
			}

			builder.Append(" - ");
			builder.Append(_ProductName);

			Text = builder.ToString();
		}

		private void NewProject() {
			if (ConfirmCloseDirtyProject()) {
				// cancel
				return;
			}

			CurrentProject = new Project();
		}

		private void SaveProject(bool saveAs) {
			if (CurrentProject == null) {
				return;
			}

			if (saveAs || String.IsNullOrEmpty(CurrentProject.ProjectFilePath)) {
				DialogResult result = sfdProject.ShowDialog();

				if (result == DialogResult.OK) {
					CurrentProject.ProjectFilePath = sfdProject.FileName;
				}
				else {
					return;
				}
			}
			
			CurrentProject.Save();
			UpdateFormText();
		}

		private void OpenProject() {
			DialogResult result = ofdProject.ShowDialog();
			if (result != DialogResult.OK) {
				return;
			}

			OpenProject(ofdProject.FileName);
		}

		private void OpenProject(String path) {
			if (ConfirmCloseDirtyProject()) {
				// cancel
				return;
			}

			try {
				Project project = Project.Load(path);

				CurrentProject = project;
			}
			catch (Exception e) {
				HandleError(Strings.ProjectLoadErrorMessage, e);
			}
		}

		private void CompileProject() {
			CompileProject(false, null, null);
		}

		private void CompileProject(bool runAfterCompile) {
			CompileProject(runAfterCompile, null, null);
		}

		private void CompileProject(Page previewPage, Language previewLanguage) {
			CompileProject(false, previewPage, previewLanguage);
		}

		private async void CompileProject(bool runAfterCompile, Page previewPage, Language previewLanguage) {
			if (CurrentProject == null || _CompilerRunning) {
				return;
			}

			_CompilerRunning = true;
			
			UpdateStatus(StatusText.BuildStarted);
			CompilerSetControls(false);
			bool taskBarProgressSupported = TaskbarManager.IsPlatformSupported;

			if (taskBarProgressSupported) {
				TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
			}

			_CompilerError.Messages = new CompilerMessage[0];
			FocusOutputWindow();
			
			Compiler compiler = new Compiler(CurrentProject, new CompilerSettings() {
				PreviewPage = previewPage,
				PreviewLanguage = previewLanguage
			});

			Progress<CompilerProgressReport> progress = new Progress<CompilerProgressReport>(report => {
				tspProgress.Value = report.Percentage;
				_CompilerOutput?.Push(report);

				if (taskBarProgressSupported) {
					TaskbarManager.Instance.SetProgressValue(report.Percentage, 100);
				}
			});

			
			await compiler.CompileAsync(progress);
				
			_CompilerError.Messages = compiler.Messages.ToArray();

			if (compiler.Error) {
				FocusErrorWindow();
			}
			else if (!compiler.Error && runAfterCompile) {
				OpenProjectInDefaultBrowser(CurrentProject);
			}

			if (taskBarProgressSupported) {
				TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
			}

			_CompilerRunning = false;
			CompilerSetControls(true);
			UpdateStatus(compiler.Error ? StatusText.BuildFailed : StatusText.BuildSucceeded);
		}

		private void FocusOutputWindow() {
			_CompilerOutput.Pane.Activate();
			_CompilerOutput.Activate();
		}

		private void FocusErrorWindow() {
			_CompilerError.Pane.Activate();
			_CompilerError.Activate();
		}

		private void CompilerSetControls(bool enabled) {
			mnuBuildProject.Enabled = enabled;
			mnuBuildAndRunProject.Enabled = enabled;
			mnuBuildPage.Enabled = enabled;
			mnuBuildCleanOutput.Enabled = enabled;
			tspProgress.Value = 0;
		}

		private void HandleError(String message) {
			HandleError(message, null);
		}

		private void HandleError(Exception e) {
			HandleError(e.Message, null);
		}
		
		private void HandleError(String message, Exception e) {
			StringBuilder builder = new StringBuilder();
			builder.Append(message);

			if (e != null) {
				builder.AppendLine();
				builder.AppendLine();
				builder.Append(Strings.Details);
				builder.Append(": ");
				builder.Append(e.Message);
			}

			MessageBox.Show(builder.ToString(), Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void OpenProjectInDefaultBrowser(Project project) {
			if (String.IsNullOrWhiteSpace(project.OutputPath) || !Directory.Exists(project.OutputPath)) {
				return;
			}

			Process.Start(project.OutputPath);
		}

		private void UpdateStatus(String status) {
			tslStatus.Text = status;
		}

		private bool ConfirmCloseDirtyProject() {
			if (!CurrentProject.Dirty) {
				return false;
			}

			DialogResult result = MessageBox.Show(
				Strings.DirtyProjectConfirmSaveMessage,
				Strings.DirtyProjectConfirmSaveTitle,
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Question);

			switch (result) {
				case DialogResult.Yes:
					SaveProject(false);
					return false;
				case DialogResult.No:
					return false;
				default:
				case DialogResult.Cancel:
					return true;
			}
		}

		private void ClearOutputDirectory() {
			if (CurrentProject == null) {
				return;
			}

			Compiler.ClearOutputDirectory(CurrentProject);
		}

		private void RefreshLanguageList() {
			int previousIndex = _LanguageComboBox.SelectedIndex;
			_LanguageComboBox.Items.Clear();

			if (CurrentProject == null) {
				return;
			}

			foreach(Language language in CurrentProject.Languages) {
				_LanguageComboBox.Items.Add(language.Description);
			}

			if (previousIndex > 0 && previousIndex < _LanguageComboBox.Items.Count) {
				_LanguageComboBox.SelectedIndex = previousIndex;
			}
			else if (_LanguageComboBox.Items.Count > 0 ){
				_LanguageComboBox.SelectedIndex = 0;
			}
		}

		private void RefreshPublishMenu() {
			if (CurrentProject == null) {
				return;
			}

			mnuBuildPublish.Enabled = CurrentProject.Publishing.Count > 0;
			mnuBuildPublish.DropDownItems.Clear();

			for(int i = 0; i < CurrentProject.Publishing.Count; i++) {
				PublishItem publishItem = CurrentProject.Publishing[i];
				ToolStripMenuItem menuItem = new ToolStripMenuItem();

				menuItem.Text = !String.IsNullOrWhiteSpace(publishItem.Name)
					? publishItem.Name
					: PluginManager.Publishers[publishItem.Type];

				menuItem.Tag = i;
				menuItem.Click += PublishMenuItem_Click;

				mnuBuildPublish.DropDownItems.Add(menuItem);
			}
		}

		private async void PublishMenuItem_Click(Object sender, EventArgs e) {
			if (CurrentProject == null) {
				return;
			}

			UpdateStatus(StatusText.PublishingStarted);
			FocusOutputWindow();

			mnuBuildPublish.Enabled = false;
			int index = (int)((ToolStripMenuItem)sender).Tag;
			PublishItem item = CurrentProject.Publishing[index];

			try {
				Progress<String> progress = new Progress<String>(report => {
					UpdateStatus(report);
					_CompilerOutput?.Push(report);
				});

				IPublish publisher = PluginManager.LoadPublisher(item.Type, CurrentProject);
				await publisher.RunAsync(CurrentProject.OutputPath, item.Data, progress);

				_CompilerError.Messages = publisher.Messages.ToArray();

				if (publisher.Error) {
					UpdateStatus(StatusText.PublishingFailed);
					FocusErrorWindow();
				}
				else {
					UpdateStatus(StatusText.PublishingSucceeded);
				}
			}
			finally {
				mnuBuildPublish.Enabled = true;
			}
		}
	}
}
