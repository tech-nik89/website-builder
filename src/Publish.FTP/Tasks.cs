using FluentFTP;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebsiteStudio.Publish.FTP {
	class Tasks {

		public FileInfo[] FilesToUpload { get; set; }

		public FtpListItem[] FilesToDelete { get; set; }

		public DirectoryInfo[] DirectoriesToProcess { get; set; }

		public FtpListItem[] DirectoriesToDelete { get; set; }

		private readonly FtpClient _Client;

		private readonly bool _HashCommandSupported;

		public Tasks(FtpClient client, IEnumerable<FileInfo> localFiles, IEnumerable<FtpListItem> remoteFiles, IEnumerable<DirectoryInfo> localDirectories, IEnumerable<FtpListItem> remoteDirectories) {
			_Client = client;
			_HashCommandSupported = _Client.HashAlgorithms != FtpHashAlgorithm.NONE;

			FilesToUpload = localFiles
				.Where(local => !ExistsAndIsEqual(local, remoteFiles))
				.ToArray();

			FilesToDelete = remoteFiles
				.Where(remote => !Exists(remote, localFiles))
				.ToArray();

			DirectoriesToProcess = localDirectories.ToArray();

			DirectoriesToDelete = remoteDirectories
				.Where(remote => !Exists(remote, localDirectories))
				.ToArray();
		}
		
		private bool Exists(FtpListItem local, IEnumerable<DirectoryInfo> remoteDirectories) {
			foreach (DirectoryInfo remote in remoteDirectories) {
				if (local.Name == remote.Name) {
					return true;
				}
			}

			return false;
		}

		private bool Exists(DirectoryInfo local, IEnumerable<FtpListItem> remoteDirectories) {
			foreach(FtpListItem remote in remoteDirectories) {
				if (local.Name == remote.Name) {
					return true;
				}
			}

			return false;
		}

		private bool Exists(FtpListItem remote, IEnumerable<FileInfo> localFiles) {
			foreach (FileInfo local in localFiles) {
				if (local.Name == remote.Name) {
					return true;
				}
			}

			return false;
		}

		private bool ExistsAndIsEqual(FileInfo localFile, IEnumerable<FtpListItem> remoteFiles) {
			foreach (FtpListItem remote in remoteFiles) {
				if (remote.Name != localFile.Name) {
					continue;
				}

				if (_HashCommandSupported) {
					FtpHash hash = _Client.GetHash(remote.FullName);
					return hash.IsValid && hash.Verify(localFile.FullName);
				}
				else {
					return remote.Size == localFile.Length;
				}
			}

			return false;
		}
	}
}
