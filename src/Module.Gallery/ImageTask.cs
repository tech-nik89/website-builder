using System;

namespace WebsiteStudio.Modules.Gallery {
	class ImageTask {

		public String Path { get; private set; }

		public String FullSizeTargetFileName { get; set; }

		public String ThumbNailTargetFileName { get; set; }

		public ImageTask(String path) {
			Path = path;
		}

	}
}
