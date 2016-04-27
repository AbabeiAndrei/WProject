using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class TaskComment
    {
        public WebApiClasses.Classes.TaskComment ToWebApi(bool getFileContent = true)
        {
            return ToWebApi(this, getFileContent);
        }

        public static WebApiClasses.Classes.TaskComment ToWebApi(TaskComment taskComment, bool getFileContent = true)
        {
            try
            {
                if (taskComment == null)
                    return null;

                return new WebApiClasses.Classes.TaskComment
                {
                    Id = taskComment.Id,
                    CreatedAt = taskComment.CreatedAt,
                    UserId = taskComment.UserId,
                    CreatedBy = User.ToWebApi(taskComment.User),
                    CustomName = taskComment.CustomName,
                    FileId = taskComment.FileId,
                    File = File.ToWebApi(taskComment.File, getFileContent),
                    TaskId = taskComment.TaskId,
                    Text = taskComment.Text,
                    Deleted = taskComment.Deleted.HasValue && taskComment.Deleted.Value == 1
                };
            }
            catch 
            {
                return null;
            }
        }

        public static explicit operator TaskComment(TaskDiscution taskDiscution)
        {
            if (taskDiscution == null)
                return null;

            return new TaskComment
            {
                Id = taskDiscution.Id,
                TaskId = taskDiscution.TaskId,
                UserId = taskDiscution.UserId,
                CustomName = taskDiscution.CustomName,
                CreatedAt = taskDiscution.CreatedAt,
                Text = taskDiscution.Text,
                FileId = taskDiscution.FileId,
                Metadata = taskDiscution.Metadata,
                Deleted = taskDiscution.Deleted,
                Task = taskDiscution.Task,
                User = taskDiscution.User,
                File = taskDiscution.File
            };
        }

        public static TaskComment FromWebApi(WebApiClasses.Classes.TaskComment taskComment)
        {
            try
            {
                if (taskComment == null)
                    return null;

                return new TaskComment
                {
                    Id = taskComment.Id,
                    CreatedAt = taskComment.CreatedAt,
                    UserId = taskComment.UserId,
                    CustomName = taskComment.CustomName,
                    FileId = taskComment.FileId,
                    TaskId = taskComment.TaskId,
                    Text = taskComment.Text,
                    Deleted = taskComment.Deleted ? 1 : (short?)null
                };
            }
            catch
            {
                return null;
            }
        }

        public static TaskComment GetById(int id, wpContext context)
        {
            return context.TaskComments.FirstOrDefault(tc => tc.Id == id);
        }
    }
}
