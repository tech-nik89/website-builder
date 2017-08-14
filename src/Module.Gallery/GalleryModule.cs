using System;
using System.Drawing;
using System.IO;
using System.Text;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.Gallery.Properties;

namespace WebsiteStudio.Modules.Gallery {

	[PluginInfo("Image Gallery", Author = "tech-nik89")]
	public class GalleryModule : IModule {

		private IPluginHelper _PluginHelper;

		private const int ResourceFilesAlreadyAddedFlag = 1;

		public GalleryModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper helper) {
			try {
				GalleryData data = GalleryData.Deserialize(source, _PluginHelper);
				String galleryCssClass = _PluginHelper.NewGuid();

				IHtmlElement container = helper.CreateHtmlElement("div");

				if (!String.IsNullOrWhiteSpace(data.Title)) {
					IHtmlElement title = helper.CreateHtmlElement("h1");
					title.Content = data.Title;
					container.AppendChild(title);
				}

				IHtmlElement gallery = helper.CreateHtmlElement("div");
				gallery.SetAttribute("class", "gallery");
				container.AppendChild(gallery);
				
				foreach (String file in data.Files) {
					String guid = _PluginHelper.NewGuid();
					String extension = Path.GetExtension(file);

					String fullSizeTargetFileName = String.Concat(guid, extension);
					String thumbNailTargetFileName = String.Format("{0}-s{1}", guid, extension);

					using (Image originalSizeImage = Image.FromFile(file))
					using (Image thumbNailImage = ImageHelper.ResizeImage(originalSizeImage, data.ThumbnailSize, true))
					using (Image fullSizeImage = ImageHelper.ResizeImage(originalSizeImage, data.FullSize)) {
						fullSizeImage.Save(helper.GetFilePath(fullSizeTargetFileName));
						thumbNailImage.Save(helper.GetFilePath(thumbNailTargetFileName));
					}

					IHtmlElement a = helper.CreateHtmlElement("a");
					a.SetAttribute("target", "_blank");
					a.SetAttribute("href", fullSizeTargetFileName);
					a.SetAttribute("class", galleryCssClass);

					IHtmlElement img = helper.CreateHtmlElement("img");
					img.SetAttribute("src", thumbNailTargetFileName);
					a.AppendChild(img);

					gallery.AppendChild(a);
				}
				
				if (!helper.HasPageFlag(ResourceFilesAlreadyAddedFlag)) {
					helper.RequireLibrary(Library.jQuery);
					helper.CreateCssFile(Resources.MagnificCSS);
					helper.CreateLessFile(Resources.GalleryStyles);
					helper.CreateJavaScriptFile(Resources.MagnificJS);
					helper.SetPageFlag(ResourceFilesAlreadyAddedFlag, true);
				}

				StringBuilder createGalleryScript = new StringBuilder();
				createGalleryScript.Append("$('.");
				createGalleryScript.Append(galleryCssClass);
				createGalleryScript.Append("').magnificPopup({type:'image',zoom:{enabled:true},gallery:{enabled:true,preload:[1,2]");
				createGalleryScript.Append("}});");

				IHtmlElement script = helper.CreateHtmlElement("script");
				script.SetAttribute("type", "text/javascript");
				gallery.AppendChild(script);
				script.Content = createGalleryScript.ToString();

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
