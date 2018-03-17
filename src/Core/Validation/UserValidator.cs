using System;
using System.Linq;
using System.Text.RegularExpressions;
using WebsiteStudio.Core.Security;

namespace WebsiteStudio.Core.Validation {
	public class UserValidator : ValidatorBase<User> {

		private static readonly Regex NameCharRegex = new Regex("^[a-zA-Z0-9]+$", RegexOptions.Compiled);

		public bool Name => !String.IsNullOrWhiteSpace(Object.Name);

		public bool InvalidCharacters => NameCharRegex.IsMatch(Object.Name);

		public bool Duplicate => _Mode == Mode.Edit || !_Project.Users.Any(x => x.Name.Equals(Object.Name, StringComparison.CurrentCultureIgnoreCase));

		public override bool Valid 
			=> Name
			&& InvalidCharacters
			&& Duplicate;

		private readonly Project _Project;
		private readonly Mode _Mode;

		public UserValidator(User user, Project project, Mode mode)
			: base(user) {

			_Project = project;
			_Mode = mode;
		}

		public enum Mode {
			Add,
			Edit
		}
	}
}
