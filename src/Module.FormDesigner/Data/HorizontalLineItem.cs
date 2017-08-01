using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class HorizontalLineItem : FormDataItem {

		public override String Title => "-";

		public override String Type => Strings.HorizontalLine;

		public override String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper) {
			return "<hr />";
		}

	}
}
