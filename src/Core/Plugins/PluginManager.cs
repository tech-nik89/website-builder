using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Core.Plugins {
	public static class PluginManager {

		private const String PluginDirectoryName = "Plugins";
		private const String PluginLibraryPattern = "*.Plugin.dll";
		
		private static readonly Type _ModuleInterface = typeof(IModule);
		private static readonly Type _EditorInterface = typeof(IEditor);
		private static readonly Type _PublishInterface = typeof(IPublish);
		private static readonly Type _WebserverInterface = typeof(IWebserver);

		private static Type[] _ModuleTypes;
		private static Type[] _EditorTypes;
		private static Type[] _PublishTypes;
		private static Type[] _WebserverTypes;

		public static Dictionary<Type, String> Modules { get; private set; }
		public static Dictionary<Type, String> Editors { get; private set; }
		public static Dictionary<Type, String> Publishers { get; private set; }
		public static Dictionary<Type, String> Webservers { get; private set; }

		public static Type[] ModuleTypes => _ModuleTypes;
		public static Type[] EditorTypes => _EditorTypes;
		public static Type[] PublishTypes => _PublishTypes;
		public static Type[] WebserverTypes => _WebserverTypes;

		private static IEnumerable<PluginInfo> _AllPlugins;

		public static IEnumerable<PluginInfo> AllPlugins {
			get {
				if (_AllPlugins == null) {
					List<PluginInfo> list = new List<PluginInfo>();

					list.AddRange(GetPluginInfos(_ModuleTypes, "Module"));
					list.AddRange(GetPluginInfos(_EditorTypes, "Editor"));
					list.AddRange(GetPluginInfos(_PublishTypes, "Publish"));
					list.AddRange(GetPluginInfos(_WebserverTypes, "Webserver"));

					_AllPlugins = list;
				}

				return _AllPlugins;
			}
		}

		private static IEnumerable<PluginInfo> GetPluginInfos(Type[] types, String category) {
			PluginHelper helper = new PluginHelper();
			Object[] parameters = { helper };

			foreach (Type type in types) {
				PluginInfo info = new PluginInfo() { Type = type, Category = category };
				PluginInfoAttribute attribute = PluginInfoAttribute.GetPluginInfoAttribute(type);

				info.Name = attribute.Name;
				info.Author = attribute.Author;

				FileVersionInfo version = FileVersionInfo.GetVersionInfo(type.Assembly.Location);

				info.VersionMajor = version.FileMajorPart;
				info.VersionMinor = version.FileMinorPart;
				info.VersionRevision = version.FileBuildPart;
				info.VersionBuild = version.FilePrivatePart;


				if (!typeof(IWebserver).IsAssignableFrom(type)) {
					IPlugin instance = (IPlugin)Activator.CreateInstance(type, parameters);
					info.LicenseInfo = instance.GetLicenseInformation();
				}

				yield return info;
			}
		}

		public static void Init() {
			LoadPluginLibraries();
			Modules = LoadModules(_ModuleInterface, out _ModuleTypes);
			Editors = LoadModules(_EditorInterface, out _EditorTypes);
			Publishers = LoadModules(_PublishInterface, out _PublishTypes);
			Webservers = LoadModules(_WebserverInterface, out _WebserverTypes);
		}

		public static Type GetEditor(String type) {
			return _EditorTypes.FirstOrDefault(x => x.AssemblyQualifiedName == type || x.FullName == type);
		}

		public static Type GetModule(String type) {
			return _ModuleTypes.FirstOrDefault(x => x.AssemblyQualifiedName == type || x.FullName == type);
		}

		public static Type GetPublisher(String type) {
			return _PublishTypes.FirstOrDefault(x => x.AssemblyQualifiedName == type || x.FullName == type);
		}

		public static Type GetWebserver(String type) {
			return _WebserverTypes.FirstOrDefault(x => x.AssemblyQualifiedName == type || x.FullName == type);
		}

		private static void LoadPluginLibraries() {
			FileInfo executable = new FileInfo(Assembly.GetEntryAssembly().Location);
			string path = Path.Combine(executable.DirectoryName, PluginDirectoryName);
			DirectoryInfo info = new DirectoryInfo(path);

			if (!info.Exists) {
				return;
			}

			AppDomain.CurrentDomain.AppendPrivatePath(PluginDirectoryName);

			FileInfo[] files = info.GetFiles(PluginLibraryPattern);
			foreach(var file in files) {
				try {
					Assembly.LoadFile(file.FullName);
				}
				catch {
				}
			}
		}

		private static Dictionary<Type, String> LoadModules(Type interfaceType, out Type[] types) {
			var dict = new Dictionary<Type, String>();
			var list = new List<Type>();
			var plugins = AppDomain.CurrentDomain.GetAssemblies()
						.SelectMany(s => s.GetTypes())
						.Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass);
			
			foreach (Type plugin in plugins) {
				dict.Add(plugin, PluginInfoAttribute.GetPluginInfoAttribute(plugin)?.Name);
				list.Add(plugin);
			}

			types = list.ToArray();
			return dict;
		}

		public static IModule LoadModule(PageContent content, Project project) {
			return LoadModule(content, null, project, null);
		}

		public static IModule LoadModule(PageContent content, IIconPack iconPack, Project project, Func<ILink> getLink) {
			if (content == null || content.ModuleType == null || content.EditorType == null) {
				return null;
			}

			PluginHelper helper = new PluginHelper(project, content.EditorType, iconPack, getLink);
			return Activator.CreateInstance(content.ModuleType, helper) as IModule;
		}

		public static IPublish LoadPublisher(Type type, Project project) {
			if (type == null || project == null) {
				return null;
			}

			PluginHelper helper = new PluginHelper(project, null, null);
			return Activator.CreateInstance(type, helper) as IPublish;
		}

		public static IWebserver LoadWebserver(Type type, Project project) {
			if (type == null || project == null) {
				return null;
			}

			PluginHelper helper = new PluginHelper(project, null, null);
			return Activator.CreateInstance(type, helper) as IWebserver;
		}
	}
}
