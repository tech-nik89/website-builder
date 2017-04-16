using System;
using WebsiteBuilder.Core.Tools;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Core.Plugins {
    class PluginHelper : IPluginHelper {

        private readonly Type _EditorType;

        private readonly IIconPack _IconPack;

        private readonly Project _Project;

        public PluginHelper(Project project, Type editorType, IIconPack iconPack) {
            _Project = project;
            _EditorType = editorType;
            _IconPack = iconPack;
        }

        public IEditor CreateEditor() {
            return Activator.CreateInstance(_EditorType, this) as IEditor;
        }
        
        public IIconPack GetIconPack() {
            return _IconPack;
        }

        public String GetFullPath(String relativePath) {
            return Utilities.RelativeToFullPath(relativePath, _Project);
        }

        public String GetRelativePath(String fullPath) {
            return Utilities.FullToRelativePath(fullPath, _Project);
        }
    }
}
