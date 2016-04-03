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
	[Table("backlog")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	[KeyGenerator(KeyGenerator.Autoinc)]
	public partial class Backlog : INotifyPropertyChanging, INotifyPropertyChanged
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
		
		private string _name;
		[Column("name", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, Length = 255, Scale = 0, SqlType = "nvarchar")]
		[Storage("_name")]
		[System.ComponentModel.DataAnnotations.StringLength(255)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if(this._name != value)
				{
					this.OnPropertyChanging("Name");
					this._name = value;
					this.OnPropertyChanged("Name");
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
		
		private int _createdById;
		[Column("created_by", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_createdById")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int CreatedById
		{
			get
			{
				return this._createdById;
			}
			set
			{
				if(this._createdById != value)
				{
					this.OnPropertyChanging("CreatedById");
					this._createdById = value;
					this.OnPropertyChanged("CreatedById");
				}
			}
		}
		
		private int? _assignedToId;
		[Column("assigned_to", OpenAccessType = OpenAccessType.Int32, IsNullable = true, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_assignedToId")]
		public virtual int? AssignedToId
		{
			get
			{
				return this._assignedToId;
			}
			set
			{
				if(this._assignedToId != value)
				{
					this.OnPropertyChanging("AssignedToId");
					this._assignedToId = value;
					this.OnPropertyChanged("AssignedToId");
				}
			}
		}
		
		private int _stateId;
		[Column("state_id", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_stateId")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int StateId
		{
			get
			{
				return this._stateId;
			}
			set
			{
				if(this._stateId != value)
				{
					this.OnPropertyChanging("StateId");
					this._stateId = value;
					this.OnPropertyChanged("StateId");
				}
			}
		}
		
		private int _typeId;
		[Column("type_id", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_typeId")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int TypeId
		{
			get
			{
				return this._typeId;
			}
			set
			{
				if(this._typeId != value)
				{
					this.OnPropertyChanging("TypeId");
					this._typeId = value;
					this.OnPropertyChanged("TypeId");
				}
			}
		}
		
		private int _categoryId;
		[Column("category_id", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_categoryId")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int CategoryId
		{
			get
			{
				return this._categoryId;
			}
			set
			{
				if(this._categoryId != value)
				{
					this.OnPropertyChanging("CategoryId");
					this._categoryId = value;
					this.OnPropertyChanged("CategoryId");
				}
			}
		}
		
		private int? _priority;
		[Column("priority", OpenAccessType = OpenAccessType.Int32, IsNullable = true, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_priority")]
		public virtual int? Priority
		{
			get
			{
				return this._priority;
			}
			set
			{
				if(this._priority != value)
				{
					this.OnPropertyChanging("Priority");
					this._priority = value;
					this.OnPropertyChanged("Priority");
				}
			}
		}
		
		private DateTime? _periodFrom;
		[Column("period_from", OpenAccessType = OpenAccessType.DateTime, IsNullable = true, Length = 0, Scale = 0, SqlType = "datetime")]
		[Storage("_periodFrom")]
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		public virtual DateTime? PeriodFrom
		{
			get
			{
				return this._periodFrom;
			}
			set
			{
				if(this._periodFrom != value)
				{
					this.OnPropertyChanging("PeriodFrom");
					this._periodFrom = value;
					this.OnPropertyChanged("PeriodFrom");
				}
			}
		}
		
		private DateTime? _periodTo;
		[Column("period_to", OpenAccessType = OpenAccessType.DateTime, IsNullable = true, Length = 0, Scale = 0, SqlType = "datetime")]
		[Storage("_periodTo")]
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		public virtual DateTime? PeriodTo
		{
			get
			{
				return this._periodTo;
			}
			set
			{
				if(this._periodTo != value)
				{
					this.OnPropertyChanging("PeriodTo");
					this._periodTo = value;
					this.OnPropertyChanged("PeriodTo");
				}
			}
		}
		
		private uint? _remainingWork;
		[Column("remaining_work", OpenAccessType = OpenAccessType.Int32, IsNullable = true, Length = 0, Scale = 0, SqlType = "integer unsigned")]
		[Storage("_remainingWork")]
		public virtual uint? RemainingWork
		{
			get
			{
				return this._remainingWork;
			}
			set
			{
				if(this._remainingWork != value)
				{
					this.OnPropertyChanging("RemainingWork");
					this._remainingWork = value;
					this.OnPropertyChanged("RemainingWork");
				}
			}
		}
		
		private string _description;
		[Column("description", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "longtext")]
		[Storage("_description")]
		public virtual string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				if(this._description != value)
				{
					this.OnPropertyChanging("Description");
					this._description = value;
					this.OnPropertyChanged("Description");
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
		
		private Category _category;
		[ForeignKeyAssociation(ConstraintName = "backlog_category_FK_category_id", SharedFields = "CategoryId", TargetFields = "Id")]
		[Storage("_category")]
		public virtual Category Category
		{
			get
			{
				return this._category;
			}
			set
			{
				if(this._category != value)
				{
					this.OnPropertyChanging("Category");
					this._category = value;
					this.OnPropertyChanged("Category");
				}
			}
		}
		
		private DictItem _dictItem;
		[ForeignKeyAssociation(ConstraintName = "backlog_dict_item_FK_state_id", SharedFields = "StateId", TargetFields = "Id")]
		[Storage("_dictItem")]
		public virtual DictItem Stage
		{
			get
			{
				return this._dictItem;
			}
			set
			{
				if(this._dictItem != value)
				{
					this.OnPropertyChanging("Stage");
					this._dictItem = value;
					this.OnPropertyChanged("Stage");
				}
			}
		}
		
		private DictItem _dictItem1;
		[ForeignKeyAssociation(ConstraintName = "backlog_dict_item_FK_type_id", SharedFields = "TypeId", TargetFields = "Id")]
		[Storage("_dictItem1")]
		public virtual DictItem Type
		{
			get
			{
				return this._dictItem1;
			}
			set
			{
				if(this._dictItem1 != value)
				{
					this.OnPropertyChanging("Type");
					this._dictItem1 = value;
					this.OnPropertyChanged("Type");
				}
			}
		}
		
		private User _user;
		[ForeignKeyAssociation(ConstraintName = "backlog_user_FK_assigned_to", SharedFields = "AssignedToId", TargetFields = "Id")]
		[Storage("_user")]
		public virtual User AssignedTo
		{
			get
			{
				return this._user;
			}
			set
			{
				if(this._user != value)
				{
					this.OnPropertyChanging("AssignedTo");
					this._user = value;
					this.OnPropertyChanged("AssignedTo");
				}
			}
		}
		
		private User _user1;
		[ForeignKeyAssociation(ConstraintName = "backlog_user_FK_created_by", SharedFields = "CreatedById", TargetFields = "Id")]
		[Storage("_user1")]
		public virtual User CreatedBy
		{
			get
			{
				return this._user1;
			}
			set
			{
				if(this._user1 != value)
				{
					this.OnPropertyChanging("CreatedBy");
					this._user1 = value;
					this.OnPropertyChanged("CreatedBy");
				}
			}
		}
		
		private IList<Task> _tasks = new List<Task>();
		[Collection(InverseProperty = "Backlog")]
		[Storage("_tasks")]
		public virtual IList<Task> Tasks
		{
			get
			{
				return this._tasks;
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
