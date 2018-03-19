using System;
using System.IO;
using System.Linq;
using WebsiteStudio.Core.Tools;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Core.Plugins {
	class PluginHelper : IPluginHelper {

		private readonly Type _EditorType;

		private readonly IIconPack _IconPack;

		private readonly Project _Project;

		private readonly Func<GetLinkMode, ILink> _GetLink;

		public DirectoryInfo OutputDirectory => new DirectoryInfo(_Project.OutputPath);
		
		internal PluginHelper() {
		}

		public PluginHelper(Project project, Type editorType, IIconPack iconPack)
			: this (project, editorType, iconPack, null) {
		}

		public PluginHelper(Project project, Type editorType, IIconPack iconPack, Func<GetLinkMode, ILink> getLink) {
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

		public bool IsBelowProject(String fullPath) {
			return Utilities.IsBelowProject(fullPath, _Project);
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

		public ILink GetLink() {
			int all = Enum.GetValues(typeof(GetLinkMode)).Cast<int>().Sum();
			return GetLink((GetLinkMode)all);
		}

		public ILink GetLink(GetLinkMode mode) {
			return _GetLink?.Invoke(mode);
		}

		public String GetFormattedFileSize(long bytes) {
			return bytes.FormatFileSize();
		}

		public String GetRemoteFullPath(String localFullPath) {
			String localRelativePath = Utilities.FullToRelativePath(localFullPath, _Project.OutputPath);
			if (_Project.ServerLocalRootPath.Contains("/")) {
				localRelativePath = localRelativePath.Replace(Path.PathSeparator, '/');
				return _Project.ServerLocalRootPath + localRelativePath;
			}
			else {
				return Path.Combine(_Project.ServerLocalRootPath, localRelativePath);
			}
		}
	}
}
