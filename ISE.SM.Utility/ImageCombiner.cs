using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace ISE.SM.Utility
{
    public static class ImageCombiner
    {
        private static readonly EncoderParameters encoderParameters = new EncoderParameters(1);

        private static readonly RectangleF sizeLocation1 = new RectangleF(0.0F, 0.0F, 400.0F, 400.0F);

        private static readonly RectangleF sizeLocation2 = new RectangleF(400.0F, 0.0F, 400.0F, 400.0F);

        private static readonly ImageCodecInfo jpgDecoder = ImageCodecInfo.GetImageDecoders().Single(codec => codec.FormatID == ImageFormat.Jpeg.Guid);

        private static readonly byte[] emptyImage = new byte[0];

        static ImageCombiner()
        {
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
        }
        public static System.Drawing.Bitmap CombineBitmap(List<Image> images)
        {
            //read all images into memory
          
            System.Drawing.Bitmap finalImage = null;

            try
            {
                int width = 0;
                int height = 0;

                foreach (Image image in images)
                {
                    //create a Bitmap from the file and add it to the list
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);

                    //update the size of the final bitmap
                    width += bitmap.Width;
                    height = bitmap.Height > height ? bitmap.Height : height;

                    images.Add(bitmap);
                }

                //create a bitmap to hold the combined image
                finalImage = new System.Drawing.Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(System.Drawing.Color.Black);

                    //go through each image and draw it on the final image
                    int offset = 0;
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        g.DrawImage(image,
                          new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }

        // Crops two squares out of two separate images
        // And then combines them into single image that's returned as byte[]
        public static Image CombineImages(Image image1,Image image2)
        {
            try
            {
                int width = image1.Width*2;
                int height = image1.Height;
                using (var ms = new MemoryStream())
                using (var bitmap = new Bitmap(width, height, image1.PixelFormat))
                using (var img1 = image1)
                using (var img2 = image2)
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(img1, sizeLocation1, GetCropParams(img1), GraphicsUnit.Pixel);
                    g.DrawImage(img2, sizeLocation2, GetCropParams(img2), GraphicsUnit.Pixel);
                    bitmap.Save(ms, jpgDecoder, encoderParameters);
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        private static RectangleF GetCropParams(Image img)
        {
            return img.Width > img.Height
                ? new RectangleF(
                        (img.Width / 2) - (img.Height / 2),
                        0.0F,
                        2 * (img.Height / 2),
                        img.Height)
                : new RectangleF(
                        0.0F,
                        (img.Height / 2) - (img.Width / 2),
                        img.Width,
                        2 * (img.Width / 2));
        }
    }
}
