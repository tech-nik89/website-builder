using System;
using System.Collections.Generic;
using System.IO;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Webserver.Apache {

	[PluginInfo("Apache", Author = "tech-nik89")]
	public class ApacheWebserver : IWebserver {
		
		private readonly IPluginHelper _PluginHelper;
		private readonly Dictionary<String, HtAccessFile> _Files;

		private readonly HtAccessFile _RootFile;
		
		public ApacheWebserver(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
			if (!_PluginHelper.OutputDirectory.Exists) {
				throw new DirectoryNotFoundException(String.Format("The output directory {0} could not be found.", _PluginHelper.OutputDirectory.FullName));
			}

			String rootFilePath = _PluginHelper.OutputDirectory.FullName.ToLower();
			_RootFile = new HtAccessFile(rootFilePath);

			_Files = new Dictionary<String, HtAccessFile>();
			_Files.Add(rootFilePath, _RootFile);
		}

		public void CreateLanguageRedirect(String[] languages, String startPageUrl) {
			_RootFile.CreateLanguageRedirect(languages, startPageUrl);
		}

		public void CreateSSLRedirect() {
			_RootFile.CreateSSLRedirect();
		}
		
		private HtAccessFile GetFile(String directoryPath) {
			directoryPath = directoryPath.ToLower();
			HtAccessFile htAccessFile;

			if (!_Files.TryGetValue(directoryPath, out htAccessFile)) {
				htAccessFile = new HtAccessFile(directoryPath);
				_Files.Add(directoryPath, htAccessFile);
			}

			return htAccessFile;
		}

		public void Complete() {
			foreach(var file in _Files) {
				file.Value.Write();
			}
		}
	}
}
