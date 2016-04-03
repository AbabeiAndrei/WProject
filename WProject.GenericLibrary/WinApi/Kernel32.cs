using System.Runtime.InteropServices;

namespace WProject.GenericLibrary.WinApi
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
    }
}
