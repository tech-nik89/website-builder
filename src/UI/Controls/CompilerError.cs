using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WebsiteStudio.Core.Compiling;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Controls {
	public partial class CompilerError : DockContent {

		private CompilerMessage[] _AllMessages;

		private CompilerMessage[] _FilteredMessages;

		public CompilerMessage[] Messages {
			get => _AllMessages;
			set {
				_AllMessages = value;
				Filter();
			}
		}

		public CompilerError() {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			DockAreas = DockAreas.DockBottom | DockAreas.DockTop | DockAreas.Float;
			CloseButton = false;
			CloseButtonVisible = false;

			tsbError.Checked = true;
			tsbWarning.Checked = true;
			tsbInfo.Checked = true;
		}

		private void ApplyIcons() {
			IIconPack iconPack = IconPack.Current;
			if (iconPack == null) {
				return;
			}

			tsbError.Image = iconPack.GetImage(IconPackIcon.Error);
			tsbWarning.Image = iconPack.GetImage(IconPackIcon.Warning);
			tsbInfo.Image = iconPack.GetImage(IconPackIcon.Info);
		}

		private void LocalizeComponent() {
			Text = Strings.CompilerErrors;

			tsbError.Text = CompilerMessageType.Error.ToString();
			tsbWarning.Text = CompilerMessageType.Warning.ToString();
			tsbInfo.Text = CompilerMessageType.Information.ToString();

			clnType.Text = Strings.Type;
			clnMessage.Text = Strings.Message;
		}

		private void Filter() {
			_FilteredMessages = _AllMessages
				.Where(x
					=> (tsbError.Checked && x.MessageType == CompilerMessageType.Error)
					|| (tsbWarning.Checked && x.MessageType == CompilerMessageType.Warning)
					|| (tsbInfo.Checked && x.MessageType == CompilerMessageType.Information)
				)
				.OrderBy(m => m.MessageType)
				.ToArray();

			lvwErrors.VirtualListSize = 0;
			lvwErrors.VirtualListSize = _FilteredMessages.Length;
		}

		private void lvwErrors_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			CompilerMessage message = _FilteredMessages[e.ItemIndex];
			String[] columns = { message.MessageType.ToString(), message.Message };
			e.Item = new ListViewItem(columns);

			if (message.MessageType == CompilerMessageType.Error) {
				e.Item.ForeColor = Color.DarkRed;
			}
			else if (message.MessageType == CompilerMessageType.Warning) {
				e.Item.ForeColor = Color.DarkOrange;
			}
		}

		private void CompilerError_Resize(object sender, EventArgs e) {
			clnMessage.Width = Width - clnType.Width - 45;
		}

		private void tsbFilter_Click(object sender, EventArgs e) {
			ToolStripButton button = (ToolStripButton)sender;
			button.Checked = !button.Checked;
			Filter();
		}
	}
}
