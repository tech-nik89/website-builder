using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner {
	public partial class InputItemForm : Form {

		public String Id {
			get => txtId.Text;
			set => txtId.Text = value;
		}

		public String Label {
			get => txtLabel.Text;
			set => txtLabel.Text = value;
		}

		private bool ShowItems {
			get => gbxItems.Visible;
			set {
				gbxItems.Visible = value;
				Height = value ? 500 : 200;
			}
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
			lblId.Text = Strings.Id + ":";
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
