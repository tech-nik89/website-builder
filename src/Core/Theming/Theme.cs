using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;
using WebsiteBuilder.Core.Exceptions;

namespace WebsiteBuilder.Core.Theming {
	public class Theme {

		public const String FileExtension = ".wbtx";

		private const String AttributeType = "type";

		private const String AttributeName = "name";

		private const String AttributeTitle = "title";

		private const String AttributeClassName = "class";

		private const String AttributeSectionCount = "sections";

		private const String NodeRoot = "theme";

		private const String NodeStyle = "style";

		private const String NodeNavItems = "navItems";

		private const String NodeNavItem = "navItem";

		private const String NodeLanguageItems = "languageItems";

		private const String NodeLanguageItem = "languageItem";

		private const String NodeFooterItem = "footerItem";

		private const String NodeFooterSection = "footerSection";

		private const String NodeImage = "image";

		private const String NodeBody = "body";

		private const String NodeSettings = "settings";
		
		private const String NodeSettingsImageCssClass = "imageCssClass";

		private const String NodeSettingsMaxMenuDepth = "maxMenuDepth";

		private const String NodeFont = "font";

		private static readonly String QueryFonts = String.Concat("/", NodeRoot, "/", NodeFont);

		private static readonly String QueryStyles = String.Concat("/", NodeRoot, "/", NodeStyle);

		private static readonly String QueryImages = String.Concat("/", NodeRoot, "/", NodeImage);
		
		private static readonly String QueryNavItems = String.Concat("/", NodeRoot, "/", NodeNavItems);

		private static readonly String QueryNavItem = String.Concat("/", NodeRoot, "/", NodeNavItem);

		private static readonly String QueryLanguageItems = String.Concat("/", NodeRoot, "/", NodeLanguageItems);

		private static readonly String QueryLanguageItem = String.Concat("/", NodeRoot, "/", NodeLanguageItem);

		private static readonly String QueryFooterItem = String.Concat("/", NodeRoot, "/", NodeFooterItem);

		private static readonly String QueryFooterSection = String.Concat("/", NodeRoot, "/", NodeFooterSection);

		private static readonly String QueryBody = String.Concat("/", NodeRoot, "/", NodeBody);

		private static readonly String QuerySettings = String.Concat("/", NodeRoot, "/", NodeSettings);

		private static readonly String QuerySettingImageCssClass = String.Concat(QuerySettings, "/", NodeSettingsImageCssClass);

		private static readonly String QuerySettingMaxMenuDepth = String.Concat(QuerySettings, "/", NodeSettingsMaxMenuDepth);

		private const String FormatNoNameStyle = "style-{0}";

		private List<Font> _Fonts;

		private List<ThemeStyle> _Styles;

		private Dictionary<String, Image> _Images;
		
		public IEnumerable<ThemeStyle> Styles => _Styles.AsReadOnly();
		
		public IReadOnlyDictionary<String, Image> Images => _Images;

		public IEnumerable<Font> Fonts => _Fonts.AsReadOnly();

		public String TemplateNavItem { get; private set; }

		public String TemplateNavItems { get; private set; }

		public String TemplateLanguageItems { get; private set; }

		public String TemplateLanguageItem { get; private set; }

		public String TemplateBody { get; private set; }

		public String TemplateFooterItem { get; private set; }

		public String TemplateFooterSection { get; private set; }

		public ThemeSettings Settings { get; private set; }

		public String Description { get; private set; }

		internal Theme() {
			_Styles = new List<ThemeStyle>();
			_Images = new Dictionary<String, Image>();
			_Fonts = new List<Font>();
			Settings = new ThemeSettings();
		}

		public static Theme Load(String path) {
			FileInfo file = new FileInfo(path);
			Validate(file);

			XmlDocument document = new XmlDocument();
			document.Load(path);

			return Load(document);
		}

		public static Theme Load(XmlDocument document) {
			Theme theme = new Theme();
			
			LoadSettings(theme.Settings, document);
			LoadStyles(theme, document);
			LoadTemplates(theme, document);
			LoadImages(theme, document);
			LoadFonts(theme, document);

			return theme;
		}

		private static void LoadFonts(Theme theme, XmlDocument document) {
			var xFonts = document.SelectNodes(QueryFonts);

			foreach(XmlNode xFont in xFonts) {
				if (xFont.Attributes[AttributeName] == null
					|| String.IsNullOrWhiteSpace(xFont.Attributes[AttributeName].InnerText)
					|| xFont.Attributes[AttributeType] == null
					|| String.IsNullOrWhiteSpace(xFont.Attributes[AttributeType].InnerText)
					|| String.IsNullOrWhiteSpace(xFont.InnerText)) {
					continue;
				}

				try {
					Font font = new Font();
					font.Name = xFont.Attributes[AttributeName].InnerText.ToLower().Trim();
					font.Type = xFont.Attributes[AttributeType].InnerText.ToLower().Trim();
					font.Data = Convert.FromBase64String(xFont.InnerText.Trim());
					theme._Fonts.Add(font);
				}
				catch {
				}
			}
		}
		
		private static void LoadSettings(ThemeSettings settings, XmlDocument document) {
			settings.ImageCssClass = document.SelectSingleNode(QuerySettingImageCssClass)?.InnerText;
			settings.MaxMenuDepth = ParseInt(document.SelectSingleNode(QuerySettingMaxMenuDepth)?.InnerText);

			if (settings.MaxMenuDepth < ThemeSettings.MaxMenuDepthMinimum) {
				settings.MaxMenuDepth = ThemeSettings.MaxMenuDepthMinimum;
			}

			if (settings.MaxMenuDepth > ThemeSettings.MaxMenuDepthMaximum) {
				settings.MaxMenuDepth = ThemeSettings.MaxMenuDepthMaximum;
			}
		}

		private static void LoadImages(Theme theme, XmlDocument document) {
			var xImages = document.SelectNodes(QueryImages);

			foreach (XmlNode xImage in xImages) {
				String name = xImage.Attributes[AttributeName]?.InnerText;
				if (String.IsNullOrWhiteSpace(name)) {
					continue;
				}

				try {
					byte[] buffer = Convert.FromBase64String(xImage.InnerText.Trim());
					using (Stream stream = new MemoryStream(buffer)) {
						theme._Images[name] = Image.FromStream(stream);
					}
				}
				catch {
				}
			}
		}

		private static void LoadTemplates(Theme theme, XmlDocument document) {
			theme.TemplateBody = document.SelectSingleNode(QueryBody)?.InnerXml ?? String.Empty;
			theme.TemplateNavItems = document.SelectSingleNode(QueryNavItems)?.InnerXml ?? String.Empty;
			theme.TemplateNavItem = document.SelectSingleNode(QueryNavItem)?.InnerXml ?? String.Empty;
			theme.TemplateLanguageItems = document.SelectSingleNode(QueryLanguageItems)?.InnerXml ?? String.Empty;
			theme.TemplateLanguageItem = document.SelectSingleNode(QueryLanguageItem)?.InnerXml ?? String.Empty;
			theme.TemplateFooterItem = document.SelectSingleNode(QueryFooterItem)?.InnerXml ?? String.Empty;
			theme.TemplateFooterSection = document.SelectSingleNode(QueryFooterSection)?.InnerXml ?? String.Empty;
		}

		private static void LoadStyles(Theme theme, XmlDocument document) {
			var xStyles = document.SelectNodes(QueryStyles);
			int noNamecount = 0;

			foreach (XmlNode xStyle in xStyles) {
				var type = ThemeStyle.Types.Css;

				if (!Enum.TryParse(xStyle.Attributes[AttributeType]?.InnerText, true, out type)) {
					continue;
				}

				String name = xStyle.Attributes[AttributeName]?.InnerText ?? String.Format(FormatNoNameStyle, noNamecount++);

				switch (type) {
					case ThemeStyle.Types.Css:
						theme._Styles.Add(new ThemeStyleCss(xStyle.InnerText, name));
						break;
					case ThemeStyle.Types.Less:
						theme._Styles.Add(new ThemeStyleLess(xStyle.InnerText, name));
						break;
				}
			}
		}

		private static void Validate(FileInfo file) {
			if (!file.Exists) {
				throw new FileNotFoundException();
			}

			if (file.Extension != FileExtension) {
				throw new BadFileExtensionException();
			}
		}

		private static int ParseInt(String value) {
			int result = 0;

			if (String.IsNullOrWhiteSpace(value)) {
				return result;
			}

			int.TryParse(value, out result);
			return result;
		}
	}
}
