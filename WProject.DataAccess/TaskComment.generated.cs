#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using System.ComponentModel;
using WProject.DataAccess;

namespace WProject.DataAccess	
{
	[Table("task_comment")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	public partial class TaskComment : INotifyPropertyChanging, INotifyPropertyChanged
	{
		private int _id;
		[Column("id", OpenAccessType = OpenAccessType.Int32, IsBackendCalculated = true, IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_id")]
		[System.ComponentModel.DataAnnotations.Required()]
		[System.ComponentModel.DataAnnotations.Key()]
		public virtual int Id
		{
			get
			{
				return this._id;
			}
			set
			{
				if(this._id != value)
				{
					this.OnPropertyChanging("Id");
					this._id = value;
					this.OnPropertyChanged("Id");
				}
			}
		}
		
		private int _taskId;
		[Column("task_id", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_taskId")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int TaskId
		{
			get
			{
				return this._taskId;
			}
			set
			{
				if(this._taskId != value)
				{
					this.OnPropertyChanging("TaskId");
					this._taskId = value;
					this.OnPropertyChanged("TaskId");
				}
			}
		}
		
		private int _userId;
		[Column("user_id", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_userId")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int UserId
		{
			get
			{
				return this._userId;
			}
			set
			{
				if(this._userId != value)
				{
					this.OnPropertyChanging("UserId");
					this._userId = value;
					this.OnPropertyChanged("UserId");
				}
			}
		}
		
		private DateTime _createdAt;
		[Column("created_at", OpenAccessType = OpenAccessType.DateTime, Length = 0, Scale = 0, SqlType = "datetime")]
		[Storage("_createdAt")]
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual DateTime CreatedAt
		{
			get
			{
				return this._createdAt;
			}
			set
			{
				if(this._createdAt != value)
				{
					this.OnPropertyChanging("CreatedAt");
					this._createdAt = value;
					this.OnPropertyChanged("CreatedAt");
				}
			}
		}
		
		private string _text;
		[Column("text", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_text")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				if(this._text != value)
				{
					this.OnPropertyChanging("Text");
					this._text = value;
					this.OnPropertyChanged("Text");
				}
			}
		}
		
		private short? _deleted;
		[Column("deleted", OpenAccessType = OpenAccessType.Byte, IsNullable = true, Length = 0, Scale = 0, SqlType = "tinyint")]
		[Storage("_deleted")]
		public virtual short? Deleted
		{
			get
			{
				return this._deleted;
			}
			set
			{
				if(this._deleted != value)
				{
					this.OnPropertyChanging("Deleted");
					this._deleted = value;
					this.OnPropertyChanged("Deleted");
				}
			}
		}
		
		private string _metadata;
		[Column("metadata", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_metadata")]
		public virtual string Metadata
		{
			get
			{
				return this._metadata;
			}
			set
			{
				if(this._metadata != value)
				{
					this.OnPropertyChanging("Metadata");
					this._metadata = value;
					this.OnPropertyChanged("Metadata");
				}
			}
		}
		
		private int? _fileId;
		[Column("file_id", OpenAccessType = OpenAccessType.Int32, IsNullable = true, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_fileId")]
		public virtual int? FileId
		{
			get
			{
				return this._fileId;
			}
			set
			{
				if(this._fileId != value)
				{
					this.OnPropertyChanging("FileId");
					this._fileId = value;
					this.OnPropertyChanged("FileId");
				}
			}
		}
		
		private string _customName;
		[Column("custom_name", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_customName")]
		public virtual string CustomName
		{
			get
			{
				return this._customName;
			}
			set
			{
				if(this._customName != value)
				{
					this.OnPropertyChanging("CustomName");
					this._customName = value;
					this.OnPropertyChanged("CustomName");
				}
			}
		}
		
		private User _user;
		[ForeignKeyAssociation(ConstraintName = "task_comment_user_id_FK_user", SharedFields = "UserId", TargetFields = "Id")]
		[Storage("_user")]
		public virtual User User
		{
			get
			{
				return this._user;
			}
			set
			{
				if(this._user != value)
				{
					this.OnPropertyChanging("User");
					this._user = value;
					this.OnPropertyChanged("User");
				}
			}
		}
		
		private Task _task;
		[ForeignKeyAssociation(ConstraintName = "task_comment_task_id_FK_task", SharedFields = "TaskId", TargetFields = "Id")]
		[Storage("_task")]
		public virtual Task Task
		{
			get
			{
				return this._task;
			}
			set
			{
				if(this._task != value)
				{
					this.OnPropertyChanging("Task");
					this._task = value;
					this.OnPropertyChanged("Task");
				}
			}
		}
		
		private File _file;
		[ForeignKeyAssociation(ConstraintName = "task_comment_file_id_FK_file", SharedFields = "FileId", TargetFields = "Id")]
		[Storage("_file")]
		public virtual File File
		{
			get
			{
				return this._file;
			}
			set
			{
				if(this._file != value)
				{
					this.OnPropertyChanging("File");
					this._file = value;
					this.OnPropertyChanged("File");
				}
			}
		}
		
		#region INotifyPropertyChanging members
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		protected virtual void OnPropertyChanging(string propertyName)
		{
			if(this.PropertyChanging != null)
			{
				this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
			}
		}
		
		#endregion
		
		#region INotifyPropertyChanged members
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if(this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		#endregion
		
	}
}
#pragma warning restore 1591
