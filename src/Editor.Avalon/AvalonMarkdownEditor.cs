using CommonMark;
using System;
using WebsiteStudio.Editors.Avalon.Properties;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Editors.Avalon {

	[PluginInfo("Avalon Markdown Editor", Author = "tech-nik89")]
	public class AvalonMarkdownEditor : IEditor {

		private readonly IPluginHelper _PluginHelper;

		public AvalonMarkdownEditor(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public IUserInterface GetUserInterface() {
			return new AvalonEditorControl(_PluginHelper, "MarkDown");
		}

		public String Compile(String source) {
			String html = CommonMarkConverter.Convert(source);
			return html;
		}

		public String GetLicenseInformation() {
			return Resources.LicenseInfo;
		}

	}
}
