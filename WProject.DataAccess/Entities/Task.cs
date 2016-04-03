using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
