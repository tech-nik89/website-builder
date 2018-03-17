using System;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Security;
using WebsiteStudio.Core.Validation;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class UserForm : Form {

		private readonly User _User;
		private readonly Project _Project;
		private readonly UserValidator.Mode _ValidationMode = UserValidator.Mode.Edit;

		public User User => _User;

		public UserForm(Project project)
			: this(project, project.CreateUser()) {

			_ValidationMode = UserValidator.Mode.Add;
		}

		public UserForm(Project project, User user) {
			InitializeComponent();
			LocalizeComponent();

			DialogResult = DialogResult.Cancel;

			_User = user;
			_Project = project;

			txtName.Text = user.Name;
		}

		private void LocalizeComponent() {
			Text = Strings.User;
			gbxGeneral.Text = Strings.General;

			lblName.Text = Strings.Name + ":";
			lblPassword.Text = Strings.Password + ":";

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;
		}

		private void ApplyToUser(User user) {
			user.Name = txtName.Text;
			user.SetAndEncryptPassword(txtPassword.Text);
		}

		private void btnAccept_Click(object sender, EventArgs e) {

			User validationUser = _Project.CreateUser();
			ApplyToUser(validationUser);

			ValidationHelper<User> validator = new ValidationHelper<User>(new UserValidator(validationUser, _Project, _ValidationMode));
			if (!validator.Valid) {
				validator.ShowMessage();
				return;
			}

			ApplyToUser(_User);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
