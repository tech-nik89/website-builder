using Octokit;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WebsiteStudio.Updater {
	public class Update {

		private Update() {
		}

		public String Name { get; private set; }

		public Version Version { get; private set; }

		public String ReleaseNotes { get; private set; }

		public Uri DownloadURL { get; private set; }

		public int FileSize { get; private set; }

		public String FileName { get; private set; }

		internal static Update Create(Release release) {
			Update update = new Update();

			update.Name = release.TagName;
			update.Version = new Version(release.TagName);
			update.ReleaseNotes = release.Body;

			if (release.Assets.Count == 1) {
				ReleaseAsset asset = release.Assets[0];
				update.DownloadURL = new Uri(asset.BrowserDownloadUrl);
				update.FileSize = asset.Size;
				update.FileName = asset.Name;
			}

			return update;
		}

		public async Task<String> Download() {
			return await Download(null);
		}

		public async Task<String> Download(IProgress<int> progress) {
			WebClient client = new WebClient();
			String path = Path.Combine(Path.GetTempPath(), FileName);

			client.DownloadProgressChanged += (sender, e) => {
				progress?.Report(e.ProgressPercentage);
			};

			try {
				await client.DownloadFileTaskAsync(DownloadURL, path);
			}
			catch {
				return null;
			}

			return path;
		}
	}
}