using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.DataAccess;
using WProject.GenericLibrary.Exceptions;

namespace WProject.Library.Helpers.Utils.Db
{
    public static class DatabaseFactory
    {
        private static string _connectionString;
        public static wpContext NewDbWpContext => new wpContext(ConnectionString);

        public static string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_connectionString))
                    _connectionString = $"Server={Properties.Settings.Default.MysqlServer};" +
                                        $"Port={Properties.Settings.Default.MysqlPort};" +
                                        $"Database={Properties.Settings.Default.MysqlDatabase};" +
                                        $"Uid={Properties.Settings.Default.MysqlUser};" +
                                        $"Pwd={Properties.Settings.Default.MysqlPassword};";

                    return _connectionString;
            }
        }

        public static User Login(string email, string pass)
        {
            using (wpContext mctx = NewDbWpContext)
                return Login(email, pass, mctx);
        }

        public static User Login(string email, string pass, wpContext context)
        {
            pass = GenericLibrary.Helpers.Crypto.Hash.Md5(pass);

            User mu = context.Users.FirstOrDefault(u => u.Email == email &&
                                                        u.Word == pass);

            if(mu == null)
                throw new WpException("User or password is wrong");

            if(mu.Suspended.GetValueOrDefault(0) == 1)
                throw new WpException("User is suspended");

            return mu;
        }
    }
}
