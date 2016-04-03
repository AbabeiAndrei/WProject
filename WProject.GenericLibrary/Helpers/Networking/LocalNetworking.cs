using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Helpers.Networking
{
    public static class LocalNetworking
    {
        public static string GetLocalIPAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName())?
                      .AddressList?
                      .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)?
                      .ToString() ?? string.Empty;
        }
    }
}
