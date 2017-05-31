using System;
using System.IO;
using WebsiteBuilder.Core.Tools;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Core.Plugins {
    class PluginHelper : IPluginHelper {

        private readonly Type _EditorType;

        private readonly IIconPack _IconPack;

        private readonly Project _Project;

        private readonly Func<String> _GetLink;
        
        public PluginHelper(Project project, Type editorType, IIconPack iconPack)
            : this (project, editorType, iconPack, null) {
        }

        public PluginHelper(Project project, Type editorType, IIconPack iconPack, Func<String> getLink) {
            _Project = project;
            _EditorType = editorType;
            _IconPack = iconPack;
            _GetLink = getLink;
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

        public bool CanSuggestCopyToProjectDirectory(String fullFilePath) {
            if (!Path.IsPathRooted(fullFilePath) || _Project.ProjectFile == null || !_Project.ProjectFile.Exists) {
                return false;
            }

            if (String.IsNullOrWhiteSpace(fullFilePath) || !File.Exists(fullFilePath)) {
                return false;
            }

            return !fullFilePath.StartsWith(_Project.ProjectFile.Directory.FullName);
        }

        public String NewGuid() {
            return Utilities.NewGuid();
        }

        public String GetLink() {
            return _GetLink?.Invoke();
        }
    }
}
