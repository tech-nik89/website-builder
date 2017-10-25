using System;
using System.Text;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.Properties;

namespace WebsiteStudio.Modules.Image {

	[PluginInfo("Static Image", Author = "tech-nik89")]
	public class StaticImageModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		public StaticImageModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper compileHelper) {
			IHtmlElement div = compileHelper.CreateHtmlElement("div");
			IHtmlElement img = compileHelper.CreateHtmlElement("img");

			try {
				ImageData data = ImageData.Derserialize(source);
				img.SetAttribute("src", data.Id);
				img.SetAttribute("alt", data.AlternateText);
				img.SetAttribute("border", "0");

				StringBuilder style = new StringBuilder();

				AppendStyle(style, "width", data.Width, data.WidthUnit);
				AppendStyle(style, "max-width", data.MaxWidth, data.MaxWidthUnit);
				AppendStyle(style, "height", data.Height, data.HeightUnit);
				AppendStyle(style, "max-height", data.MaxHeight, data.MaxHeightUnit);

				if (style.Length > 0) {
					img.SetAttribute("style", style.ToString());
				}

				div.SetAttribute("style", String.Format("text-align:{0}", data.Alignment.ToString().ToLower()));

				if (!String.IsNullOrWhiteSpace(data.Link)) {
					IHtmlElement a = compileHelper.CreateHtmlElement("a");
					a.SetAttribute("href", data.Link);

					if (!String.IsNullOrWhiteSpace(data.LinkTarget)) {
						a.SetAttribute("target", data.LinkTarget);
					}

					div.AppendChild(a);
					a.AppendChild(img);
				}
				else {
					div.AppendChild(img);
				}
			}
			catch {
			}

			return compileHelper.Compile(div);
		}

		private static void AppendStyle(StringBuilder style, String type, int value, String unit) {
			if(value <= 0) {
				return;
			}

			style.Append(type);
			style.Append(":");
			style.Append(value);
			style.Append(unit);
			style.Append(";");
		}

		public String GetLicenseInformation() {
			return Resources.LicenseInfo;
		}

		public IUserInterface GetUserInterface() {
			return new StaticImageControl(_PluginHelper);
		}

	}
}
