using System;
using System.Text;
using System.Xml;
using WebsiteBuilder.Core.Tools;

namespace ThemeEditor {
	class PreviewRenderer {

		private readonly ThemeDocument _Theme;

		public PreviewRenderer(ThemeDocument theme) {
			_Theme = theme;
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

			String htmlBody = _Theme.Body.InnerXml;
			htmlBody = ReplaceVariable(htmlBody, "Title", RenderTitle());
			htmlBody = ReplaceVariable(htmlBody, "Languages", RenderLanguage());
			htmlBody = ReplaceVariable(htmlBody, "Navigation", RenderNavigation());
			htmlBody = ReplaceVariable(htmlBody, "Content", RenderContent());
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
			return "<p>The footer goes here ...</p>";
		}

		private String RenderNavigation() {
			StringBuilder html = new StringBuilder();
			StringBuilder gallery = new StringBuilder();

			gallery.AppendLine(RenderNavigationItem("Pictures"));
			gallery.AppendLine(RenderNavigationItem("Images"));
			gallery.AppendLine(RenderNavigationItem("Photos"));

			html.AppendLine(RenderNavigationItem("News"));
			html.AppendLine(RenderNavigationItem("About"));
			html.AppendLine(RenderNavigationItem("Downloads"));
			html.AppendLine(RenderNavigationItem("Gallery", ReplaceVariable(_Theme.NavItems.InnerXml, "Children", gallery.ToString())));

			return ReplaceVariable(_Theme.NavItems.InnerXml, "Children", html.ToString());
		}

		private String RenderNavigationItem(String name, String children = "") {
			String html = _Theme.NavItem.InnerXml;
			html = ReplaceVariable(html, "Url", "#");
			html = ReplaceVariable(html, "Text", name);
			html = ReplaceVariable(html, "Children", children);
			return html;
		}

		private String RenderLanguage() {
			StringBuilder html = new StringBuilder();
			String[] languages = { "English", "Deutsch" };

			foreach (String language in languages) {
				String itemHtml = _Theme.LanguageItem.InnerXml;
				itemHtml = ReplaceVariable(itemHtml, "Url", "#");
				itemHtml = ReplaceVariable(itemHtml, "Text", language);
				html.Append(itemHtml);
			}

			return ReplaceVariable(_Theme.LanguageItems.InnerXml, "Items", html.ToString());
		}

		private void RenderHead(StringBuilder html) {
			html.AppendLine("<head>");

			html.AppendLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />");

			foreach (XmlElement style in _Theme.Styles) {
				String type = style.Attributes["type"].Value;
				String css = style.InnerText;

				switch(type) {
					case "less":
						css = Utilities.LessCompiler.Compile(css);
						break;
				}

				html.AppendLine("<style type=\"text/css\">");
				html.Append(css);
				html.AppendLine("</style>");
			}

			html.AppendLine("</head>");
		}

		private static String ReplaceVariable(String source, String variable, String value) {
			return source.Replace(String.Format("@Model.{0}", variable), value);
		}
	}
}
