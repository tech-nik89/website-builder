using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebsiteStudio.Core.Localization;

namespace WebsiteStudio.Core.Validation {
	public class LanguageValidator : ValidatorBase<Language> {

		private static readonly IEnumerable<CultureInfo> _All = CultureInfo.GetCultures(CultureTypes.AllCultures);

		public override bool Valid => Id;

		public bool Id => _All.Any(x => x.TwoLetterISOLanguageName == Object.Id);

		public LanguageValidator(Language obj)
			: base(obj) {
		}

	}
}
