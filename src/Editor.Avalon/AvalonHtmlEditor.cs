using System;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Editors.Avalon {

	[PluginInfo("Avalon HTML Editor", Author = "tech-nik89")]
	public class AvalonHtmlEditor : IEditor {

		private readonly IPluginHelper _PluginHelper;

		public AvalonHtmlEditor(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public IUserInterface GetUserInterface() {
			return new AvalonEditorControl(_PluginHelper, "HTML");
		}

		public String Compile(String source) {
			return source;
		}
	}
}
