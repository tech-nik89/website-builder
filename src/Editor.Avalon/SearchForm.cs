using ICSharpCode.AvalonEdit;
using System;
using System.Windows.Forms;
using WebsiteBuilder.Editors.Avalon.Localization;

namespace WebsiteBuilder.Editors.Avalon {
	public partial class SearchForm : Form {

		private readonly TextEditor _Editor;

		private int _Index = 0;

		public SearchForm(TextEditor editor) {
			InitializeComponent();
			LocalizeComponent();

			_Editor = editor;
			_Index = _Editor.SelectionStart;
		}

		private void LocalizeComponent() {
			Text = Strings.Search;
			lblWhat.Text = Strings.FindWhat;
			btnSearch.Text = Strings.Search;
		}

		private void SearchForm_Shown(object sender, EventArgs e) {
			txtSearch.Focus();
		}

		private void btnSearch_Click(object sender, EventArgs e) {
			int start = _Editor.Text.IndexOf(txtSearch.Text, _Index, StringComparison.CurrentCultureIgnoreCase);

			if (start == -1) {
				_Index = 0;
				return;
			}

			_Editor.SelectionStart = start;
			_Editor.SelectionLength = txtSearch.TextLength;
			_Index = start + txtSearch.TextLength;
		}

		private void SearchForm_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Escape) {
				e.Handled = true;
				Close();
			}
		}
	}
}
