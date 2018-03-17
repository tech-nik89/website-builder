using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Security;
using WebsiteStudio.UI.Localization;

namespace WebsiteStudio.UI.Forms {
	public partial class SecurityForm : Form {

		private readonly Project _Project;
		private readonly List<User> _Users;
		private readonly List<Group> _Groups;

		public SecurityForm(Project project) {
			InitializeComponent();
			LocalizeComponent();

			DialogResult = DialogResult.Cancel;

			_Project = project;

			_Users = new List<User>();
			_Users.AddRange(project.Users);

			_Groups = new List<Group>();
			_Groups.AddRange(project.Groups);

			RefreshUserList();
			RefreshGroupList();
		}

		private void LocalizeComponent() {
			Text = Strings.Security;
			clnUserName.Text = Strings.Name;
			clnGroupName.Text = Strings.Name;

			tabGroups.Text = Strings.Groups;
			tabUsers.Text = Strings.Users;

			btnUserAdd.Text = Strings.Add;
			btnUserEdit.Text = Strings.Edit;
			btnUserDelete.Text = Strings.Delete;

			btnGroupAdd.Text = Strings.Add;
			btnGroupEdit.Text = Strings.Edit;
			btnGroupDelete.Text = Strings.Delete;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;
		}

		private void RefreshUserList() {
			lvwUsers.VirtualListSize = 0;
			lvwUsers.VirtualListSize = _Users.Count;
			lvwUsers_SelectedIndexChanged(this, null);
		}

		private void RefreshGroupList() {
			lvwGroups.VirtualListSize = 0;
			lvwGroups.VirtualListSize = _Groups.Count;
			lvwGroups_SelectedIndexChanged(this, null);
		}

		private void lvwUsers_SelectedIndexChanged(object sender, EventArgs e) {
			btnUserEdit.Enabled =
				btnUserDelete.Enabled = lvwUsers.SelectedIndices.Count > 0;
		}

		private void lvwItems_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			User user = _Users[e.ItemIndex];
			ListViewItem item = new ListViewItem();
			item.Text = user.Name;
			e.Item = item;
		}

		private void lvwGroups_SelectedIndexChanged(object sender, EventArgs e) {
			btnGroupEdit.Enabled =
				btnGroupDelete.Enabled = lvwGroups.SelectedIndices.Count > 0;
		}

		private void lvwGroups_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			Group group = _Groups[e.ItemIndex];
			ListViewItem item = new ListViewItem();
			item.Text = group.Name;
			e.Item = item;
		}

		private void btnUserAdd_Click(object sender, EventArgs e) {
			UserForm form = new UserForm(_Project);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			_Users.Add(form.User);
			RefreshUserList();
		}

		private void btnUserEdit_Click(object sender, EventArgs e) {
			if (lvwUsers.SelectedIndices.Count == 0) {
				return;
			}

			User user = _Users[lvwUsers.SelectedIndices[0]];

			UserForm form = new UserForm(_Project, user);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			RefreshUserList();
		}

		private void btnUserDelete_Click(object sender, EventArgs e) {
			if (lvwUsers.SelectedIndices.Count == 0) {
				return;
			}

			User user = _Users[lvwUsers.SelectedIndices[0]];
			if (MessageBox.Show(Strings.UserDeleteConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			_Users.Remove(user);
			RefreshUserList();
		}

		private void btnGroupAdd_Click(object sender, EventArgs e) {
			GroupForm form = new GroupForm(_Project);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			_Groups.Add(form.Group);
			RefreshGroupList();
		}

		private void btnGroupEdit_Click(object sender, EventArgs e) {
			if (lvwGroups.SelectedIndices.Count == 0) {
				return;
			}

			Group group = _Groups[lvwGroups.SelectedIndices[0]];

			GroupForm form = new GroupForm(_Project, group);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			RefreshGroupList();
		}

		private void btnGroupDelete_Click(object sender, EventArgs e) {
			if (lvwGroups.SelectedIndices.Count == 0) {
				return;
			}

			Group group = _Groups[lvwGroups.SelectedIndices[0]];
			if (MessageBox.Show(Strings.GroupDeleteConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			_Groups.Remove(group);
			RefreshGroupList();
		}

		private void btnAccept_Click(object sender, EventArgs e) {

			_Project.Users.Clear();
			_Project.Users.AddRange(_Users);

			_Project.Groups.Clear();
			_Project.Groups.AddRange(_Groups);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
