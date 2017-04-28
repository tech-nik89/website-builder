using System;
using System.Windows.Forms;
using WebsiteBuilder.Core;
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

            btnAccept.Text = Strings.Accept;
            btnCancel.Text = Strings.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            _Project.Languages = plsLanguages.Languages;
            pgsGeneral.FillProjectFrom(_Project);

            ValidationHelper<Project> validator = new ValidationHelper<Project>(new ProjectValidator(_Project));
            if (!validator.Valid) {
                validator.ShowMessage();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
