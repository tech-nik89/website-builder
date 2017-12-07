using System;
using System.Text;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.FormDesigner.Data;
using WebsiteStudio.Modules.FormDesigner.Localization;
using WebsiteStudio.Modules.FormDesigner.Properties;
using WebsiteStudio.Modules.FormDesigner.Services;

namespace WebsiteStudio.Modules.FormDesigner {

	[PluginInfo("Form Designer", Author = "tech-nik89")]
	public class FormDesignerModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		private const int ResourceFilesAlreadyAddedFlag = 1;

		public FormDesignerModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper compileHelper) {
			return Compile(source, compileHelper, false);
		}

		public String Compile(String source, ICompileHelper compileHelper, bool preview) {
			try {
				FormData data = FormData.Deserialize(source);
				Service service = Service.GetService(data.TargetService, data);

				StringBuilder innerHtml = new StringBuilder();
				IHtmlElement form = compileHelper.CreateHtmlElement("form");

				form.SetAttribute("class", "form-designer");
				form.SetAttribute("action", service.GetUrl());
				form.SetAttribute("method", "post");

				if (!String.IsNullOrWhiteSpace(data.SuccessMessage)) {
					form.SetAttribute("data-message", data.SuccessMessage);
				}

				foreach(FormDataItem item in data.Items) {
					innerHtml.AppendLine(item.Render(_PluginHelper, compileHelper));
				}

				IHtmlElement submit = compileHelper.CreateHtmlElement("input");
				submit.SetAttribute("type", "submit");
				submit.SetAttribute("value", !String.IsNullOrWhiteSpace(data.SubmitButtonText) ? data.SubmitButtonText : Strings.Submit);

				innerHtml.Append(compileHelper.Compile(submit));

				if (!compileHelper.HasPageFlag(ResourceFilesAlreadyAddedFlag)) {
					compileHelper.CreateLessFile(Resources.FormStyle);
					compileHelper.CreateJavaScriptFile(Resources.FormCode, true);
					compileHelper.RequireLibrary(Library.jQuery);
					compileHelper.SetPageFlag(ResourceFilesAlreadyAddedFlag, true);
				}

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

		public String GetLicenseInformation() {
			return Resources.LicenseInfo;
		}
	}
}
