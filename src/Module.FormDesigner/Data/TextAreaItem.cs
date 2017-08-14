using System;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner.Data {
	class TextAreaItem : FormDataItem {

		public override String Title => Label;

		public override String Type => Strings.TextArea;

		public String Label { get; set; }

		public override String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper) {
			String guid = pluginHelper.NewGuid();

			IHtmlElement container = compileHelper.CreateHtmlElement("p");
			IHtmlElement label = compileHelper.CreateHtmlElement("label");
			IHtmlElement textarea = compileHelper.CreateHtmlElement("textarea");

			container.AppendChild(label);
			container.AppendChild(textarea);

			label.SetAttribute("for", guid);
			label.Content = Label;

			textarea.SetAttribute("id", guid);
			textarea.SetAttribute("name", Name);

			return compileHelper.Compile(container);
		}

	}
}
