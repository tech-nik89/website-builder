using System;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner.Data {
	class HorizontalLineItem : FormDataItem {

		public override String Title => "-";

		public override String Type => Strings.HorizontalLine;

		public override String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper) {
			return "<hr />";
		}

	}
}
