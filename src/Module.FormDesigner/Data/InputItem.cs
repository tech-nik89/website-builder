using Newtonsoft.Json;
using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	abstract class InputItem : FormDataItem {

		[JsonIgnore]
		private readonly String _InputType;

		[JsonIgnore]
		protected String Value { get; set; }

		public String Label { get; set; }
		
		public override String Title => Label;

		protected InputItem(String inputType) {
			_InputType = inputType;
		}

		public override String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper) {
			String guid = pluginHelper.NewGuid();

			IHtmlElement container = compileHelper.CreateHtmlElement("p");
			IHtmlElement label = compileHelper.CreateHtmlElement("label");
			IHtmlElement input = compileHelper.CreateHtmlElement("input");
			IHtmlElement wrapper = compileHelper.CreateHtmlElement("span");

			container.AppendChild(label);
			container.AppendChild(wrapper);
			wrapper.AppendChild(input);

			wrapper.SetAttribute("class", "wrapper");
			container.SetAttribute("class", "input");
			
			label.SetAttribute("for", guid);
			label.Content = Label;

			input.SetAttribute("type", _InputType);
			input.SetAttribute("id", guid);
			input.SetAttribute("name", Id);

			if (!String.IsNullOrWhiteSpace(Value)) {
				input.SetAttribute("value", Value);
			}

			return compileHelper.Compile(container);
		}

	}
}
