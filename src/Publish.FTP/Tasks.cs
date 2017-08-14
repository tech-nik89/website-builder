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

		private Tasks() {
		}

		public static Tasks Determine(IEnumerable<FileInfo> localFiles, IEnumerable<FtpListItem> remoteFiles, IEnumerable<DirectoryInfo> localDirectories, IEnumerable<FtpListItem> remoteDirectories) {
			Tasks tasks = new Tasks();

			tasks.FilesToUpload = localFiles
				.Where(local => !ExistsAndIsEqual(local, remoteFiles))
				.ToArray();

			tasks.FilesToDelete = remoteFiles
				.Where(remote => !Exists(remote, localFiles))
				.ToArray();

			tasks.DirectoriesToProcess = localDirectories.ToArray();

			tasks.DirectoriesToDelete = remoteDirectories
				.Where(remote => !Exists(remote, localDirectories))
				.ToArray();

			return tasks;
		}

		private static bool Exists(FtpListItem local, IEnumerable<DirectoryInfo> remoteDirectories) {
			foreach (DirectoryInfo remote in remoteDirectories) {
				if (local.Name == remote.Name) {
					return true;
				}
			}

			return false;
		}

		private static bool Exists(DirectoryInfo local, IEnumerable<FtpListItem> remoteDirectories) {
			foreach(FtpListItem remote in remoteDirectories) {
				if (local.Name == remote.Name) {
					return true;
				}
			}

			return false;
		}

		private static bool Exists(FtpListItem remote, IEnumerable<FileInfo> localFiles) {
			foreach (FileInfo local in localFiles) {
				if (local.Name == remote.Name) {
					return true;
				}
			}

			return false;
		}

		private static bool ExistsAndIsEqual(FileInfo localFile, IEnumerable<FtpListItem> remoteFiles) {
			foreach (FtpListItem remote in remoteFiles) {
				if (remote.Name == localFile.Name) {
					return remote.Size == localFile.Length;
				}
			}

			return false;
		}
	}
}
