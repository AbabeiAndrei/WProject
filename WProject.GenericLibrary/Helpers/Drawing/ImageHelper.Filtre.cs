using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Helpers.Drawing
{
    public partial class ImageHelper
    {
        public static Image SetBrightness(Image image, float brightness)
        {
            float b = brightness;
            ColorMatrix cm = new ColorMatrix(new[]
            {
                new[] {b, 0, 0,  0,  0},
                new[] {0, b, 0,  0,  0},
                new[] {0, 0, b,  0,  0},
                new[] {0, 0, 0, 1f,  0},
                new[] {0, 0, 0,  0, 1f}
            });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);
            
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width - 1, 0),
                new Point(0, image.Height - 1),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
            return bm;
        }

        public static Image InvertColors(Image image)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(image.Width, image.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            // create the negative color matrix
            ColorMatrix colorMatrix = new ColorMatrix(new[]
            {
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}
            });
            
            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(image, 
                        new Rectangle(0, 0, image.Width, image.Height), 
                        0, 0, 
                        image.Width, 
                        image.Height, 
                        GraphicsUnit.Pixel, 
                        attributes);
            
            g.Dispose();

            return newBitmap;
        }
    }
}
