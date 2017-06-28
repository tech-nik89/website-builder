using CommonMark;
using System;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Editors.Avalon {

	[PluginInfo("Avalon Markdown Editor", Author = "tech-nik89")]
	public class AvalonMarkdownEditor : IEditor {
		
		public AvalonMarkdownEditor(IPluginHelper pluginHelper) {
		}

		public IUserInterface GetUserInterface() {
			return new AvalonEditorControl("MarkDown");
		}

		public String Compile(String source) {
			String html = CommonMarkConverter.Convert(source);
			return html;
		}

	}
}
