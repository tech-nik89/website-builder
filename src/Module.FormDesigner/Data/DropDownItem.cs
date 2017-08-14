using System;
using System.Collections.Generic;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner.Data {
	class DropDownItem : FormDataItem {

		public override String Type => Strings.DropDown;

		public override String Title => Label;

		public String Label { get; set; }

		public List<String> Items { get; private set; }

		public DropDownItem() {
			Items = new List<String>();
		}

		public override String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper) {
			String guid = pluginHelper.NewGuid();

			IHtmlElement container = compileHelper.CreateHtmlElement("p");
			IHtmlElement label = compileHelper.CreateHtmlElement("label");
			IHtmlElement select = compileHelper.CreateHtmlElement("select");
			IHtmlElement wrapper = compileHelper.CreateHtmlElement("span");

			container.AppendChild(label);
			container.AppendChild(wrapper);
			wrapper.AppendChild(select);

			container.SetAttribute("class", "input");
			wrapper.SetAttribute("class", "wrapper");

			label.SetAttribute("for", guid);
			label.Content = Label;

			select.SetAttribute("type", "select");
			select.SetAttribute("id", guid);
			select.SetAttribute("name", Name);

			if (Items != null) {
				foreach(String item in Items) {
					IHtmlElement option = compileHelper.CreateHtmlElement("option");
					select.AppendChild(option);
					option.Content = item;
				}
			}

			return compileHelper.Compile(container);
		}
	}
}
