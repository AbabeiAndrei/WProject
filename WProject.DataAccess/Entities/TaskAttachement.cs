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

        private WebApiClasses.Classes.TaskAttachement ToWebApi(TaskAttachement taskAttachement, bool getFileContent = true)
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
                    File = taskAttachement.File.ToWebApi(getFileContent)
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
    }
}
