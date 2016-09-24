using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class Group
    {
        public static WebApiClasses.Classes.Group ToWebApi(Group group)
        {
            try
            {
                if (group == null)
                    return null;

                return new WebApiClasses.Classes.Group
                {
                    Id = group.Id,
                    Name = group.Name,
                    Description = group.Description,
                    Created = group.Created,
                    OwnedById = group.OwnerId,
                    Deleted = group.Deleted.GetValueOrDefault() == 1
                };
            }
            catch
            {
                return null;
            }
        }

        public static Group FromWebApi(WebApiClasses.Classes.Group group)
        {
            try
            {
                if (group == null)
                    return null;

                return new Group
                {
                    Id = group.Id,
                    Name = group.Name,
                    Description = group.Description,
                    Created = group.Created,
                    OwnerId= group.OwnedById,
                    Deleted = group.Deleted ? 1 : (short?)null
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
