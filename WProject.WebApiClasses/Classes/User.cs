using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class User : TableNameble
    {
        private const string TABLE_NAME = "user";
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime? Expire { get; set; }

        public bool Suspended { get; set; }

        public bool SuperUser { get; set; }

        public string Metadata { get; set; }

        public bool Deleted { get; set; }

        public File Avatar { get; set; }

        public new static string TableName => TABLE_NAME;

        public static User None { get; }

        static User()
        {
            None = new User
            {
                Name = "None"
            };
        }
    }
}
