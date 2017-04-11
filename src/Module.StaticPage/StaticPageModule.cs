using System;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.StaticPage {

    [PluginInfo("Static Page")]
    public class StaticPageModule : IModule {

        private readonly IPluginHelper _PluginHelper;

        public StaticPageModule(IPluginHelper pluginHelper) {
            _PluginHelper = pluginHelper;
        }

        public String Compile(String source) {
            IEditor editor = _PluginHelper.CreateEditor();
            return editor.Compile(source);
        }

        public IUserInterface GetUserInterface() {
            return new StaticPageControl(_PluginHelper);
        }
    }
}
