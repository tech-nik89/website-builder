using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.News {
    public class NewsModule : IModule {

        private readonly IPluginHelper _PluginHelper;

        public NewsModule(IPluginHelper pluginHelper) {
            _PluginHelper = pluginHelper;
        }

        public String Compile(String source, ICompileHelper compileHelper) {
            return String.Empty;
        }

        public IUserInterface GetUserInterface() {
            return new NewsControl(_PluginHelper);
        }

    }
}
