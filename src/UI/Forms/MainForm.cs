using System;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Controls;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Forms {
	public partial class MainForm : Form {

		private readonly PagesTreeView _Pages;

		private readonly PageContentList _Content;

		private readonly DockPanel _DockPanel;

		private readonly CompilerOutput _CompilerOutput;
		private readonly CompilerError _CompilerError;

		public MainForm() {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();
			
			_Content = new PageContentList(EnableContentControls);
			_Pages = new PagesTreeView(EnableContentControls, EnableTreeControls, _Content.RefreshContent);
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

			tscLanguage.SelectedIndexChanged += (sender, e) => { _Pages.RedrawTree(); };
			tsbPageAdd.Click += (sender, e) => { _Pages.Add(); };
			tsbPageEdit.Click += (sender, e) => { _Pages.Edit(); };
			tsbPageDelete.Click += (sender, e) => { _Pages.Delete(); };

			tsbContentAdd.Click += (sender, e) => { _Content.Add(); };
			tsbContentEdit.Click += (sender, e) => { _Content.Edit(); };
			tsbContentDelete.Click += (sender, e) => { _Content.Delete(); };
			tsbContentUp.Click += (sender, e) => { _Content.MoveContentUp(); };
			tsbContentDown.Click += (sender, e) => { _Content.MoveContentDown(); };

			_Pages.BuildPageRequested += mnuBuildPage_Click;

			tslStatus.Text = StatusText.Ready;
			CurrentProject = new Project();
		}
		
		private void ApplyIcons() {
			if (IconPack.Current == null) {
				return;
			}

			// Menus
			mnuProjectSave.Image = IconPack.Current.GetImage(IconPackIcon.Save);
			mnuProjectOpen.Image = IconPack.Current.GetImage(IconPackIcon.Open);
			mnuProjectSettings.Image = IconPack.Current.GetImage(IconPackIcon.Settings);
			mnuProjectExit.Image = IconPack.Current.GetImage(IconPackIcon.Close);

			mnuContentMedia.Image = IconPack.Current.GetImage(IconPackIcon.Media);
			mnuContentFooter.Image = IconPack.Current.GetImage(IconPackIcon.Footer);

			mnuBuildProject.Image = IconPack.Current.GetImage(IconPackIcon.Build);
			mnuBuildPage.Image = IconPack.Current.GetImage(IconPackIcon.BuildPage);
			mnuBuildPublish.Image = IconPack.Current.GetImage(IconPackIcon.Publish);

			mnuToolsPlugins.Image = IconPack.Current.GetImage(IconPackIcon.Plugin);

			mnuHelpAbout.Image = IconPack.Current.GetImage(IconPackIcon.About);

			// Toolstrip
			tsbProjectNew.Image = IconPack.Current.GetImage(IconPackIcon.New);
			tsbProjectOpen.Image = IconPack.Current.GetImage(IconPackIcon.Open);
			tsbProjectSave.Image = IconPack.Current.GetImage(IconPackIcon.Save);

			tsbContentMedia.Image = IconPack.Current.GetImage(IconPackIcon.Media);
			tsbContentFooter.Image = IconPack.Current.GetImage(IconPackIcon.Footer);

			tsbBuildProject.Image = IconPack.Current.GetImage(IconPackIcon.Build);

			tsbPageAdd.Image = IconPack.Current.GetImage(IconPackIcon.Add);
			tsbPageEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
			tsbPageDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);

			tsbContentAdd.Image = IconPack.Current.GetImage(IconPackIcon.Add);
			tsbContentEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
			tsbContentDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);

			tsbContentUp.Image = IconPack.Current.GetImage(IconPackIcon.OrderUp);
			tsbContentDown.Image = IconPack.Current.GetImage(IconPackIcon.OrderDown);
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

			mnuHelpAbout.Text = Strings.About;

			// Toolstrip
			tsbProjectNew.Text = Strings.New;
			tsbProjectOpen.Text = Strings.Open;
			tsbProjectSave.Text = Strings.Save;

			tsbContentMedia.Text = Strings.Media;
			tsbContentFooter.Text = Strings.Footer;

			tsbBuildProject.Text = Strings.Build;

			tsbPageAdd.Text = Strings.PageAdd;
			tsbPageEdit.Text = Strings.PageEdit;
			tsbPageDelete.Text = Strings.PageDelete;

			tsbContentAdd.Text = Strings.ContentAdd;
			tsbContentEdit.Text = Strings.ContentEdit;
			tsbContentDelete.Text = Strings.ContentDelete;

			tsbContentUp.Text = Strings.Up;
			tsbContentDown.Text = Strings.Down;
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
			if (CurrentProject == null || tscLanguage.SelectedIndex >= CurrentProject.Languages.Length) {
				return;
			}

			_Pages.SelectedLanguage 
				= _Content.SelectedLanguage 
				= CurrentProject.Languages[tscLanguage.SelectedIndex];
		}

		private void mnuToolsPlugins_Click(object sender, EventArgs e) {
			PluginsForm form = new PluginsForm();
			form.ShowDialog();
		}

		private void EnableContentControls() {
			tsbContentAdd.Enabled = _Pages?.SelectedPage != null;
			tsbContentEdit.Enabled = _Content.ContentSelected;
			tsbContentDelete.Enabled = _Content.ContentSelected;
			tsbContentUp.Enabled = _Content.CanMoveUp;
			tsbContentDown.Enabled = _Content.CanMoveDown;
		}

		private void EnableTreeControls() {
			tsbPageEdit.Enabled 
				= tsbPageDelete.Enabled 
				= _Pages?.SelectedPage != null;
		}
	}
}
