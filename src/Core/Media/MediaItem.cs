using System;
using System.IO;

namespace WebsiteStudio.Core.Media {

	public abstract class MediaItem {

		public static readonly String[] ImageExtensions = { ".jpg", ".jpeg", ".gif", ".png" };

		protected readonly Project _Project;

		internal MediaItem(Project project) {
			_Project = project;
		}
		
		public String Id { get; set; }
		
		public abstract bool DeployToOutput { get; set; }
		
		public abstract String Name { get; }
		
		public abstract long Size { get; }

		public abstract void SaveTo(String path);

		public String Extension => Path.GetExtension(Name).ToLower();

		public bool IsImage => Array.IndexOf(ImageExtensions, Extension) > -1;

	}
}
