using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebsiteStudio.Core.Compiling.Links;
using WebsiteStudio.Core.Extensions;
using WebsiteStudio.Core.Footer;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Media;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Core.Theming;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Core.Compiling.Steps {
	class BuildPageStep : ICompilerStep {

		private readonly Page _Page;

		private readonly Language _Language;

		private readonly Theme _Theme;

		private readonly DirectoryInfo _OutputDirectory;

		private readonly IReadOnlyCollection<String> _StyleSheetFiles;

		private readonly FileInfo _File;

		private readonly int _Level;

		public String Output { get; private set; }

		private CompileHelper _CompileHelper;

		public BuildPageStep(Language language, Page page, Theme theme, DirectoryInfo outputDirectory, IReadOnlyCollection<String> styleSheetFiles) {
			_Language = language;
			_Page = page;
			_Theme = theme;
			_OutputDirectory = outputDirectory;
			_StyleSheetFiles = styleSheetFiles;
			_Level = page.Level;

			_File = GetFileInfo();
			Output = String.Format("Building page: {0}", _File.FullName);
		}

		public void Run() {
			_File.Directory.Create();

			HtmlDocument htmlFile = new HtmlDocument();
			htmlFile.Title = _Page.Title.Get(_Language);
			_CompileHelper = new CompileHelper(htmlFile, _File, CreateSubPage);

			AddMeta(htmlFile);

			String path = CreatePath();

			String[] pageContent = new String[_Page.ContentCount];

			for(int i = 0; i < _Page.ContentCount; i++) {
				PageContent content = _Page[i];
				if (content == null) {
					continue;
				}

				IModule module = PluginManager.LoadModule(content, _Page.Project);
				String data = content.LoadData(_Language);

				if (module == null || String.IsNullOrWhiteSpace(data)) {
					continue;
				}

				_CompileHelper.ModuleType = content.ModuleType;
				pageContent[i] = ResolveUrls(module.Compile(data, _CompileHelper), _Level);
			}

			htmlFile.Body = RenderTemplate(_Theme.TemplateBody, new {
				Content = String.Join(Environment.NewLine, pageContent),
				Navigation = RenderNavigation(_Language, _Level),
				Title = htmlFile.Title,
				Languages = RenderLanguageSwitcher(),
				Footer = RenderFooter(),
				Path = path
			});

			AddStyles(htmlFile);
			AddScripts(htmlFile);

			htmlFile.Compile(_File.FullName);
		}

		private void AddMeta(HtmlDocument document) {

			// Redirect
			if (_Page.LinkType == PageLinkType.Redirect && !String.IsNullOrWhiteSpace(_Page.LinkTarget)) {
				document.AddMetaTagHttpEquiv("refresh", String.Format("0;URL={0}", ResolveUrls(_Page.LinkTarget, _Level)));
			}

			// Favicon
			if (_Page.Project.Favicon?.Length > 0) {
				String faviconPath = GetRelativePath(String.Concat(Compiler.MetaDirectoryName, "/", BuildImagesStep.FileFavicon), _Level);
				document.AddFaviconTag(faviconPath);
			}

			// Description
			String description = _Page.MetaDescription.Get(_Language);
			if (!String.IsNullOrWhiteSpace(description)) {
				// Use page description
				document.AddMetaTag("description", description);
			}
			else {
				// Use project description
				description = _Page.Project.MetaDescription.Get(_Language);
				if (!String.IsNullOrWhiteSpace(description)) {
					document.AddMetaTag("description", description);
				}
			}

			// Keywords
			String[] keywords = _Page.MetaKeywords.Get(_Language);
			if (keywords != null && keywords.Length > 0) {
				// Use page keywords
				document.AddMetaTag("keywords", String.Join(", ", keywords));
			}
			else {
				// Use project keywords
				keywords = _Page.Project.MetaKeywords.Get(_Language);
				if (keywords != null && keywords.Length > 0) {
					document.AddMetaTag("keywords", String.Join(", ", keywords));
				}
			}

			// Robots
			List<String> robots = new List<String>();

			if (_Page.RobotsNoIndex) {
				robots.Add("noindex");
			}

			if (_Page.RobotsNoFollow) {
				robots.Add("nofollow");
			}

			if (robots.Any()) {
				document.AddMetaTag("robots", String.Join(",", robots));
			}
		}

		private String CreateSubPage(String pathName, String content) {
			HtmlDocument htmlFile = new HtmlDocument();
			String path = CreatePath();

			htmlFile.Body = RenderTemplate(_Theme.TemplateBody, new {
				Content = content,
				Navigation = RenderNavigation(_Language, _Level),
				Title = _Page.Title.Get(_Language),
				Languages = RenderLanguageSwitcher(),
				Footer = RenderFooter(),
				Path = path
			});

			AddStyles(htmlFile);
			AddScripts(htmlFile);

			String fileName = pathName + "." + Compiler.FileExtensionHtml;
			String filePath = Path.Combine(_File.DirectoryName, fileName);
			htmlFile.Compile(filePath);
			
			return fileName;
		}

		private void AddStyles(HtmlDocument htmlFile) {
			foreach (String fileName in _StyleSheetFiles) {
				var sheetPath = GetRelativePath(String.Concat(Compiler.MetaDirectoryName, "/", fileName), _Level);
				htmlFile.AddStyleLink(sheetPath);
			}

			foreach (StyleLink link in _CompileHelper.StyleLinks) {
				htmlFile.AddStyleLink(link.FileName);
			}

			htmlFile.AddStyle(GenerateFontsCSS(_Theme.Fonts, _Level));
		}

		private void AddScripts(HtmlDocument htmlFile) {
			foreach (ScriptLink link in _CompileHelper.ScriptLinks) {
				htmlFile.AddScriptLink(link);
			}
		}

		private String RenderFooter() {
			StringBuilder builder = new StringBuilder();

			foreach(FooterSection section in _Page.Project.Footer) {
				RenderFooterSection(section, builder);
			}

			return builder.ToString();
		}

		private void RenderFooterSection(FooterSection section, StringBuilder builder) {
			String str = RenderTemplate(_Theme.TemplateFooterSection, new {
				Title = section.Title.Get(_Language),
				Items = RenderFooterItems(section)
			});

			builder.Append(str);
		}

		private String RenderFooterItems(FooterSection section) {
			StringBuilder builder = new StringBuilder();

			foreach(FooterLink link in section.Items) {
				builder.Append(RenderTemplate(_Theme.TemplateFooterItem, new {
					Url = GetFooterLinkUrl(link),
					Text = link.Text.Get(_Language),
					Target = link.Target
				}));
			}

			return builder.ToString();
		}

		private String GetFooterLinkUrl(FooterLink link) {
			switch(link.Type) {
				case FooterLinkType.External:
					return link.Data;
				case FooterLinkType.Internal:
					Page page = _Page.Project.AllPages.SingleOrDefault(x => x.Id == link.Data);
					return Compiler.CreateUrl(page, _Page);
				case FooterLinkType.Media:
					MediaItem media = _Page.Project.Media.SingleOrDefault(x => x.Id == link.Data);
					return GetMediaUrl(media, _Level);
			}

			return null;
		}

		private static String GenerateFontsCSS(IEnumerable<Font> fonts, int level) {
			StringBuilder builder = new StringBuilder();

			foreach (Font font in fonts) {
				String path = GetRelativePath(String.Concat(Compiler.MetaDirectoryName, "/", font.Name), level);
				String name = Path.GetFileNameWithoutExtension(font.Name);

				builder.StartSelector("@font-face");

				builder.AppendProperty("font-family", "'{0}'", name);
				builder.AppendLine();

				builder.AppendProperty("src", "url('{0}') format('{1}')", path, font.Type);
				builder.AppendLine();

				builder.AppendProperty("font-style", "normal");
				builder.AppendProperty("font-weight", "normal");

				builder.EndSelector();
			}

			return builder.ToString();
		}

		private String RenderLanguageSwitcher() {
			if (_Page.Project.Languages.Length < 1) {
				return String.Empty;
			}

			StringBuilder builder = new StringBuilder();
			foreach (Language language in _Page.Project.Languages) {
				builder.Append(RenderTemplate(_Theme.TemplateLanguageItem, new {
					Url = Compiler.CreateUrl(_Page, language),
					Text = language.Description
				}));
			}

			return RenderTemplate(_Theme.TemplateLanguageItems, new { Items = builder.ToString() });
		}

		private String CreatePath() {
			List<String> path = new List<String>();
			Page parent = _Page as Page;

			while (parent != null) {
				if (!String.IsNullOrWhiteSpace(parent.Title.Get(_Language))) {
					path.Insert(0, parent.Title.Get(_Language));
				}

				parent = parent.Parent as Page;
			}

			return String.Join(" / ", path);
		}

		private FileInfo GetFileInfo() {
			var parts = new List<String>();

			if (_Page.Project.UglyURLs) {
				Page parent = _Page.Parent as Page;

				while (parent != null) {
					parts.Insert(0, parent.PathName);
					parent = parent.Parent as Page;
				}

				parts.Insert(0, _Language.Id);
				parts.Insert(0, _OutputDirectory.FullName);

				parts.Add(String.Format("{0}.{1}", _Page.PathName, Compiler.FileExtensionHtml));
			}
			else {
				Page parent = _Page as Page;

				while (parent != null) {
					parts.Insert(0, parent.PathName);
					parent = parent.Parent as Page;
				}

				parts.Insert(0, _Language.Id);
				parts.Insert(0, _OutputDirectory.FullName);

				parts.Add(Project.FileIndex);
			}

			String path = Path.Combine(parts.ToArray());
			return new FileInfo(path);
		}

		private static String RenderTemplate(String template, object model) {
			foreach (var property in model.GetType().GetProperties()) {
				if (property.PropertyType.IsArray) {
					object[] value = (object[])property.GetValue(model);
					for(int i = 0; i < value.Length; i++) {
						ReplaceTemplateValue(ref template, String.Format("{0}[{1}]", property.Name, i), value[i]);
					}
				}
				else {
					ReplaceTemplateValue(ref template, property.Name, property.GetValue(model));
				}
			}

			return template;
		}

		private static void ReplaceTemplateValue(ref String template, String propertyName, object value) {
			String strValue = value != null ? value.ToString() : String.Empty;
			template = template.Replace(String.Format("@Model.{0}", propertyName), strValue);
		}

		private static String GetRelativePath(String path, int level) {
			StringBuilder builder = new StringBuilder();

			for (int i = 0; i <= level; i++) {
				builder.Append("../");
			}

			builder.Append(path);
			return builder.ToString();
		}

		private String RenderNavigation(Language language, int pageLevel) {
			if (String.IsNullOrWhiteSpace(_Theme?.TemplateNavItem) || String.IsNullOrWhiteSpace(_Theme?.TemplateNavItems)) {
				return String.Empty;
			}

			return RenderNavigation(language, _Page.Project.Pages, pageLevel);
		}

		private String RenderNavigation(Language language, PageCollection pages, int pageLevel) {
			if (!pages.Any()) {
				return String.Empty;
			}

			StringBuilder builder = new StringBuilder();

			foreach (Page page in pages) {
				if (!page.IncludeInMenu || page.Disable || (_Theme.Settings.MaxMenuDepth > 0 && page.ParentCount > _Theme.Settings.MaxMenuDepth - 1)) {
					continue;
				}

				builder.Append(RenderTemplate(_Theme.TemplateNavItem, new {
					Text = page.Title.Get(language),
					Url = Compiler.CreateUrl(page, _Page),
					Children = RenderNavigation(language, page.Pages, pageLevel)
				}));
			}

			return RenderTemplate(_Theme.TemplateNavItems, new { Children = builder.ToString() });
		}
		
		private String ResolveUrls(String html, int level) {
			html = CompilerConstants.MediaLinkRegex.Replace(html, match => {

				String id = match.Groups[1].Value;
				MediaItem media = _Page.Project.Media.SingleOrDefault(m => m.Id == id);

				if (media == null) {
					return String.Empty;
				}

				return GetMediaUrl(media, level);
			});

			html = CompilerConstants.PageLinkRegex.Replace(html, match => {

				String id = match.Groups[1].Value;
				var targetPage = _Page.Project.AllPages.SingleOrDefault(p => p.Id == id);

				if (targetPage == null) {
					return String.Empty;
				}

				return Compiler.CreateUrl(targetPage, _Page);
			});

			return html;
		}

		private static String GetMediaUrl(MediaItem media, int level) {
			String path = String.Concat(Compiler.MediaDirectoryName, "/", media.Id, Path.GetExtension(media.Name));
			return GetRelativePath(path, level);
		}
	}
}
