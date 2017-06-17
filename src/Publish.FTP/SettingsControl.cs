using System;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Publish.FTP.Localization;

namespace WebsiteBuilder.Publish.FTP {
	public partial class SettingsControl : UserControl, IUserInterface {

		private readonly IPluginHelper _PluginHelper;

		public String Data {
			get => Settings.Serialize(Settings);
			set => Settings = Settings.Deserialize(value);
		}

		private Settings Settings {
			get {
				return new Settings() {
					Host = txtHost.Text,
					Port = (int)numPort.Value,
					Encryption = (EncryptionType)cbxEncryption.SelectedIndex,
					UserName = txtUserName.Text,
					Password = txtPassword.Text
				};
			}
			set {
				txtHost.Text = value.Host;
				numPort.Value = value.Port;
				cbxEncryption.SelectedIndex = (int)value.Encryption;
				txtUserName.Text = value.UserName;
				txtPassword.Text = value.Password;
			}
		}

		public SettingsControl(IPluginHelper pluginHelper) {
			InitializeComponent();
			LocalizeComponent();

			_PluginHelper = pluginHelper;

			String[] encryptionTypeNames = Enum.GetNames(typeof(EncryptionType));
			foreach (String name in encryptionTypeNames) {
				cbxEncryption.Items.Add(name);
			}
		}

		private void LocalizeComponent() {
			gbxServer.Text = Strings.Server;
			lblHost.Text = Strings.Host + ":";
			lblPort.Text = Strings.Port + ":";
			lblEncryption.Text = Strings.Encryption + ":";

			gbxCredentials.Text = Strings.Credentials;
			lblUserName.Text = Strings.UserName + ":";
			lblPassword.Text = Strings.Password + ":";
		}

		public void Insert(string str) {
		}

	}
}
