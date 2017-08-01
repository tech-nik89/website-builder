using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class HeadlineItem : FormDataItem {

		public override String Title => HeadlineText;

		public override String Type => Strings.Headline;

		public String HeadlineText { get; set; }

		public override String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper) {
			IHtmlElement h1 = compileHelper.CreateHtmlElement("h1");
			h1.Content = HeadlineText;
			return compileHelper.Compile(h1);
		}

	}
}
