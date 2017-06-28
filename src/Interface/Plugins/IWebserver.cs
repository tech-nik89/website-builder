using System;

namespace WebsiteBuilder.Interface.Plugins {
	public interface IWebserver {

		void CreateLanguageRedirect(String[] languages, String outputDirectoryPath, String startPageUrl);

	}
}
