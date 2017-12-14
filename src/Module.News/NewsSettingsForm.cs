using System;
using System.Windows.Forms;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Modules.News.Localization;

namespace WebsiteStudio.Modules.News {
	public partial class NewsSettingsForm : Form {

		public int LargeItemsCount => (int)numLargeItemsCount.Value;

		public int LargeItemsMaxHeight => (int)numLargeItemsMaxHeight.Value;

		public String ExpanderText => txtExpanderText.Text;

		public NewsSettingsForm(IIconPack iconPack, int largeItemsCount, int largeItemsMaxHeight, String expanderText) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons(iconPack);

			DialogResult = DialogResult.Cancel;

			numLargeItemsCount.Minimum = 1;
			numLargeItemsCount.Maximum = 50;

			numLargeItemsMaxHeight.Minimum = 50;
			numLargeItemsMaxHeight.Maximum = decimal.MaxValue;

			numLargeItemsCount.Value = largeItemsCount;
			numLargeItemsMaxHeight.Value = largeItemsMaxHeight;
			txtExpanderText.Text = expanderText;
		}

		private void ApplyIcons(IIconPack iconPack) {
			if (iconPack == null) {
				return;
			}

			Icon = iconPack.GetIcon(IconPackIcon.Settings);
		}

		private void LocalizeComponent() {
			Text = Strings.NewsSettings;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			lblLargeItemsCount.Text = Strings.LargeItemsCount + ":";
			lblLargeItemsMaxHeight.Text = Strings.LargeItemsMaxHeight + ":";
			lblExpanderText.Text = Strings.ExpanderTextCaption + ":";
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
