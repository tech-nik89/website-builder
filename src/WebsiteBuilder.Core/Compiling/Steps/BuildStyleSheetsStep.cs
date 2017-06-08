using System;
using System.Collections.Generic;
using System.IO;
using WebsiteBuilder.Core.Theming;
using WebsiteBuilder.Core.Tools;

namespace WebsiteBuilder.Core.Compiling.Steps {
	class BuildStyleSheetsStep : ICompilerStep {

		private const String FileExtensionCss = "css";

		private readonly DirectoryInfo _MetaDirectory;

		private readonly Theme _Theme;

		private readonly List<String> _StyleSheetFiles;

		public String Output { get; private set; }

		public BuildStyleSheetsStep(Theme theme, DirectoryInfo metaDirectory, List<String> styleSheetFiles) {
			_MetaDirectory = metaDirectory;
			_StyleSheetFiles = styleSheetFiles;
			_Theme = theme;

			Output = "Building style sheets";
		}

		public void Run() {
			foreach (ThemeStyle style in _Theme.Styles) {
				String css = Utilities.CssMinifier.Compile(style.Css);

				if (String.IsNullOrWhiteSpace(css)) {
					continue;
				}

				String fileName = String.Concat(Utilities.NewGuid(), ".", FileExtensionCss);
				String path = Path.Combine(_MetaDirectory.FullName, fileName);
				File.WriteAllText(path, css);

				_StyleSheetFiles.Add(fileName);
			}
		}
	}
}
