using System;
using System.IO;

namespace WebsiteStudio.Core.Media {

	public class MediaReference : MediaItem {

		internal MediaReference(Project project)
			: base(project) {
		}

		private String _FilePath;

		public String FilePath {
			get => _FilePath;
			set { _FilePath = value; _Project.Dirty = true; }
		}
		
		public FileInfo FileInfo => new FileInfo(FilePath);
		
		public override String Name => FileInfo.Name;
		
		public override long Size => FileInfo.Length;
		
		public override bool AutoSave { get; set; }

		public override void SaveTo(String path) {
			if (AutoSave) {
				File.Copy(FileInfo.FullName, path, true);
			}
		}
	}
}
