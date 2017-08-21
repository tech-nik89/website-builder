using System;

namespace WebsiteStudio.Interface.Plugins {
	public interface IWebserver {

		void CreateLanguageRedirect(String[] languages, String startPageUrl);

		void CreateSSLRedirect();

		void Complete();

	}
}
