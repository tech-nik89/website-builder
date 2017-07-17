using System;
using System.Windows.Forms;
using ThemeEditor.Localization;

namespace ThemeEditor {
	public partial class StyleForm : Form {

		public String Style {
			get => txtData.Text;
			set => txtData.Text = value;
		}

		public String StyleName {
			get => txtName.Text;
			set => txtName.Text = value;
		}

		public String StyleType {
			get => cbxType.Text;
			set => cbxType.Text = value;
		}

		public StyleForm() {
			InitializeComponent();
			LocalizeComponent();
			DialogResult = DialogResult.Cancel;
		}

		private void LocalizeComponent() {
			Text = Strings.Style;

			gbxGeneral.Text = Strings.General;
			gbxStyle.Text = Strings.Style;

			lblName.Text = Strings.Name + ":";
			lblType.Text = Strings.Type + ":";

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
	}
}
