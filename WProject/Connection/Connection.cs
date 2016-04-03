using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using WProject.GenericLibrary.Helpers.Log;
using WProject.GenericLibrary.Helpers.Networking;
using WProject.Helpers;
using WProject.Properties;
using WProject.WebApiClasses.MessanginCenter;

namespace WProject.Connection
{
    public enum ConnectionState
    {
        NotConected,
        Connecting,
        Connected,
        Reconecting,
        Reconected,
        Disconnected
    }

    public static class Connection
    {
        private static HubConnection _connection;
        private static IHubProxy _hubProxy;
        private static ConnectionState _state;

        public static bool ConnectionIsAlive { get; private set; }

        public static MessagingAddress FromAddress { get; set; }
        public static bool NetworkTransferInProgress { get; set; }
        public static IHubProxy Hub => _hubProxy;

        public static ConnectionState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                ConnectionStateChanged?.Invoke(new ConnectionStateChangedArgs(_state));
            }
        }

        public static event ConnectionStateChangedHandler ConnectionStateChanged;

        public static async Task InitConnection()
        {
            _connection = new HubConnection(Settings.Default.DispatcherUrl);
            _connection.Closed += Connection_Closed;
            _connection.Reconnecting += Connection_Reconnecting;
            _connection.Reconnected += Connection_Reconnected;
            _hubProxy = _connection.CreateHubProxy("MessagingCenter");
            
            _hubProxy.On<string>("ShutDownClient", reason => UIHelper.RunOnUiThread(UIHelper.CloseApplication));

            try
            {
                Logger.Log("ATEMPT TO CREATE CONNECTION");

                State = ConnectionState.Connecting;

                await _connection.Start();
                ConnectionIsAlive = true;
                State = ConnectionState.Connected;

                Logger.Log($"CONNECTION CREATED TO : {Settings.Default.DispatcherUrl} HOORAY!!");
            }
            catch (Exception mex)
            {
                State = ConnectionState.NotConected;
                ConnectionIsAlive = false;
                Logger.Log(mex);
            }
        }

        public static void InitStuff()
        {
            FromAddress = new MessagingAddress
            {
                ConnectionId = _connection.ConnectionId,
                Ip = LocalNetworking.GetLocalIPAddress()
            };
        }

        private static void Connection_Closed()
        {
            State = ConnectionState.Disconnected;
            ConnectionIsAlive = false;
            Logger.Log("Connection closed");
        }

        private static void Connection_Reconnecting()
        {
            Logger.Log("Reconecting...");
            ConnectionIsAlive = false;
            State = ConnectionState.Reconecting;
        }

        private static void Connection_Reconnected()
        {
            Logger.Log("Reconedted!!");
            ConnectionIsAlive = true;
            State = ConnectionState.Connected;
        }
    }

    public delegate void ConnectionStateChangedHandler(ConnectionStateChangedArgs args);

    public class ConnectionStateChangedArgs
    {
        public ConnectionState NewState { get; set; }

        public ConnectionStateChangedArgs(ConnectionState newState)
        {
            NewState = newState;
        }
    }
}
