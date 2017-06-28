using System;
using System.Linq;

namespace WebsiteBuilder.Interface.Plugins {
	public class PluginInfoAttribute : Attribute {

		public String Name { get; private set; }

		public String Author { get; set; }

		public int VersionMajor { get; internal set; }

		public int VersionMinor { get; internal set; }

		public int VersionRevision { get; internal set; }

		public PluginInfoAttribute(String name) {
			Name = name;
		}
		
		public static PluginInfoAttribute GetPluginInfoAttribute(Type pluginType) {
			if (pluginType == null) {
				throw new ArgumentNullException(nameof(pluginType));
			}
			
			var attribute = pluginType
				.GetCustomAttributes(typeof(PluginInfoAttribute), false)
				.Cast<PluginInfoAttribute>()
				.FirstOrDefault();

			return attribute;
		}
	}
}
