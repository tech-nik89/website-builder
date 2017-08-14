using System.IO;
using System.Linq;

namespace WebsiteStudio.Core.Validation {
	public class ProjectValidator : ValidatorBase<Project> {

		public override bool Valid
			=> OutputPath
			&& ThemePath
			&& Languages;

		public bool OutputPath => Directory.Exists(Object.OutputPath);

		public bool ThemePath => File.Exists(Object.ThemePath);

		public bool Languages
			=> Object.Languages != null 
			&& Object.Languages.Length > 0
			&& Object.Languages.All(x => new LanguageValidator(x).Valid);

		public ProjectValidator(Project project)
			: base(project) {
		}

	}
}
