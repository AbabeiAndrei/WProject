using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WProject.Connection;
using WProject.GenericLibrary.Helpers.Log;
using WProject.GenericLibrary.WinApi;
using WProject.Helpers;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;
using WProject.WebApiClasses.MessanginCenter;
using Task = System.Threading.Tasks.Task;

namespace WProject
{
    public static class Module
    {
        public const string CONSOLE_TITLE_NAME = "WProject [DESKTOP] Console";

        public static async Task<bool> InitApplicationData()
        {

            try
            {
#if DEBUG
                Kernel32.AllocConsole();
                Console.Title = CONSOLE_TITLE_NAME;

                Logger.WriteToConsole = true;
                
                var ms = Screen.AllScreens.LastOrDefault(s => !s.Primary);
                if (ms != null)
                {
                    IntPtr mcw = User32.FindWindow(null, CONSOLE_TITLE_NAME);
                    if (mcw != IntPtr.Zero)
                        User32.SetWindowPos(mcw,
                                            (IntPtr) SpecialWindowHandles.HWND_TOP,
                                            ms.Bounds.Left + 300,
                                            100,
                                            600,
                                            400,
                                            SetWindowPosFlags.SWP_NOSIZE);

                }

#endif

                await Connection.Connection.InitConnection();
                Connection.Connection.InitStuff();
                await LoadSimpleCache();
                return true;
            }
            catch (Exception mex)
            {
                UIHelper.ShowError(mex);
                return false;
            }
        }

        public static async Task LoadSimpleCache()
        {
            try
            {
                Logger.Log("Load simple cache");

                var mres = await WebCallFactory.ExecuteMethod("GetSimleCache", null);

                if(mres.ErrorCode > 0)
                {
                    Logger.Log(mres.Error);
                    return;
                }

                if (string.IsNullOrEmpty(mres.Content))
                {
                    Logger.Log("Simple cache looks like to be empty");
                    return;
                }

                var mresData = JsonConvert.DeserializeObject<SimpleCacheResponse>(mres.Content);

                if (mresData != null)
                {
                    if(mresData.Data.ContainsKey(User.TableName))
                        SimpleCache.SetData(User.TableName, mresData.Data[User.TableName]
                                                                    .Cast<JObject>()
                                                                    .Select(j => j.ToObject<User>())
                                                                    .ToList());

                    if (mresData.Data.ContainsKey(DictItem.TableName))
                        SimpleCache.SetData(DictItem.TableName, mresData.Data[DictItem.TableName]
                                                                        .Cast<JObject>()
                                                                        .Select(j => j.ToObject<DictItem>())
                                                                        .ToList());


                    Logger.Log(mresData.Data?.Count + " elements loaded in simple cache");
                }
                else
                    Logger.Log("Response from simple GetSimleCache is null");
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
            }
        }
    }
}
