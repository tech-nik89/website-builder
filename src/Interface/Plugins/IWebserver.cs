using System;
using System.Collections.Generic;
using System.IO;
using WebsiteStudio.Interface.Compiling.Security;

namespace WebsiteStudio.Interface.Plugins {
	public interface IWebserver {

		void CreateLanguageRedirect(String[] languages, String startPageUrl);

		void CreateSSLRedirect();

		void CreateAuthentication(IEnumerable<IGroup> groups, IEnumerable<IUser> users, IEnumerable<PageSecurityInfo> pages);

		void Complete();

	}
}
