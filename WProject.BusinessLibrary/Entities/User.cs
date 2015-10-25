using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.BusinessLibrary
{
    public partial class User
    {
        public static User GetById(int uid, WModel context)
        {
            return context.Users.FirstOrDefault(u => u.Id == uid);
        }
    }
}
