using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace WebsiteBuilder.Core.Compiling.Steps {
    class BuildIndexFile : ICompilerStep {

        private readonly Project _Project;

        private readonly String _Path;

        public String Output { get; private set; }

        private const String LanguageRedirectScript = @"
            var WebsiteBuilder = WebsiteBuilder || {};

            WebsiteBuilder.LanguageRedirect = function (supportedLanguages, startPage) {
                supportedLanguages = supportedLanguages || [];

                var language = navigator.language || navigator.userLanguage;
                var index = supportedLanguages.indexOf(language);

                if (index == -1) return;

                var file = 'index.html';
                var url = location.href;
                var fileIndex = url.lastIndexOf(file);

                if (fileIndex > -1) url = url.substr(0, fileIndex);

                if (url.indexOf('/', url.length - 1) === -1) url += '/';

                url += language;
                if (startPage) {
                    url += '/' + startPage;
                }

                location.href = url;
            }";

        public BuildIndexFile(Project project) {
            _Project = project;

            _Path = Path.Combine(_Project.OutputPath, Project.FileIndex);
            Output = String.Format("Building index file: {0}", _Path);
        }

        public void Run() {
            var file = new HtmlDocument();
            var languages = _Project.Languages.Select(l => l.Id).ToArray();

            var script = new StringBuilder();
            script.Append("WebsiteBuilder.LanguageRedirect(");
            script.Append(JsonConvert.SerializeObject(languages));

            if (_Project.StartPage != null) {
                script.Append(", \"");
                script.Append(Compiler.CreateUrl(_Project.StartPage, 0));
                script.Append("\"");
            }

            script.Append(");");

            file.AddScript(LanguageRedirectScript);
            file.AddScript(script.ToString());

            file.Compile(_Path);
        }
    }
}
