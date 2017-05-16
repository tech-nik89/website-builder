using System;
using System.Linq;
using System.Text.RegularExpressions;
using WebsiteBuilder.Core.Pages;

namespace WebsiteBuilder.Core.Validation {
    public class PageValidator : ValidatorBase<Page> {

        private static readonly Regex PathNameRegex = new Regex("^[a-z0-9]+$", RegexOptions.Compiled);

        private static readonly Regex PathNameCharRegex = new Regex("[a-z0-9\b]", RegexOptions.Compiled);

        private static readonly int[] AllowedKeys = { 8, 35, 36, 37, 39, 46};

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
