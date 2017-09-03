using Octokit;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace WebsiteStudio.Updater {
	public class UpdateService {

		private readonly GitHubClient _Client;
		
		private const String UserName = "tech-nik89";
		private const String RepositoryName = "website-studio";
		
		private Version CurrentVersion {
			get => Assembly.GetExecutingAssembly().GetName().Version;
		}

		public UpdateService() {
			_Client = new GitHubClient(new ProductHeaderValue(RepositoryName));
		}
		
		public async Task<Update> IsUpdateAvailable() {
			try {
				Release release = await _Client.Repository.Release.GetLatest(UserName, RepositoryName);
				if (release == null) {
					return null;
				}

				Update update = Update.Create(release);
				if (update.Version <= CurrentVersion) {
					return null;
				}

				return update;
			}
			catch (NotFoundException) {
				return null;
			}
		}

	}
}
