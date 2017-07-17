using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThemeEditor.Localization;

namespace ThemeEditor {
	public partial class ImageForm : Form {

		public String ImageName {
			get => txtName.Text;
			set => txtName.Text = value;
		}

		public Byte[] ImageData {
			get {
				if (String.IsNullOrWhiteSpace(txtFile.Text)
					|| !File.Exists(txtFile.Text)) {
					return new Byte[0];
				}

				return File.ReadAllBytes(txtFile.Text);
			}
		}

		public ImageForm()
			: this(String.Empty) {
		}

		public ImageForm(String name) {
			InitializeComponent();
			LocalizeComponent();

			DialogResult = DialogResult.Cancel;
			ofdImage.Filter = String.Format(Strings.ImageFileFilter, String.Join(";", MainForm.SupportedFileTypes.Select(x => "*." + x)));
		}

		private void LocalizeComponent() {
			lblName.Text = Strings.Name + ":";
			lblFile.Text = Strings.File + ":";

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

		private void btnBrowse_Click(object sender, EventArgs e) {
			if (ofdImage.ShowDialog() != DialogResult.OK) {
				return;
			}

			txtFile.Text = ofdImage.FileName;
		}
	}
}
