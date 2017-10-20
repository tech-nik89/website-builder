using System;
using System.Linq;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Core.Compiling.Steps {
	class WebserverStep : ICompilerStep {

		public String Output { get; private set; }

		private readonly IWebserver _Webserver;
		private readonly Project _Project;
		
		public WebserverStep(Project project) {
			_Project = project;

			if (_Project?.Webserver != null) {
				_Webserver = PluginManager.LoadWebserver(_Project.Webserver, _Project);
				Output = String.Format("Applying webserver specifics: {0}", _Project.Webserver.Name);
			}
		}

		public void Run() {
			if (_Project == null || _Webserver == null) {
				return;
			}

			if (_Project.StartPage != null) {
				String url = Compiler.CreateUrl(_Project.StartPage);
				String[] languages = _Project.Languages.Select(x => x.Id).ToArray();
				_Webserver.CreateLanguageRedirect(languages, url);
			}

			if (_Project.SSLRedirect) {
				_Webserver.CreateSSLRedirect();
			}
			
			_Webserver.Complete();
		}
	}
}
