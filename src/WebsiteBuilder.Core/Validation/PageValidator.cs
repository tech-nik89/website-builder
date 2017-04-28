using System;
using System.Linq;
using System.Text.RegularExpressions;
using WebsiteBuilder.Core.Pages;

namespace WebsiteBuilder.Core.Validation {
    public class PageValidator : ValidatorBase<Page> {

        private static readonly Regex PathNameRegex = new Regex("^[a-z]+$", RegexOptions.Compiled);

        public override bool Valid
            => PathName
            && Title
            && Layout;

        public bool PathName => PathNameRegex.IsMatch(Object.PathName);

        public bool Title
            => Object.Title != null
            && !Object.Project.Languages.Any(x => String.IsNullOrWhiteSpace(Object.Title.Get(x.Id)));

        public bool Layout => Object.Layout != null;

        public PageValidator(Page page)
            : base(page) {
        }

    }
}
