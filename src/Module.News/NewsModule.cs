using System;
using WebsiteBuilder.Interface.Compiling;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.News {
    public class NewsModule : IModule {

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

                IHtmlElement ul = compileHelper.CreateHtmlElement("ul");
                element.AppendChild(ul);

                foreach(NewsItem item in data) {
                    IHtmlElement li = compileHelper.CreateHtmlElement("li");
                    ul.AppendChild(li);

                    String url = CompileNewsPage(item, compileHelper, editor);

                    IHtmlElement a = compileHelper.CreateHtmlElement("a");
                    a.Content = item.Title;
                    a.SetAttribute("href", url);
                    li.AppendChild(a);
                }

                return compileHelper.Compile(element);
            }
            catch {
                return String.Empty;
            }
        }

        private String CompileNewsPage(NewsItem item, ICompileHelper compileHelper, IEditor editor) {
            IHtmlElement element = compileHelper.CreateHtmlElement("div");
            element.SetAttribute("class", "module-news");

            IHtmlElement h1 = compileHelper.CreateHtmlElement("h1");
            element.AppendChild(h1);
            h1.Content = item.Title;

            IHtmlElement p = compileHelper.CreateHtmlElement("p");
            element.AppendChild(p);
            p.Content = editor.Compile(item.Data);

            return compileHelper.CreateSubPage(item.Id, compileHelper.Compile(element));
        }

        public IUserInterface GetUserInterface() {
            return new NewsControl(_PluginHelper);
        }

    }
}
