using System;
using System.IO;

namespace WebsiteBuilder.Core.Media {

    public class MediaReference : MediaItem {
        
        public String FilePath { get; set; }
        
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
