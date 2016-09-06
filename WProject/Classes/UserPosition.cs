using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Classes;

namespace WProject.Classes
{
    public class UserPosition
    {
        public int UserId { get; set; }
        public int Top { get; set; }
        public int Height { get; set; }

        public IEnumerable<BacklogPosition> Positions { get; set; }

        public UserPosition()
        {
        }

        public UserPosition(int userId, int top)
        {
            UserId = userId;
            Top = top;
        }
    }

    public class BacklogPosition
    {
        public int BacklogId { get; set; }
        public int Top { get; set; }

        public BacklogPosition()
        {
        }

        public BacklogPosition(int backlogId, int top)
        {
            BacklogId = backlogId;
            Top = top;
        }
    }
}
