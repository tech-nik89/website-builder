using System;
using System.IO;
using System.Text;

namespace WebsiteStudio.Webserver.Apache {
	class HtAccessFile {

		private const String HtAccessFileName = ".htaccess";

		private readonly FileInfo _File;
		private readonly StringBuilder _Content;

		private bool _RewriteEngineOn;
		
		public HtAccessFile(String directoryPath) {
			String path = Path.Combine(directoryPath, HtAccessFileName);
			_File = new FileInfo(path);
			_Content = new StringBuilder();
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
		
		public void Write() {
			if (_Content.Length == 0) {
				return;
			}

			File.WriteAllText(_File.FullName, _Content.ToString());
		}
	}
}
