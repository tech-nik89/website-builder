using System;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Core.Plugins {
    class PluginHelper : IPluginHelper {

        private readonly Type _EditorType;

        public PluginHelper(Type editorType) {
            _EditorType = editorType;
        }

        public IEditor CreateEditor() {
            return Activator.CreateInstance(_EditorType, this) as IEditor;
        }

    }
}
