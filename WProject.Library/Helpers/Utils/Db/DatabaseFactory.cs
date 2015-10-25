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
        public static WModel NewDbWpContext => new WModel();

        public static User Login(string email, string pass)
        {
            using (WModel mctx = NewDbWpContext)
                return Login(email, pass, mctx);
        }

        public static User Login(string email, string pass, WModel context)
        {
            pass = GenericLibrary.Helpers.Crypto.Hash.Md5(pass);

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
