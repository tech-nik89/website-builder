﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebsiteBuilder.Core.Tools;
using WebsiteBuilder.Interface.Compiling;

namespace WebsiteBuilder.Core.Compiling {
    class CompileHelper : ICompileHelper {

        private readonly HtmlDocument _Document;

        private readonly FileInfo _File;
        
        private Func<String, String, String> _CreateSubPage;

        public CompileHelper(HtmlDocument document, FileInfo file, Func<String, String, String> createSubPage) {
            _Document = document;
            _File = file;
            _CreateSubPage = createSubPage;
        }

        public String Compile(IHtmlElement element) {
            StringBuilder builder = new StringBuilder();

            using (TextWriter writer = new StringWriter(builder)) {
                element.Compile(writer);
            }

            return builder.ToString();
        }
        
        public void CreateCssFile(String css) {
            String fileName = String.Concat(Utilities.NewGuid(), ".css");
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
            String fileName = String.Concat(Utilities.NewGuid(), ".js");
            String path = Path.Combine(_File.Directory.FullName, fileName);

            javaScript = Utilities.JavaScriptMinifier.Compile(javaScript);
            File.WriteAllText(path, javaScript);

            _Document.AddScriptLink(fileName, runAfterLoad);
        }

        public IHtmlElement CreateHtmlElement(String name) {
            return new HtmlElement(name);
        }

        public String CreateSubPage(String pathName, String content) {
            return _CreateSubPage(pathName, content);
        }

    }
}
