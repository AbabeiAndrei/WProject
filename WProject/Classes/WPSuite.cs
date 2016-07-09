using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Classes
{
    public static class WPSuite
    {
        public static User ConnectedUser { get; set; }
        public static Project SelectedProject { get; set; }
        public static Spring SelectedSpring { get; set; }
        public static Category SelectedCategory { get; set; }

        public static int ConnectedUserId => ConnectedUser?.Id ?? 0;

        public static Task CreateTask(Backlog backlog)
        {
            return new Task
            {
                BacklogId = backlog.Id,
                CreatedAt = DateTime.Now,
                CreatedById = ConnectedUserId,
                TypeId = GetTaskTypeId()
            };
        }

        private static int GetTaskTypeId()
        {
            return SimpleCache.GetAll<DictItem>()
                              .FirstOrDefault(di => di.Type == DictItem.Types.TaskType && di.Code == Task.Types.TASK)?
                              .Id ?? 0;
        }

        public static Backlog CreateBacklog(Category category)
        {
            return new Backlog
            {
                CategoryId = category.Id,
                CreatedAt = DateTime.Now,
                CreatedById = ConnectedUserId,
                TypeId = GetBacklogTypeId()
            };
        }
        private static int GetBacklogTypeId()
        {
            return SimpleCache.GetAll<DictItem>()
                              .FirstOrDefault(di => di.Type == DictItem.Types.BacklogType && di.Code == Backlog.Types.BACKLOG)?
                              .Id ?? 0;
        }
    }
}
