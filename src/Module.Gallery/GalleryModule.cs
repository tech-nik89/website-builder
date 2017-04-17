using System;
using System.Drawing;
using System.IO;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.Gallery.Properties;

namespace WebsiteBuilder.Modules.Gallery {

    [PluginInfo("Image Gallery")]
    public class GalleryModule : IModule {

        private IPluginHelper _PluginHelper;

        public GalleryModule(IPluginHelper pluginHelper) {
            _PluginHelper = pluginHelper;
        }

        public String Compile(String source, ICompileHelper helper) {
            try {
                GalleryData data = GalleryData.Deserialize(source, _PluginHelper);

                IHtmlElement container = helper.CreateHtmlElement("div");
                container.SetAttribute("class", "gallery");

                if (!String.IsNullOrWhiteSpace(data.Title)) {
                    IHtmlElement title = helper.CreateHtmlElement("h1");
                    title.Content = data.Title;
                    container.AppendChild(title);
                }

                foreach (String file in data.Files) {
                    Guid guid = Guid.NewGuid();
                    String extension = Path.GetExtension(file);

                    String fullSizeTargetFileName = String.Concat(guid, extension);
                    String thumbNailTargetFileName = String.Format("{0}-s{1}", guid, extension);

                    using (Image originalSizeImage = Image.FromFile(file))
                    using (Image thumbNailImage = ImageHelper.ResizeImage(originalSizeImage, data.ThumbnailSize))
                    using (Image fullSizeImage = ImageHelper.ResizeImage(originalSizeImage, data.FullSize)) {
                        fullSizeImage.Save(helper.GetFilePath(fullSizeTargetFileName));
                        thumbNailImage.Save(helper.GetFilePath(thumbNailTargetFileName));
                    }

                    IHtmlElement a = helper.CreateHtmlElement("a");
                    a.SetAttribute("target", "_blank");
                    a.SetAttribute("href", fullSizeTargetFileName);

                    IHtmlElement img = helper.CreateHtmlElement("img");
                    img.SetAttribute("src", thumbNailTargetFileName);
                    a.AppendChild(img);

                    container.AppendChild(a);
                }

                IHtmlElement full = helper.CreateHtmlElement("div");
                full.SetAttribute("class", "full");
                container.AppendChild(full);
                
                helper.CreateLessFile(Resources.GalleryStyles);
                helper.CreateJavaScriptFile(Resources.GalleryCode, true);

                return helper.Compile(container);
            }
            catch {
                throw;
            }
        }

        public IUserInterface GetUserInterface() {
            return new GalleryControl(_PluginHelper);
        }
    }
}
