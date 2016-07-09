using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class Backlog : TableNameble
    {
        private const string TABLE_NAME = "backlog";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }

        public int? AssignedToId { get; set; }

        public int StateId { get; set; }

        public int TypeId { get; set; }

        public int CategoryId { get; set; }

        public int? Priority { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        /// <summary>
        /// In minutes
        /// </summary>
        public int? RemainingWork { get; set; }

        public string Metadata { get; set; }

        public IEnumerable<string> Tags { get; set;}

        public bool Deleted { get; set; }

        public User CreatedBy { get; set; }

        public User AssignedTo { get; set; }

        public DictItem State { get; set; }

        public DictItem Type { get; set; }

        public Category Category { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        public new static string TableName => TABLE_NAME;

        public string FullName => $"Backlog {Id}";

        public static class Types
        {
            public const string BACKLOG = "BACKLOG";
            public const string BACKLOG_BUG = "BACKLOG_BUG";
        }

        public static class States
        {
            public const string BCK_STATE_TO_DO = "BCK_STATE_TO_DO";
            public const string BCK_STATE_IN_PROGR = "BCK_STATE_IN_PROGR";
            public const string BCK_STATE_REMOVED = "BCK_STATE_REMOVED";
            public const string BCK_STATE_DONE = "BCK_STATE_DONE";

        }
    }
}
