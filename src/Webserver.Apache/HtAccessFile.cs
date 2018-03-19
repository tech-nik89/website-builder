using System;
using System.IO;
using System.Text;

namespace WebsiteStudio.Webserver.Apache {
	class HtAccessFile : FileBase {

		private const String HtAccessFileName = ".htaccess";

		private bool _RewriteEngineOn;
		
		public HtAccessFile(String directoryPath)
			: base (Path.Combine(directoryPath, HtAccessFileName)) {
			
			_RewriteEngineOn = false;
		}

		private void TurnRewriteEngineOn() {
			if (_RewriteEngineOn) {
				return;
			}

			_Content.AppendLine("RewriteEngine On");
			_RewriteEngineOn = true;
		}

		public void CreateLanguageRedirect(String[] languages, String startPageUrl) {
			const String rule = "RewriteRule ^$ %{{REQUEST_URI}}{0}/{1} [L,R=301]";

			TurnRewriteEngineOn();

			foreach (String language in languages) {
				_Content.AppendFormat("RewriteCond %{{HTTP:Accept-Language}} ^{0} [NC]", language);
				_Content.AppendLine();
				_Content.AppendFormat(rule, language, startPageUrl ?? String.Empty);
				_Content.AppendLine();
			}

			if (languages.Length > 0) {
				// the default language fallback
				_Content.AppendFormat(rule, languages[0], startPageUrl ?? String.Empty);
				_Content.AppendLine();
			}
		}

		public void CreateSSLRedirect() {
			TurnRewriteEngineOn();

			_Content.AppendLine(@"RewriteCond %{HTTPS} off");
			_Content.AppendLine(@"RewriteRule .* https://%{HTTP_HOST}%{REQUEST_URI} [L,R=301]");
			_Content.AppendLine(@"RewriteCond %{HTTP_HOST} !^www\. [NC]");
			_Content.AppendLine(@"RewriteRule .* https://www.%{HTTP_HOST}%{REQUEST_URI} [L,R=301]");
		}

		public void RequireAuthentication(String passwdFilePath, String groupFilePath, String[] groups) {
			RequireAuthentication("Password required", passwdFilePath, groupFilePath, groups);
		}

		public void RequireAuthentication(String passwdFilePath) {
			RequireAuthentication("Password required", passwdFilePath, null, new String[0]);
		}

		public void RequireAuthentication(String message, String passwdFilePath, String groupFilePath, String[] groups) {
			_Content.AppendLine("AuthType Basic");

			_Content.AppendFormat("AuthName \"{0}\"", message);
			_Content.AppendLine();

			_Content.AppendFormat("AuthUserFile \"{0}\"", passwdFilePath);
			_Content.AppendLine();

			if (groups?.Length == 0 || String.IsNullOrWhiteSpace(groupFilePath)) {
				_Content.AppendLine("Require valid-user");
			}
			else {
				_Content.AppendFormat("AuthGroupFile \"{0}\"", groupFilePath);
				_Content.AppendLine();

				_Content.Append("Require group ");
				_Content.AppendLine(String.Join(" ", groups));
			}
		}
	}
}
