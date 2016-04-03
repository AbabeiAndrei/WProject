using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class Project
    {
        public static WebApiClasses.Classes.Project ToWebApi(Project project)
        {
            try
            {
                if (project == null)
                    return null;

                return new WebApiClasses.Classes.Project
                {
                    Name = project.Name,
                    Id = project.Id,
                    From = project.PeriodFrom,
                    OwnerId = project.OwnerId,
                    Deleted = project.Deleted.GetValueOrDefault() != 0,
                    Created = project.CreatedAt,
                    CreatedById = project.CreatedById,
                    CreatedBy = User.ToWebApi(project.CreatedBy),
                    Description = project.Description,
                    Owner = User.ToWebApi(project.Owner),
                    To = project.PeriodTo
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
