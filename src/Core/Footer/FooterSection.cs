using WebsiteBuilder.Core.Localization;

namespace WebsiteBuilder.Core.Footer {
	public class FooterSection {

		public LocalizedString Title { get; set; }

		public CustomCollection<FooterLink> Items { get; set; }

		private readonly Project _Project;

		internal FooterSection(Project project) {
			_Project = project;
			Title = new LocalizedString(_Project);
			Items = new CustomCollection<FooterLink>(_Project);
		}

	}
}
