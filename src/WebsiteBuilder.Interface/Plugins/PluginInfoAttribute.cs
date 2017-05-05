using System;
using System.Linq;

namespace WebsiteBuilder.Interface.Plugins {
	public class PluginInfoAttribute : Attribute {

        public String Name { get; private set; }

        public bool SupportsMultiSectionLayout { get; set; }
        
		public PluginInfoAttribute(String name) {
            Name = name;
        }

		public static String GetPluginName(Type pluginType) {
			var attribute = GetPluginInfoAttribute(pluginType);

			if (attribute != null) {
				return attribute.Name;
			}

			return pluginType.Name;
		}
        
		private static PluginInfoAttribute GetPluginInfoAttribute(Type pluginType) {
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
