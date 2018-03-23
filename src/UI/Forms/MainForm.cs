using System;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Controls;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;
using WebsiteStudio.Updater;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Forms {
	public partial class MainForm : Form {

		private readonly PagesTreeView _Pages;

		private readonly PageContentListAdvanced _Content;

		private readonly DockPanel _DockPanel;

		private readonly CompilerOutput _CompilerOutput;
		private readonly CompilerError _CompilerError;

		private readonly ToolStripComboBox _LanguageComboBox;

		private readonly ToolStrip _ProjectToolbar;

		private readonly UpdateService _Updater;
		
		public MainForm() {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			_Updater = new UpdateService();
			_LanguageComboBox = new ToolStripComboBox();
			_ProjectToolbar = CreateProjectToolbar();

			_Content = new PageContentListAdvanced();
			_Pages = new PagesTreeView(_Content.EnableContentControls, _Content.RefreshContent);
			_Content.Pages = _Pages;
			_Content.KeyPressed += Content_KeyPressed;

			_CompilerOutput = new CompilerOutput();
			_CompilerError = new CompilerError();

			_DockPanel = new DockPanel() {
				Dock = DockStyle.Fill,
				Theme = new VS2015LightTheme(),
				DocumentStyle = DocumentStyle.DockingWindow
			};

			tscMain.ContentPanel.Controls.Add(_DockPanel);
			_Pages.Show(_DockPanel, DockState.DockLeft);
			_Content.Show(_DockPanel, DockState.Document);
			_CompilerOutput.Show(_DockPanel, DockState.DockBottomAutoHide);
			_CompilerError.Show(_DockPanel, DockState.DockBottomAutoHide);

			_ProductName = GetProductName();
			ofdProject.Filter = _ProjectFilesFilter;
			sfdProject.Filter = _ProjectFilesFilter;
			
			_Pages.BuildPageRequested += mnuBuildPage_Click;
			_Content.ContentUpdated += ptvwPages_ContentUpdated;

			tscMain.TopToolStripPanel.Controls.Add(_Content.Toolbar);
			tscMain.TopToolStripPanel.Controls.Add(_Pages.Toolbar);
			tscMain.TopToolStripPanel.Controls.Add(_ProjectToolbar);

			tslStatus.Text = StatusText.Ready;
			CurrentProject = new Project();

			// Focus the output window once to ensure it's being
			// displayed when running a build (workaround).
			FocusOutputWindow();
		}
		
		private void ApplyIcons() {
			if (IconPack.Current == null) {
				return;
			}

			// Menus
			mnuProjectSave.Image = IconPack.Current.GetImage(IconPackIcon.Save);
			mnuProjectOpen.Image = IconPack.Current.GetImage(IconPackIcon.Open);
			mnuProjectSettings.Image = IconPack.Current.GetImage(IconPackIcon.Settings);
			mnuProjectSecurity.Image = IconPack.Current.GetImage(IconPackIcon.Security);
			mnuProjectExit.Image = IconPack.Current.GetImage(IconPackIcon.Close);

			mnuContentMedia.Image = IconPack.Current.GetImage(IconPackIcon.Media);
			mnuContentFooter.Image = IconPack.Current.GetImage(IconPackIcon.Footer);

			mnuBuildProject.Image = IconPack.Current.GetImage(IconPackIcon.Build);
			mnuBuildPage.Image = IconPack.Current.GetImage(IconPackIcon.BuildPage);
			mnuBuildPublish.Image = IconPack.Current.GetImage(IconPackIcon.Publish);

			mnuToolsPlugins.Image = IconPack.Current.GetImage(IconPackIcon.Plugin);

			mnuHelpUpdateCheck.Image = IconPack.Current.GetImage(IconPackIcon.Update);
			mnuHelpAbout.Image = IconPack.Current.GetImage(IconPackIcon.About);
		}

		private void LocalizeComponent() {

			// Menus
			mnuProject.Text = Strings.Project;
			mnuProjectNew.Text = Strings.New;
			mnuProjectOpen.Text = Strings.Open;
			mnuProjectRecents.Text = Strings.RecentProjects;
			mnuProjectSave.Text = Strings.Save;
			mnuProjectSaveAs.Text = Strings.SaveAs;
			mnuProjectSettings.Text = Strings.ProjectSettings;
			mnuProjectSecurity.Text = Strings.Security;
			mnuProjectExit.Text = Strings.Exit;

			mnuContent.Text = Strings.Content;
			mnuContentMedia.Text = Strings.Media;
			mnuContentFooter.Text = Strings.Footer;

			mnuBuild.Text  = Strings.Build;
			mnuBuildProject.Text = Strings.BuildProject;
			mnuBuildAndRunProject.Text = Strings.BuildAndOpenProject;
			mnuBuildPage.Text = Strings.BuildSelectedPageOnly;
			mnuBuildCleanOutput.Text = Strings.ClearOutputDirectory;
			mnuBuildPublish.Text = Strings.Publishing;

			mnuTools.Text = Strings.Tools;
			mnuToolsPlugins.Text = Strings.Plugins;

			mnuHelpUpdateCheck.Text = Strings.UpdateCheck;
			mnuHelpAbout.Text = Strings.About;
		}

		private ToolStrip CreateProjectToolbar() {
			ToolStrip bar = new ToolStrip();

			if (IconPack.Current == null) {
				return bar;
			}

			ToolStripButton btnNew = new ToolStripButton(Strings.New, IconPack.Current.GetImage(IconPackIcon.New)) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			btnNew.Click += mnuProjectNew_Click;
			bar.Items.Add(btnNew);

			ToolStripButton btnOpen = new ToolStripButton(Strings.Open, IconPack.Current.GetImage(IconPackIcon.Open)) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			btnOpen.Click += mnuProjectOpen_Click;
			bar.Items.Add(btnOpen);

			ToolStripButton btnSave = new ToolStripButton(Strings.Save, IconPack.Current.GetImage(IconPackIcon.Save)) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			btnSave.Click += mnuProjectSave_Click;
			bar.Items.Add(btnSave);
			
			bar.Items.Add(new ToolStripSeparator());

			ToolStripButton btnBuild = new ToolStripButton(Strings.Build, IconPack.Current.GetImage(IconPackIcon.Build)) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			btnBuild.Click += mnuBuildProject_Click;
			bar.Items.Add(btnBuild);

			bar.Items.Add(new ToolStripSeparator());

			_LanguageComboBox.SelectedIndexChanged += tscLanguage_SelectedIndexChanged;
			_LanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			bar.Items.Add(_LanguageComboBox);

			return bar;
		}

		private void mnuProjectExit_Click(object sender, EventArgs e) {
			Close();
		}
		
		private void mnuProjectSettings_Click(object sender, EventArgs e) {
			ProjectPropertiesForm form = new ProjectPropertiesForm(CurrentProject);
			DialogResult result = form.ShowDialog();

			if (result == DialogResult.OK) {
				RefreshLanguageList();
				RefreshPublishMenu();
				UpdateFormText();
			}
		}

		private void mnuProjectSecurity_Click(object sender, EventArgs e) {
			SecurityForm form = new SecurityForm(CurrentProject);
			DialogResult result = form.ShowDialog();

			if (result == DialogResult.OK) {
				UpdateFormText();
			}
		}

		private void mnuProjectNew_Click(object sender, EventArgs e) {
			NewProject();
		}

		private void mnuProjectOpen_Click(object sender, EventArgs e) {
			OpenProject();
		}

		private void mnuProjectSave_Click(object sender, EventArgs e) {
			SaveProject(false);
		}

		private void mnuProjectSaveAs_Click(object sender, EventArgs e) {
			SaveProject(true);
		}

		private void mnuBuildProject_Click(object sender, EventArgs e) {
			CompileProject();
		}

		private void mnuBuildAndRunProject_Click(object sender, EventArgs e) {
			CompileProject(true);
		}

		private void mnuContentMedia_Click(object sender, EventArgs e) {
			if (CurrentProject == null) {
				return;
			}

			MediaForm form = new MediaForm(CurrentProject);
			form.ShowDialog();

			UpdateFormText();
		}

		private void mnuContentFooter_Click(object sender, EventArgs e) {
			if (CurrentProject == null) {
				return;
			}

			FooterContentForm form = new FooterContentForm(CurrentProject);
			form.ShowDialog();

			UpdateFormText();
		}

		private void ptvwPages_ContentUpdated(object sender, EventArgs e) {
			UpdateFormText();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = ConfirmCloseDirtyProject();

			if (!e.Cancel) {
				ConfigHelper.StoreMainForm(this);
				ConfigHelper.Save();
			}
		}

		private void MainForm_Load(object sender, EventArgs e) {
			ConfigHelper.RestoreMainForm(this);
			ConfigHelper.UpdateRecents(mnuProjectRecents, mnuProjectRecentItem_Click);

			CheckForUpdate(true);
		}

		private void mnuBuildCleanOutput_Click(object sender, EventArgs e) {
			ClearOutputDirectory();
		}

		private void ptvwPages_BuildPageRequested(object sender, Controls.BuildPageEventArgs e) {
			CompileProject(e.Page, e.Language);
		}

		private void mnuBuildPage_Click(object sender, EventArgs e) {
			if (_Pages.SelectedPage == null || _Pages.SelectedLanguage == null) {
				return;
			}

			CompileProject(_Pages.SelectedPage, _Pages.SelectedLanguage);
		}

		private void mnuHelpAbout_Click(object sender, EventArgs e) {
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		private void tscLanguage_SelectedIndexChanged(object sender, EventArgs e) {
			if (CurrentProject == null || _LanguageComboBox.SelectedIndex >= CurrentProject.Languages.Length) {
				return;
			}

			_Pages.SelectedLanguage 
				= _Content.SelectedLanguage 
				= CurrentProject.Languages[_LanguageComboBox.SelectedIndex];

			_Pages.RedrawTree();
		}

		private void mnuToolsPlugins_Click(object sender, EventArgs e) {
			PluginsForm form = new PluginsForm();
			form.ShowDialog();
		}

		private async void CheckForUpdate(bool silent) {
			mnuHelpUpdateCheck.Enabled = false;
			Update update = await _Updater.IsUpdateAvailable();
			mnuHelpUpdateCheck.Enabled = true;

			if (update == null) {
				if (!silent) {
					MessageBox.Show(Strings.UpdateNotAvailableMessage, Strings.Update, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				return;
			}

			UpdateForm form = new UpdateForm(update);
			form.ShowDialog();
		}

		private void mnuHelpUpdateCheck_Click(object sender, EventArgs e) {
			CheckForUpdate(false);
		}

		private void Content_KeyPressed(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.F5:
					mnuBuildAndRunProject_Click(sender, e);
					break;
				case Keys.F6:
					mnuBuildProject_Click(sender, e);
					break;
			}
		}
	}
}
