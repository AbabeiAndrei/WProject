using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class Project : TableNameble
    {
        private const string TABLE_NAME = "project";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public int CreatedById { get; set; }

        public int? OwnerId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public bool Deleted { get; set; }

        public User CreatedBy { get; set; }

        public User Owner { get; set; }

        public new static string TableName => TABLE_NAME;
    }
}
