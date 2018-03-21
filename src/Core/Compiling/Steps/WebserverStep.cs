using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Interface.Compiling.Security;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Core.Compiling.Steps {
	class WebserverStep : CompilerStep {
		
		private readonly IWebserver _Webserver;
		private readonly Project _Project;
		private readonly IEnumerable<PageSecurityInfo> _PageSecurityInfos;

		public WebserverStep(Project project, IEnumerable<PageSecurityInfo> pageSecurityInfos) {
			_Project = project;
			_PageSecurityInfos = pageSecurityInfos;

			if (_Project?.Webserver != null) {
				_Webserver = PluginManager.LoadWebserver(_Project.Webserver, _Project);
				Output = String.Format("Applying webserver specifics: {0}", _Project.Webserver.Name);
			}
		}

		public override void Run() {
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

			if (_Project.Users.Any() && _Project.Groups.Any() && _PageSecurityInfos.Any()) {
				_Webserver.CreateAuthentication(_Project.Groups, _Project.Users, _PageSecurityInfos);
			}
			
			_Webserver.Complete();
		}
	}
}
