using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class DictItem :TableNameble
    {
        private const string TABLE_NAME = "dict_item";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set;}

        public string Type { get; set; }

        public int? ParentId { get; set; }

        public bool Reserved { get; set; }

        public string Code { get; set; }

        public int? Order { get; set; }

        public Color? Color { get; set; }

        public string Tag { get; set; }

        public bool Deleted { get; set; }

        public DictItem Parent { get; set; }

        public bool IsType(string type)
        {
            return OfType(this, type);
        }

        public new static string TableName => TABLE_NAME;

        public static class Types
        {
            private const string TSK_TYPE = "TSK_TYPE";
            private const string TSK_STATE = "TSK_STATE";
            private const string TSK_ACTIVITY = "TSK_ACTIVITY";
            private const string BCK_TYPE = "BCK_TYPE";
            private const string BCK_STATE = "BCK_STATE";

            public static string TaskType => TSK_TYPE;
            public static string TaskState => TSK_STATE;
            public static string TaskActivity => TSK_ACTIVITY;
            public static string BacklogType => BCK_TYPE;
            public static string BacklogState => BCK_STATE;
        }

        public static bool OfType(DictItem di, string type)
        {
            return di.Type == type;
        }
    }
}
