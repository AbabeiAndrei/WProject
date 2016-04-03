using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public partial class File
    {
        public const string PARENT_TYPE_USER_AVATAR = "USER";
        public const string TYPE_USER_AVATAR = "USER_AVATAR";

        public WebApiClasses.Classes.File ToWebApi()
        {
            return ToWebApi(this);
        }

        public static WebApiClasses.Classes.File ToWebApi(File file)
        {
            try
            {
                if (file == null)
                    return null;

                return new WebApiClasses.Classes.File
                {
                    Id = file.Id,
                    Name = file.Name,
                    Type = file.Type,
                    Content = file.Content,
                    Thumbmail = file.Thumbnail,
                    Size = file.Size,
                    ParentType = file.ParentType,
                    ParentId = file.ParentId,
                    Metadata = file.Metadata,
                    Path = file.Path,
                    Url = file.Url,
                    CreatedAt = file.CreatedAt,
                    CreatedById = file.CreatedBy,
                    Deleted = false //todo
                };
            }
            catch 
            {
                return null;
            }
        }
    }
}
