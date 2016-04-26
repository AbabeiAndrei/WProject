using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess.FetchOptimization;

namespace WProject.DataAccess
{
    public partial class Task
    {
        public static Task GetById(int id, wpContext context)
        {
            try
            {
                return context.Tasks.FirstOrDefault(t => t.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public WebApiClasses.Classes.Task ToWebApi()
        {
            return ToWebApi(this);
        }

        public WebApiClasses.Classes.Task ToWebApi(wpContext context)
        {
            return ToWebApi(this, context);
        }

        public static WebApiClasses.Classes.Task ToWebApi(Task task)
        {
            try
            {
                if (task == null)
                    return null;

                return new WebApiClasses.Classes.Task
                {
                    Id = task.Id,
                    Name = task.Name,
                    CreatedAt = task.CreatedAt,
                    CreatedById = task.CreatedById,
                    AssignedToId = task.AssignedToId,
                    StateId = task.StateId,
                    TypeId = task.TypeId,
                    StageId = task.StageId,
                    BacklogId = task.BacklogId,
                    Priority = task.Priority,
                    From = task.PeriodFrom,
                    To = task.PeriodTo,
                    RemainingWork = task.RemainingWork,
                    Description = task.Description,
                    Deleted = task.Deleted.GetValueOrDefault() == 1
                };
            }
            catch
            {
                return null;
            }
        }

        public static WebApiClasses.Classes.Task ToWebApi(Task task, wpContext context)
        {
            var mt = ToWebApi(task);

            if (mt == null)
                return null;

            mt.CreatedBy = User.ToWebApi(User.GetById(mt.CreatedById, context), context);

            if(mt.AssignedToId.HasValue)
                mt.AssignedTo = User.ToWebApi(User.GetById(mt.AssignedToId.Value, context), context);

            mt.State = DictItem.ToWebApi(DictItem.GetById(mt.StateId, context));

            mt.Type = DictItem.ToWebApi(DictItem.GetById(mt.TypeId, context));

            if (mt.StageId.HasValue)
                mt.Stage = DictItem.ToWebApi(DictItem.GetById(mt.StageId.Value, context));

            mt.Backlog = Backlog.ToWebApi(Backlog.GetById(mt.BacklogId, context));

            return mt;
        }

        public WebApiClasses.Classes.Task ToWebApiExtended(wpContext context)
        {
            return ToWebApiExtended(this, context);
        }

        private static WebApiClasses.Classes.Task ToWebApiExtended(Task task, wpContext context)
        {
            var mtask = task.ToWebApi(context);

            FetchStrategy mfs = new FetchStrategy();
            mfs.LoadWith<TaskAttachement>(f => f.File);
            mfs.LoadWith<TaskAttachement>(f => f.User);

            mtask.Attachments = context.CreateDetachedCopy(context.TaskAttachements.Where(t => t.TaskId == mtask.Id).ToList(), mfs)
                                       .Select(ta => ta.ToWebApi(context, false))
                                       .ToList();

            mfs = new FetchStrategy();
            mfs.LoadWith<TaskComment>(f => f.File);
            mfs.LoadWith<TaskComment>(f => f.User);

            mtask.Comments = context.CreateDetachedCopy(context.TaskComments.Where(tc => tc.TaskId == mtask.Id).ToList(), mfs)
                                    .Select(tc => tc.ToWebApi(false))
                                    .ToList();

            mfs = new FetchStrategy();
            mfs.LoadWith<TaskDiscution>(f => f.File);
            mfs.LoadWith<TaskDiscution>(f => f.User);

            mtask.Discusion = context.CreateDetachedCopy(context.TaskDiscutions.Where(td => td.TaskId == mtask.Id).ToList(), mfs)
                                     .Select(td => td.ToWebApi(false))
                                     .ToList();

            return mtask;
        }
    }
}
