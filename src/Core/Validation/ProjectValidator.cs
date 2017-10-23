using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace WebsiteStudio.Core.Validation {
	public class ProjectValidator : ValidatorBase<Project> {

		public override bool Valid
			=> OutputPath
			&& ThemePath
			&& Languages
			&& Favicon;

		public bool OutputPath => Directory.Exists(Object.OutputPath);

		public bool ThemePath => File.Exists(Object.ThemePath);

		public bool Languages
			=> Object.Languages != null 
			&& Object.Languages.Length > 0
			&& Object.Languages.All(x => new LanguageValidator(x).Valid);

		private static readonly ImageCodecInfo[] _Codecs = ImageCodecInfo.GetImageDecoders();

		public bool Favicon {
			get {
				try {
					if (Object.Favicon == null || Object.Favicon.Length == 0) {
						return true;
					}

					using (MemoryStream stream = new MemoryStream(Object.Favicon)) {
						Image image = Image.FromStream(stream);
						ImageCodecInfo codec = _Codecs.FirstOrDefault(x => x.FormatID == image.RawFormat.Guid);
						if (codec == null) {
							return false;
						}

						return codec.MimeType == "image/x-icon";
					}
				}
				catch {
					return false;
				}
			}
		}

		public ProjectValidator(Project project)
			: base(project) {
		}

	}
}
