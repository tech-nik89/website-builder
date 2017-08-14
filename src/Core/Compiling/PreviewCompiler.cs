using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebsiteStudio.Core.Theming;

namespace WebsiteStudio.Core.Compiling {
	public class PreviewCompiler {

		private readonly Theme _Theme;

		private readonly SpriteGenerator _SpriteGenerator;
		
		public PreviewCompiler(XmlDocument theme) {
			_Theme = Theme.Load(theme);
			_SpriteGenerator = new SpriteGenerator(_Theme.Images, "", _Theme.Settings.ImageCssClass);
		}

		public async Task<String> RenderAsync() {
			return await Task.Run(() => {
				return Render();
			});
		}

		public String Render() {
			StringBuilder html = new StringBuilder();

			html.AppendLine("<!DOCTYPE html>");
			html.AppendLine("<html>");

			RenderHead(html);
			RenderBody(html);

			html.AppendLine("</html>");
			return html.ToString();
		}

		private void RenderBody(StringBuilder html) {
			html.AppendLine("<body>");

			String htmlBody = _Theme.TemplateBody;
			htmlBody = ReplaceVariable(htmlBody, "Title", RenderTitle());
			htmlBody = ReplaceVariable(htmlBody, "Languages", RenderLanguage());
			htmlBody = ReplaceVariable(htmlBody, "Navigation", RenderNavigation(0));
			htmlBody = ReplaceVariable(htmlBody, "Content", RenderContent());
			htmlBody = ReplaceVariable(htmlBody, "Footer", RenderFooter());
			html.Append(htmlBody);

			html.AppendLine("</body>");
		}

		private String RenderTitle() {
			return "The Title!";
		}

		private String RenderContent() {
			return "<p>The content goes here ...</p>";
		}

		private String RenderFooter() {
			StringBuilder html = new StringBuilder();

			html.AppendLine(RenderFooterSection("Links", "Github", "SourceForge", "xkcd"));
			html.AppendLine(RenderFooterSection("Social", "Facebook", "Twitter"));

			return html.ToString();
		}

		private String RenderFooterSection(String title, params String[] items) {
			StringBuilder html = new StringBuilder();

			foreach (String item in items) {
				html.AppendLine(RenderFooterItem(item));
			}

			String section = _Theme.TemplateFooterSection;
			section = ReplaceVariable(section, "Title", title);
			section = ReplaceVariable(section, "Items", html.ToString());
			return section;
		}

		private String RenderFooterItem(String item) {
			String html = _Theme.TemplateFooterItem;
			html = ReplaceVariable(html, "Target", "");
			html = ReplaceVariable(html, "Url", "#");
			html = ReplaceVariable(html, "Text", item);
			return html;
		}

		private String RenderNavigation(int level) {
			if (level > _Theme.Settings.MaxMenuDepth - 1 || level > ThemeSettings.MaxMenuDepthMaximum) {
				return String.Empty;
			}

			StringBuilder html = new StringBuilder();
			
			for(int i = 0; i < 3; i++) {
				html.AppendLine(RenderNavigationItem(level, i, RenderNavigation(level + 1)));
			}
			
			return ReplaceVariable(_Theme.TemplateNavItems, "Children", html.ToString());
		}

		private String RenderNavigationItem(int level, int index, String children = "") {
			const String text = "Nav-Item {0}/{1}";
			return RenderNavigationItem(String.Format(text, level, index), children);
		}

		private String RenderNavigationItem(String name, String children = "") {
			String html = _Theme.TemplateNavItem;
			html = ReplaceVariable(html, "Url", "#");
			html = ReplaceVariable(html, "Text", name);
			html = ReplaceVariable(html, "Children", children);
			return html;
		}

		private String RenderLanguage() {
			StringBuilder html = new StringBuilder();
			String[] languages = { "English", "Deutsch" };

			foreach (String language in languages) {
				String itemHtml = _Theme.TemplateLanguageItem;
				itemHtml = ReplaceVariable(itemHtml, "Url", "#");
				itemHtml = ReplaceVariable(itemHtml, "Text", language);
				html.Append(itemHtml);
			}

			return ReplaceVariable(_Theme.TemplateLanguageItems, "Items", html.ToString());
		}

		private void RenderHead(StringBuilder html) {
			html.AppendLine("<head>");

			html.AppendLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />");

			foreach (ThemeStyle style in _Theme.Styles) {
				html.AppendLine("<style type=\"text/css\">");
				html.Append(style.Css);
				html.AppendLine("</style>");
			}

			RenderSprites(html);

			if (_Theme.Fonts.Any()) {
				html.AppendLine("<style type=\"text/css\">");
				foreach (Font font in _Theme.Fonts) {
					RenderFont(font, html);
				}
				html.AppendLine("</style>");
			}
			
			html.AppendLine("</head>");
		}

		private void RenderSprites(StringBuilder html) {
			_SpriteGenerator.GenerateSprite();

			html.AppendLine("<style type=\"text/css\">");
			html.Append(_SpriteGenerator.CSS);
			html.AppendLine("</style>");
		}

		private void RenderFont(Font font, StringBuilder builder) {
			builder.AppendLine("@font-face {");

			builder.AppendFormat("font-family: '{0}';", Path.GetFileNameWithoutExtension(font.Name));
			builder.AppendLine();

			builder.AppendFormat("src: url(data:application/{1};charset=utf-8;base64,{0}) format('{1}');", Convert.ToBase64String(font.Data), font.Type);
			builder.AppendLine();

			builder.AppendLine("font-style: normal;");
			builder.AppendLine("font-weight: normal;");
			builder.AppendLine("}");
		}

		private static String ReplaceVariable(String source, String variable, String value) {
			return source.Replace(String.Format("@Model.{0}", variable), value);
		}
	}
}
