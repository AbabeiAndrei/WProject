using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;

namespace WProject.DataAccess
{
    public partial class User : IGenericEntity<User>
    {
        public const string FILE_IS_USER_AVATAR = "USER_AVATAR";

        public static User GetById(int id, wpContext context, bool detached = false)
        {
            try
            {
                return context.Users.FirstOrDefault(u => u.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public File Avatar
        {
            get
            {
                return Files.FirstOrDefault(f => f.ParentType == FILE_IS_USER_AVATAR && f.ParentId == Id);
            }
        }

        public static WebApiClasses.Classes.User ToWebApi(User user)
        {
            try
            {
                if (user == null)
                    return null;

                return new WebApiClasses.Classes.User
                {
                    Name = user.Name,
                    Id = user.Id,
                    Deleted = user.Deleted.GetValueOrDefault() != 1,
                    Email = user.Email,
                    Expire = user.Expire,
                    Login = user.Login,
                    Password = user.Word,
                    SuperUser = user.Su.GetValueOrDefault() == 1,
                    Suspended = user.Suspended.GetValueOrDefault() == 1,
                    Metadata = user.Metadata
                };
            }
            catch
            {
                return null;
            }
        }

        public static WebApiClasses.Classes.User ToWebApi(User user, wpContext context)
        {
            var mu = ToWebApi(user);

            if (mu == null)
                return null;

            mu.Avatar = File.ToWebApi(context.Files
                                             .FirstOrDefault(f => f.ParentId.HasValue &&
                                                                  f.ParentId.Value == mu.Id &&
                                                                  f.ParentType == File.PARENT_TYPE_USER_AVATAR &&
                                                                  f.Type == File.TYPE_USER_AVATAR));

            return mu;
        }
    }
}
