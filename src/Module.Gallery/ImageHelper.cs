using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WebsiteBuilder.Modules.Gallery {
	static class ImageHelper {

		public static Image ResizeImageToSquare(Image image, int size) {
			Bitmap targetImage = new Bitmap(size, size);
			int x = 0;
			int y = 0;

			using (Graphics graphics = Graphics.FromImage(targetImage))
			using (Image resizedImage = ResizeImage(image, size, size, true)) {
				
				if (resizedImage.Width > resizedImage.Height) {
					y = (size - resizedImage.Height) / 2;
				}
				else {
					x = (size - resizedImage.Width) / 2;
				}

				graphics.FillRectangle(Brushes.White, 0, 0, size, size);
				graphics.DrawImage(resizedImage, x, y);
			}

			return targetImage;
		}

		public static Image ResizeImage(Image image, Size size) {
			return ResizeImage(image, size.Width, size.Height, true);
		}

		public static Image ResizeImage(Image image, int width, int height, bool preserveRatio) {

			if (image.Width < width || image.Height < height) {
				return image;
			}

			int imageWidth = width;
			int imageHeight = height;

			if (preserveRatio) {
				Double dbl = (Double)image.Width / (Double)image.Height;

				if (image.Width > image.Height) {
					imageWidth = width;
					imageHeight = (int)(width / dbl);
				}
				else {
					imageWidth = (int)(height * dbl);
					imageHeight = height;
				}
			}

			Rectangle destRect = new Rectangle(0, 0, imageWidth, imageHeight);
			Bitmap destImage = new Bitmap(imageWidth, imageHeight);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (Graphics graphics = Graphics.FromImage(destImage)) {
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes()) {
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}

	}
}
