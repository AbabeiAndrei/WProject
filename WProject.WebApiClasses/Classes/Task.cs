﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class Task : TableNameble
    {
        public const string TABLE_NAME = "task";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }

        public int? AssignedToId { get; set; }

        public int UpdatedById { get; set; }

        public int StateId { get; set; }

        public int TypeId { get; set; }

        public int? StageId { get; set; }

        public int BacklogId { get; set; }

        public int? Priority { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        /// <summary>
        /// In Minutes
        /// </summary>
        public int? RemainingWork { get; set; }

        public string Metadata { get; set; }

        public TimeSpan? StartHour { get; set; }

        public TimeSpan? EndHour { get; set; }

        public DateTime? WorkDate { get; set; }

        public bool Deleted { get; set; }

        public User CreatedBy { get; set; }

        public User AssignedTo { get; set; }

        public DictItem State { get; set; }
        
        public DictItem Type { get; set; }

        public DictItem Stage { get; set; }

        public Backlog Backlog { get; set; }

        public IEnumerable<TaskComment> Comments { get; set; }

        public IEnumerable<TaskComment> Discusion { get; set; }

        public IEnumerable<TaskAttachement> Attachments { get; set; }

        public IEnumerable<TaskHistory> Changes { get; set; }

        public new static string TableName => TABLE_NAME;

        public string FullName => $"Task {Id} {Name}";

        public bool InTodoOrInProgress => State != null && (State.Code == States.TO_DO_CODE || State.Code == States.IN_PROGRESS_CODE);

        public bool IsDone => State?.Code == States.DONE_CODE;

        public bool IsRemoved => State?.Code == States.REMOVED_CODE;

        public static class Types
        {
            public const string TASK = "TASK";
            public const string BUG = "BUG";
        }

        public static class States
        {
            public const string TO_DO_CODE = "TO_DO";
            public const string IN_PROGRESS_CODE = "IN_PROGR";
            public const string DONE_CODE = "DONE";
            public const string REMOVED_CODE = "REMOVED";
        }
    }
}
