using System;

namespace WebsiteBuilder.Core.Media {

	public abstract class MediaItem {

		protected readonly Project _Project;

		internal MediaItem(Project project) {
			_Project = project;
		}
		
		public String Id { get; set; }
		
		public abstract bool AutoSave { get; set; }
		
		public abstract String Name { get; }
		
		public abstract long Size { get; }

		public abstract void SaveTo(String path);

	}
}
