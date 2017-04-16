using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Editors.Avalon {

    [PluginInfo("Avalon HTML Editor")]
    public class AvalonHtmlEditor : IEditor {
        
        public AvalonHtmlEditor(IPluginHelper pluginHelper) {
        }

        public IUserInterface GetUserInterface() {
            return new AvalonEditorControl("HTML");
        }

        public String Compile(String source) {
            return source;
        }
    }
}
