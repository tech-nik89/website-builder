using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Compiling;
using WebsiteBuilder.Core.Exceptions;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
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
                ptvwPages.Project = _CurrentProject;
            }
        }
        
        private String GetProductName() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return versionInfo.ProductName;
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

            Project project = Project.Load(ofdProject.FileName);

            if (project != null) {
                CurrentProject = project;
                UpdateFormText();
            }
            else {
                HandleError(Strings.ProjectLoadErrorMessage);
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

        private void CompileProject(bool runAfterCompile, Page previewPage, Language previewLanguage) {
            if (CurrentProject == null || _CompilerRunning) {
                return;
            }

            _CompilerRunning = true;
            
            UpdateStatus(StatusText.BuildStarted);
            CompilerSetControls(false);

            try {
                Compiler compiler = new Compiler(CurrentProject, new CompilerSettings() {
                    PreviewPage = previewPage,
                    PreviewLanguage = previewLanguage
                });

                compiler.Completed += (sender, e) => {
                    if (runAfterCompile) {
                        OpenProjectInDefaultBrowser(CurrentProject);
                    }

                    if (compiler.Error) {
                        CompilerErrorForm form = new CompilerErrorForm(compiler.ErrorMessage);
                        form.ShowDialog();
                    }

                    _CompilerRunning = false;
                    CompilerSetControls(true);
                    UpdateStatus(StatusText.BuildSucceeded);
                };

                compiler.ProgressChanged += (sender, e) => {
                    tspProgress.Value = e.Percentage;
                    UpdateStatus(e.Message);
                };

                compiler.StartAsync();
            }
            catch (OutputPathMissingException) {
                _CompilerRunning = false;
                HandleError(Strings.MessageOutputPathRequired);
            }
            catch (Exception e) {
                _CompilerRunning = false;
                HandleError(e);
            }
        }

        private void CompilerSetControls(bool enabled) {
            mnuBuildProject.Enabled = enabled;
            mnuBuildAndRunProject.Enabled = enabled;
            mnuBuildPage.Enabled = enabled;
            mnuBuildCleanOutput.Enabled = enabled;
            tspProgress.Value = 0;
        }

        private void HandleError(Exception e) {
            HandleError(e.Message);
        }

        private void HandleError(String message) {
            MessageBox.Show(message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void OpenProjectInDefaultBrowser(Project project) {
            String path = Path.Combine(project.OutputPath, Project.FileIndex);

            if (!File.Exists(path)) {
                return;
            }

            Process.Start(path);
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
            int previousIndex = tscLanguage.SelectedIndex;
            tscLanguage.Items.Clear();

            if (CurrentProject == null) {
                return;
            }

            foreach(Language language in CurrentProject.Languages) {
                tscLanguage.Items.Add(language.Description);
            }

            if (previousIndex > 0 && previousIndex < tscLanguage.Items.Count) {
                tscLanguage.SelectedIndex = previousIndex;
            }
            else if (tscLanguage.Items.Count > 0 ){
                tscLanguage.SelectedIndex = 0;
            }
        }
    }
}
