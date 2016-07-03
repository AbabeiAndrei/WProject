using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.GenericLibrary;
using WProject.GenericLibrary.Exceptions;

namespace WProject.DataAccess
{
    public partial class Backlog
    {
        public WebApiClasses.Classes.Backlog ToWebApi()
        {
            return ToWebApi(this);
        }

        public static WebApiClasses.Classes.Backlog ToWebApi(Backlog backlog)
        {
            try
            {
                if (backlog == null)
                    return null;

                return new WebApiClasses.Classes.Backlog
                {
                    Id = backlog.Id,
                    Name = backlog.Name,
                    CreatedAt = backlog.CreatedAt,
                    CreatedById = backlog.CreatedById,
                    AssignedToId = backlog.AssignedToId,
                    StateId = backlog.StateId,
                    TypeId = backlog.TypeId,
                    CategoryId = backlog.CategoryId,
                    Priority = backlog.Priority,
                    From = backlog.PeriodFrom,
                    To = backlog.PeriodTo,
                    RemainingWork = (int?)backlog.RemainingWork,
                    Description = backlog.Description,
                    Metadata = "",
                    Tags = Enumerable.Empty<string>(),
                    Deleted = backlog.Deleted.GetValueOrDefault() == 1
                };
            }
            catch
            {
                return null;
            }
        }

        public WebApiClasses.Classes.Backlog ToWebApi(wpContext context)
        {
            return ToWebApi(this, context);
        }

        public static WebApiClasses.Classes.Backlog ToWebApi(Backlog backlog, wpContext context)
        {
            var mb = ToWebApi(backlog);

            if (mb == null)
                return null;

            mb.CreatedBy = User.ToWebApi(User.GetById(mb.CreatedById, context), context);

            if(mb.AssignedToId.HasValue)
                mb.AssignedTo = User.ToWebApi(User.GetById(mb.AssignedToId.Value, context), context);

            mb.State = DictItem.ToWebApi(DictItem.GetById(mb.StateId, context));

            mb.Type = DictItem.ToWebApi(DictItem.GetById(mb.TypeId, context));

            mb.Category = Category.ToWebApi(Category.GetById(mb.CategoryId, context));

            mb.Tasks = context.Tasks
                              .Where(t => t.BacklogId == mb.Id && t.Deleted.GetValueOrDefault() == 0)
                              .Select(t => Task.ToWebApi(t, context))
                              .ToList();

            return mb;
        }

        public static Backlog GetById(int id, wpContext context)
        {
            return context.Backlogs.FirstOrDefault(b => b.Id == id);
        }

        public static Backlog FromWebApi(WebApiClasses.Classes.Backlog backlog)
        {

            try
            {
                if (backlog == null)
                    return null;

                return new Backlog
                {
                    Id = backlog.Id,
                    Name = backlog.Name,
                    CreatedAt = backlog.CreatedAt,
                    CreatedById = backlog.CreatedById,
                    AssignedToId = backlog.AssignedToId,
                    StateId = backlog.StateId,
                    TypeId = backlog.TypeId,
                    CategoryId = backlog.CategoryId,
                    Priority = backlog.Priority,
                    PeriodFrom= backlog.From,
                    PeriodTo= backlog.To,
                    RemainingWork = (uint?) backlog.RemainingWork,
                    Description = backlog.Description,
                    Metadata = "",
                    Deleted= backlog.Deleted ? (short?)1 : null
                };
            }
            catch
            {
                return null;
            }
        }

        public static SaveDataResponse Save(Backlog backlog, wpContext context)
        {
            try
            {
                if (backlog.Id == 0)
                    context.Add(backlog);
                else
                {
                    var mentity = GetById(backlog.Id, context);

                    if(mentity == null)
                        throw new WpException(WpErrors.ENTITY_NOT_FOUND, "Entity not found");

                    mentity.AssignedToId = backlog.AssignedToId;
                    mentity.Name = backlog.Name;
                    mentity.CreatedAt = backlog.CreatedAt;
                    mentity.CreatedById = backlog.CreatedById;
                    mentity.StateId = backlog.StateId;
                    mentity.TypeId = backlog.TypeId;
                    mentity.CategoryId = backlog.CategoryId;
                    mentity.Priority = backlog.Priority;
                    mentity.PeriodFrom = backlog.PeriodFrom;
                    mentity.PeriodTo = backlog.PeriodTo;
                    mentity.RemainingWork = backlog.RemainingWork;
                    mentity.Description = backlog.Description;
                    mentity.Metadata = backlog.Metadata;
                    mentity.Tags = backlog.Tags;
                    mentity.Deleted = backlog.Deleted;
                }

                return new SaveDataResponse();
            }
            catch (Exception mex)
            {
                return new SaveDataResponse(mex);
            }
        }
    }
}
