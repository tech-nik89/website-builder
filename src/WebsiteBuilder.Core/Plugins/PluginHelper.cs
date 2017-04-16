using System;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Core.Plugins {
    class PluginHelper : IPluginHelper {

        private readonly Type _EditorType;

        private readonly IIconPack _IconPack;

        public PluginHelper(Type editorType, IIconPack iconPack) {
            _EditorType = editorType;
            _IconPack = iconPack;
        }

        public IEditor CreateEditor() {
            return Activator.CreateInstance(_EditorType, this) as IEditor;
        }

        public IIconPack GetIconPack() {
            return _IconPack;
        }
    }
}
