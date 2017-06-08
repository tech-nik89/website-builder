using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WebsiteBuilder.Core.Compiling {
	class SpriteGenerator {

		private const String SpriteSelectorFormatDefault = ".img-{0}";

		private readonly IReadOnlyDictionary<String, Image> _Images;

		private readonly String _FileName;

		public Image Image { get; private set; }

		public String CSS { get; private set; }

		private readonly String _ImageCssClass;

		public SpriteGenerator(IReadOnlyDictionary<String, Image> images, String pngFileName)
			: this(images, pngFileName, SpriteSelectorFormatDefault) {
		}
		
		public SpriteGenerator(IReadOnlyDictionary<String, Image> images, String pngFileName, String imageCssClass) {
			_Images = images;
			_FileName = pngFileName;

			if (!String.IsNullOrWhiteSpace(imageCssClass) && imageCssClass.Contains("{0}")) {
				if (!imageCssClass.StartsWith(".")) {
					imageCssClass = "." + imageCssClass;
				}
				_ImageCssClass = imageCssClass;
			}
			else {
				_ImageCssClass = SpriteSelectorFormatDefault;
			}
		}

		public void GenerateSprite() {
			if (!_Images.Any()) {
				return;
			}

			int rows = (int)Math.Ceiling(Math.Sqrt(_Images.Count));
			Dictionary<String, Point> points = new Dictionary<String, Point>();
			
			int x = 0;
			int y = 0;
			int width = 0;
			int height = 0;
			int row = 0;

			foreach (var image in _Images) {
				if (width - x < image.Value.Width) {
					width = x + image.Value.Width;
				}

				if (height - y < image.Value.Height) {
					height = y + image.Value.Height;
				}

				points.Add(image.Key, new Point(x, y));
				y += image.Value.Height;
				row++;

				if (row > rows) {
					x = width;
					y = 0;
				}
			}

			DrawImage(height, width, points);
			WriteCSS(points);
		}

		private void WriteCSS(Dictionary<String, Point> points) {
			StringBuilder builder = new StringBuilder();

			String selectorAll = String.Join(",", points.Select(x => String.Format(_ImageCssClass, x.Key)));

			builder.StartSelector(selectorAll);
			builder.AppendProperty("background-repeat", "no-repeat");
			builder.AppendProperty("display", "inline-block");
			builder.AppendProperty("background-image", "url({0})", _FileName);
			builder.EndSelector();

			foreach (var point in points) {
				Image image = _Images[point.Key];
				
				builder.StartSelector(_ImageCssClass, point.Key);
				builder.AppendProperty("width", "{0}px;", image.Width);
				builder.AppendProperty("height", "{0}px", image.Height);
				builder.AppendProperty("background-position", "{0}px {1}px", -point.Value.X, -point.Value.Y);
				builder.EndSelector();
			}

			CSS = builder.ToString();
		}

		private void DrawImage(int height, int width, Dictionary<String, Point> points) {
			Image = new Bitmap(width, height);
			using (Graphics graphics = Graphics.FromImage(Image)) {
				foreach (var point in points) {
					Image img = _Images[point.Key];
					Rectangle rect = new Rectangle(point.Value, img.Size);
					graphics.DrawImage(_Images[point.Key], rect);
				}
			}
		}
	}

	static class StringBuilderCssExtensions {

		public static void AppendProperty(this StringBuilder sb, String property, String valueFormat, params object[] values) {
			AppendProperty(sb, property, String.Format(valueFormat, values));
		}

		public static void AppendProperty(this StringBuilder sb, String property, String value) {
			sb.Append(property);
			sb.Append(":");
			sb.Append(value);
			sb.Append(";");
		}

		public static void StartSelector(this StringBuilder sb, String selectorFormat, params object[] values) {
			StartSelector(sb, String.Format(selectorFormat, values));
		}

		public static void StartSelector(this StringBuilder sb, String selector) {
			sb.Append(selector);
			sb.Append("{");
		}

		public static void EndSelector(this StringBuilder sb) {
			sb.AppendLine("}");
		}
	}
}
