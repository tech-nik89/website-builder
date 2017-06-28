using System;
using System.IO;
using System.Text;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Webserver.Apache {

	[PluginInfo("Apache", Author = "tech-nik89")]
	public class ApacheWebserver : IWebserver {

		private const String HtAccessFileName = ".htaccess";

		private const String RewriteEngineOn = "RewriteEngine On";
		private const String RewriteCondFormat = "RewriteCond %{{HTTP:Accept-Language}} ^{0} [NC]";
		private const String RewriteRuleFormat = "RewriteRule ^$ %{{REQUEST_URI}}{0}/{1} [L,R=301]";

		private readonly IPluginHelper _PluginHelper;

		public ApacheWebserver(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public void CreateLanguageRedirect(String[] languages, String outputDirectoryPath, String startPageUrl) {
			StringBuilder file = new StringBuilder();

			file.AppendLine(RewriteEngineOn);

			foreach (String language in languages) {
				file.AppendFormat(RewriteCondFormat, language);
				file.AppendLine();
				file.AppendFormat(RewriteRuleFormat, language, startPageUrl ?? String.Empty);
				file.AppendLine();
			}

			if (languages.Length > 0) {
				// the default language fallback
				file.AppendFormat(RewriteRuleFormat, languages[0], startPageUrl ?? String.Empty);
			}

			String path = Path.Combine(outputDirectoryPath, HtAccessFileName);
			File.WriteAllText(path, file.ToString());
		}

	}
}
