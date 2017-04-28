using System;
using System.IO;

namespace WebsiteBuilder.Core.Media {

    public class MediaFile : MediaItem {

        internal MediaFile(Project project)
            : base(project) {
        }

        private String _FileName;

        public String FileName {
            get => _FileName;
            set { _FileName = value; _Project.Dirty = true; }
        }

        private Byte[] _Data;

        public Byte[] Data {
            get => _Data;
            set { _Data = value; _Project.Dirty = true; }
        }
        
        public override String Name => FileName;
        
        public override long Size => Data.Length;
        
        public override bool AutoSave {
            get => true;
            set { }
		}

		public override void SaveTo(String path) {
			File.WriteAllBytes(path, Data);
		}

	}
}
