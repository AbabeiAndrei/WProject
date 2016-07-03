using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WProject.WebApiClasses.Classes;

namespace WProject.WebApiClasses.Data
{
    public class RefreshDashboardInfo
    {
        public bool RefreshAll { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        public IEnumerable<Backlog> Backlogs { get; set; }
    }
}
