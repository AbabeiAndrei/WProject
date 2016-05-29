using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class TaskHistory
    {
        public WebApiClasses.Classes.TaskHistory ToWebApi()
        {
            return ToWebApi(this);
        }

        public static WebApiClasses.Classes.TaskHistory ToWebApi(TaskHistory th)
        {
            try
            {
                if (th == null)
                    return null;

                return new WebApiClasses.Classes.TaskHistory
                {
                    Id = th.Id,
                    ChangeStamp = th.ChangeStamp,
                    TaskId = th.TaskId,
                    UpdatedAt = th.UpdatedAt,
                    UpdatedById = th.UpdatedBy,
                    FieldName = th.FieldName,
                    OldValue = th.FieldOldValue,
                    NewValue = th.FieldNewValue,
                    Comments = th.Comments,
                    Metadata = th.Metadata,
                    Deleted = th.Deleted.GetValueOrDefault() == 1,
                    UpdatedBy = User.ToWebApi(th.User)
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
