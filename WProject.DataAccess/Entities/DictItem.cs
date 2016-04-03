using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.GenericLibrary.Helpers.Drawing;

namespace WProject.DataAccess
{
    public partial class DictItem
    {
        public static DictItem GetById(int id, wpContext context)
        {
            return context.DictItems.FirstOrDefault(di => di.Id == id);
        }

        public WebApiClasses.Classes.DictItem ToWebApi()
        {
            return ToWebApi(this);
        }

        public static WebApiClasses.Classes.DictItem ToWebApi(DictItem dictItem)
        {
            try
            {
                if (dictItem == null)
                    return null;

                return new WebApiClasses.Classes.DictItem
                {
                    Id = dictItem.Id,
                    Name = dictItem.Name,
                    Description = dictItem.Description,
                    Type = dictItem.Type,
                    ParentId = dictItem.ParentId,
                    Reserved = dictItem.Reserved.GetValueOrDefault() == 1,
                    Code = dictItem.Code,
                    Order = dictItem.Order,
                    Color = GraphicsHelper.TryParse(dictItem.Color, System.Drawing.Color.Empty),
                    Tag = dictItem.Tag,
                    Deleted = dictItem.Deleted.GetValueOrDefault() == 1
                };
            }
            catch 
            {
                return null;
            }
        }
    }
}
