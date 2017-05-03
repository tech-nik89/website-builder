using System;
using System.Text;
using System.Text.RegularExpressions;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.News {

    [PluginInfo("News")]
    public class NewsModule : IModule {

        private const Int32 _LargeItemsCount = 3;

        private readonly IPluginHelper _PluginHelper;

        public NewsModule(IPluginHelper pluginHelper) {
            _PluginHelper = pluginHelper;
        }

        public String Compile(String source, ICompileHelper compileHelper) {

            IEditor editor = _PluginHelper.CreateEditor();

            try {
                NewsData data = NewsData.Deserialize(source);

                IHtmlElement element = compileHelper.CreateHtmlElement("div");
                element.SetAttribute("class", "module-news");

                var enumerator = data.GetEnumerator();
                
                for(Int32 i = 0; i < _LargeItemsCount; i++) {
                    if (enumerator.MoveNext()) {
                        element.AppendChild(CreateNewsItem(enumerator.Current, compileHelper, editor));
                    }
                }
                
                IHtmlElement ul = compileHelper.CreateHtmlElement("ul");
                element.AppendChild(ul);
                    
                while (enumerator.MoveNext()) {
                    IHtmlElement li = compileHelper.CreateHtmlElement("li");
                    ul.AppendChild(li);

                    String url = CompileNewsPage(enumerator.Current, compileHelper, editor);

                    IHtmlElement a = compileHelper.CreateHtmlElement("a");
                    a.Content = enumerator.Current.Title;
                    a.SetAttribute("href", url);
                    li.AppendChild(a);
                }
                
                return compileHelper.Compile(element);
            }
            catch {
                return String.Empty;
            }
        }

        private IHtmlElement CreateNewsItem(NewsItem item, ICompileHelper compileHelper, IEditor editor) {
            IHtmlElement element = compileHelper.CreateHtmlElement("div");
            element.SetAttribute("class", "module-news");

            IHtmlElement h1 = compileHelper.CreateHtmlElement("h1");
            element.AppendChild(h1);
            h1.Content = item.Title;

            IHtmlElement p = compileHelper.CreateHtmlElement("p");
            element.AppendChild(p);
            p.Content = editor.Compile(item.Data);

            return element;
        }

        private String CompileNewsPage(NewsItem item, ICompileHelper compileHelper, IEditor editor) {
            IHtmlElement element = CreateNewsItem(item, compileHelper, editor);

            String pathName = GetNewsPagePath(item);
            return compileHelper.CreateSubPage(pathName, compileHelper.Compile(element));
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
