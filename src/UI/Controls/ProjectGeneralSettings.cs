using System;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Theming;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Plugins;

namespace WebsiteStudio.UI.Controls {
	public partial class ProjectGeneralSettings : UserControl {
		
		private static String ThemeFileFilter => String.Format(Strings.ThemeFilesFilter, Theme.FileExtension);

		public ProjectGeneralSettings() {
			InitializeComponent();
			LocalizeComponent();

			cbxWebserver.FillWithWebserverPlugins(true);
		}

		private void LocalizeComponent() {
			gbxGeneral.Text = Strings.General;
			gbxOutput.Text = Strings.Output;
			gbxTheme.Text = Strings.Theme;
			gbxWebserver.Text = Strings.Webserver;

			lblBaseURL.Text = Strings.BaseURL + ":";
			lblOutputPath.Text = Strings.Path + ":";
			lblThemePath.Text = Strings.Path + ":";
			chkUglyURLs.Text = Strings.UglyURLs;
			chkGenerateSitemap.Text = Strings.SitemapGenerate;
		}

		public void FillFromProject(Project project) {
			txtBaseURL.Text = project.BaseURL;
			txtOutputPath.Text = project.OutputPath;
			txtThemePath.Text = project.ThemePath;
			chkUglyURLs.Checked = project.UglyURLs;
			chkGenerateSitemap.Checked = project.GenerateSitemap;
			cbxWebserver.SelectWebserverPlugin(project.Webserver);
		}

		public void FillProjectFrom(Project project) {
			project.BaseURL = txtBaseURL.Text;
			project.OutputPath = txtOutputPath.Text;
			project.ThemePath = txtThemePath.Text;
			project.UglyURLs = chkUglyURLs.Checked;
			project.GenerateSitemap = chkGenerateSitemap.Checked;
			project.Webserver = cbxWebserver.GetWebserverPlugin();
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
