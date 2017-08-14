using System;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner.Data {
	class TextItem : FormDataItem {

		public override String Title => Text;

		public override String Type => Strings.Text;

		public String Text { get; set; }

		public override String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper) {
			IHtmlElement p = compileHelper.CreateHtmlElement("p");
			p.Content = Text;
			return compileHelper.Compile(p);
		}

	}
}
