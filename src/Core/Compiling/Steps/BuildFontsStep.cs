using System;
using System.IO;
using WebsiteStudio.Core.Theming;

namespace WebsiteStudio.Core.Compiling.Steps {
	class BuildFontsStep : CompilerStep {

		private readonly Theme _Theme;

		private readonly DirectoryInfo _MetaDirectory;

		public BuildFontsStep(Theme theme, DirectoryInfo metaDirectory)
			: base("Building font files") {

			_Theme = theme;
			_MetaDirectory = metaDirectory;
		}

		public override void Run() {
			foreach(Font font in _Theme.Fonts) {
				String path = Path.Combine(_MetaDirectory.FullName, font.Name);
				File.WriteAllBytes(path, font.Data);
			}
		}

	}
}
