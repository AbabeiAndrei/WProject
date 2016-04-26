using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WProject.DataAccess;
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.Library.Helpers.Log;
using WProject.Library.Helpers.Utils.Db;
using WProject.WebApiClasses.Interfaces;
using WProject.WebApiClasses.MessanginCenter;

namespace WProject.Dispatcher.Connection
{
    public partial class MessagingCenter
    {
        public MessagingCenterResponse TestResponse(MessagingCenterPackage package)
        {
            var mv = int.Parse(package.Content);

            return new MessagingCenterResponse
            {
                Content = (mv*2).ToString()
            };
        }

        public MessagingCenterResponse GetAllProjects(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY,
                                          "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<GetAllProjectsRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    var ml = mctx.ProjectMembers
                                 .Where(pm => (!mreq.UserId.HasValue || mreq.UserId.Value == pm.UserId) &&
                                              (!pm.Expire.HasValue || pm.Expire.Value > DateTime.Now) &&
                                              pm.Deleted.GetValueOrDefault() == 0)
                                 .Select(pe => pe.Project)
                                 .Where(p => (!mreq.OwnerId.HasValue || p.OwnerId == mreq.OwnerId.Value) &&
                                             (!mreq.OnlyActive ||
                                              (
                                                  !p.PeriodFrom.HasValue || p.PeriodFrom.Value.Date >= DateTime.Now.Date
                                              ) &&
                                              (
                                                  !p.PeriodTo.HasValue || p.PeriodTo.Value.Date <= DateTime.Now.Date
                                              )) &&
                                             p.Name.Contains(mreq.Name ?? string.Empty) &&
                                             p.Deleted.GetValueOrDefault() == 0)
                                 .ToList()
                                 .GroupBy(p => p.Id)
                                 .Select(p => p.First())
                                 .Select(Project.ToWebApi)
                                 .ToList();

                    mres.Content = JsonConvert.SerializeObject(new GetAllProjectsResponse
                    {
                        Projects = ml
                    });
                }
            }
            catch (WpException mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = mex.ErrorCode;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = MessagingCenterErrors.UNKNOW_ERROR;
            }

            return mres;
        }

        public MessagingCenterResponse ExecuteLogin(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY,
                                          "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<ExecuteLoginRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    var mpwmd5 = mreq.Pass.ToMd5();

                    var ml = mctx.Users
                                 .FirstOrDefault(u => u.Login.ToLower() == mreq.Name.ToLower() &&
                                                      u.Word == mpwmd5 &&
                                                      u.Deleted.GetValueOrDefault(0) == 0);

                    if(ml == null)
                        throw new WpException(MessagingCenterErrors.ERROR_USER_OR_PASS_WRONG,
                                              "User or password is wrong");

                    if(ml.Expire.HasValue  && ml.Expire.Value > DateTime.Now) 
                        throw new WpException(MessagingCenterErrors.ERROR_USER_IS_EXPIRED,
                                              "User is expired");

                    if(ml.Suspended.GetValueOrDefault(0) == 1)
                        throw new WpException(MessagingCenterErrors.ERROR_USER_IS_SUSPENDED,    
                                              "User is suspended");

                    var mc = WpClients.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId);

                    if (mc != null)
                        mc.Name = ml.Name;

                    var mwu = User.ToWebApi(ml, mctx);

                    mres.Content = JsonConvert.SerializeObject(new ExecuteLoginResonse
                    {
                        User = mwu
                    });
                }
            }
            catch (WpException mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = mex.ErrorCode;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = MessagingCenterErrors.UNKNOW_ERROR;
            }

            return mres;
        }

        public MessagingCenterResponse GetSprings(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY,
                                          "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<GetSpringsRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    var ml = mctx.Springs
                                 .Where(s => (!mreq.OwnerId.HasValue || s.OwnerId == mreq.OwnerId.Value) &&
                                             (!mreq.OnlyActive ||
                                              (
                                                  !s.PeriodFrom.HasValue || s.PeriodFrom.Value.Date >= DateTime.Now.Date
                                              ) &&
                                              (
                                                  !s.PeriodTo.HasValue || s.PeriodTo.Value.Date <= DateTime.Now.Date
                                              )) &&
                                             s.Name.Contains(mreq.Name ?? string.Empty) &&
                                             (!mreq.ProjectId.HasValue || s.ProjectId == mreq.ProjectId.Value))
                                 .ToList()
                                 .GroupBy(s => s.Id)
                                 .Select(s => s.First())
                                 .Select(s => Spring.ToWebApi(s, mctx))
                                 .ToList();

                    mres.Content = JsonConvert.SerializeObject(new GetSpringsResponse
                    {
                        Springs = ml
                    });
                }
            }
            catch (WpException mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = mex.ErrorCode;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = MessagingCenterErrors.UNKNOW_ERROR;
            }

            return mres;
        }

        public MessagingCenterResponse GetAllBackLogs(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY,
                                          "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<GetAllBackLogsRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    var ml = mctx.Backlogs
                                 .Where(b => ((mreq.CategoryId.HasValue && b.CategoryId == mreq.CategoryId.Value ) ||
                                             (
                                                !mreq.CategoryId.HasValue && 
                                                mreq.SpringId.HasValue && 
                                                b.Category != null && 
                                                b.Category.SpringId == mreq.SpringId.Value)
                                             ) &&
                                             b.Deleted.GetValueOrDefault(0) == 0)
                                 .ToList();

                    mres.Content = JsonConvert.SerializeObject(new GetAllBackLogsResonse
                    {
                        Backlogs = ml.Select(b => Backlog.ToWebApi(b, mctx)).ToList()
                    });
                }
            }
            catch (WpException mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = mex.ErrorCode;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = MessagingCenterErrors.UNKNOW_ERROR;
            }

            return mres;
        }

        public MessagingCenterResponse GetSimleCache(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    IDictionary<string, List<object>> mdata = new Dictionary<string, List<object>>();

                    mdata.Add(WebApiClasses.Classes.User.TableName, new List<object>(mctx.Users.Select(u => User.ToWebApi(u, mctx))));
                    mdata.Add(WebApiClasses.Classes.DictItem.TableName, new List<object>(mctx.DictItems.Select(d => DictItem.ToWebApi(d))));

                    mres.Content = JsonConvert.SerializeObject(new SimpleCacheResponse
                    {
                        Data = mdata
                    });
                }
            }
            catch (WpException mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = mex.ErrorCode;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = MessagingCenterErrors.UNKNOW_ERROR;
            }

            return mres;
        }

        public MessagingCenterResponse ChangeTaskState(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY, "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<RegisterTaskStateRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    var mtask = mctx.Tasks.FirstOrDefault(t => t.Id == mreq.TaskId);

                    if(mtask == null)
                        throw new WpException(MessagingCenterErrors.ERROR_REGISTER_TASK_STATE_TASK_NOT_FOUND, $"Task {mreq.TaskId} not found.");

                    var mstate = mctx.DictItems.FirstOrDefault(di => di.Type == Constants.DictItemCodes[DictItemType.TaskState] &&
                                                                     di.Code == mreq.NewStateCode);

                    if(mstate == null)
                        throw new WpException(MessagingCenterErrors.ERROR_REGISTER_TASK_STATE_STATE_NOT_FOUND, $"State {mreq.NewStateCode} not found.");

                    mtask.StateId = mstate.Id;

                    try
                    {
                        mctx.SaveChanges();
                    }
                    catch (Exception mex)
                    {
                        throw new WpException(MessagingCenterErrors.ERROR_REGISTER_TASK_STATE_SAVE_CONTEXT, "Cannot save new state for task", mex);
                    }

                    mres.Content = JsonConvert.SerializeObject(new RegisterTaskStateResponse());
                }
            }
            catch (WpException mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = mex.ErrorCode;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = MessagingCenterErrors.UNKNOW_ERROR;
            }

            return mres;
        }

        public MessagingCenterResponse ChangeBacklogState(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY, "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<RegisterBacklogStateRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    var mbacklog = mctx.Backlogs.FirstOrDefault(t => t.Id == mreq.BacklogId);

                    if (mbacklog == null)
                        throw new WpException(MessagingCenterErrors.ERROR_REGISTER_BACKLOG_STATE_BACKLOG_NOT_FOUND, $"Backlog {mreq.BacklogId} not found.");

                    var mstate = mctx.DictItems.FirstOrDefault(di => di.Type == Constants.DictItemCodes[DictItemType.BacklogState] &&
                                                                     di.Code == mreq.NewStateCode);

                    if (mstate == null)
                        throw new WpException(MessagingCenterErrors.ERROR_REGISTER_BACKLOG_STATE_STATE_NOT_FOUND, $"State {mreq.NewStateCode} not found.");

                    mbacklog.StateId = mstate.Id;

                    try
                    {
                        mctx.SaveChanges();
                    }
                    catch (Exception mex)
                    {
                        throw new WpException(MessagingCenterErrors.ERROR_REGISTER_BACKLOG_STATE_SAVE_CONTEXT, "Cannot save new state for backlog", mex);
                    }

                    mres.Content = JsonConvert.SerializeObject(new RegisterBacklogStateResponse());
                }
            }
            catch (WpException mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = mex.ErrorCode;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = MessagingCenterErrors.UNKNOW_ERROR;
            }

            return mres;
        }

        public MessagingCenterResponse GetTask(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY, "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<GetTaskRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    var mtask = mctx.Tasks.FirstOrDefault(t => t.Id == mreq.TaskId);

                    if (mtask == null)
                        throw new WpException(MessagingCenterErrors.ERROR_GET_TASK_NOT_FOUND, $"Task {mreq.TaskId} not found.");

                    var mtres = new GetTaskResponse
                    {
                        Task = mtask.ToWebApiExtended(mctx)
                    };

                    mres.Content = JsonConvert.SerializeObject(mtres);
                }
            }
            catch (WpException mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = mex.ErrorCode;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);

                mres.Exception = mex;
                mres.Error = mex.Message;
                mres.ErrorCode = MessagingCenterErrors.UNKNOW_ERROR;
            }

            return mres;
        }
    }
}