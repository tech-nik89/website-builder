using WebsiteBuilder.Core.Tools;

namespace WebsiteBuilder.Core.Theming {
	public class ThemeStyleLess : ThemeStyle {

		public override string Css => Utilities.LessCompiler.Compile(Data);

		public ThemeStyleLess(string data, string name)
			: base (data, name) {
		}
	}
}
