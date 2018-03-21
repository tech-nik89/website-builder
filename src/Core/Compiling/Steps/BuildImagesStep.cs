using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebsiteStudio.Core.Theming;
using WebsiteStudio.Core.Tools;

namespace WebsiteStudio.Core.Compiling.Steps {
	class BuildImagesStep : CompilerStep {

		private const String FileSpritesPng = "sprites.png";

		private const String FileSpritesCss = "sprites.css";

		public const String FileFavicon = "favicon.ico";

		private readonly List<String> _StyleSheetFiles;

		private readonly Theme _Theme;
		
		private readonly DirectoryInfo _MetaDirectory;

		private readonly byte[] _Favicon;

		public BuildImagesStep(Theme theme, DirectoryInfo metaDirectory, List<String> styleSheetFiles, byte[] favicon) 
			: base("Building image files") {

			_MetaDirectory = metaDirectory;
			_Theme = theme;
			_StyleSheetFiles = styleSheetFiles;
			_Favicon = favicon;
		}

		public override void Run() {
			if (!_Theme.Images.Any()) {
				return;
			}

			_StyleSheetFiles.Add(FileSpritesCss);

			String pngPath = Path.Combine(_MetaDirectory.FullName, FileSpritesPng);
			String cssPath = Path.Combine(_MetaDirectory.FullName, FileSpritesCss);
			
			SpriteGenerator generator = new SpriteGenerator(_Theme.Images, FileSpritesPng, _Theme.Settings.ImageCssClass);
			generator.GenerateSprite();

			generator.Image.Save(pngPath);
			File.WriteAllText(cssPath, Utilities.CssMinifier.Compile(generator.CSS));

			if (_Favicon?.Length > 0) {
				String faviconPath = Path.Combine(_MetaDirectory.FullName, FileFavicon);
				File.WriteAllBytes(faviconPath, _Favicon);
			}
		}

	}
}
