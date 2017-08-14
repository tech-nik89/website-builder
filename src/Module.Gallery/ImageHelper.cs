using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WebsiteStudio.Modules.Gallery {
	static class ImageHelper {

		public static Image ResizeImageToSquare(Image image, int size) {
			Bitmap targetImage = new Bitmap(size, size);
			int x = 0;
			int y = 0;

			using (Graphics graphics = Graphics.FromImage(targetImage))
			using (Image resizedImage = ResizeImage(image, size, size, true, false)) {
				
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
			return ResizeImage(image, size.Width, size.Height, true, false);
		}

		public static Image ResizeImage(Image image, Size size, bool crop) {
			return ResizeImage(image, size.Width, size.Height, true, crop);
		}

		public static Image ResizeImage(Image image, int width, int height, bool preserveRatio, bool crop) {

			if (image.Width < width || image.Height < height) {
				return image;
			}

			int imageWidth = width;
			int imageHeight = height;
			int x = 0;
			int y = 0;

			if (preserveRatio) {
				Double ratio = (Double)image.Width / (Double)image.Height;

				if (image.Width > image.Height) {
					imageWidth = width;
					imageHeight = (int)(width / ratio);
				}
				else {
					imageWidth = (int)(height * ratio);
					imageHeight = height;
				}
			}

			if (crop) {
				if (imageHeight < height) {
					Double dbl = ((Double)height - (Double)imageHeight) / (Double)height;
					x = (height - imageHeight) / -2;
					imageHeight = height;
					imageWidth = (int)(width + width * dbl);
				}
				else {
					Double dbl = ((Double)width - (Double)imageWidth) / (Double)width;
					y = (width - imageWidth) / -2;
					imageWidth = width;
					imageHeight = (int)(height + height * dbl);
				}
			}

			Rectangle destRect = new Rectangle(x, y, imageWidth, imageHeight);
			Bitmap destImage = preserveRatio && crop
				? new Bitmap(width, height)
				: new Bitmap(imageWidth, imageHeight);

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
