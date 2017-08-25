using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WebsiteStudio.UI.Localization;

namespace WebsiteStudio.UI.Forms {
	public partial class PluginDetailsForm : Form {

		private static readonly Regex _NewLineRegex = new Regex("(?<!\r)\n", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		
		public String License {
			get => txtLicense.Text;
			set {
				txtLicense.Text = _NewLineRegex.Replace(value, Environment.NewLine);
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
