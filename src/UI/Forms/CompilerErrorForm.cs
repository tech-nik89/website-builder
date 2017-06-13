using System;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
	public partial class CompilerErrorForm : Form {
		
		public CompilerErrorForm(String errorMessage) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			txtError.Text = errorMessage;
		}

		private void ApplyIcons() {
			if (IconPack.Current == null) {
				return;
			}

			Icon = IconPack.Current.GetIcon(IconPackIcon.Build);
		}

		public void LocalizeComponent() {
			Text = Strings.BuildError;
		}
	}
}
