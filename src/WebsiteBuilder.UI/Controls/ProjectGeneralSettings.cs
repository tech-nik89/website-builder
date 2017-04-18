using System;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Theming;
using WebsiteBuilder.UI.Localization;

namespace WebsiteBuilder.UI.Controls {
    public partial class ProjectGeneralSettings : UserControl {
        
        private static String ThemeFileFilter => String.Format(Strings.ThemeFilesFilter, Theme.FileExtension);

        public ProjectGeneralSettings() {
            InitializeComponent();
            LocalizeComponent();
        }

        private void LocalizeComponent() {
            gbxOutput.Text = Strings.Output;
            gbxTheme.Text = Strings.Theme;

            lblOutputPath.Text = Strings.Path + ":";
            lblThemePath.Text = Strings.Path + ":";
            chkUglyURLs.Text = Strings.UglyURLs;
        }

        public void FillFromProject(Project project) {
            txtOutputPath.Text = project.OutputPath;
            txtThemePath.Text = project.ThemePath;
            chkUglyURLs.Checked = project.UglyURLs;
        }

        public void FillProjectFrom(Project project) {
            project.OutputPath = txtOutputPath.Text;
            project.ThemePath = txtThemePath.Text;
            project.UglyURLs = chkUglyURLs.Checked;
        }

        private void btnThemeBrowse_Click(object sender, EventArgs e) {
            ofdFile.Filter = ThemeFileFilter;
            ofdFile.FileName = txtThemePath.Text;

            var result = ofdFile.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }

            txtThemePath.Text = ofdFile.FileName;
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e) {
            fbdDirectory.SelectedPath = txtOutputPath.Text;

            var result = fbdDirectory.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }

            txtOutputPath.Text = fbdDirectory.SelectedPath;
        }
    }
}
