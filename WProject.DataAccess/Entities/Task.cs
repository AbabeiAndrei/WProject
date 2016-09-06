using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess.FetchOptimization;
using WProject.GenericLibrary.Helpers;
using WProject.GenericLibrary.Helpers.Extensions;

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
                    WorkDate = task.WorkDate,
                    StartHour = Utils.GetTimpStampFromDateTime(task.StartHour),
                    EndHour = Utils.GetTimpStampFromDateTime(task.EndHour),
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
            mfs.LoadWith<File>(f => f.User);
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

            mfs = new FetchStrategy();
            mfs.LoadWith<TaskHistory>(f => f.User);

            mtask.Changes = context.CreateDetachedCopy(context.TaskHistories.Where(td => td.TaskId == mtask.Id).ToList(), mfs)
                                   .Select(th => th.ToWebApi())
                                   .ToList();

            return mtask;
        }

        public static Task FromWebApi(WebApiClasses.Classes.Task task)
        {
            try
            {
                if (task == null)
                    return null;

                return new Task
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
                    PeriodFrom= task.From,
                    PeriodTo= task.To,
                    RemainingWork = task.RemainingWork,
                    WorkDate = task.WorkDate,
                    StartHour = Utils.GetDateFromTimeStamp(task.StartHour),
                    EndHour = Utils.GetDateFromTimeStamp(task.EndHour),
                    Description = task.Description,
                    Deleted = task.Deleted.If((short?)1, null)
                };
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TaskHistory> GetDiferences(Task newTask, int updatedBy)
        {
            var mchstamp = Guid.NewGuid().ToString();

            if (Name != newTask.Name)
                yield return TaskHistory.Create(Id, mchstamp, nameof(Name), Name, newTask.Name, updatedBy); 

            if(StateId != newTask.StateId && State != null && newTask.State != null)
                yield return TaskHistory.Create(Id, mchstamp, nameof(State), State.Name, newTask.State.Name, updatedBy);
            else if (StateId != newTask.StateId)
                yield return TaskHistory.Create(Id, mchstamp, nameof(State), StateId.ToString(), newTask.StateId.ToString(), updatedBy);

            if(AssignedToId != newTask.AssignedToId && AssignedTo != null && newTask.AssignedTo != null)
                yield return TaskHistory.Create(Id, mchstamp, nameof(AssignedTo), AssignedTo.Name, newTask.AssignedTo.Name, updatedBy);
            else if (AssignedToId != newTask.AssignedToId)
                yield return TaskHistory.Create(Id, mchstamp, nameof(AssignedTo), AssignedToId.ToString(), newTask.AssignedToId.ToString(), updatedBy);
            
            if(BacklogId != newTask.BacklogId)
                yield return TaskHistory.Create(Id, mchstamp, nameof(Backlog), BacklogId.ToString(), BacklogId.ToString(), updatedBy);

            if(Description != newTask.Description)
                yield return TaskHistory.Create(Id, mchstamp, nameof(Description), Description, Description, updatedBy);

            if (PeriodFrom != newTask.PeriodFrom)
                yield return TaskHistory.Create(Id, mchstamp, nameof(PeriodFrom), PeriodFrom.ToString(), PeriodFrom.ToString(), updatedBy);

            if (PeriodTo != newTask.PeriodTo)
                yield return TaskHistory.Create(Id, mchstamp, nameof(PeriodTo), PeriodTo.ToString(), PeriodTo.ToString(), updatedBy);

            if (Priority != newTask.Priority)
                yield return TaskHistory.Create(Id, mchstamp, nameof(Priority), Priority?.ToString() ?? "none", Priority?.ToString() ?? "none", updatedBy);

            if (RemainingWork != newTask.RemainingWork)
                yield return TaskHistory.Create(Id, mchstamp, nameof(RemainingWork), RemainingWork?.ToString() ?? "none", RemainingWork?.ToString() ?? "none", updatedBy);
            
            if (StageId != newTask.StageId && Stage != null && newTask.Stage != null)
                yield return TaskHistory.Create(Id, mchstamp, nameof(Stage), Stage.Name, newTask.Stage.Name, updatedBy);
            else if (StageId != newTask.StageId)
                yield return TaskHistory.Create(Id, mchstamp, nameof(Stage), StageId.ToString(), newTask.StageId.ToString(), updatedBy);
        }
    }
}
