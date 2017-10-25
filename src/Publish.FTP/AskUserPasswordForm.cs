using System;
using System.Windows.Forms;
using WebsiteStudio.Publish.FTP.Localization;

namespace WebsiteStudio.Publish.FTP {
	public partial class AskUserPasswordForm : Form {

		public String Password => txtPassword.Text;

		public AskUserPasswordForm(String userName) {
			InitializeComponent();
			LocalizeComponent();

			DialogResult = DialogResult.Cancel;
			txtUserName.Text = userName;
		}

		private void LocalizeComponent() {
			Text = Strings.RequestPassword;

			lblUserName.Text = Strings.UserName + ":";
			lblPassword.Text = Strings.Password + ":";

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}

		private void AskUserPasswordForm_Shown(object sender, EventArgs e) {
			txtPassword.Focus();
		}
	}
}
