using System;
using System.IO;
using System.Text;
using WebsiteBuilder.Core.Tools;
using WebsiteBuilder.Interface.Compiling;

namespace WebsiteBuilder.Core.Compiling {
    class CompileHelper : ICompileHelper {

        private readonly HtmlDocument _Document;

        private readonly FileInfo _File;
        
        public CompileHelper(HtmlDocument document, FileInfo file) {
            _Document = document;
            _File = file;
        }

        public String Compile(IHtmlElement element) {
            StringBuilder builder = new StringBuilder();

            using (TextWriter writer = new StringWriter(builder)) {
                element.Compile(writer);
            }

            return builder.ToString();
        }
        
        public void CreateCssFile(String css) {
            String fileName = String.Concat(Guid.NewGuid().ToString(), ".css");
            String path = Path.Combine(_File.Directory.FullName, fileName);

            css = Utilities.CssMinifier.Compile(css);
            File.WriteAllText(path, css);

            _Document.AddStyleLink(fileName);
        }

        public void CreateLessFile(String less) {
            String css = Utilities.LessCompiler.Compile(less);
            CreateCssFile(css);
        }

        public String GetFilePath(String targetFileName) {
            String path = Path.Combine(_File.Directory.FullName, targetFileName);
            return path;
        }

        public void CreateJavaScriptFile(String javaScript) {
            CreateJavaScriptFile(javaScript, false);
        }

        public void CreateJavaScriptFile(String javaScript, bool runAfterLoad) {
            String fileName = String.Concat(Guid.NewGuid().ToString(), ".js");
            String path = Path.Combine(_File.Directory.FullName, fileName);

            javaScript = Utilities.JavaScriptMinifier.Compile(javaScript);
            File.WriteAllText(path, javaScript);

            _Document.AddScriptLink(fileName, runAfterLoad);
        }

        public IHtmlElement CreateHtmlElement(String name) {
            return new HtmlElement(name);
        }

    }
}
