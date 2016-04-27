using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class TaskAttachement
    {
        public WebApiClasses.Classes.TaskAttachement ToWebApi(bool getFileContent = true)
        {
            return ToWebApi(this, getFileContent);
        }

        public static WebApiClasses.Classes.TaskAttachement ToWebApi(TaskAttachement taskAttachement, bool getFileContent = true)
        {
            try
            {
                if (taskAttachement == null)
                    return null;
                
                return new WebApiClasses.Classes.TaskAttachement
                {
                    Id = taskAttachement.Id,
                    FileId = taskAttachement.FileId,
                    TaskId = taskAttachement.TaskId,
                    AttachedAt = taskAttachement.AttachedAt,
                    AttachedBy = taskAttachement.AttachedBy,
                    User = User.ToWebApi(taskAttachement.User),
                    Comments = taskAttachement.Comments,
                    Metadata = taskAttachement.Metadata,
                    File = taskAttachement.File.ToWebApi(getFileContent),
                    Deleted = taskAttachement.Deleted.HasValue && taskAttachement.Deleted.Value == 1
                };
            }
            catch
            {
                return null;
            }
        }

        public WebApiClasses.Classes.TaskAttachement ToWebApi(wpContext context, bool getFileContent = true)
        {
            return ToWebApi(this, context, getFileContent);
        }

        private WebApiClasses.Classes.TaskAttachement ToWebApi(TaskAttachement taskAttachement, wpContext context, bool getFileContent = true)
        {
            var mta = ToWebApi(taskAttachement);

            if (mta == null)
                return null;

            mta.File = File.ToWebApi(context.Files.FirstOrDefault(f => f.Id == mta.FileId), getFileContent);

            return mta;
        }

        public static TaskAttachement FromWebApi(WebApiClasses.Classes.TaskAttachement taskAttachement)
        {
            try
            {
                if (taskAttachement == null)
                    return null;

                return new TaskAttachement
                {
                    Id = taskAttachement.Id,
                    FileId = taskAttachement.FileId,
                    TaskId = taskAttachement.TaskId,
                    AttachedAt = taskAttachement.AttachedAt,
                    AttachedBy = taskAttachement.AttachedBy,
                    Comments = taskAttachement.Comments,
                    Metadata = taskAttachement.Metadata,
                    Deleted = taskAttachement.Deleted ? 1 : (short?)null
                };
            }
            catch
            {
                return null;
            }
        }

        public static TaskAttachement GetById(int id, wpContext context)
        {
            return context.TaskAttachements.FirstOrDefault(ta => ta.Id == id);
        }
    }
}
