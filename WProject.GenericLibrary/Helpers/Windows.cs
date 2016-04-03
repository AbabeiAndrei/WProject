using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using WProject.GenericLibrary.Helpers.Log;

namespace WProject.GenericLibrary.Helpers
{
    public static class Windows
    {
        public static void SetIEVersioneKeyforWebBrowserControl(string appName, int ieval)
        {
            RegistryKey Regkey = null;
            try
            {
                Regkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                
                if (Regkey == null)
                {
                    Logger.Log("Application FEATURE_BROWSER_EMULATION Failed - Registry key Not found");
                    return;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));
                
                if (FindAppkey == "" + ieval)
                {
                    Logger.Log("Application FEATURE_BROWSER_EMULATION already set to " + ieval);
                    Regkey.Close();
                    return;
                }
                
                Regkey.SetValue(appName, ieval, RegistryValueKind.DWord);
                
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                if (FindAppkey == "" + ieval)
                    Logger.Log("Application FEATURE_BROWSER_EMULATION changed to " + ieval + "; changes will be visible at application restart");
                else
                    Logger.Log("Application FEATURE_BROWSER_EMULATION setting failed; current value is  " + ieval);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

            }
            finally
            {
                Regkey?.Close();
            }
        }
    }
}
