using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.Gallery.Properties;

namespace WebsiteStudio.Modules.Gallery {

	[PluginInfo("Image Gallery", Author = "tech-nik89")]
	public class GalleryModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		private readonly int _MaxThreadCount;

		private const int ResourceFilesAlreadyAddedFlag = 1;

		public GalleryModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
			_MaxThreadCount = Environment.ProcessorCount;
		}

		public String Compile(String source, ICompileHelper helper) {
			return Compile(source, helper, false);
		}

		public String Compile(String source, ICompileHelper helper, bool preview) {
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

				if (preview) {
					for (int i = 0; i < data.Files.Count; i++) {
						IHtmlElement img = helper.CreateHtmlElement("img");

						if (data.ThumbnailSize.Width > data.ThumbnailSize.Height) {
							img.SetAttribute("width", data.ThumbnailSize.Width.ToString());
						}
						else {
							img.SetAttribute("height", data.ThumbnailSize.Height.ToString());
						}

						container.AppendChild(img);
					}

					return helper.Compile(container);
				}
				
				int threadCount = data.Files.Count;

				if (threadCount == 0) {
					return String.Empty;
				}

				if (threadCount > _MaxThreadCount) {
					threadCount = _MaxThreadCount;
				}

				int currentThreadImageCount = 0;
				int imagesPerThread = (int)(Math.Ceiling((decimal)data.Files.Count / (decimal)threadCount));
				List<ImageTask>[] imageTasks = new List<ImageTask>[threadCount];

				for (int i = 0; i < threadCount; i++) {
					imageTasks[i] = new List<ImageTask>();
				}

				foreach (String file in data.Files) {
					String guid = _PluginHelper.NewGuid();
					String extension = Path.GetExtension(file);

					ImageTask task = new ImageTask(file);
					task.FullSizeTargetFileName = String.Concat(guid, extension);
					task.ThumbNailTargetFileName = String.Format("{0}-s{1}", guid, extension);

					IHtmlElement a = helper.CreateHtmlElement("a");
					a.SetAttribute("target", "_blank");
					a.SetAttribute("href", task.FullSizeTargetFileName);
					a.SetAttribute("class", galleryCssClass);

					IHtmlElement img = helper.CreateHtmlElement("img");
					img.SetAttribute("src", task.ThumbNailTargetFileName);
					a.AppendChild(img);

					gallery.AppendChild(a);

					imageTasks[currentThreadImageCount].Add(task);
					if (imageTasks[currentThreadImageCount].Count >= imagesPerThread) {
						currentThreadImageCount++;
					}
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

				Task[] tasks = new Task[imageTasks.Length];
				for(int i = 0; i < imageTasks.Length; i++) {
					List<ImageTask> images = new List<ImageTask>();
					images.AddRange(imageTasks[i]);

					tasks[i] = Task.Run(() => {
						ProcessImages(images, data.ThumbnailSize, data.FullSize, helper);
					});
				}

				Task.WaitAll(tasks);

				return helper.Compile(container);
			}
			catch {
				throw;
			}
		}

		private static void ProcessImages(IEnumerable<ImageTask> tasks, Size thumbnailSize, Size fullSize, ICompileHelper helper) {
			foreach (ImageTask task in tasks) {
				ProcessImage(task, thumbnailSize, fullSize, helper);
			}
		}

		private static void ProcessImage(ImageTask task, Size thumbnailSize, Size fullSize, ICompileHelper helper) {
			using (Image originalSizeImage = Image.FromFile(task.Path))
			using (Image thumbNailImage = ImageHelper.ResizeImage(originalSizeImage, thumbnailSize, true))
			using (Image fullSizeImage = ImageHelper.ResizeImage(originalSizeImage, fullSize)) {
				fullSizeImage.Save(helper.GetFilePath(task.FullSizeTargetFileName));
				thumbNailImage.Save(helper.GetFilePath(task.ThumbNailTargetFileName));
			}
		}

		public IUserInterface GetUserInterface() {
			return new GalleryControl(_PluginHelper);
		}

		public String GetLicenseInformation() {
			return Resources.LicenseInfo;
		}
	}
}
