using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.Toolbox.Properties;
using WebsiteBuilder.Modules.Toolbox.Quotes;

namespace WebsiteBuilder.Modules.Toolbox.Accordion {

	[PluginInfo("Accordion")]
	public class AccordionModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		private const int ResourcesAddedFlag = 1;

		public AccordionModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper compileHelper) {
			try {
				IEditor editor = _PluginHelper.CreateEditor();
				IEnumerable<AccordionItem> data = DataSerializer.Deserialize<AccordionItem>(source);

				if (!compileHelper.HasPageFlag(ResourcesAddedFlag) && data.Any()) {
					compileHelper.CreateJavaScriptFile(Resources.AccordionScript, true);
					compileHelper.CreateLessFile(Resources.AccordionStyle);
					compileHelper.SetPageFlag(ResourcesAddedFlag, true);
				}

				StringBuilder builder = new StringBuilder();

				foreach(AccordionItem item in data) {
					IHtmlElement title = compileHelper.CreateHtmlElement("div");
					title.SetAttribute("class", "accordion");
					title.Content = item.Title;

					IHtmlElement content = compileHelper.CreateHtmlElement("div");
					content.Content = editor.Compile(item.Text);

					builder.Append(compileHelper.Compile(title));
					builder.Append(compileHelper.Compile(content));
				}

				return builder.ToString();
			}
			catch {
				return String.Empty;
			}
		}

		public IUserInterface GetUserInterface() {
			return new GenericControl<AccordionItem>(_PluginHelper);
		}
	}
}
