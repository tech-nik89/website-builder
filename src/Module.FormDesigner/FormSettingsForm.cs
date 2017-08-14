using System;
using System.Linq;
using System.Windows.Forms;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.FormDesigner.Localization;
using WebsiteStudio.Modules.FormDesigner.Services;

namespace WebsiteStudio.Modules.FormDesigner {
	public partial class FormSettingsForm : Form {

		private readonly IPluginHelper _PluginHelper;

		public String TargetMailAddress {
			get => txtTargetMailAddress.Text;
			set => txtTargetMailAddress.Text = value;
		}

		public String SubmitButtonText {
			get => txtSubmitButtonText.Text;
			set => txtSubmitButtonText.Text = value;
		}

		public String SuccessMessage {
			get => txtSuccessMessage.Text;
			set => txtSuccessMessage.Text = value;
		}

		public String TargetService {
			get => Service.Services.ElementAt(cbxService.SelectedIndex).Key;
			set {
				for(int index = 0; index < Service.Services.Count; index++) {
					if (Service.Services.Keys.ElementAt(index) == value) {
						cbxService.SelectedIndex = index;
						return;
					}
				}

				if (cbxService.Items.Count > 0) {
					cbxService.SelectedIndex = 0;
				}
			}
		}

		public FormSettingsForm(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;

			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();
			FillTargetServiceList();

			DialogResult = DialogResult.Cancel;
		}
		
		private void FillTargetServiceList() {
			cbxService.Items.Clear();
			foreach(var service in Service.Services) {
				cbxService.Items.Add(service.Key);
			}
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			Icon = iconPack.GetIcon(IconPackIcon.Settings);
		}

		private void LocalizeComponent() {
			Text = Strings.Settings;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			gbxTarget.Text = Strings.TargetService;
			gbxStrings.Text = Strings.Text;

			lblService.Text = Strings.Service + ":";
			lblMail.Text = Strings.Mail + ":";
			lblSubmit.Text = Strings.Submit + ":";
			lblSuccessMessage.Text = Strings.SuccessMessage + ":";
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, System.EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
