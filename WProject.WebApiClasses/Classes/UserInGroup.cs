using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.WebApiClasses.Classes
{
    public class UserInGroup
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public DateTime Added { get; set; }

        public int? AddedById { get; set; }

        public string Coments { get; set; }

        public string Metadata { get; set; }

        public bool Deleted { get; set; }

        public User User { get; set; }

        public Group Group { get; set; }
    }
}
