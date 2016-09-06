using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Transports;
using Newtonsoft.Json;
using WProject.DataAccess;
using WProject.GenericLibrary.Exceptions;
using WProject.Library.Helpers.Log;
using WProject.Library.Helpers.Utils.Db;
using WProject.WebApiClasses.MessanginCenter;
using Task = System.Threading.Tasks.Task;

namespace WProject.Dispatcher.Connection
{
    public partial class MessagingCenter : Hub
    {
        #region Constants

        public const int MAXIMUM_NUMBER_CONNECTIONS = 2;

        #endregion

        #region Properties

        public static List<WPClient> WpClients { get; }

        public static bool AllowMoreConnections => WpClients.Count < MAXIMUM_NUMBER_CONNECTIONS;

        #endregion

        #region Constructors

        public MessagingCenter()
        {
            Module.CenterConnection = this;
        }

        static MessagingCenter()
        {
            WpClients = new List<WPClient>();
        }

        #endregion

        #region Overrides of HubBase

        public override Task OnConnected()
        {
            if(AllowMoreConnections)
                WpClients.Add(new WPClient
                {
                    ConnectionId = Context?.ConnectionId,
                    Name = Context?.User?.Identity?.Name ?? "UNKNOW",
                    Ip = GetIpAddress(Context)
                });

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var mi = WpClients.FindIndex(c => c.ConnectionId == Context?.ConnectionId);

            if(mi >= 0)
                WpClients.RemoveAt(mi);

            return base.OnDisconnected(stopCalled);
        }

        #endregion

        #region Private methods

        private static string GetIpAddress(HubCallerContext context)
        {
            object tempObject;

            context.Request.Environment.TryGetValue("server.RemoteIpAddress", out tempObject);

            return tempObject?.ToString() ?? string.Empty;
        }

        #endregion
        
        #region Public methods

        public static void ClearClients()
        {
            var heartBeat = GlobalHost.DependencyResolver.Resolve<ITransportHeartbeat>();

            var mlca = heartBeat.GetConnections()
                                .Where(c => c.IsAlive)
                                .Select(c => c.ConnectionId)
                                .ToList();

            WpClients.RemoveAll(c => !mlca.Contains(c.ConnectionId));
        }

        public MessagingCenterResponse CallServiceMethod(MessagingCenterPackage package)
        {
            if (WpClients.All(c => c.ConnectionId != Context.ConnectionId))
                return ErrorResponse(null,
                                     "CONNECTIONS LIMIT HAS REACHED",
                                     MessagingCenterErrors.ERROR_LIMIT_CONNECTIONS_REACHED);
            if (package == null)
                return ErrorResponse(null,
                                     "PACKAGE IS NULL",
                                     MessagingCenterErrors.ERROR_MESSANGING_CENTERE_PACKAGE_IS_NULL);

            if (string.IsNullOrEmpty(package.Method))
                return ErrorResponse(package,
                                     "NO METHOD REQUESTED",
                                     MessagingCenterErrors.ERROR_MESSANGING_CENTERE_NO_METHOD_REQUESTED);

            var mmethodInfo = GetType().GetMethod(package.Method);

            if (mmethodInfo == null)
                return ErrorResponse(package,
                                     $"METHOD [{package.Method}] NOT FOUND",
                                     MessagingCenterErrors.ERROR_MESSANGING_CENTERE_METHOD_NOT_FOUND);

            try
            {
                return (MessagingCenterResponse)mmethodInfo.Invoke(this, new object[] { package });
            }
            catch (Exception mex)
            {
                return ErrorResponse(package,
                                     $"EXCEPTION DURING THE EXECUTION OF {package.Method}",
                                     MessagingCenterErrors.ERROR_MESSANGING_CENTERE_DURING_THE_EXECUTION,
                                     mex);
            }

        }

        public MessagingCenterResponse ErrorResponse(MessagingCenterPackage package, string message, int errorCode, Exception exception = null)
        {
            WpException mex = new WpException(errorCode, message, exception)
            {
                Metadata = JsonConvert.SerializeObject(package)
            };

            Logger.Log(mex);

            return MessagingCenterResponse.CreateError(mex);
        }


        #endregion

    }
}