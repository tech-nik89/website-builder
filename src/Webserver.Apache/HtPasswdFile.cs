using System;
using System.IO;
using WebsiteStudio.Interface.Compiling.Security;

namespace WebsiteStudio.Webserver.Apache {
	class HtPasswdFile : FileBase {

		private const String HtPasswdFileName = ".htpasswd";

		public HtPasswdFile(String directoryPath)
			: base(Path.Combine(directoryPath, HtPasswdFileName)) {
		}

		public void AddUser(IUser user) {
			AddUser(user.Name, user.Password);
		}

		public void AddUser(String userName, String password) {
			_Content.Append(userName);
			_Content.Append(":");
			_Content.Append(password);
			_Content.AppendLine();
		}

	}
}
