using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class TextItem : FormDataItem {

		public override String Title => Text;

		public override String Type => Strings.Text;

		public String Text { get; set; }

		public override String Render(ICompileHelper compileHelper) {
			IHtmlElement p = compileHelper.CreateHtmlElement("p");
			p.Content = Text;
			return compileHelper.Compile(p);
		}

	}
}
