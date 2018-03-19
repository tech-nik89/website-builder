using System;
using System.IO;
using System.Text;

namespace WebsiteStudio.Webserver.Apache {
	abstract class FileBase {

		protected readonly FileInfo _File;
		protected readonly StringBuilder _Content;

		public String FilePath => _File.FullName;

		protected FileBase(String path) {
			_File = new FileInfo(path);
			_Content = new StringBuilder();
		}

		public void Write() {
			if (_Content.Length == 0) {
				return;
			}

			File.WriteAllText(_File.FullName, _Content.ToString());
		}

	}
}
