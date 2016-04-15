using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.WinApi
{
    public enum EmfToWmfBitsFlags
    {
        EmfToWmfBitsFlagsDefault = 0x00000000,
        EmfToWmfBitsFlagsEmbedEmf = 0x00000001,
        EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,
        EmfToWmfBitsFlagsNoXORClip = 0x00000004
    };

    public class GdiPlus
    {
        [DllImport("gdiplus.dll")]
        public static extern uint GdipEmfToWmfBits(IntPtr _hEmf,
                                                   uint _bufferSize,
                                                   byte[] _buffer,
                                                   int _mappingMode,
                                                   EmfToWmfBitsFlags _flags);
    }
}
