using FluentFTP;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Publish.FTP {

	[PluginInfo("FTP", Author = "tech-nik89")]
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

		public async Task RunAsync(String outputhPath, String data, IProgress<String> progress) {
			await Task.Run(() => {
				Run(outputhPath, data, progress);
			});
		}

		public void Run(String outputhPath, String data) {
			Run(outputhPath, data, null);
		}

		public void Run(String outputhPath, String data, IProgress<String> progress) {
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
						ProcessDirectory(directory, client, directory, progress);
					}
					finally {
						client.Disconnect();
					}
				}
			}
			catch {

			}
		}

		private void ProcessDirectory(DirectoryInfo rootDirectory, FtpClient client, DirectoryInfo currentDirectory, IProgress<String> progress) {
			String remoteDirectoryPath = GetRemotePath(rootDirectory, currentDirectory);
			progress?.Report("Processing directory " + remoteDirectoryPath);

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
				progress?.Report("Uploading file " + remotePath);
				client.UploadFile(file.FullName, remotePath);
				progress?.Report("Uploaded file " + remotePath);
			}

			foreach (FtpListItem file in tasks.FilesToDelete) {
				progress?.Report("Deleting file " + file.FullName);
				client.DeleteFile(file.FullName);
				progress?.Report("Deleted file " + file.FullName);
			}

			foreach (FtpListItem directory in tasks.DirectoriesToDelete) {
				progress?.Report("Deleting directory " + directory.FullName);
				client.DeleteDirectory(directory.FullName);
				progress?.Report("Deleted directory " + directory.FullName);
			}

			foreach (DirectoryInfo directory in tasks.DirectoriesToProcess) {
				String remotePath = GetRemotePath(rootDirectory, directory);

				if (!client.DirectoryExists(remotePath)) {
					progress?.Report("Creating directory " + directory.FullName);
					client.CreateDirectory(remotePath);
					progress?.Report("Created directory " + directory.FullName);
				}

				ProcessDirectory(rootDirectory, client, directory, progress);
			}

			progress?.Report("Processed directory " + remoteDirectoryPath);
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
