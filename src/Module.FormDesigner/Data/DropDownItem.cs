using System;
using System.Collections.Generic;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class DropDownItem : FormDataItem {

		public override String Type => Strings.DropDown;

		public override String Title => Label;

		public String Label { get; set; }

		public List<String> Items { get; private set; }

		public DropDownItem() {
			Items = new List<String>();
		}

		public override String Render(ICompileHelper compileHelper) {
			IHtmlElement container = compileHelper.CreateHtmlElement("p");
			IHtmlElement label = compileHelper.CreateHtmlElement("label");
			IHtmlElement input = compileHelper.CreateHtmlElement("input");

			container.AppendChild(input);
			container.AppendChild(label);

			label.SetAttribute("for", Id);
			label.Content = Label;

			input.SetAttribute("type", "select");
			input.SetAttribute("id", Id);
			
			if (Items != null) {
				foreach(String item in Items) {
					IHtmlElement option = compileHelper.CreateHtmlElement("option");
					input.AppendChild(option);
					option.Content = item;
				}
			}

			return compileHelper.Compile(container);
		}
	}
}
