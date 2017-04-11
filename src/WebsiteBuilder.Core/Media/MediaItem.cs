using System;

namespace WebsiteBuilder.Core.Media {

    public abstract class MediaItem {
        
        public String Id { get; set; }
        
        public abstract bool AutoSave { get; set; }
        
        public abstract string Name { get; }
        
        public abstract long Size { get; }

		public abstract void SaveTo(String path);

    }
}
