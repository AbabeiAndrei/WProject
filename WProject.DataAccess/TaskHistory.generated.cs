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
	[Table("task_history")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	[KeyGenerator(KeyGenerator.Autoinc)]
	public partial class TaskHistory : INotifyPropertyChanging, INotifyPropertyChanged
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
		
		private DateTime _updatedAt;
		[Column("updated_at", OpenAccessType = OpenAccessType.DateTime, Length = 0, Scale = 0, SqlType = "datetime")]
		[Storage("_updatedAt")]
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual DateTime UpdatedAt
		{
			get
			{
				return this._updatedAt;
			}
			set
			{
				if(this._updatedAt != value)
				{
					this.OnPropertyChanging("UpdatedAt");
					this._updatedAt = value;
					this.OnPropertyChanged("UpdatedAt");
				}
			}
		}
		
		private int _updatedBy;
		[Column("updated_by", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_updatedBy")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int UpdatedBy
		{
			get
			{
				return this._updatedBy;
			}
			set
			{
				if(this._updatedBy != value)
				{
					this.OnPropertyChanging("UpdatedBy");
					this._updatedBy = value;
					this.OnPropertyChanged("UpdatedBy");
				}
			}
		}
		
		private string _fieldName;
		[Column("field_name", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, Length = 255, Scale = 0, SqlType = "nvarchar")]
		[Storage("_fieldName")]
		[System.ComponentModel.DataAnnotations.StringLength(255)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string FieldName
		{
			get
			{
				return this._fieldName;
			}
			set
			{
				if(this._fieldName != value)
				{
					this.OnPropertyChanging("FieldName");
					this._fieldName = value;
					this.OnPropertyChanged("FieldName");
				}
			}
		}
		
		private string _fieldOldValue;
		[Column("field_old_value", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "longtext")]
		[Storage("_fieldOldValue")]
		public virtual string FieldOldValue
		{
			get
			{
				return this._fieldOldValue;
			}
			set
			{
				if(this._fieldOldValue != value)
				{
					this.OnPropertyChanging("FieldOldValue");
					this._fieldOldValue = value;
					this.OnPropertyChanged("FieldOldValue");
				}
			}
		}
		
		private string _fieldNewValue;
		[Column("field_new_value", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, Length = 0, Scale = 0, SqlType = "longtext")]
		[Storage("_fieldNewValue")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string FieldNewValue
		{
			get
			{
				return this._fieldNewValue;
			}
			set
			{
				if(this._fieldNewValue != value)
				{
					this.OnPropertyChanging("FieldNewValue");
					this._fieldNewValue = value;
					this.OnPropertyChanged("FieldNewValue");
				}
			}
		}
		
		private string _comments;
		[Column("comments", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_comments")]
		public virtual string Comments
		{
			get
			{
				return this._comments;
			}
			set
			{
				if(this._comments != value)
				{
					this.OnPropertyChanging("Comments");
					this._comments = value;
					this.OnPropertyChanged("Comments");
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
		
		private string _changeStamp;
		[Column("change_stamp", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, Length = 64, Scale = 0, SqlType = "nvarchar")]
		[Storage("_changeStamp")]
		[System.ComponentModel.DataAnnotations.StringLength(64)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string ChangeStamp
		{
			get
			{
				return this._changeStamp;
			}
			set
			{
				if(this._changeStamp != value)
				{
					this.OnPropertyChanging("ChangeStamp");
					this._changeStamp = value;
					this.OnPropertyChanged("ChangeStamp");
				}
			}
		}
		
		private Task _task;
		[ForeignKeyAssociation(ConstraintName = "task_history_task_FK_task_id", SharedFields = "TaskId", TargetFields = "Id")]
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
		
		private User _user;
		[ForeignKeyAssociation(ConstraintName = "task_history_user_FK_updated_by", SharedFields = "UpdatedBy", TargetFields = "Id")]
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
