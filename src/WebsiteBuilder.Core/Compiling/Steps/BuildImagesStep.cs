using System;
using System.Collections.Generic;
using System.IO;
using WebsiteBuilder.Core.Theming;
using WebsiteBuilder.Core.Tools;

namespace WebsiteBuilder.Core.Compiling.Steps {
    class BuildImagesStep : ICompilerStep {

        private const String FileSpritesPng = "sprites.png";

        private const String FileSpritesCss = "sprites.css";

        private readonly List<String> _StyleSheetFiles;

        private readonly Theme _Theme;
        
        private readonly DirectoryInfo _MetaDirectory;

        public String Output { get; private set; }

        public BuildImagesStep(Theme theme, DirectoryInfo metaDirectory, List<String> styleSheetFiles) {
            _MetaDirectory = metaDirectory;
            _Theme = theme;
            _StyleSheetFiles = styleSheetFiles;

            Output = "Building image files";
        }

        public void Run() {
            _StyleSheetFiles.Add(FileSpritesCss);

            String pngPath = Path.Combine(_MetaDirectory.FullName, FileSpritesPng);
            String cssPath = Path.Combine(_MetaDirectory.FullName, FileSpritesCss);

            SpriteGenerator generator = new SpriteGenerator(_Theme.Images, FileSpritesPng, _Theme.Settings.ImageCssClass);
            generator.GenerateSprite();

            generator.Image.Save(pngPath);
            File.WriteAllText(cssPath, Utilities.CssMinifier.Compile(generator.CSS));
        }

    }
}
