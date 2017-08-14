using System;
using System.Linq;
using System.Text.RegularExpressions;
using WebsiteStudio.Core.Pages;

namespace WebsiteStudio.Core.Validation {
	public class PageValidator : ValidatorBase<Page> {

		private static readonly Regex PathNameRegex = new Regex("^[a-z0-9\\-]+$", RegexOptions.Compiled);

		private static readonly Regex PathNameCharRegex = new Regex("[a-z0-9\b\\-]", RegexOptions.Compiled);
		
		public override bool Valid
			=> PathName
			&& Title;

		public bool PathName => PathNameRegex.IsMatch(Object.PathName);

		public bool Title
			=> Object.Title != null
			&& !Object.Project.Languages.Any(x => String.IsNullOrWhiteSpace(Object.Title.Get(x.Id)));

		public PageValidator(Page page)
			: base(page) {
		}

		public static bool ValidatePathNameInput(String character) {
			return PathNameCharRegex.IsMatch(character);
		}
	}
}
