using System;
using System.IO;
using WebsiteBuilder.Core.Theming;

namespace WebsiteBuilder.Core.Compiling.Steps {
	class BuildFontsStep : ICompilerStep {

		public String Output { get; private set; }

		private readonly Theme _Theme;

		private readonly DirectoryInfo _MetaDirectory;

		public BuildFontsStep(Theme theme, DirectoryInfo metaDirectory) {
			_Theme = theme;
			_MetaDirectory = metaDirectory;

			Output = "Building font files";
		}

		public void Run() {
			foreach(Font font in _Theme.Fonts) {
				String path = Path.Combine(_MetaDirectory.FullName, font.Name);
				File.WriteAllBytes(path, font.Data);
			}
		}

	}
}
