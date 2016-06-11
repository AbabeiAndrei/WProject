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
        public static MessagingCenterResponse TestResponse(MessagingCenterPackage package)
        {
            var mv = int.Parse(package.Content);

            return new MessagingCenterResponse
            {
                Content = (mv*2).ToString()
            };
        }

        public static MessagingCenterResponse GetAllProjects(MessagingCenterPackage package)
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

        public static MessagingCenterResponse GetSprings(MessagingCenterPackage package)
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

        public static MessagingCenterResponse GetAllBackLogs(MessagingCenterPackage package)
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

        public static MessagingCenterResponse GetSimleCache(MessagingCenterPackage package)
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

        public static MessagingCenterResponse ChangeTaskState(MessagingCenterPackage package)
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

        public static MessagingCenterResponse ChangeBacklogState(MessagingCenterPackage package)
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

        public static MessagingCenterResponse GetTask(MessagingCenterPackage package)
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

        public static MessagingCenterResponse PostCommentOnTask(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY, "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<PostCommentOnTaskRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {

                    var mtaskc = TaskComment.FromWebApi(mreq.TaskComment);

                    if (mtaskc == null)
                        throw new WpException(MessagingCenterErrors.ERROR_COMMENT_TO_TASK_COMMENT_IS_NULL, "Task comment is null");

                    mtaskc.CreatedAt = DateTime.Now;

                    mctx.Add(mtaskc);

                    try
                    {
                        mctx.SaveChanges();
                    }
                    catch (Exception mex)
                    {
                        throw new WpException(MessagingCenterErrors.ERROR_COMMENT_TO_TASK_SAVE_CONTEXT, "Cannot save task comment", mex);
                    }

                    mres.Content = JsonConvert.SerializeObject(new PostCommentOnTaskReponse
                    {
                        TaskComment = TaskComment.ToWebApi(mtaskc, false)
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

        public static MessagingCenterResponse AttachFileToTask(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY, "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<AttachFileToTaskRequest>(package.Content);

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {

                    var mtaska = TaskAttachement.FromWebApi(mreq.TaskAttachement);
                    var mfile = File.FromWebApi(mreq.TaskAttachement.File);

                    if(mtaska == null || mfile == null)
                        throw new WpException(MessagingCenterErrors.ERROR_ATTACH_FILE_TO_TASK_TASK_ATTACHEMENT_IS_NULL, "Task attachement or file is null");
                    
                    mtaska.File = mfile;
                    mtaska.AttachedAt = DateTime.Now;
                    mfile.CreatedAt = DateTime.Now;
                    

                    mctx.Add(mtaska);

                    try
                    {
                        mctx.SaveChanges();
                    }
                    catch (Exception mex)
                    {
                        throw new WpException(MessagingCenterErrors.ERROR_ATTACH_FILE_TO_TASK_TASK_SAVE_CONTEXT, "Cannot save task attachement", mex);
                    }
                   
                    mres.Content = JsonConvert.SerializeObject(new AttachFileToTaskResponse
                    {
                        TaskAttachement = TaskAttachement.ToWebApi(mtaska, false)
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

        public static MessagingCenterResponse SaveTask(MessagingCenterPackage package)
        {
            MessagingCenterResponse mres = new MessagingCenterResponse();

            try
            {
                if (string.IsNullOrEmpty(package.Content))
                    throw new WpException(MessagingCenterErrors.ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY, "CONTENT IS EMPTY");

                var mreq = JsonConvert.DeserializeObject<SaveTaskRequest>(package.Content);

                var moldTask = mreq.Task;
                var mtaskIsNew = moldTask.Id == 0;

                using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                {
                    var mtask = !mtaskIsNew
                                    ? Task.GetById(moldTask.Id, mctx)
                                    : new Task();

                    if (!mtaskIsNew)
                    {
                        var mdiff = mtask.GetDiferences(Task.FromWebApi(moldTask), moldTask.UpdatedById);
                        mctx.Add(mdiff);
                        mctx.FlushChanges();
                    }

                    mtask.Name = moldTask.Name;
                    mtask.StateId = moldTask.StateId;
                    mtask.AssignedToId = moldTask.AssignedToId;
                    mtask.CreatedAt = DateTime.Now;
                    mtask.CreatedById = moldTask.CreatedById;
                    mtask.BacklogId = moldTask.BacklogId;
                    mtask.Deleted = moldTask.Deleted.If((short?) 1, null);
                    mtask.Description = moldTask.Description;
                    mtask.Metadata = moldTask.Metadata;
                    mtask.PeriodFrom = moldTask.From;
                    mtask.PeriodTo = moldTask.To;
                    mtask.Priority = moldTask.Priority;
                    mtask.RemainingWork = moldTask.RemainingWork;
                    mtask.StageId = moldTask.StageId;

                    if(mtaskIsNew)
                        mctx.Add(mtask);

                    mctx.SaveChanges();
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