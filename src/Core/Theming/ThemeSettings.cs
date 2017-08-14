using System;

namespace WebsiteStudio.Core.Theming {
	public class ThemeSettings {

		public String ImageCssClass { get; internal set; }

		public int MaxMenuDepth { get; internal set; }

		public const int MaxMenuDepthMinimum = 1;

		public const int MaxMenuDepthMaximum = 25;

	}
}
