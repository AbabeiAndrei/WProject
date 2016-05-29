using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WProject.WebApiClasses.Classes
{
    public class TaskHistory
    {
        public int Id { get; set; }

        public string ChangeStamp { get; set; }

        public int TaskId { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UpdatedById { get; set; }

        public string FieldName { get; set; }
        
        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public string Comments { get; set; }

        public string Metadata { get; set; }

        public bool Deleted { get; set; }

        public Task Task { get; set; }

        public User UpdatedBy { get; set; }
    }
}
