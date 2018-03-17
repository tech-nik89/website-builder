using System.Linq;
using System.Text.RegularExpressions;

namespace WebsiteStudio.Core.Validation {
	public class GroupValidator : ValidatorBase<Security.Group> {

		private static readonly Regex NameCharRegex = new Regex("^[a-zA-Z0-9]+$", RegexOptions.Compiled);

		public bool Name => NameCharRegex.IsMatch(Object.Name);

		public bool Duplicate => _Mode == Mode.Edit || !_Project.Groups.Any(x => x.Name.Equals(Object.Name, System.StringComparison.CurrentCultureIgnoreCase));

		public override bool Valid => Name;

		private readonly Project _Project;
		private readonly Mode _Mode;

		public GroupValidator(Security.Group group, Project project, Mode mode)
			: base(group) {

			_Project = project;
			_Mode = mode;
		}

		public enum Mode {
			Add,
			Edit
		}
	}
}
