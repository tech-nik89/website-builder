using FluentFTP;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Publish.FTP {

	[PluginInfo("FTP")]
	public class PublishFTP : IPublish {

		private IPluginHelper _PluginHelper;

		private const String RemotePathSeparator = "/";

		public PublishFTP(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public IUserInterface GetUserInterface() {
			return new SettingsControl(_PluginHelper);
		}

		public async Task RunAsync(String outputhPath, String data) {
			await Task.Run(() => {
				Run(outputhPath, data);
			});
		}

		public void Run(String outputhPath, String data) {
			try {
				Settings settings = Settings.Deserialize(data);
				DirectoryInfo directory = new DirectoryInfo(outputhPath);

				if (!directory.Exists) {
					return;
				}

				using (FtpClient client = new FtpClient(settings.Host, settings.Port, settings.UserName, settings.Password)) {
					try {
						client.RetryAttempts = 3;
						client.Connect();
						ProcessDirectory(directory, client, directory);
					}
					finally {
						client.Disconnect();
					}
				}
			}
			catch {

			}
		}

		private void ProcessDirectory(DirectoryInfo rootDirectory, FtpClient client, DirectoryInfo currentDirectory) {
			String remoteDirectoryPath = GetRemotePath(rootDirectory, currentDirectory);

			FileInfo[] localFiles = currentDirectory.GetFiles();
			DirectoryInfo[] localDirectories = currentDirectory.GetDirectories();
			FtpListItem[] remoteItems = client.GetListing(remoteDirectoryPath);

			Tasks tasks = Tasks.Determine(
				localFiles,
				remoteItems.Where(x => x.Type == FtpFileSystemObjectType.File),
				localDirectories,
				remoteItems.Where(x => x.Type == FtpFileSystemObjectType.Directory));

			foreach (FileInfo file in tasks.FilesToUpload) {
				String remotePath = GetRemotePath(rootDirectory, file);
				client.UploadFile(file.FullName, remotePath);
			}

			foreach (FtpListItem file in tasks.FilesToDelete) {
				client.DeleteFile(file.FullName);
			}

			foreach (FtpListItem directory in tasks.DirectoriesToDelete) {
				client.DeleteDirectory(directory.FullName);
			}

			foreach (DirectoryInfo directory in tasks.DirectoriesToProcess) {
				String remotePath = GetRemotePath(rootDirectory, directory);

				if (!client.DirectoryExists(remotePath)) {
					client.CreateDirectory(remotePath);
				}

				ProcessDirectory(rootDirectory, client, directory);
			}
		}

		private static String GetRemotePath(DirectoryInfo rootDirectory, DirectoryInfo directory) {
			return GetRemotePath(rootDirectory, directory.FullName);
		}

		private static String GetRemotePath(DirectoryInfo rootDirectory, FileInfo file) {
			return GetRemotePath(rootDirectory, file.FullName);
		}

		private static String GetRemotePath(DirectoryInfo rootDirectory, String path) {
			path = path.Substring(rootDirectory.FullName.Length);
			path = path.Replace(Path.DirectorySeparatorChar.ToString(), RemotePathSeparator);

			if (!path.StartsWith(RemotePathSeparator)) {
				path = RemotePathSeparator + path;
			}

			return path;
		}
	}
}
