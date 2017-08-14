using System;
using System.Windows.Forms;
using WebsiteStudio.Editors.Avalon.Localization;

namespace WebsiteStudio.Editors.Avalon {
	public partial class GoToForm : Form {

		public int TargetLine => (int)numTargetLine.Value;

		public GoToForm(int lineCount, int currentLine) {
			InitializeComponent();
			LocalizeComponent();

			DialogResult = DialogResult.Cancel;

			lblCurrentLine.Text = currentLine.ToString();
			lblLineCount.Text = lineCount.ToString();

			numTargetLine.Minimum = 0;
			numTargetLine.Maximum = lineCount;

			numTargetLine.Value = currentLine;
			numTargetLine.Select(0, numTargetLine.Value.ToString().Length);
		}

		private void LocalizeComponent() {
			Text = Strings.GoTo;

			lblCurrentLineCaption.Text = Strings.CurrentLine + ":";
			lblTargetLineCaption.Text = Strings.TargetLine + ":";
			lblLineCountCaption.Text = Strings.LineCount + ":";

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
