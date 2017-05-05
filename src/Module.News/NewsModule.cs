using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.News.Properties;

namespace WebsiteBuilder.Modules.News {

    [PluginInfo("News", SupportsMultiSectionLayout = false)]
    public class NewsModule : IModule {
        
        private readonly IPluginHelper _PluginHelper;

        public NewsModule(IPluginHelper pluginHelper) {
            _PluginHelper = pluginHelper;
        }

        public String Compile(String source, ICompileHelper compileHelper) {

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
                        element.AppendChild(CreateNewsItem(enumerator.Current, compileHelper, editor, data.LargeItemsMaxHeight, data.ExpanderText));
                    }
                }
                
                IHtmlElement ul = compileHelper.CreateHtmlElement("ul");
                element.AppendChild(ul);
                
                while (enumerator.MoveNext()) {
                    IHtmlElement li = compileHelper.CreateHtmlElement("li");
                    ul.AppendChild(li);

                    String url = CompileNewsSubPage(enumerator.Current, compileHelper, editor);

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

        private IHtmlElement CreateNewsItem(NewsItem item, ICompileHelper compileHelper, IEditor editor, int maxHeight = 0, String expanderText = "") {
            IHtmlElement element = compileHelper.CreateHtmlElement("article");
            element.AppendChild(CreateTimeElement(item.Created, compileHelper));

            IHtmlElement inner = compileHelper.CreateHtmlElement("div");
            inner.SetAttribute("class", "inner");
            element.AppendChild(inner);

            IHtmlElement h1 = compileHelper.CreateHtmlElement("h1");
            inner.AppendChild(h1);
            h1.Content = item.Title;

            IHtmlElement p = compileHelper.CreateHtmlElement("p");
            inner.AppendChild(p);
            p.Content = editor.Compile(item.Data);

            if (maxHeight > 0) {
                inner.SetAttribute("style", "max-height:" + maxHeight + "px");

                IHtmlElement a = compileHelper.CreateHtmlElement("a");
                element.AppendChild(a);

                a.Content = expanderText;
                a.SetAttribute("href", "javascript:void(0);");
                a.SetAttribute("class", "expander");
            }

            return element;
        }

        private String CompileNewsSubPage(NewsItem item, ICompileHelper compileHelper, IEditor editor) {
            IHtmlElement element = compileHelper.CreateHtmlElement("div");
            element.SetAttribute("class", "module-news");
            element.AppendChild(CreateNewsItem(item, compileHelper, editor));

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

    }
}
