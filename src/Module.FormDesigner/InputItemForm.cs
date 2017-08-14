using System;
using System.Windows.Forms;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner {
	public partial class InputItemForm : Form {

		public String ItemName {
			get => txtName.Text;
			set => txtName.Text = value;
		}

		public String ItemLabel {
			get => txtLabel.Text;
			set => txtLabel.Text = value;
		}

		private bool ShowItems {
			get => gbxItems.Visible;
			set {
				gbxItems.Visible = value;
				AcceptButton = value ? null : btnAccept;
				Height = value ? 500 : 200;
			}
		}

		public bool EnableItemName {
			get => txtName.Enabled;
			set => txtName.Enabled = value;
		}

		public String[] Items {
			get => txtItems.Text.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			set {
				txtItems.Text = String.Join(Environment.NewLine, value);
				ShowItems = true;
			}
		}

		public InputItemForm() {
			InitializeComponent();
			LocalizeComponent();

			DialogResult = DialogResult.Cancel;
			ShowItems = false;
		}

		private void LocalizeComponent() {
			gbxDetails.Text = Strings.Details;
			gbxItems.Text = Strings.Items;

			lblName.Text = Strings.Name + ":";
			lblLabel.Text = Strings.Label + ":";

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
