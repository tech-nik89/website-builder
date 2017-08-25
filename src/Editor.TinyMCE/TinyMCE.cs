using System;
using WebsiteStudio.Editors.TinyMCE.Properties;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Editors.TinyMCE {

	[PluginInfo("TinyMCE Editor", Author = "tech-nik89")]
	public class TinyMCE : IEditor {

		private readonly IPluginHelper _PluginHelper;

		public TinyMCE(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source) {
			return source;
		}

		public String GetLicenseInformation() {
			return Resources.License;
		}

		public IUserInterface GetUserInterface() {
			return new EditorControl(_PluginHelper);
		}

	}
}
