using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Cors;
using Owin;
using WProject.Dispatcher.Connection;
using WProject.Dispatcher.Properties;
using WProject.GenericLibrary.WinApi;
using WProject.Library.Helpers.Log;

namespace WProject.Dispatcher
{
    public static class Module
    {
        public static IDisposable Connection;
        public static MessagingCenter CenterConnection { get; set; }

        public static void InitConnection()
        {
            Connection = WebApp.Start("http://localhost:8087/");
        }

        public static void CloseConnection()
        {
            Connection.Dispose();
        }

        public static void InitLogger()
        {
            Logger.WriteInDb = true;
            Logger.WriteInConsole = false;
            Logger.WriteInFile = false;


#if DEBUG
            Logger.WriteInDiagnostics = true;
            Kernel32.AllocConsole();
#else
            Logger.WriteInDiagnostics = false;
#endif
        }
    }

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var hubConfiguration = new HubConfiguration();
            app.MapSignalR(hubConfiguration);
        }
    }
}