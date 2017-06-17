using System;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Publish.FTP {

	[PluginInfo("FTP")]
	public class PublishFTP : IPublish {

		private IPluginHelper _PluginHelper;

		public PublishFTP(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public IUserInterface GetUserInterface() {
			return new SettingsControl(_PluginHelper);
		}

		public void Run(String data) {
			try {
				Settings settings = Settings.Deserialize(data);
			}
			catch {

			}
		}

	}
}
