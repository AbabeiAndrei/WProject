using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.GenericLibrary.Helpers.Log;

namespace WProject.GenericLibrary.Helpers.Drawing
{
    public static class GraphicsHelper
    {
        public static Color SetOpacity(this Color color, int opacity)
        {
            return Color.FromArgb(opacity, color);
        }

        public static Color TryParse(string color, Color @default = default(Color))
        {
            try
            {
                return ColorTranslator.FromHtml(color);
            }
            catch
            {
                return @default;
            }
        }

        public static void DrawShadow(Graphics gfx, GraphicsPath gPath, Color shadowColor, int depth)
        {
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            

            try
            {
                
                using (PathGradientBrush _Brush = new PathGradientBrush(gPath))
                {
                    _Brush.WrapMode = WrapMode.Clamp;

                    ColorBlend _ColorBlend = new ColorBlend(3)
                    {
                        Colors = new[]
                        {
                            Color.Transparent,
                            Color.FromArgb(180, shadowColor),
                            Color.FromArgb(180, shadowColor)
                        },
                        Positions = new[]
                        {
                            0f,
                            0.1f,
                            1f
                        }
                    };
                    _Brush.InterpolationColors = _ColorBlend;
                    
                    gfx.FillPath(_Brush, gPath);
                }
                Matrix _Matrix = new Matrix();
                
                _Matrix.Translate(depth, depth);
                
                gPath.Transform(_Matrix);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
            }
        }

        public static List<Color> GetColorVector(Color fc, Color bc, int depth)
        {
            List<Color> cv = new List<Color>();
            float dRed = 1f * (bc.R - fc.R) / depth;
            float dGreen = 1f * (bc.G - fc.G) / depth;
            float dBlue = 1f * (bc.B - fc.B) / depth;
            for (int d = 1; d <= depth; d++)
                cv.Add(Color.FromArgb(255, (int)(fc.R + dRed * d),
                  (int)(fc.G + dGreen * d), (int)(fc.B + dBlue * d)));
            return cv;
        }

        public static GraphicsPath GetRectPath(Rectangle R)
        {
            byte[] fm = new byte[3];
            for (int b = 0; b < 3; b++) fm[b] = 1;
            List<Point> points = new List<Point>();
            points.Add(new Point(R.Left, R.Bottom));
            points.Add(new Point(R.Right, R.Bottom));
            points.Add(new Point(R.Right, R.Top));
            return new GraphicsPath(points.ToArray(), fm);
        }
    }
}
