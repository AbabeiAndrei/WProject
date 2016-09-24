using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.WebApiClasses.Classes;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Interfaces
{
    public interface ITaskAddableControl
    {
        int AddTasks(IEnumerable<Task> tasks, int backlogId, int userId);
        Control AddUser(int userId);
        Control AddBackLog(int userId, int backlogId);
    }
}
