using System;
using System.Collections.Generic;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.Toolbox.Properties;
using WebsiteStudio.Modules.Toolbox.Quotes;

namespace WebsiteStudio.Modules.Toolbox.Timeline {

	[PluginInfo("Timeline", Author = "tech-nik89")]
	public class TimelineModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		private const int ResourcesAddedFlag = 1;

		public TimelineModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public string Compile(String source, ICompileHelper compileHelper) {
			try {
				IEditor editor = _PluginHelper.CreateEditor();
				IEnumerable<TimelineItem> data = DataSerializer.Deserialize<TimelineItem>(source);

				IHtmlElement container = compileHelper.CreateHtmlElement("ul");
				container.SetAttribute("class", "timeline");

				foreach(TimelineItem item in data) {
					IHtmlElement li = compileHelper.CreateHtmlElement("li");
					container.AppendChild(li);

					IHtmlElement h1 = compileHelper.CreateHtmlElement("h1");
					h1.Content = item.Title;
					li.AppendChild(h1);

					IHtmlElement content = compileHelper.CreateHtmlElement("div");
					content.Content = editor.Compile(item.Text);
					content.SetAttribute("class", "content");
					li.AppendChild(content);

					IHtmlElement time = compileHelper.CreateHtmlElement("time");
					time.Content = item.Time;
					li.AppendChild(time);
				}

				if (!compileHelper.HasPageFlag(ResourcesAddedFlag)) {
					compileHelper.CreateLessFile(Resources.TimelineStyle);
					compileHelper.SetPageFlag(ResourcesAddedFlag, true);
				}

				return compileHelper.Compile(container);
			}
			catch {
				return String.Empty;
			}
		}

		public IUserInterface GetUserInterface() {
			return new GenericControl<TimelineItem>(_PluginHelper);
		}

	}
}
