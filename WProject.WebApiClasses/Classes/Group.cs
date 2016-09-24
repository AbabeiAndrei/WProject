using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.WebApiClasses.Classes
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public int OwnedById { get; set; }

        public bool Deleted { get; set; }

        public User OwnedBy { get; set; }
    }
}
