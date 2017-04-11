using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Compiling;
using WebsiteBuilder.Core.Exceptions;
using WebsiteBuilder.UI.Localization;

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

            if (String.IsNullOrWhiteSpace(_CurrentProject.ProjectFilePath)) {
                Text = _ProductName;
                return;
            }

            StringBuilder builder = new StringBuilder();
            builder.Append(_CurrentProject.ProjectFileName);

            builder.Append(" - ");
            builder.Append(_ProductName);

            Text = builder.ToString();
        }

        private void SaveProject(bool saveAs) {
            if (CurrentProject == null) {
                return;
            }

            if (saveAs || string.IsNullOrEmpty(CurrentProject.ProjectFilePath)) {
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

            CurrentProject = Project.Load(ofdProject.FileName);
        }

        private void CompileProject(bool runAfterCompile = false) {
            if (CurrentProject == null || _CompilerRunning) {
                return;
            }

            _CompilerRunning = true;

            CompilerSetControls(true);
            CompilingForm form = new CompilingForm(CurrentProject);

            try {
                Compiler compiler = new Compiler(CurrentProject);

                compiler.Completed += (sender, e) => {
                    if (runAfterCompile) {
                        OpenProjectInDefaultBrowser(CurrentProject);
                    }

                    form.Done(compiler.Error);
                    _CompilerRunning = false;
                    CompilerSetControls(true);
                };

                compiler.ProgressChanged += (sender, e) => {
                    tspProgress.Value = e.Percentage;
                    form.Push(e);
                };

                compiler.StartAsync();
                form.ShowDialog();
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
            tspProgress.Value = 0;
        }

        private void HandleError(Exception e) {
            HandleError(e.Message);
        }

        private void HandleError(String message) {
            MessageBox.Show(message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void OpenProjectInDefaultBrowser(Project project) {
            String path = System.IO.Path.Combine(project.OutputPath, Project.FileIndex);

            if (!File.Exists(path)) {
                return;
            }

            Process.Start(path);
        }
    }
}
