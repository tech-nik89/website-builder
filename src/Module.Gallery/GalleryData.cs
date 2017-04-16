using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.Gallery {
    class GalleryData {

        private const String RootTag = "gallery";

        private const String FileTag = "file";

        private const String ThumbnailSizeTag = "thumbnailSize";

        private const String FullSizeTag = "fullSize";

        private const String HeightAttribute = "height";

        private const String WidthAttribute = "width";

        public Size ThumbnailSize { get; set; }

        public Size FullSize { get; set; }

        public List<String> Files { get; set; }

        public GalleryData() {
            Files = new List<String>();
            ThumbnailSize = new Size(120, 120);
            FullSize = new Size(1280, 720);
        }

        public static String Serialize(GalleryData data, IPluginHelper helper) {
            XDocument doc = new XDocument(new XElement(RootTag,
                new XElement(ThumbnailSizeTag, new XAttribute(HeightAttribute, data.ThumbnailSize.Height), new XAttribute(WidthAttribute, data.ThumbnailSize.Width)),
                new XElement(FullSizeTag, new XAttribute(HeightAttribute, data.FullSize.Height), new XAttribute(WidthAttribute, data.FullSize.Width)),
                data.Files.Select(x => new XElement(FileTag, helper.GetRelativePath(x)))
            ));

            return doc.ToString();
        }

        public static GalleryData Deserialize(String input, IPluginHelper helper) {
            GalleryData data = new GalleryData();
            
            try {
                XDocument doc = XDocument.Parse(input);
                XElement root = doc.Element(RootTag);

                data.Files = root.Elements(FileTag).Select(x => helper.GetFullPath(x.Value)).ToList();

                XElement thumbnailSize = root.Element(ThumbnailSizeTag);
                data.ThumbnailSize = new Size(Convert.ToInt32(thumbnailSize.Attribute(WidthAttribute).Value), Convert.ToInt32(thumbnailSize.Attribute(HeightAttribute).Value));

                XElement fullSize = root.Element(FullSizeTag);
                data.FullSize = new Size(Convert.ToInt32(fullSize.Attribute(WidthAttribute).Value), Convert.ToInt32(fullSize.Attribute(HeightAttribute).Value));
            }
            catch {
            }

            return data;
        }

    }
}
