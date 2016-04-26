using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class TaskDiscution
    {
        public WebApiClasses.Classes.TaskComment ToWebApi(bool getFileContent = true)
        {
            return ToWebApi(this, getFileContent);
        }

        public static WebApiClasses.Classes.TaskComment ToWebApi(TaskDiscution taskDiscution, bool getFileContent = true)
        {
            try
            {
                return taskDiscution != null 
                            ? TaskComment.ToWebApi((TaskComment)taskDiscution, getFileContent) 
                            : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
