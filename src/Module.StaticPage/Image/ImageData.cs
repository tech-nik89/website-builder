using Newtonsoft.Json;
using System;

namespace WebsiteStudio.Modules.Image {
	class ImageData {

		public static readonly String[] SizeUnits = new String[] { "px", "pt", "em", "%" };

		public String Id { get; set; }

		public String AlternateText { get; set; }

		public int Width { get; set; }

		public int MaxWidth { get; set; }

		public int Height { get; set; }
		
		public int MaxHeight { get; set; }

		public String WidthUnit { get; set; }

		public String MaxWidthUnit { get; set; }

		public String HeightUnit { get; set; }

		public String MaxHeightUnit { get; set; }

		public StaticImageAlignment Alignment { get; set; }

		public String Link { get; set; }

		public String LinkTarget { get; set; }

		public String FooterText { get; set; }

		public ImageData() {
			WidthUnit = SizeUnits[0];
			MaxWidthUnit = SizeUnits[0];
			HeightUnit = SizeUnits[0];
			MaxHeightUnit = SizeUnits[0];
		}

		public static String Serialize(ImageData data) {
			return JsonConvert.SerializeObject(data);
		}

		public static ImageData Derserialize(String str) {
			ImageData data = new ImageData();

			if (String.IsNullOrWhiteSpace(str)) {
				return data;
			}

			try {
				data = JsonConvert.DeserializeObject<ImageData>(str);
			}
			catch {
			}

			return data;
		}

	}
}
