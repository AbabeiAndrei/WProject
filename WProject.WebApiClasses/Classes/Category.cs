using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class Category : TableNameble
    {
        private const string TABLE_NAME = "category";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }

        public int OwnerId { get; set; }

        public DateTime? From {get; set; }

        public DateTime? To { get; set; }

        public int SpringId { get; set; }

        public int? ParentId { get; set; }

        public bool Deleted { get; set; }

        public User CreatedBy { get; set; }

        public User Owner { get; set; }

        public Spring Spring { get; set; }

        public Category Parent { get; set; }

        public IEnumerable<Category> SubCategories { get; set; }

        public Category()
        {
            SubCategories = Enumerable.Empty<Category>();
        }

        public new static string TableName => TABLE_NAME;
    }
}
