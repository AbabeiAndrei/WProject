﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Log;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.MessanginCenter;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Connection
{
    public static class WebCallFactory
    {
        public static async Task<MessagingCenterResponse> TestMethod()
        {
            return await ExecuteMethod("TestResponse", 1);
        }

        public static async Task<GetAllProjectsResponse> GetAllProjects(int userId)
        {
            try
            {
                var mres = await ExecuteMethod("GetAllProjects", new GetAllProjectsRequest
                {
                    OnlyActive = true,
                    UserId = userId
                });

                if(mres == null)
                    throw new Exception("[GetAllProjects]Response is empty");

                if(mres.ErrorCode != MessagingCenterErrors.NO_ERROR)
                    throw new WpException(mres.ErrorCode, mres.Error, mres.Exception);

                if(string.IsNullOrEmpty(mres.Content))
                    throw new Exception("[GetAllProjects]Content is empty");

                return JsonConvert.DeserializeObject<GetAllProjectsResponse>(mres.Content);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                return new GetAllProjectsResponse
                {
                    Error = true,
                    Exception = mex
                };
            }
        }

        public static async Task<ExecuteLoginResonse> ExecuteLogin(string user, string pass)
        {
            try
            {
                var mres = await ExecuteMethod("ExecuteLogin", new ExecuteLoginRequest
                {
                    Name = user,
                    Pass = pass
                });

                if (mres == null)
                    throw new Exception("[ExecuteLogin]Response is empty");

                if (mres.ErrorCode != MessagingCenterErrors.NO_ERROR)
                    throw new WpException(mres.ErrorCode, mres.Error, mres.Exception);

                if (string.IsNullOrEmpty(mres.Content))
                    throw new Exception("[ExecuteLogin]Content is empty");

                return JsonConvert.DeserializeObject<ExecuteLoginResonse>(mres.Content);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                return new ExecuteLoginResonse
                {
                    Error = true,
                    Exception = mex
                };
            }
        }

        public static async Task<GetSpringsResponse> GetSprings(int projectid, int userId)
        {
            try
            {
                var mres = await ExecuteMethod("GetSprings", new GetSpringsRequest
                {
                    ProjectId = projectid,
                    UserId = userId
                });

                if (mres == null)
                    throw new Exception("[GetSprings]Response is empty");

                if (mres.ErrorCode != MessagingCenterErrors.NO_ERROR)
                    throw new WpException(mres.ErrorCode, mres.Error, mres.Exception);

                if (string.IsNullOrEmpty(mres.Content))
                    throw new Exception("[GetSprings]Content is empty");

                return JsonConvert.DeserializeObject<GetSpringsResponse>(mres.Content);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                return new GetSpringsResponse
                {
                    Error = true,
                    Exception = mex
                };
            }
        }

        public static async Task<GetAllBackLogsResonse> GetAllBackLogs(int? sprindId, int? categoryId)
        {
            try
            {
                var mres = await ExecuteMethod("GetAllBackLogs", new GetAllBackLogsRequest
                {
                    SpringId = sprindId,
                    CategoryId = categoryId
                });

                if (mres == null)
                    throw new Exception("[GetAllBackLogs]Response is empty");

                if (mres.ErrorCode != MessagingCenterErrors.NO_ERROR)
                    throw new WpException(mres.ErrorCode, mres.Error, mres.Exception);

                if (string.IsNullOrEmpty(mres.Content))
                    throw new Exception("[GetAllBackLogs]Content is empty");

                return JsonConvert.DeserializeObject<GetAllBackLogsResonse>(mres.Content);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                return new GetAllBackLogsResonse
                {
                    Error = true,
                    Exception = mex
                };
            }
        }

        public static async Task<GetAllTasksForTodayResponse> GetAllBackLogsForToday(int projectId, DateTime? date = null)
        {
            return await ExecuteMethod<GetAllTasksForTodayResponse>("GetAllBackLogsForToday", new GetAllTasksForTodayRequest
            {
                ProjectId = projectId,
                Date = date
            } );
        }

        public static async Task<RegisterTaskStateResponse> ChangeTaskState(int taskId, string newState)
        {
            return await ExecuteMethod<RegisterTaskStateResponse>("ChangeTaskState", new RegisterTaskStateRequest
            {
                TaskId = taskId,
                NewStateCode = newState
            });
        }

        public static async Task<RegisterBacklogStateResponse> ChangeBacklogState(int backlogId, string newState)
        {
            return await ExecuteMethod<RegisterBacklogStateResponse>("ChangeBacklogState", new RegisterBacklogStateRequest
            {
                BacklogId = backlogId,
                NewStateCode = newState
            });
        }

        public static async Task<GetTaskResponse> GetTask(int taskId)
        {
            return await ExecuteMethod<GetTaskResponse>("GetTask", new GetTaskRequest
            {
                TaskId = taskId
            });
        }

        public static async Task<PostCommentOnTaskReponse> PostCommentOnTask(TaskComment mtc)
        {
            return await ExecuteMethod<PostCommentOnTaskReponse>("PostCommentOnTask", new PostCommentOnTaskRequest
            {
                TaskComment = mtc
            });
        }

        public static async Task<AttachFileToTaskResponse> AttachFileToTask(TaskAttachement taskAttachement)
        {
            return await ExecuteMethod<AttachFileToTaskResponse>("AttachFileToTask", new AttachFileToTaskRequest
            {
                TaskAttachement = taskAttachement
            });
        }

        public static async Task<SaveTaskResponse> SaveTask(Task task)
        {
            return await ExecuteMethod<SaveTaskResponse>("SaveTask", new SaveTaskRequest
            {
                Task = task
            });
        }

        public static async Task<SaveBacklogResponse> SaveBacklog(Backlog backlog)
        {
            return await ExecuteMethod<SaveBacklogResponse>("SaveBacklog", new SaveBacklogRequest
            {
                Backlog = backlog
            });
        }

        public static async Task<SetNewTimeToTaskResponse> SetNewTimeToTask(int taskId, TimeSpan newTime, bool start = true)
        {
            return await ExecuteMethod<SetNewTimeToTaskResponse>("SetNewTimeToTask", new SetNewTimeToTaskRequest
            {
                TaskId = taskId,
                NewTime = newTime,
                Start = start
            }, checkForEmpty: false);
        }

        public static async Task<GetAdminDataResponse> GetAdminData()
        {
            return await ExecuteMethod<GetAdminDataResponse>("GetAdminData", null);
        }

        public static async Task<SaveUserResponse> SaveUser(User user)
        {
            return await ExecuteMethod<SaveUserResponse>("SaveUser", new SaveUserRequest
            {
                User = user
            });
        }

        /// <summary>
        /// Execute a method from server using SignalR Hub
        /// </summary>
        /// <typeparam name="T">Type of response expected</typeparam>
        /// <param name="method">Method name to call</param>
        /// <param name="content">Request parameters requeried in WebMethod</param>
        /// <param name="continueThrow">In any error case the exception is catched and error is return within <value>IMessangingCenterResponse</value> object, 
        /// if flag is set on true, the exception will throw on the exception</param>
        /// <param name="checkForEmpty">In case of response <value>Content</value> property is null or empty an exception will throw, 
        /// if flag is set on false the method will return a new instance of <value>T</value></param>
        /// <returns>Deserialized content of response into type <value>T</value></returns>
        public static async Task<T> ExecuteMethod<T>(string method, object content, bool continueThrow = false, bool checkForEmpty = true)
            where T : IMessangingCenterResponse, new()
        {
            try
            {
                var mres = await ExecuteMethod(method, content);

                if (mres == null)
                    throw new Exception($"[{method}]Response is empty");

                if (mres.ErrorCode != MessagingCenterErrors.NO_ERROR)
                    throw new WpException(mres.ErrorCode, mres.Error, mres.Exception);

                if (string.IsNullOrEmpty(mres.Content))
                    if(checkForEmpty)
                        throw new Exception($"[{method}]Content is empty");
                    else
                        return new T();

                return JsonConvert.DeserializeObject<T>(mres.Content);
            }
            catch (Exception mex)
            {
                if (continueThrow)
                    throw;

                Logger.Log(mex);
                return new T
                {
                    Error = true,
                    Exception = mex
                };
            }
        }

        /*
        ＜￣｀ヽ、　　　　　　　／ ￣ ＞
　        ゝ、　　＼　／⌒ヽ,ノ 　  /´
　　　        ゝ （ ( ͡◉ ͜> ͡◉) ／
　　 　　        >　 　 　,ノ
　　　　　        ∠_,,,/´       The messanger
        */
        public static async Task<MessagingCenterResponse> ExecuteMethod(string method, object content)
        {
            try
            {
                if (!Connection.ConnectionIsAlive)
                    throw new Exception("Connection is not alive");


                MessagingCenterPackage mpackage = new MessagingCenterPackage
                {
                    FromAddress = Connection.FromAddress,
                    Method = method
                };

                if (content != null)
                    mpackage.Content = JsonConvert.SerializeObject(content);
                else
                    mpackage.Content = string.Empty;

                Connection.NetworkTransferInProgress = true;

                //Make webCall
                var mresult = await Connection.Hub.Invoke<MessagingCenterResponse>("CallServiceMethod", mpackage);

                return mresult;
            }
            finally
            {
                Connection.NetworkTransferInProgress = false;
            }
        }
    }
}
