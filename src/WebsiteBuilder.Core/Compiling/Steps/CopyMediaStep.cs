using System;
using System.Collections.Generic;
using System.IO;
using WebsiteBuilder.Core.Media;

namespace WebsiteBuilder.Core.Compiling.Steps {
    class CopyMediaStep : ICompilerStep {

		public String Output { get; private set; }

        private readonly List<MediaItem> _Media;

        private readonly DirectoryInfo _Directory;

        public CopyMediaStep(List<MediaItem> media, DirectoryInfo mediaDirectory) {
            Output = "Copying media";
            _Media = media;
            _Directory = mediaDirectory;
        }

        public void Run() {
            foreach (MediaItem item in _Media) {
                string path = Path.Combine(_Directory.FullName, String.Concat(item.Id, Path.GetExtension(item.Name)));
                item.SaveTo(path);
            }
        }

	}
}
