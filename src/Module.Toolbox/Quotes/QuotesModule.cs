using System;
using System.Collections.Generic;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.Toolbox.Properties;

namespace WebsiteStudio.Modules.Toolbox.Quotes {

	[PluginInfo("Quotes", Author = "tech-nik89")]
	public class QuotesModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		private const int ResourcesAddedFlag = 1;

		public QuotesModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper compileHelper) {
			try {
				IEditor editor = _PluginHelper.CreateEditor();
				IEnumerable<Quote> data = DataSerializer.Deserialize<Quote>(source);

				IHtmlElement container = compileHelper.CreateHtmlElement("div");
				container.SetAttribute("class", "quotes");

				IHtmlElement progress = compileHelper.CreateHtmlElement("div");
				progress.SetAttribute("class", "progress");
				container.AppendChild(progress);

				IHtmlElement progressRunner = compileHelper.CreateHtmlElement("span");
				progress.AppendChild(progressRunner);

				foreach (Quote quote in data) {
					IHtmlElement blockquote = compileHelper.CreateHtmlElement("blockquote");
					container.AppendChild(blockquote);

					IHtmlElement content = compileHelper.CreateHtmlElement("div");
					content.Content = editor.Compile(quote.Text);
					blockquote.AppendChild(content);

					IHtmlElement footer = compileHelper.CreateHtmlElement("div");
					footer.SetAttribute("class", "footer");
					footer.Content = quote.Author;
					blockquote.AppendChild(footer);
				}

				if (!compileHelper.HasPageFlag(ResourcesAddedFlag)) {
					compileHelper.CreateJavaScriptFile(Resources.QuotesScript, true);
					compileHelper.CreateLessFile(Resources.QuotesStyle);
					compileHelper.SetPageFlag(ResourcesAddedFlag, true);
				}

				return compileHelper.Compile(container);
			}
			catch {
				return String.Empty;
			}
		}

		public IUserInterface GetUserInterface() {
			return new GenericControl<Quote>(_PluginHelper);
		}

		public String GetLicenseInformation() {
			return Resources.LicenseInfo;
		}

	}
}
