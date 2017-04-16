using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Plugins;
using WebsiteBuilder.Core.Theming;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Core.Compiling.Steps {
    class BuildPageStep : ICompilerStep {

        private readonly Page _Page;

        private readonly Language _Language;

        private readonly Theme _Theme;

        private readonly DirectoryInfo _OutputDirectory;

        private readonly IReadOnlyCollection<String> _StyleSheetFiles;
        
        private readonly FileInfo _File;

        public String Output { get; private set; }

        public BuildPageStep(Language language, Page page, Theme theme, DirectoryInfo outputDirectory, IReadOnlyCollection<String> styleSheetFiles) {
            _Language = language;
            _Page = page;
            _Theme = theme;
            _OutputDirectory = outputDirectory;
            _StyleSheetFiles = styleSheetFiles;

            _File = GetFileInfo();
            Output = String.Format("Building page: {0}", _File.FullName);
        }

        public void Run() {
            _File.Directory.Create();

            HtmlDocument htmlFile = new HtmlDocument();
            CompileHelper helper = new CompileHelper(htmlFile, _File);

            int level = GetLevel();
            String path = CreatePath();

            Layout layout = _Page.Layout;
            String[] sections = new String[layout.SectionCount];

            for(int i = 0; i < layout.SectionCount; i++) {
                PageContent content = _Page[i];
                if (content == null) {
                    continue;
                }

                IModule module = PluginManager.LoadModule(content, _Page.Project);
                String data = content.LoadData(_Language);

                if (module == null || String.IsNullOrWhiteSpace(data)) {
                    continue;
                }

                sections[i] = ResolveUrls(module.Compile(data, helper), _Page.Project, level);
            }

            htmlFile.Body = RenderTemplate(_Theme.TemplateBody, new {
                Content = RenderTemplate(layout.Template, new { Content = sections }),
                Navigation = RenderNavigation(_Language, level),
                Title = _Page.Title.Get(_Language),
				Languages = RenderLanguageSwitcher(level),
                Path = path
            });

            foreach (String fileName in _StyleSheetFiles) {
                var sheetPath = GetRelativePath(String.Concat(Compiler.MetaDirectoryName, "/", fileName), level);
                htmlFile.AddStyleLink(sheetPath);
            }

            htmlFile.AddStyle(GenerateFontsCSS(_Theme.Fonts, level));

            htmlFile.Compile(_File.FullName);
        }

        private static String GenerateFontsCSS(IEnumerable<Font> fonts, int level) {
            StringBuilder builder = new StringBuilder();

            foreach (Font font in fonts) {
                String path = GetRelativePath(String.Concat(Compiler.MetaDirectoryName, "/", font.Name), level);
                String name = Path.GetFileNameWithoutExtension(font.Name);

                builder.AppendLine("@font-face {");

                builder.AppendFormat("font-family: '{0}';", name);
                builder.AppendLine();

                builder.AppendFormat("src: url('{0}') format('{1}');", path, font.Type);
                builder.AppendLine();

                builder.AppendLine("font-style: normal;");
                builder.AppendLine("font-weight: normal;");
                builder.AppendLine("}");
            }

            return builder.ToString();
        }

		private String RenderLanguageSwitcher(int pageLevel) {
			if (_Page.Project.Languages.Length > 1) {
				return String.Empty;
			}

			StringBuilder builder = new StringBuilder();
			foreach (Language language in _Page.Project.Languages) {
				builder.Append(RenderTemplate(_Theme.TemplateLanguageItem, new {
					Url = Compiler.CreateUrl(_Page, pageLevel, language),
					Text = language.Description
				}));
			}

			return RenderTemplate(_Theme.TemplateLanguageItems, new { Items = builder.ToString() });
		}

        private int GetLevel() {
            int level = 0;

            Page parent = _Page.Parent as Page;
            while (parent != null) {
                level++;
                parent = parent.Parent as Page;
            }

            return level;
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

            Page parent = _Page.Parent as Page;
            while (parent != null) {
                parts.Insert(0, parent.PathName);
                parent = parent.Parent as Page;
            }

            parts.Insert(0, _Language.Id);
            parts.Insert(0, _OutputDirectory.FullName);

            parts.Add(String.Format("{0}.{1}", _Page.PathName, Compiler.FileExtensionHtml));

            var path = Path.Combine(parts.ToArray());
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

            foreach (var page in pages) {
                builder.Append(RenderTemplate(_Theme.TemplateNavItem, new {
                    Text = page.Title.Get(language),
                    Url = Compiler.CreateUrl(page, pageLevel),
                    Children = RenderNavigation(language, page.Pages, pageLevel)
                }));
            }

            return RenderTemplate(_Theme.TemplateNavItems, new { Children = builder.ToString() });
        }

		private static String ResolveUrls(String html, Project project, int level) {
			html = CompilerConstants.MediaLinkRegex.Replace(html, match => {

                String id = match.Groups[1].Value;
                var media = project.Media.SingleOrDefault(m => m.Id == id);

				if (media == null) {
					return String.Empty;
				}

				String path = String.Concat(Compiler.MediaDirectoryName, "/", media.Id, Path.GetExtension(media.Name));
				return GetRelativePath(path, level);
			});

            html = CompilerConstants.PageLinkRegex.Replace(html, match => {

                String id = match.Groups[1].Value;
                var page = project.AllPages.SingleOrDefault(p => p.Id == id);

                if (page == null) {
                    return String.Empty;
                }

                return Compiler.CreateUrl(page, level);
            });

			return html;
		}
    }
}
