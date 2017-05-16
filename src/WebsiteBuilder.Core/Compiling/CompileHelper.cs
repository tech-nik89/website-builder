using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebsiteBuilder.Core.Compiling.Links;
using WebsiteBuilder.Core.Tools;
using WebsiteBuilder.Interface.Compiling;

namespace WebsiteBuilder.Core.Compiling {
    class CompileHelper : ICompileHelper {

        private readonly HtmlDocument _Document;

        private readonly FileInfo _File;
        
        private Func<String, String, String> _CreateSubPage;

        private readonly List<StyleLink> _StyleLinks;

        private readonly List<ScriptLink> _ScriptLinks;

        private readonly List<String> _PageStyleClasses;

        internal IReadOnlyList<StyleLink> StyleLinks => _StyleLinks.AsReadOnly();

        internal IReadOnlyList<ScriptLink> ScriptLinks => _ScriptLinks.AsReadOnly();

        internal IReadOnlyList<String> PageStyleClasses => _PageStyleClasses.AsReadOnly();

        private readonly Dictionary<Type, int> _ModuleCompilerFlags;

        public Type ModuleType { get; set; }

        public CompileHelper(HtmlDocument document, FileInfo file, Func<String, String, String> createSubPage) {
            _Document = document;
            _File = file;
            _CreateSubPage = createSubPage;
            _StyleLinks = new List<StyleLink>();
            _ScriptLinks = new List<ScriptLink>();
            _PageStyleClasses = new List<String>();
            _ModuleCompilerFlags = new Dictionary<Type, int>();
        }

        public String Compile(IHtmlElement element) {
            StringBuilder builder = new StringBuilder();

            using (TextWriter writer = new StringWriter(builder)) {
                element.Compile(writer);
            }

            return builder.ToString();
        }

        public void AddPageStyleClass(String className) {
            _PageStyleClasses.Add(className);
        }
        
        public void CreateCssFile(String css) {
            String fileName = String.Concat(Utilities.NewGuid(), ".css");
            String path = Path.Combine(_File.Directory.FullName, fileName);

            css = Utilities.CssMinifier.Compile(css);
            File.WriteAllText(path, css);
            
            _StyleLinks.Add(new StyleLink(fileName));
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
            
            _ScriptLinks.Add(new ScriptLink(fileName, runAfterLoad));
        }

        public IHtmlElement CreateHtmlElement(String name) {
            return new HtmlElement(name);
        }

        public String CreateSubPage(String pathName, String content) {
            return _CreateSubPage(pathName, content);
        }

        public void SetPageFlag(int flag, bool value) {
            if (ModuleType == null) {
                return;
            }
            
            if (!_ModuleCompilerFlags.ContainsKey(ModuleType)) {
                _ModuleCompilerFlags.Add(ModuleType, 0);
            }

            if (value) {
                _ModuleCompilerFlags[ModuleType] = (_ModuleCompilerFlags[ModuleType] | flag);
            }
            else {
                _ModuleCompilerFlags[ModuleType] = (_ModuleCompilerFlags[ModuleType] & (~flag));
            }
        }

        public bool HasPageFlag(int flag) {
            if (ModuleType == null) {
                return false;
            }
            
            if (!_ModuleCompilerFlags.ContainsKey(ModuleType)) {
                return false;
            }

            return (_ModuleCompilerFlags[ModuleType] & flag) != 0;
        }
    }
}
