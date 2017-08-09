using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Linq;
using System.Windows.Forms;
using WebsiteBuilder.Core.Theming;
using WebsiteBuilder.ThemeEditor.Localization;

namespace WebsiteBuilder.ThemeEditor {
	public partial class StyleForm : Form {

		private TextEditor _TextEditor;

		public String Style {
			get => _TextEditor.Text;
			set => _TextEditor.Text = value;
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

			_TextEditor = new TextEditor() {
				SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("CSS"),
				FontFamily = new System.Windows.Media.FontFamily("Consolas"),
				ShowLineNumbers = true
			};

			ehEditor.Child = _TextEditor;

			var types = Enum.GetNames(typeof(ThemeStyle.Types)).Select(x => x.ToLower());
			cbxType.Items.AddRange(types.ToArray());
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
