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

        public new static string TableName => TABLE_NAME;
    }
}
