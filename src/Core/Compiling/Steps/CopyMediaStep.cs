using System;
using System.Collections.Generic;
using System.IO;
using WebsiteStudio.Core.Media;

namespace WebsiteStudio.Core.Compiling.Steps {
	class CopyMediaStep : CompilerStep {
		
		private readonly IEnumerable<MediaItem> _Media;

		private readonly DirectoryInfo _Directory;

		public CopyMediaStep(IEnumerable<MediaItem> media, DirectoryInfo mediaDirectory) 
			: base("Copying media") {
			
			_Media = media;
			_Directory = mediaDirectory;
		}

		public override void Run() {
			foreach (MediaItem item in _Media) {
				String path = Path.Combine(_Directory.FullName, String.Concat(item.Id, Path.GetExtension(item.Name)));
				item.SaveTo(path);
			}
		}

	}
}
