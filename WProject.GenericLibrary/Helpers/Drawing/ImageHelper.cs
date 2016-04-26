using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.GenericLibrary.Helpers.Log;

namespace WProject.GenericLibrary.Helpers.Drawing
{
    public static partial class ImageHelper
    {
        public const int DEFAULT_TIMEOUT_DOWNLOAD_IMAGE = 4000;

        private static IDictionary<string, Image> _cacheImages;

        static ImageHelper()
        {
            _cacheImages = new Dictionary<string, Image>();
        }

        public static Image Convert(byte[] byteArray)
        {
            if (byteArray == null)
                return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(byteArray, 0, byteArray.Length))
                {
                    ms.Write(byteArray, 0, byteArray.Length);
                    return Image.FromStream(ms, true);
                }
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                return null;
            }
        }

        public static Image SetOpacity(this Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                
                ColorMatrix matrix = new ColorMatrix
                {
                    Matrix33 = opacity
                };
                
                ImageAttributes attributes = new ImageAttributes();
                
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                
                gfx.DrawImage(image, 
                              new Rectangle(0, 0, bmp.Width, bmp.Height), 
                              0, 
                              0, 
                              image.Width, 
                              image.Height, 
                              GraphicsUnit.Pixel, 
                              attributes);
            }

            return bmp;
        }

        public static Image DownloadImage(string url, bool forceDownload = false)
        {
            if (string.IsNullOrEmpty(url))
                return null;
            if (!forceDownload && _cacheImages.ContainsKey(url))
                return _cacheImages[url];

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(url);

                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        var mimg = Image.FromStream(mem);

                        if (!_cacheImages.ContainsKey(url))
                            _cacheImages.Add(url, mimg);
                        else
                            _cacheImages[url] = mimg;

                        return mimg;
                    }
                }
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                return null;
            }
        }

        public static async Task<Image> DownloadImageAsync(string url, bool forceDownload = false)
        {
            if (string.IsNullOrEmpty(url))
                return null;
            if (!forceDownload && _cacheImages.ContainsKey(url))
                return _cacheImages[url];

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = await webClient.DownloadDataTaskAsync(url);

                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        var mimg = Image.FromStream(mem);

                        if (!_cacheImages.ContainsKey(url))
                            _cacheImages.Add(url, mimg);
                        else
                            _cacheImages[url] = mimg;

                        return mimg;
                    }
                }
            }
            catch (WebException mex)
            {
                _cacheImages.Add(url, null);
                Logger.Log(mex);
                return null;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                return null;
            }
        }

        public static Image SetNumber(Image image, int value, Color bkcolor, Color txtColor, Font font, int max = 99)
        {
            if (value <= 0)
                return image;

            Graphics mgfx = Graphics.FromImage(image);

            mgfx.SmoothingMode = SmoothingMode.AntiAlias;

            var ms = Math.Min(value, max).ToString();
            if (value > max)
                ms = "+" + ms;

            var mssize = mgfx.MeasureString(ms, font);

            var mp = new PointF(image.Width - mssize.Width - 1, image.Height - mssize.Height);

            var mr = new RectangleF(mp, mssize + new SizeF(2, 0));

            mgfx.FillRectangle(new SolidBrush(bkcolor), mr);

            mr.Location = new PointF(mr.X + 1, mr.Y);   //weird padding .... change asap

            mr.Size = new SizeF(mr.Width - 2, mr.Height);

            mgfx.DrawString(ms, font, new SolidBrush(txtColor),  mr, new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            });

            var msta = mgfx.Save();

            Logger.Log(msta.ToString());

            return image;
        }

        public static Image ResizeImage(Image image, Size newSize, bool keepRatio = false)
        {
            return keepRatio 
                        ? ResizeImageRatio(image, newSize) 
                        : new Bitmap(image, newSize);
        }

        private static Image ResizeImageRatio(Image image, Size newSize)
        {
            int boxWidth = newSize.Width.IsZero(1);
            int boxHeight = newSize.Height.IsZero(1);

            double dbl = image.Width / (double)image.Height;

            //set height of image to boxHeight and check if resulting width is less than boxWidth, 
            //else set width of image to boxWidth and calculate new height

            Bitmap resizedImage = (int)(boxHeight * dbl) <= boxWidth 
                                      ? new Bitmap(image, (int)(boxHeight * dbl), boxHeight) 
                                      : new Bitmap(image, boxWidth, (int)(boxWidth / dbl));

            return resizedImage;
        }
    }
}
