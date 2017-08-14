using System;

namespace WebsiteStudio.Core.Plugins {
	public class PluginInfo {

		public String Category { get; internal set; }

		public Type Type { get; internal set; }

		public String Name { get; internal set; }

		public int VersionMajor { get; internal set; }

		public int VersionMinor { get; internal set; }

		public int VersionRevision { get; internal set; }

		public int VersionBuild { get; internal set; }

		public String Author { get; internal set; }

		public String Version => String.Format("{0}.{1}.{2}.{3}", VersionMajor, VersionMinor, VersionRevision, VersionBuild);

	}
}
