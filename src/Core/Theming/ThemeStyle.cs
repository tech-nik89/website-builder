using System;

namespace WebsiteStudio.Core.Theming {
	public abstract class ThemeStyle {

		public String Data { get; private set; }

		public String Name { get; private set; }

		public abstract String Css { get; }

		public enum Types {
			Css,
			Less
		}

		public ThemeStyle(String data, String name) {
			Data = data;
			Name = name;
		}
	}
}
