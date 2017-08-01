using Newtonsoft.Json;
using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	abstract class FormDataItem {

		public String Id { get; set; }

		[JsonIgnore]
		public abstract String Title { get; }

		[JsonIgnore]
		public abstract String Type { get; }

		public abstract String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper);

	}
}
