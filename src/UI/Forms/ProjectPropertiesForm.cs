using System;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Validation;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class ProjectPropertiesForm : Form {

		private readonly Project _Project;

		public ProjectPropertiesForm(Project project) {
			InitializeComponent();
			LocalizeComponent();

			_Project = project;

			plsLanguages.Languages = _Project.Languages;
			pgsGeneral.FillFromProject(_Project);

			psPublishingSettings.Project = _Project;
			psPublishingSettings.Items = _Project.Publishing;

			DialogResult = DialogResult.Cancel;
		}

		private void LocalizeComponent() {
			Text = Strings.ProjectSettings;
			Icon = IconPack.Current.GetIcon(Interface.Icons.IconPackIcon.Settings);

			tabGeneral.Text = Strings.General;
			tabLanguages.Text = Strings.Languages;
			tabMeta.Text = Strings.Meta;
			tabPublish.Text = Strings.Publishing;

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

			project.Publishing.Clear();
			project.Publishing.AddRange(psPublishingSettings.Items);
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
