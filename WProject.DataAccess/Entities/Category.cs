using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.GenericLibrary.Helpers.Log;

namespace WProject.DataAccess
{
    public partial class Category
    {
        public static Category GetById(int id, wpContext context)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public WebApiClasses.Classes.Category ToWebApi()
        {
            return ToWebApi(this);
        }

        public static WebApiClasses.Classes.Category ToWebApi(Category category)
        {
            try
            {
                if (category == null)
                    return null;

                return new WebApiClasses.Classes.Category
                {
                    Name = category.Name,
                    Id = category.Id,
                    CreatedAt = category.CreatedAt,
                    CreatedById = category.CreatedById,
                    Description = category.Description,
                    OwnerId =  category.OwnerId,
                    From = category.PeriodFrom,
                    To = category.PeriodTo,
                    SpringId = category.SpringId,
                    ParentId = category.ParentId,
                    Deleted = category.Deleted.GetValueOrDefault() == 1
                };
            }
            catch 
            {
                return null;
            }
        }

        public static WebApiClasses.Classes.Category ToWebApi(Category category, wpContext context)
        {
            var mc = ToWebApi(category);

            if (mc == null)
                return null;

            var mcs = GetById(mc.Id, context);

            if (mcs == null)
                return mc;

            mc.Owner = User.ToWebApi(mcs.Owner);
            mc.CreatedBy = User.ToWebApi(mcs.CreatedBy);
            mc.Spring = Spring.ToWebApi(mcs.Spring);
            mc.Parent = ToWebApi(mcs.Parent);
            if(mcs.Subategories.Count > 0)
                mc.SubCategories = context.Categories
                                          .Where(c => c.ParentId.HasValue && 
                                                      c.ParentId.Value == mc.Id)
                                          .Select(c => ToWebApi(c, context))
                                          .ToList();
            
            return mc;
        }
    }
}
