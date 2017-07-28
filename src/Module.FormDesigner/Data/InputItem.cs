using Newtonsoft.Json;
using System;
using WebsiteBuilder.Interface.Compiling;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	abstract class InputItem : FormDataItem {

		[JsonIgnore]
		private readonly String _InputType;

		public String Label { get; set; }
		
		public override String Title => Label;

		protected InputItem(String inputType) {
			_InputType = inputType;
		}

		public override String Render(ICompileHelper compileHelper) {
			IHtmlElement container = compileHelper.CreateHtmlElement("p");
			IHtmlElement label = compileHelper.CreateHtmlElement("label");
			IHtmlElement input = compileHelper.CreateHtmlElement("input");

			container.AppendChild(label);
			container.AppendChild(input);

			label.SetAttribute("for", Id);
			label.Content = Label;

			input.SetAttribute("type", _InputType);
			input.SetAttribute("id", Id);

			return compileHelper.Compile(container);
		}

	}
}
