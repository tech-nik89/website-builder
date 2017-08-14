using Microsoft.Ajax.Utilities;
using WebsiteStudio.Interface.Compiling;

namespace WebsiteStudio.Core.Tools {
	class MicrosoftMinifier : ICompiler {

		public enum Mode {
			CSS,
			JavaScript
		}

		private readonly Minifier _Minifier;

		private readonly Mode _Mode;

		public MicrosoftMinifier(Mode mode) {
			_Minifier = new Minifier();
			_Mode = mode;
		}

		public string Compile(string source) {
			switch(_Mode) {
				case Mode.CSS:
					return _Minifier.MinifyStyleSheet(source);
				case Mode.JavaScript:
					return _Minifier.MinifyJavaScript(source);
			}

			return null;
		}

	}
}
