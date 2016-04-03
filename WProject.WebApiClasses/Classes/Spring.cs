using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class Spring : TableNameble
    {
        private const string TABLE_NAME = "spring";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }

        public int OwnderId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public int ProjectId { get; set; }

        public bool Deleted { get; set; }

        public User CreatedBy { get; set; }

        public User Owner { get; set; }

        public Project Project { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public Spring()
        {
            Categories = Enumerable.Empty<Category>();
        }

        public new static string TableName => TABLE_NAME;
    }
}
