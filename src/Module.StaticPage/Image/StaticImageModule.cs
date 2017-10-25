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
			IHtmlElement figure = compileHelper.CreateHtmlElement("figure");
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

				figure.SetAttribute("style", String.Format("text-align:{0}", data.Alignment.ToString().ToLower()));

				if (!String.IsNullOrWhiteSpace(data.Link) && String.IsNullOrWhiteSpace(data.FooterText)) {
					IHtmlElement a = compileHelper.CreateHtmlElement("a");
					a.SetAttribute("href", data.Link);

					if (!String.IsNullOrWhiteSpace(data.LinkTarget)) {
						a.SetAttribute("target", data.LinkTarget);
					}

					figure.AppendChild(a);
					a.AppendChild(img);
				}
				else {
					figure.AppendChild(img);
				}

				if (!String.IsNullOrWhiteSpace(data.FooterText)) {
					IHtmlElement figcaption = compileHelper.CreateHtmlElement("figcaption");
					figcaption.SetAttribute("style", "text-align:right;display:block;");

					if (!String.IsNullOrWhiteSpace(data.Link)) {
						IHtmlElement a = compileHelper.CreateHtmlElement("a");
						a.SetAttribute("href", data.Link);
						a.Content = data.FooterText;

						if (!String.IsNullOrWhiteSpace(data.LinkTarget)) {
							a.SetAttribute("target", data.LinkTarget);
						}

						figcaption.AppendChild(a);
						figure.AppendChild(figcaption);
					}
					else {
						figcaption.Content = data.FooterText;
						figure.AppendChild(figcaption);
					}
				}
			}
			catch {
			}

			return compileHelper.Compile(figure);
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
