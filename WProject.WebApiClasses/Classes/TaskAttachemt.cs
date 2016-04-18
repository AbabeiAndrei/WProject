using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class TaskAttachemt : TableNameble
    {
        public const string TABLE_NAME = "task_comment";

        public new static string TableName => TABLE_NAME;

        public int Id { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }
        
        public int FileId { get; set; }

        public File File { get; set; }
    }
}
