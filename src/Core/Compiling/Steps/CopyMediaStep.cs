using System;
using System.Collections.Generic;
using System.IO;
using WebsiteStudio.Core.Media;

namespace WebsiteStudio.Core.Compiling.Steps {
	class CopyMediaStep : ICompilerStep {

		public String Output { get; private set; }

		private readonly IEnumerable<MediaItem> _Media;

		private readonly DirectoryInfo _Directory;

		public CopyMediaStep(IEnumerable<MediaItem> media, DirectoryInfo mediaDirectory) {
			Output = "Copying media";
			_Media = media;
			_Directory = mediaDirectory;
		}

		public void Run() {
			foreach (MediaItem item in _Media) {
				String path = Path.Combine(_Directory.FullName, String.Concat(item.Id, Path.GetExtension(item.Name)));
				item.SaveTo(path);
			}
		}

	}
}
