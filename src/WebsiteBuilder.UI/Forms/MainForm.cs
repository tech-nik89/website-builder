﻿using System;
using System.Windows.Forms;
using WebsiteBuilder.Core;
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

            CurrentProject = new Project();
        }

        private void ApplyIcons() {
            if (IconPack.Current == null) {
                return;
            }

            mnuProjectSave.Image = IconPack.Current.GetImage(IconPack.Icon.Save);
            mnuProjectOpen.Image = IconPack.Current.GetImage(IconPack.Icon.Open);
            mnuProjectSettings.Image = IconPack.Current.GetImage(IconPack.Icon.Settings);

            mnuBuildProject.Image = IconPack.Current.GetImage(IconPack.Icon.Build);
            mnuBuildAndRunProject.Image = IconPack.Current.GetImage(IconPack.Icon.BuildAndRun);
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
