using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.WinApi;

namespace WProject.UiLibrary.Helpers.GUI
{
    public static class RichTextBoxEx
    {
        public static void InsertImage(this RichTextBox rtb, Image img)
        {
            var rtf = new StringBuilder();

            // Append the RTF header
            rtf.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033");

            // Create the font table using the RichTextBox's current font and append
            // it to the RTF string
            rtf.Append(GetFontTable(rtb.Font));

            // Create the image control string and append it to the RTF string
            using (var mgfx = rtb.CreateGraphics())
                rtf.Append(GetImagePrefix(img, mgfx));

            // Create the Windows Metafile and append its bytes in HEX format
            using (var mgfx = rtb.CreateGraphics())
                rtf.Append(GetRtfImage(img, mgfx));

            // Close the RTF image control string
            rtf.Append(@"}");
            rtb.SelectedRtf = rtf.ToString();
        }

        private struct RtfFontFamilyDef
        {
            public const string Unknown = @"\fnil";
            public const string Roman = @"\froman";
            public const string Swiss = @"\fswiss";
            public const string Modern = @"\fmodern";
            public const string Script = @"\fscript";
            public const string Decor = @"\fdecor";
            public const string Technical = @"\ftech";
            public const string BiDirect = @"\fbidi";
        }

        private static string GetFontTable(Font font)
        {
            var fontTable = new StringBuilder();
            // Append table control string
            fontTable.Append(@"{\fonttbl{\f0");
            fontTable.Append(@"\");
            var rtfFontFamily = new HybridDictionary();
            rtfFontFamily.Add(FontFamily.GenericMonospace.Name, RtfFontFamilyDef.Modern);
            rtfFontFamily.Add(FontFamily.GenericSansSerif, RtfFontFamilyDef.Swiss);
            rtfFontFamily.Add(FontFamily.GenericSerif, RtfFontFamilyDef.Roman);
            rtfFontFamily.Add("UNKNOWN", RtfFontFamilyDef.Unknown);

            // If the font's family corresponds to an RTF family, append the
            // RTF family name, else, append the RTF for unknown font family.
            fontTable.Append(rtfFontFamily.Contains(font.FontFamily.Name) ? rtfFontFamily[font.FontFamily.Name] : rtfFontFamily["UNKNOWN"]);
            // \fcharset specifies the character set of a font in the font table.
            // 0 is for ANSI.
            fontTable.Append(@"\fcharset0 ");
            // Append the name of the font
            fontTable.Append(font.Name);
            // Close control string
            fontTable.Append(@";}}");
            return fontTable.ToString();
        }

        private static string GetImagePrefix(Image _image, Graphics gfx)
        {
            float xDpi, yDpi;
            var rtf = new StringBuilder();

            xDpi = gfx.DpiX;
            yDpi = gfx.DpiY;

            // Calculate the current width of the image in (0.01)mm
            var picw = (int)Math.Round((_image.Width / xDpi) * 2540);
            // Calculate the current height of the image in (0.01)mm
            var pich = (int)Math.Round((_image.Height / yDpi) * 2540);
            // Calculate the target width of the image in twips
            var picwgoal = (int)Math.Round((_image.Width / xDpi) * 1440);
            // Calculate the target height of the image in twips
            var pichgoal = (int)Math.Round((_image.Height / yDpi) * 1440);
            // Append values to RTF string
            rtf.Append(@"{\pict\wmetafile8");
            rtf.Append(@"\picw");
            rtf.Append(picw);
            rtf.Append(@"\pich");
            rtf.Append(pich);
            rtf.Append(@"\picwgoal");
            rtf.Append(picwgoal);
            rtf.Append(@"\pichgoal");
            rtf.Append(pichgoal);
            rtf.Append(" ");

            return rtf.ToString();
        }

        private static string GetRtfImage(Image image, Graphics gfx)
        {
            // Used to store the enhanced metafile
            MemoryStream stream = null;
            // Used to create the metafile and draw the image
            Graphics graphics = gfx;
            // The enhanced metafile
            Metafile metaFile = null;
            try
            {
                var rtf = new StringBuilder();
                stream = new MemoryStream();

                // Get the device context from the graphics context
                IntPtr hdc = graphics.GetHdc();
                // Create a new Enhanced Metafile from the device context
                metaFile = new Metafile(stream, hdc);
                // Release the device context
                graphics.ReleaseHdc(hdc);

                // Get a graphics context from the Enhanced Metafile
                using (graphics = Graphics.FromImage(metaFile))
                {
                    // Draw the image on the Enhanced Metafile
                    graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                }

                // Get the handle of the Enhanced Metafile
                IntPtr hEmf = metaFile.GetHenhmetafile();
                // A call to EmfToWmfBits with a null buffer return the size of the
                // buffer need to store the WMF bits.  Use this to get the buffer
                // size.
                uint bufferSize = GdiPlus.GdipEmfToWmfBits(hEmf, 0, null, 8, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
                // Create an array to hold the bits
                var buffer = new byte[bufferSize];
                // A call to EmfToWmfBits with a valid buffer copies the bits into the
                // buffer an returns the number of bits in the WMF.  
                uint _convertedSize = GdiPlus.GdipEmfToWmfBits(hEmf, bufferSize, buffer, 8, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
                // Append the bits to the RTF string
                foreach (byte t in buffer)
                    rtf.Append($"{t:X2}");

                return rtf.ToString();
            }
            finally
            {
                graphics?.Dispose();
                metaFile?.Dispose();
                stream?.Close();
            }
        }
    }
}
