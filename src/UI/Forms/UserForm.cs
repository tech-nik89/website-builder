using System;
using System.Collections.Generic;
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
		private readonly IEnumerable<Group> _Groups;
		private readonly UserValidator.Mode _ValidationMode = UserValidator.Mode.Edit;

		public User User => _User;

		public UserForm(Project project, IEnumerable<Group> groups)
			: this(project, project.CreateUser(), groups) {

			_ValidationMode = UserValidator.Mode.Add;
		}

		public UserForm(Project project, User user, IEnumerable<Group> groups) {
			InitializeComponent();
			LocalizeComponent();

			DialogResult = DialogResult.Cancel;
			Icon = IconPack.Current.GetIcon(Interface.Icons.IconPackIcon.User);

			_User = user;
			_Groups = groups;
			_Project = project;

			txtName.Text = user.Name;

			FillGroupList();
		}
		
		private void LocalizeComponent() {
			Text = Strings.User;
			tabGeneral.Text = Strings.General;
			tabMemberships.Text = Strings.Memberships;

			clnGroup.Text = Strings.Group;

			lblName.Text = Strings.Name + ":";
			lblPassword.Text = Strings.Password + ":";

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;
		}

		private void FillGroupList() {
			foreach (Group group in _Groups) {
				ListViewItem item = new ListViewItem(group.Name);
				item.Checked = _User.Memberships.Contains(group);
				lvwGroups.Items.Add(item);
			}
		}

		private void ApplyToUser(User user) {
			user.Name = txtName.Text;
			user.SetAndEncryptPassword(txtPassword.Text);

			user.Memberships.Clear();
			for(int i = 0; i < _Project.Groups.Count; i++) {
				if (lvwGroups.Items[i].Checked) {
					user.Memberships.Add(_Project.Groups[i]);
				}
			}
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
