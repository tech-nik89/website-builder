using System;
using System.IO;

namespace WebsiteBuilder.Core.Media {

    public class MediaFile : MediaItem {
        
        public String FileName { get; set; }
		
        public byte[] Data { get; set; }
        
        public override String Name => FileName;
        
        public override long Size => Data.Length;
        
        public override bool AutoSave {
			get {
				return true;
			}
			set {
			}
		}

		public override void SaveTo(String path) {
			File.WriteAllBytes(path, Data);
		}

	}
}
