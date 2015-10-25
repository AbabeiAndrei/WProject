using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.BusinessLibrary;

namespace WProject.Library.Helpers.Utils.Db
{
    public static class DatabaseFactory
    {
        public static WPModel NewDbWpContext => new WPModel();

        public static User Login(string email, string pass)
        {
            using (WPModel mctx = NewDbWpContext)
                return Login(email, pass, mctx);
        }

        public static User Login(string email, string pass, WPModel context)
        {
            var mu = context.Users.FirstOrDefault(u => u.Email == email &&
                                                       u.Word == pass);

            if(mu == null)
                throw new Exception("User or password is wrong");

            if(mu.Suspended.GetValueOrDefault(false))
                throw new Exception("User is suspended");

            return mu;
        }
    }
}
