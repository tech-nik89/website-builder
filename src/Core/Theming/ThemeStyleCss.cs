using System;

namespace WebsiteStudio.Core.Theming {
	public class ThemeStyleCss : ThemeStyle {

		public override String Css => Data;
		
		public ThemeStyleCss(String data, String name)
			: base(data, name) {
		}
		
	}
}
