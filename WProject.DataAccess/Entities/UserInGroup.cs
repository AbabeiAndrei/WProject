using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class UserInGroup
    {
        public static WebApiClasses.Classes.UserInGroup ToWebApi(UserInGroup obj)
        {
            try
            {
                if (obj == null)
                    return null;

                return new WebApiClasses.Classes.UserInGroup
                {
                    Id = obj.Id,
                    UserId = obj.UserId,
                    GroupId = obj.GroupId,
                    Added = obj.Added,
                    AddedById = obj.AddedById,
                    Coments = obj.Comments,
                    Metadata = obj.Metadata,
                    Deleted = obj.Deleted.GetValueOrDefault() == 1
                };
            }
            catch
            {
                return null;
            }
        }
        public static UserInGroup FromWebApi(WebApiClasses.Classes.UserInGroup obj)
        {
            try
            {
                if (obj == null)
                    return null;

                return new UserInGroup
                {
                    Id = obj.Id,
                    UserId = obj.UserId,
                    GroupId = obj.GroupId,
                    Added = obj.Added,
                    AddedById = obj.AddedById,
                    Comments= obj.Coments,
                    Metadata = obj.Metadata,
                    Deleted = obj.Deleted ? 1 : (short?)null
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
