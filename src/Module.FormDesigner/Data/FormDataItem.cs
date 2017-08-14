using Newtonsoft.Json;
using System;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Modules.FormDesigner.Data {
	abstract class FormDataItem {

		public String Name { get; set; }

		[JsonIgnore]
		public abstract String Title { get; }

		[JsonIgnore]
		public abstract String Type { get; }

		public abstract String Render(IPluginHelper pluginHelper, ICompileHelper compileHelper);

	}
}
