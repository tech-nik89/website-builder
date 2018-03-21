﻿using System;
using System.Collections.Generic;
using System.IO;
using WebsiteStudio.Core.Theming;
using WebsiteStudio.Core.Tools;

namespace WebsiteStudio.Core.Compiling.Steps {
	class BuildStyleSheetsStep : CompilerStep {

		private const String FileExtensionCss = "css";

		private readonly DirectoryInfo _MetaDirectory;

		private readonly Theme _Theme;

		private readonly List<String> _StyleSheetFiles;
		
		public BuildStyleSheetsStep(Theme theme, DirectoryInfo metaDirectory, List<String> styleSheetFiles) 
			: base("Building style sheets") {
			_MetaDirectory = metaDirectory;
			_StyleSheetFiles = styleSheetFiles;
			_Theme = theme;
		}

		public override void Run() {
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
