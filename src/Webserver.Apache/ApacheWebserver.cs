using System;
using System.IO;
using System.Text;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Webserver.Apache {

	[PluginInfo("Apache", Author = "tech-nik89")]
	public class ApacheWebserver : IWebserver {

		private const String HtAccessFileName = ".htaccess";

		private const String RewriteEngineOn = "RewriteEngine On";
		private const String RewriteCondFormat = "RewriteCond %{{HTTP:Accept-Language}} ^{0} [NC]";
		private const String RewriteRuleFormat = "RewriteRule ^$ %{{REQUEST_URI}}{0}/{1} [L,R=301]";

		private readonly IPluginHelper _PluginHelper;

		private readonly StringBuilder _File;

		private readonly String _Path;

		public ApacheWebserver(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
			if (!_PluginHelper.OutputDirectory.Exists) {
				throw new DirectoryNotFoundException(String.Format("The output directory {0} could not be found.", _PluginHelper.OutputDirectory.FullName));
			}

			_Path = Path.Combine(_PluginHelper.OutputDirectory.FullName, HtAccessFileName);
			_File = new StringBuilder();
		}

		public void CreateLanguageRedirect(String[] languages, String startPageUrl) {
			_File.AppendLine(RewriteEngineOn);

			foreach (String language in languages) {
				_File.AppendFormat(RewriteCondFormat, language);
				_File.AppendLine();
				_File.AppendFormat(RewriteRuleFormat, language, startPageUrl ?? String.Empty);
				_File.AppendLine();
			}

			if (languages.Length > 0) {
				// the default language fallback
				_File.AppendFormat(RewriteRuleFormat, languages[0], startPageUrl ?? String.Empty);
				_File.AppendLine();
			}
		}

		public void CreateSSLRedirect() {
			_File.AppendLine(@"RewriteCond %{HTTPS} off");
			_File.AppendLine(@"RewriteRule .* https://%{HTTP_HOST}%{REQUEST_URI} [L,R=301]");
			_File.AppendLine(@"RewriteCond %{HTTP_HOST} !^www\. [NC]");
			_File.AppendLine(@"RewriteRule .* https://www.%{HTTP_HOST}%{REQUEST_URI} [L,R=301]");
		}

		public void Complete() {
			File.WriteAllText(_Path, _File.ToString());
		}
	}
}
