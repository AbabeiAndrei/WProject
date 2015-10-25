using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using WProject.GenericLibrary.Exceptions;

namespace WProject.GenericLibrary.Helpers.Drawing
{
    public static class ImageHelper
    {
        public static Image Convert(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray), "Image as byte array cannot be null");

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
                throw new ConvertImageException("Cannot convert image.", mex);
            }
        }
    }
}
