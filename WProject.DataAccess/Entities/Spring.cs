using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class Spring
    {
        public static Spring GetById(int id, wpContext context)
        {
            return context.Springs.FirstOrDefault(s => s.Id == id);
        }

        public WebApiClasses.Classes.Spring ToWebApi()
        {
            return ToWebApi(this);
        }

        public static WebApiClasses.Classes.Spring ToWebApi(Spring spring)
        {
            try
            {
                if (spring == null)
                    return null;

                return new WebApiClasses.Classes.Spring
                {
                    Name = spring.Name,
                    CreatedAt = spring.CreatedAt,
                    CreatedById = spring.CreatedById,
                    Deleted = spring.Deleted.GetValueOrDefault() == 1,
                    Description = spring.Description,
                    From = spring.PeriodFrom,
                    To = spring.PeriodTo,
                    Id = spring.Id,
                    OwnderId = spring.OwnerId,
                    ProjectId = spring.ProjectId
                };
            }
            catch 
            {
                return null;
            }
        }

        public static WebApiClasses.Classes.Spring ToWebApi(Spring spring, wpContext context)
        {
            var ms = ToWebApi(spring);

            if (ms == null)
                return null;

            var msp = GetById(spring.Id, context);

            if (msp == null)
                return ms;

            ms.Project = Project.ToWebApi(msp.Project);
            ms.Owner = User.ToWebApi(msp.Owner);
            ms.CreatedBy = User.ToWebApi(msp.CreatedBy);
            ms.Categories = context.Categories
                                   .Where(c => !c.ParentId.HasValue &&
                                                c.SpringId == ms.Id && 
                                                c.Deleted.GetValueOrDefault() == 0)
                                   .ToList()
                                   .Select(c => Category.ToWebApi(c, context))
                                   .ToList();
                                                        

            return ms;
        }
    }
}
