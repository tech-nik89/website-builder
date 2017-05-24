﻿using System;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Validation;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
    public partial class ProjectPropertiesForm : Form {

        private readonly Project _Project;

        public ProjectPropertiesForm(Project project) {
            InitializeComponent();
            LocalizeComponent();

            _Project = project;

            plsLanguages.Languages = _Project.Languages;
            pgsGeneral.FillFromProject(_Project);

            DialogResult = DialogResult.Cancel;
        }

        private void LocalizeComponent() {
            Text = Strings.ProjectSettings;
            Icon = IconPack.Current.GetIcon(Interface.Icons.IconPackIcon.Settings);

            tabGeneral.Text = Strings.General;
            tabLanguages.Text = Strings.Languages;
            tabMeta.Text = Strings.Meta;

            clnLanguage.Text = Strings.Language;

            btnAccept.Text = Strings.Accept;
            btnCancel.Text = Strings.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {

            Project validationProject = new Project();
            ApplyToProject(validationProject);

            ValidationHelper<Project> validator = new ValidationHelper<Project>(new ProjectValidator(validationProject));
            if (!validator.Valid) {
                validator.ShowMessage();
                return;
            }

            ApplyToProject(_Project);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ApplyToProject(Project project) {
            project.Languages = plsLanguages.Languages;
            pgsGeneral.FillProjectFrom(project);
        }

        private void tabMain_Selected(object sender, TabControlEventArgs e) {
            if (e.TabPage == tabMeta) {
                RefreshMetaList();
            }
        }

        private void RefreshMetaList() {
            lvwMeta.Items.Clear();

            foreach (Language language in _Project.Languages) {
                lvwMeta.Items.Add(new ListViewItem(language.Description));
            }
        }

        private void lvwMeta_DoubleClick(object sender, EventArgs e) {
            if (lvwMeta.SelectedIndices.Count == 0) {
                return;
            }

            Language language = _Project.Languages[lvwMeta.SelectedIndices[0]];
            String description = _Project.MetaDescription.Get(language);
            String[] keywords = _Project.MetaKeywords.Get(language);

            MetaForm form = new MetaForm(description, keywords);
            if (form.ShowDialog() != DialogResult.OK) {
                return;
            }

            _Project.MetaDescription.Set(language, form.Description);
            _Project.MetaKeywords.Set(language, form.Keywords);
        }
    }
}
