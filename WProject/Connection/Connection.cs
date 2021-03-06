﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using WProject.Classes;
using WProject.Controls.MainPageControls;
using WProject.GenericLibrary.Helpers.Log;
using WProject.GenericLibrary.Helpers.Networking;
using WProject.Helpers;
using WProject.Properties;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;
using WProject.WebApiClasses.MessanginCenter;
using Task = System.Threading.Tasks.Task;

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

        public static string WebUrl => Settings.Default.DispatcherUrl;

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
            
            _hubProxy.On<string>(WPClient.Broadcasts.SHUT_DOWN_CLIENT, 
                                 reason => UIHelper.ExecuteServerMethod(reason, UIHelper.CloseApplication, WPClient.Broadcasts.SHUT_DOWN_CLIENT));
            _hubProxy.On<string>(WPClient.Broadcasts.REFRESH_DASHBOARD_BROADCAST,   //broadcast modificare task/backlog
                                 data => UIHelper.ExecuteServerMethod(data, RefreshDashBoard, WPClient.Broadcasts.REFRESH_DASHBOARD_BROADCAST));

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

        private static void RefreshDashBoard(string data)   
        {
            if(string.IsNullOrEmpty(data))
                UIHelper.RefreshDashboard();

            var mdata = JsonConvert.DeserializeObject<RefreshDashboardInfo>(data);

            if(mdata == null)
                return;

            if (UIHelper.MainPanel.SelectedPage == Pages.DashBoard) //todo de continuat cu restul paginilor 
            {
                var mdboard = UIHelper.MainPanel.GetPage(Pages.DashBoard) as ctrlDashBoard;

                if(mdboard == null)
                    return;

                if (mdata.RefreshAll)   //in caz ca se face refresh all 
                {
                    UIHelper.RefreshDashboard();
                    return;
                }

                if (mdata.Tasks != null)
                    foreach (var mtask in mdata.Tasks)
                    {
                        var mctrlb = mdboard.TasksControl
                                            .BacklogControls
                                            .FirstOrDefault(bc => bc.Backlog.Id == mtask.BacklogId);

                        if (mctrlb == null)
                            continue; // task-ul trimis nu se afla in lista ( utilizatorul se afla pe alt spring sau alta categorie)

                        var mtctrl = mctrlb.TaskControls
                                           .FirstOrDefault(tc => tc.Task.Id == mtask.Id);
                        if (mtctrl == null)
                            mctrlb.AddTask(mtask); //nu exista task-ul (se adauga)
                        else
                        {
                            if (mtask.StateId != mtctrl.Task.StateId)
                                mctrlb.SetTaskState(mtctrl.Task, mtask.StateId);

                            mtctrl.SetTask(mtask);
                        }
                    }

                if(mdata.Backlogs != null)
                    foreach (var mbacklog in mdata.Backlogs)
                    {
                        var mctrlb = mdboard.TasksControl
                                            .BacklogControls
                                            .FirstOrDefault(bc => bc.Backlog.Id == mbacklog.Id);

                        if (mctrlb != null)
                            mctrlb.SetBacklog(mbacklog);
                        else
                            mdboard.TasksControl.AddBackLog(mbacklog);  //nu exista backlogul
                    }
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
