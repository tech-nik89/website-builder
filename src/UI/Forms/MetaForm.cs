using System;
using System.Windows.Forms;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class MetaForm : Form {

		private static String[] KeywordSeparator = { Environment.NewLine };

		public String[] Keywords => txtKeywords.Text.Split(KeywordSeparator, StringSplitOptions.RemoveEmptyEntries);

		public String Description => txtDescription.Text;

		public MetaForm(String description, String[] keywords) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();
			DialogResult = DialogResult.Cancel;

			if (!String.IsNullOrWhiteSpace(description)) {
				txtDescription.Text = description;
			}

			if (keywords != null && keywords.Length > 0) {
				txtKeywords.Text = String.Join(Environment.NewLine, keywords);
			}
		}

		private void ApplyIcons() {
			IIconPack iconPack = IconPack.Current;
			if (iconPack == null) {
				return;
			}

			Icon = iconPack.GetIcon(IconPackIcon.MetaTag);
		}

		private void LocalizeComponent() {
			Text = Strings.Meta;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			gbxDescription.Text = Strings.Description;
			gbxKeywords.Text = Strings.Keywords;
			lblKeywordsDescription.Text = Strings.KeywordsDescription;
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
