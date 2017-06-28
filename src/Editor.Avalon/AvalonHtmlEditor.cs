using System;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Editors.Avalon {

	[PluginInfo("Avalon HTML Editor", Author = "tech-nik89")]
	public class AvalonHtmlEditor : IEditor {
		
		public AvalonHtmlEditor(IPluginHelper pluginHelper) {
		}

		public IUserInterface GetUserInterface() {
			return new AvalonEditorControl("HTML");
		}

		public String Compile(String source) {
			return source;
		}
	}
}
