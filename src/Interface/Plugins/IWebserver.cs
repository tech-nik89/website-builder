using System;

namespace WebsiteStudio.Interface.Plugins {
	public interface IWebserver {

		void CreateLanguageRedirect(String[] languages, String outputDirectoryPath, String startPageUrl);

	}
}
