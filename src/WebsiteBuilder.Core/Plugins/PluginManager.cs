using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Core.Plugins {
    public static class PluginManager {

		private const String PluginDirectoryName = "Plugins";
		private const String PluginLibraryPattern = "*.Plugin.dll";
        
        private static readonly Type _ModuleInterface = typeof(IModule);
        private static readonly Type _EditorInterface = typeof(IEditor);

		private static Type[] _ModuleTypes;
		private static Type[] _EditorTypes;

		public static Dictionary<Type, String> Modules { get; private set; }
        public static Dictionary<Type, String> Editors { get; private set; }

		public static Type[] ModuleTypes => _ModuleTypes;
		public static Type[] EditorTypes => _EditorTypes;

		public static void Init() {
			LoadPluginLibraries();
			Modules = LoadModules(_ModuleInterface, out _ModuleTypes);
			Editors = LoadModules(_EditorInterface, out _EditorTypes);
		}

		public static Type GetEditor(string type) {
			return _EditorTypes.FirstOrDefault(x => x.AssemblyQualifiedName == type || x.FullName == type);
		}

		public static Type GetModule(string type) {
			return _ModuleTypes.FirstOrDefault(x => x.AssemblyQualifiedName == type || x.FullName == type);
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
            
            foreach (var plugin in plugins) {
                dict.Add(plugin, PluginInfoAttribute.GetPluginName(plugin));
				list.Add(plugin);
            }

			types = list.ToArray();
            return dict;
        }

        public static IModule LoadModule(PageContent content) {
            if (content == null || content.ModuleType == null || content.EditorType == null) {
                return null;
            }

            PluginHelper helper = new PluginHelper(content.EditorType);
            return Activator.CreateInstance(content.ModuleType, helper) as IModule;
        }
    }
}
