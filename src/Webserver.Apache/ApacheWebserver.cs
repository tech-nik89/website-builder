using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebsiteStudio.Interface.Compiling.Security;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Webserver.Apache {

	[PluginInfo("Apache", Author = "tech-nik89")]
	public class ApacheWebserver : IWebserver {
		
		private readonly IPluginHelper _PluginHelper;
		private readonly Dictionary<String, FileBase> _Files;

		private readonly HtAccessFile _RootFile;
		
		public ApacheWebserver(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
			if (!_PluginHelper.OutputDirectory.Exists) {
				throw new DirectoryNotFoundException(String.Format("The output directory {0} could not be found.", _PluginHelper.OutputDirectory.FullName));
			}

			String rootFilePath = _PluginHelper.OutputDirectory.FullName;
			_RootFile = new HtAccessFile(rootFilePath);

			_Files = new Dictionary<String, FileBase>();
			_Files.Add(_RootFile.FilePath, _RootFile);
		}

		public void CreateLanguageRedirect(String[] languages, String startPageUrl) {
			_RootFile.CreateLanguageRedirect(languages, startPageUrl);
		}

		public void CreateSSLRedirect() {
			_RootFile.CreateSSLRedirect();
		}

		public void CreateAuthentication(IEnumerable<IGroup> groups, IEnumerable<IUser> users, IEnumerable<PageSecurityInfo> pages) {
			String rootDirectory = _PluginHelper.OutputDirectory.FullName;
			HtPasswdFile passwdFile = new HtPasswdFile(rootDirectory);
			_Files.Add(passwdFile.FilePath, passwdFile);

			foreach(IUser user in users) {
				passwdFile.AddUser(user);
			}

			HtGroupFile groupFile = new HtGroupFile(rootDirectory);
			_Files.Add(groupFile.FilePath, groupFile);

			foreach(IGroup group in groups) {
				groupFile.AddGroup(group, users);
			}

			String serverLocalPasswdFilePath = _PluginHelper.GetRemoteFullPath(passwdFile.FilePath);
			String serverLocalGroupFilePath = _PluginHelper.GetRemoteFullPath(groupFile.FilePath);

			foreach (PageSecurityInfo page in pages) {
				HtAccessFile file = new HtAccessFile(page.Directory.FullName);
				if (_Files.ContainsKey(file.FilePath)) {
					file = (HtAccessFile)_Files[file.FilePath];
				}
				else {
					_Files.Add(file.FilePath, file);
				}

				file.RequireAuthentication(serverLocalPasswdFilePath, serverLocalGroupFilePath, page.Groups.Select(x => x.Name).ToArray());
			}
		}
		
		public void Complete() {
			foreach(var file in _Files) {
				file.Value.Write();
			}
		}
	}
}
