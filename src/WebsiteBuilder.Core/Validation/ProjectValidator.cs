using System.IO;

namespace WebsiteBuilder.Core.Validation {
    public class ProjectValidator : ValidatorBase<Project> {

        public override bool Valid
            => OutputPath
            && ThemePath
            && Languages;

        public bool OutputPath => Directory.Exists(Object.OutputPath);

        public bool ThemePath => File.Exists(Object.ThemePath);

        public bool Languages => Object.Languages != null && Object.Languages.Length > 0;

        public ProjectValidator(Project project)
            : base(project) {
        }

    }
}
