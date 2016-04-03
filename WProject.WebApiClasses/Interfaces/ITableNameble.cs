using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WProject.WebApiClasses.Interfaces
{
    public class TableNameble
    {
        [JsonIgnore]
        public static string TableName { get; }

        static TableNameble()
        {
            TableName = string.Empty;
        }
    }
}
