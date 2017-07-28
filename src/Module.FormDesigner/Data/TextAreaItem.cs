using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class TextAreaItem : FormDataItem {

		public override String Title => Label;

		public override String Type => Strings.TextArea;

		public String Label { get; set; }

		public override String Render(ICompileHelper compileHelper) {
			IHtmlElement container = compileHelper.CreateHtmlElement("p");
			IHtmlElement label = compileHelper.CreateHtmlElement("label");
			IHtmlElement textarea = compileHelper.CreateHtmlElement("textarea");

			container.AppendChild(label);
			container.AppendChild(textarea);

			label.SetAttribute("for", Id);
			label.Content = Label;

			textarea.SetAttribute("id", Id);

			return compileHelper.Compile(container);
		}

	}
}
