using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Classes;

namespace WProject.Classes
{
    public static class WPSuite
    {
        public static User ConnectedUser { get; set; }
        public static Project SelectedProject { get; set; }
        public static Spring SelectedSpring { get; set; }
        public static Category SelectedCategory { get; set; }

        public static int ConnectedUserId => ConnectedUser?.Id ?? 0;
    }
}
