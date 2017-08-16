using System;
using System.Windows.Forms;
using WebsiteStudio.Core.Compiling;
using WebsiteStudio.UI.Localization;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Controls {
	public partial class CompilerError : DockContent {

		private CompilerMessage[] _Messages;

		public CompilerMessage[] Messages {
			get => _Messages;
			set {
				_Messages = value;
				lvwErrors.VirtualListSize = 0;
				lvwErrors.VirtualListSize = _Messages.Length;
			}
		}

		public CompilerError() {
			InitializeComponent();
			LocalizeComponent();

			DockAreas = DockAreas.DockBottom | DockAreas.DockTop;
			CloseButton = false;
			CloseButtonVisible = false;
		}

		private void LocalizeComponent() {
			Text = Strings.CompilerErrors;

			clnType.Text = Strings.Type;
			clnMessage.Text = Strings.Message;
		}

		private void lvwErrors_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			CompilerMessage message = _Messages[e.ItemIndex];
			String[] columns = { message.MessageType.ToString(), message.Message };
			e.Item = new ListViewItem(columns);
		}
	}
}
