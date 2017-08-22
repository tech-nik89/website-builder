using System;
using System.Text;
using WebsiteStudio.Core.Compiling;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Controls {
	public partial class CompilerOutput : DockContent {

		public CompilerOutput() {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			DockAreas = DockAreas.DockBottom | DockAreas.DockTop | DockAreas.Float;
			CloseButton = false;
			CloseButtonVisible = false;
		}

		private void ApplyIcons() {
			tsbClear.Image = IconPack.Current.GetImage(IconPackIcon.Clear);
		}

		private void LocalizeComponent() {
			Text = Strings.Output;
			tsbClear.Text = Strings.ClearAll;
		}

		public void Push(CompilerProgressReport report) {
			Push(report.Message);
		}

		public void Push(String message) {
			StringBuilder line = new StringBuilder();

			line.Append("1> ");
			line.Append(message);
			line.AppendLine();

			txtOutput.AppendText(line.ToString());
			txtOutput.Select(txtOutput.Text.Length, 0);
		}

		private void tsbClear_Click(object sender, System.EventArgs e) {
			txtOutput.Text = String.Empty;
		}
	}
}
