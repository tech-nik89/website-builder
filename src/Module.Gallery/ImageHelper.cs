using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WebsiteBuilder.Modules.Gallery {
    static class ImageHelper {

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
