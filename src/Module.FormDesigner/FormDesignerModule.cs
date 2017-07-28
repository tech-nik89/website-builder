using System;
using System.Text;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.FormDesigner.Data;

namespace WebsiteBuilder.Modules.FormDesigner {

	[PluginInfo("Form Designer", Author = "tech-nik89")]
	public class FormDesignerModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		public FormDesignerModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper compileHelper) {
			try {
				FormData data = FormData.Deserialize(source);
				StringBuilder innerHtml = new StringBuilder();
				IHtmlElement form = compileHelper.CreateHtmlElement("form");
				form.SetAttribute("action", "");
				form.SetAttribute("method", "post");

				foreach(FormDataItem item in data) {
					innerHtml.AppendLine(item.Render(compileHelper));
				}

				IHtmlElement submit = compileHelper.CreateHtmlElement("input");
				submit.SetAttribute("type", "submit");
				submit.SetAttribute("value", data.SubmitButtonText);

				innerHtml.Append(compileHelper.Compile(submit));

				form.Content = innerHtml.ToString();
				return compileHelper.Compile(form);
			}
			catch {
				return String.Empty;
			}
		}

		public IUserInterface GetUserInterface() {
			return new FormDesignerControl(_PluginHelper);
		}

	}
}
