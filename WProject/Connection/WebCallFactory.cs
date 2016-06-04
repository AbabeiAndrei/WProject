using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Properties;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.MessanginCenter;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Connection
{
    public enum SendMethod : short
    {
        Http = 0,
        SignalR = 1
    }

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

        public static async Task<AttachFileToTaskResoponse> AttachFileToTask(TaskAttachement taskAttachement)
        {
            return await ExecuteMethod<AttachFileToTaskResoponse>("AttachFileToTask", new AttachFileToTaskRequest
            {
                TaskAttachement = taskAttachement
            });
        }

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

                if (checkForEmpty && string.IsNullOrEmpty(mres.Content))
                        throw new Exception($"[{method}]Content is empty");

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
        public static async Task<MessagingCenterResponse> ExecuteMethod(string method, object content, SendMethod sendType = SendMethod.Http )
        {
            try
            {
                if (!Connection.ConnectionIsAlive)
                    throw new Exception("Connection is not alive");

                MessagingCenterResponse mresult;

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

                if (sendType == SendMethod.SignalR)
                    mresult = await Connection.Hub.Invoke<MessagingCenterResponse>("CallServiceMethod", mpackage);
                else
                    mresult = await ExecuteMethodWeb(mpackage); 

                return mresult;
            }
            finally
            {
                Connection.NetworkTransferInProgress = false;
            }
        }

        private static Task<MessagingCenterResponse> ExecuteMethodWeb(MessagingCenterPackage package)
        {
            using (var mwebService = new WebService())
            {
                return null;
            }
        }
    }
}
