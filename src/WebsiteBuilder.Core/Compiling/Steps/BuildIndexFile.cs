using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using WebsiteBuilder.Core.Properties;

namespace WebsiteBuilder.Core.Compiling.Steps {
    class BuildIndexFile : ICompilerStep {

        private readonly Project _Project;

        private readonly String _Path;

        public String Output { get; private set; }

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
                script.Append(Compiler.CreateUrl(_Project.StartPage));
                script.Append("\"");
            }

            script.Append(");");

            file.AddScript(Resources.IndexPageScript);
            file.AddScript(script.ToString());

            file.Compile(_Path);
        }
    }
}
