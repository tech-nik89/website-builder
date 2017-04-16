using System;
using System.Drawing;
using System.IO;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.Gallery {

    [PluginInfo("Image Gallery")]
    public class GalleryModule : IModule {

        private IPluginHelper _PluginHelper;

        public GalleryModule(IPluginHelper pluginHelper) {
            _PluginHelper = pluginHelper;
        }

        public String Compile(String source, ICompileHelper helper) {
            try {
                GalleryData data = GalleryData.Deserialize(source);

                IHtmlElement container = helper.CreateHtmlElement("div");
                container.SetAttribute("class", "gallery");

                foreach(String file in data.Files) {
                    Guid guid = Guid.NewGuid();
                    String extension = Path.GetExtension(file);

                    String fullSizeTargetFileName = String.Concat(guid, extension);
                    String thumbNailTargetFileName = String.Format("{0}-s{1}", guid, extension);

                    Image originalSizeImage = Image.FromFile(file);
                    Image fullSizeImage = ImageHelper.ResizeImage(originalSizeImage, data.FullSize);
                    Image thumbNailImage = ImageHelper.ResizeImage(originalSizeImage, data.ThumbnailSize);

                    fullSizeImage.Save(helper.GetFilePath(fullSizeTargetFileName));
                    thumbNailImage.Save(helper.GetFilePath(thumbNailTargetFileName));

                    IHtmlElement a = helper.CreateHtmlElement("a");
                    a.SetAttribute("href", "#");

                    IHtmlElement img = helper.CreateHtmlElement("img");
                    img.SetAttribute("src", thumbNailTargetFileName);
                    a.AppendChild(img);

                    container.AppendChild(a);
                }

                helper.CreateLessFile(GalleryStyles.Styles);
                
                return helper.Compile(container);
            }
            catch {
                return String.Empty;
            }
        }

        public IUserInterface GetUserInterface() {
            return new GalleryControl(_PluginHelper);
        }
    }
}
