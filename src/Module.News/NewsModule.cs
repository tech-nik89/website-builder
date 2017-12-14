using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.News.Properties;

namespace WebsiteStudio.Modules.News {

	[PluginInfo("News", Author = "tech-nik89")]
	public class NewsModule : IModule {
		
		private readonly IPluginHelper _PluginHelper;

		public NewsModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper compileHelper) {
			return Compile(source, compileHelper, false);
		}

		public String Compile(String source, ICompileHelper compileHelper, bool preview) {

			IEditor editor = _PluginHelper.CreateEditor();
			compileHelper.CreateLessFile(Resources.NewsStyles);
			compileHelper.CreateJavaScriptFile(Resources.NewsScript, true);

			try {
				NewsData data = NewsData.Deserialize(source);
				var items = data.OrderByDescending(x => x.Created);
				var enumerator = items.GetEnumerator();

				IHtmlElement element = compileHelper.CreateHtmlElement("div");
				element.SetAttribute("class", "module-news");
				
				for(Int32 i = 0; i < data.LargeItemsCount; i++) {
					if (enumerator.MoveNext()) {
						String url = CompileNewsSubPage(enumerator.Current, compileHelper, editor, data.ExpanderText);
						element.AppendChild(CreateNewsItem(enumerator.Current, compileHelper, editor, data.ExpanderText, true, url));
					}
				}
				
				IHtmlElement ul = compileHelper.CreateHtmlElement("ul");
				element.AppendChild(ul);

				while (enumerator.MoveNext()) {
					IHtmlElement li = compileHelper.CreateHtmlElement("li");
					ul.AppendChild(li);

					String url = CompileNewsSubPage(enumerator.Current, compileHelper, editor, data.ExpanderText);

					IHtmlElement a = compileHelper.CreateHtmlElement("a");
					a.Content = enumerator.Current.Title;
					a.SetAttribute("href", url);
					li.AppendChild(a);

					IHtmlElement author = compileHelper.CreateHtmlElement("span");
					author.SetAttribute("class", "author");
					author.Content = enumerator.Current.Author;
					li.AppendChild(author);

					li.AppendChild(CreateTimeElement(enumerator.Current.Created, compileHelper));
				}
				
				return compileHelper.Compile(element);
			}
			catch {
				return String.Empty;
			}
		}

		private IHtmlElement CreateNewsItem(NewsItem item, ICompileHelper compileHelper, IEditor editor, String expanderText, bool overview, String url = null) {
			IHtmlElement element = compileHelper.CreateHtmlElement("article");
			element.AppendChild(CreateTimeElement(item.Created, compileHelper));
			
			IHtmlElement h1 = compileHelper.CreateHtmlElement("h1");
			h1.Content = item.Title;

			if (overview && !String.IsNullOrWhiteSpace(url)) {
				IHtmlElement a = compileHelper.CreateHtmlElement("a");
				a.SetAttribute("href", url);
				element.AppendChild(a);
				a.AppendChild(h1);
			}
			else {
				element.AppendChild(h1);
			}

			IHtmlElement p = compileHelper.CreateHtmlElement("p");
			element.AppendChild(p);
			
			p.Content = editor.Compile(item.Data);
			if (overview) {
				p.Content = GetPreview(p.Content);

				if (!String.IsNullOrWhiteSpace(url)) {
					IHtmlElement a = compileHelper.CreateHtmlElement("a");
					a.Content = expanderText;
					a.SetAttribute("href", url);
					element.AppendChild(a);
				}
			}

			return element;
		}

		private static readonly Regex _PreviewRegex = new Regex("<p[^>]*>([^~]*?)<\\/p>", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);

		private static String GetPreview(String html) {
			MatchCollection matches = _PreviewRegex.Matches(html);

			if (matches.Count > 1 && matches[0].Groups.Count > 1) {
				return matches[1].Groups[1].Value;
			}

			return html;
		}

		private String CompileNewsSubPage(NewsItem item, ICompileHelper compileHelper, IEditor editor, String expanderText) {
			IHtmlElement element = compileHelper.CreateHtmlElement("div");
			element.SetAttribute("class", "module-news");
			element.AppendChild(CreateNewsItem(item, compileHelper, editor, expanderText, false));

			String pathName = GetNewsPagePath(item);
			return compileHelper.CreateSubPage(pathName, compileHelper.Compile(element));
		}

		private static IHtmlElement CreateTimeElement(DateTime date, ICompileHelper compileHelper) {
			IHtmlElement time = compileHelper.CreateHtmlElement("time");
			time.Content = date.ToShortDateString();
			time.SetAttribute("datetime", date.ToString("o"));
			return time;
		}

		private static String GetNewsPagePath(NewsItem item) {
			String title = item.Title.ToLower().Trim();

			title = Regex.Replace(title, @"[^0-9a-z ]+", "");
			title = Regex.Replace(title, @"\s+", " ");
			title = title.Replace(" ", "-");

			StringBuilder builder = new StringBuilder();

			builder.Append(item.Created.Year);
			builder.Append("-");
			builder.AppendFormat("{0:00}", item.Created.Month);
			builder.Append("-");
			builder.AppendFormat("{0:00}", item.Created.Day);
			builder.Append("-");
			builder.AppendFormat("{0:00}", title);
			builder.Append("-");
			builder.Append(item.Id);

			return builder.ToString();
		}

		public IUserInterface GetUserInterface() {
			return new NewsControl(_PluginHelper);
		}

		public String GetLicenseInformation() {
			return String.Empty;
		}
	}
}
