using WebsiteStudio.Core.Pages;

namespace WebsiteStudio.Core.Security {
	public class GroupCollection : CustomCollection<Group> {

		private readonly Project _Project;

		public GroupCollection(Project project)
			: base(project) {

			_Project = project;
		}

		public override void Remove(Group item) {
			base.Remove(item);

			foreach(Page page in _Project.AllPages) {
				page.AllowedGroups.Remove(item);
			}
		}

	}
}
