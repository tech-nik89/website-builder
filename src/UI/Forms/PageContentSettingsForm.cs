using System;
using System.Windows.Forms;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Plugins;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class PageContentSettingsForm : Form {

		private readonly PageContent _PageContent;

		public PageContentSettingsForm(PageContent content) {
			InitializeComponent();
			LocalizeComponent();

			DialogResult = DialogResult.Cancel;

			cbxModule.FillWithModulePlugins();
			cbxEditor.FillWithEditorPlugins();

			cbxModule.SelectModulePlugin(content.ModuleType);
			cbxEditor.SelectEditorPlugin(content.EditorType);

			_PageContent = content;
		}

		private void LocalizeComponent() {
			Text = Strings.ContentSettings;

			lblModule.Text = Strings.Module + ":";
			lblEditor.Text = Strings.Editor + ":";

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			Icon = IconPack.Current.GetIcon(Interface.Icons.IconPackIcon.Settings);
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			_PageContent.ModuleType = cbxModule.GetModulePlugin();
			_PageContent.EditorType = cbxEditor.GetEditorPlugin();

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
