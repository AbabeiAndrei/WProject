using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.WinApi
{
    public static class UXTheme
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, int pszSubIdList);

        public static void SetWindowTheme(IntPtr hwnd)
        {
            SetWindowTheme(hwnd, Constants.EXPLORER_THEME_NAME, 0);
        }
    }
}
