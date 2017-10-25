using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Publish.FTP.Properties;

namespace WebsiteStudio.Publish.FTP {

	[PluginInfo("FTP", Author = "tech-nik89")]
	public class PublishFTP : IPublish {

		private IPluginHelper _PluginHelper;

		private const String RemotePathSeparator = "/";

		private readonly List<CompilerMessage> _Messages;
		public IEnumerable<CompilerMessage> Messages => _Messages.AsReadOnly();
		
		public bool Error { get; private set; }

		public PublishFTP(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
			_Messages = new List<CompilerMessage>();
			Error = false;
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
			progress?.Report("------ Publishing started: FTP ------");

			try {
				progress?.Report("Reading publishing settings ...");
				Settings settings = Settings.Deserialize(data);
				progress?.Report(String.Format("Publishing to: {0}:{1}", settings.Host, settings.Port));
				
				if (String.IsNullOrWhiteSpace(settings.Password)) {
					progress?.Report("Password missing. Asking user for password.");

					AskUserPasswordForm form = new AskUserPasswordForm(settings.UserName);
					DialogResult result = form.ShowDialog();

					if (result != DialogResult.OK) {
						throw new Exception("User cancelled.");
					}

					settings.Password = form.Password;
				}

				DirectoryInfo directory = new DirectoryInfo(outputhPath);

				if (!directory.Exists) {
					throw new DirectoryNotFoundException(String.Format("The directory '{0}' could not be found.", outputhPath));
				}

				progress?.Report("Connecting ...");
				using (FtpClient client = new FtpClient(settings.Host, settings.Port, settings.UserName, settings.Password)) {
					try {
						client.RetryAttempts = 3;
						client.Connect();
						progress?.Report("Connected.");

						if (client.HashAlgorithms == FtpHashAlgorithm.NONE) {
							CompilerMessage message = new CompilerMessage("FTP server does not support the HASH command. File size is used instead.", CompilerMessageType.Warning);

							_Messages.Add(message);
							progress?.Report(message.Message);
						}

						ProcessDirectory(directory, client, directory, progress);
					}
					finally {
						client.Disconnect();
						progress?.Report("Connection closed.");
					}
				}
			}
			catch (Exception ex) {
				Error = true;
				_Messages.Add(new CompilerMessage(ex));
			}

			if (Error) {
				progress?.Report("========== Publishing failed ==========");
			}
			else {
				progress?.Report("========== Publishing succeeded ==========");
			}
		}

		private void ProcessDirectory(DirectoryInfo rootDirectory, FtpClient client, DirectoryInfo currentDirectory, IProgress<String> progress) {
			String remoteDirectoryPath = GetRemotePath(rootDirectory, currentDirectory);
			progress?.Report(String.Format("Processing directory: {0}", remoteDirectoryPath));

			FileInfo[] localFiles = currentDirectory.GetFiles();
			DirectoryInfo[] localDirectories = currentDirectory.GetDirectories();
			FtpListItem[] remoteItems = client.GetListing(remoteDirectoryPath);

			Tasks tasks = new Tasks(
				client,
				localFiles,
				remoteItems.Where(x => x.Type == FtpFileSystemObjectType.File),
				localDirectories,
				remoteItems.Where(x => x.Type == FtpFileSystemObjectType.Directory));

			foreach (FileInfo file in tasks.FilesToUpload) {
				String remotePath = GetRemotePath(rootDirectory, file);
				progress?.Report(String.Format("Uploading file: {0}", remotePath));
				client.UploadFile(file.FullName, remotePath);
				progress?.Report(String.Format("Uploading file completed: {0}", remotePath));
			}

			foreach (FtpListItem file in tasks.FilesToDelete) {
				progress?.Report(String.Format("Deleting file: {0}", file.FullName));
				client.DeleteFile(file.FullName);
				progress?.Report(String.Format("Deleting file completed: {0}", file.FullName));
			}

			foreach (FtpListItem directory in tasks.DirectoriesToDelete) {
				progress?.Report(String.Format("Deleting directory: {0}", directory.FullName));
				client.DeleteDirectory(directory.FullName);
				progress?.Report(String.Format("Deleting directory completed: {0}", directory.FullName));
			}

			foreach (DirectoryInfo directory in tasks.DirectoriesToProcess) {
				String remotePath = GetRemotePath(rootDirectory, directory);

				if (!client.DirectoryExists(remotePath)) {
					progress?.Report(String.Format("Creating directory: {0}", directory.FullName));
					client.CreateDirectory(remotePath);
					progress?.Report(String.Format("Creating directory completed: {0}", directory.FullName));
				}

				ProcessDirectory(rootDirectory, client, directory, progress);
			}

			progress?.Report(String.Format("Processing directory completed: {0}", remoteDirectoryPath));
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

		public String GetLicenseInformation() {
			return Resources.LicenseInfo;
		}
	}
}
