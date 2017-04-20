using System;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            LocalizeComponent();
            ApplyIcons();

            _ProductName = GetProductName();
            ofdProject.Filter = _ProjectFilesFilter;
            sfdProject.Filter = _ProjectFilesFilter;

            tslStatus.Text = StatusText.Ready;
            CurrentProject = new Project();
        }

        private void ApplyIcons() {
            if (IconPack.Current == null) {
                return;
            }

            mnuProjectSave.Image = IconPack.Current.GetImage(IconPackIcon.Save);
            mnuProjectOpen.Image = IconPack.Current.GetImage(IconPackIcon.Open);
            mnuProjectSettings.Image = IconPack.Current.GetImage(IconPackIcon.Settings);
            mnuProjectMedia.Image = IconPack.Current.GetImage(IconPackIcon.Media);
            mnuProjectExit.Image = IconPack.Current.GetImage(IconPackIcon.Close);
            
            mnuBuildProject.Image = IconPack.Current.GetImage(IconPackIcon.Build);

            tsbProjectNew.Image = IconPack.Current.GetImage(IconPackIcon.New);
            tsbProjectOpen.Image = IconPack.Current.GetImage(IconPackIcon.Open);
            tsbProjectSave.Image = IconPack.Current.GetImage(IconPackIcon.Save);

            tsbBuildProject.Image = IconPack.Current.GetImage(IconPackIcon.Build);
        }

        private void LocalizeComponent() {
            mnuProject.Text = Strings.Project;
            mnuProjectNew.Text = Strings.New;
            mnuProjectOpen.Text = Strings.Open;
            mnuProjectSave.Text = Strings.Save;
            mnuProjectSaveAs.Text = Strings.SaveAs;
            mnuProjectSettings.Text = Strings.ProjectSettings;
            mnuProjectMedia.Text = Strings.Media;
            mnuProjectExit.Text = Strings.Exit;

            mnuBuild.Text  = Strings.Build;
            mnuBuildProject.Text = Strings.BuildProject;
            mnuBuildAndRunProject.Text = Strings.BuildAndOpenProject;

            tsbProjectNew.Text = Strings.New;
            tsbProjectOpen.Text = Strings.Open;
            tsbProjectSave.Text = Strings.Save;

            tsbBuildProject.Text = Strings.Build;
        }

        private void mnuProjectExit_Click(object sender, EventArgs e) {
            Close();
        }
        
        private void mnuProjectSettings_Click(object sender, EventArgs e) {
            ProjectPropertiesForm form = new ProjectPropertiesForm(CurrentProject);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK) {
                ptvwPages.RefreshLanguageList();
            }
        }

        private void mnuProjectNew_Click(object sender, EventArgs e) {
            CurrentProject = new Project();
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

        private void mnuProjectMedia_Click(object sender, EventArgs e) {
            if (CurrentProject == null) {
                return;
            }

            MediaForm form = new MediaForm(CurrentProject);
            form.ShowDialog();
        }
    }
}
