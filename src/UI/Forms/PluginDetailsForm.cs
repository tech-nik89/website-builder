using System;
using System.Windows.Forms;
using WebsiteStudio.UI.Localization;

namespace WebsiteStudio.UI.Forms {
	public partial class PluginDetailsForm : Form {

		public String License {
			get => txtLicense.Text;
			set {
				txtLicense.Text = value;
				txtLicense.Select(0, 0);
			}
		}

		public PluginDetailsForm() {
			InitializeComponent();
			LocalizeComponent();
		}

		private void LocalizeComponent() {
			Text = Strings.Details;
		}
	}
}
