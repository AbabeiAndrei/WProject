using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WProject.WebApiClasses.MessanginCenter
{
    public class WPClient
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }

        public static class Broadcasts
        {
            public const string REFRESH_DASHBOARD_BROADCAST = "REFRESH_DASHBOARD_BROADCAST";
            public const string SHUT_DOWN_CLIENT = "SHUT_DOWN_CLIENT";
        }
    }
}