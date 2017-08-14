using System;
using System.Windows.Forms;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
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
