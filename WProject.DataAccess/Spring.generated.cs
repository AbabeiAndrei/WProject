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
	[Table("spring")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	[KeyGenerator(KeyGenerator.Autoinc)]
	public partial class Spring : INotifyPropertyChanging, INotifyPropertyChanged
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
		
		private string _description;
		[Column("description", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "text")]
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
		
		private int _ownerId;
		[Column("owner_id", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_ownerId")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int OwnerId
		{
			get
			{
				return this._ownerId;
			}
			set
			{
				if(this._ownerId != value)
				{
					this.OnPropertyChanging("OwnerId");
					this._ownerId = value;
					this.OnPropertyChanged("OwnerId");
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
		
		private int _projectId;
		[Column("project_id", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_projectId")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int ProjectId
		{
			get
			{
				return this._projectId;
			}
			set
			{
				if(this._projectId != value)
				{
					this.OnPropertyChanging("ProjectId");
					this._projectId = value;
					this.OnPropertyChanged("ProjectId");
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
		
		private Project _project;
		[ForeignKeyAssociation(ConstraintName = "spring_project_FK_project_id", SharedFields = "ProjectId", TargetFields = "Id")]
		[Storage("_project")]
		public virtual Project Project
		{
			get
			{
				return this._project;
			}
			set
			{
				if(this._project != value)
				{
					this.OnPropertyChanging("Project");
					this._project = value;
					this.OnPropertyChanged("Project");
				}
			}
		}
		
		private User _user;
		[ForeignKeyAssociation(ConstraintName = "spring_user_FK_created_by", SharedFields = "CreatedById", TargetFields = "Id")]
		[Storage("_user")]
		public virtual User CreatedBy
		{
			get
			{
				return this._user;
			}
			set
			{
				if(this._user != value)
				{
					this.OnPropertyChanging("CreatedBy");
					this._user = value;
					this.OnPropertyChanged("CreatedBy");
				}
			}
		}
		
		private User _user1;
		[ForeignKeyAssociation(ConstraintName = "spring_user_FK_owner_id", SharedFields = "OwnerId", TargetFields = "Id")]
		[Storage("_user1")]
		public virtual User Owner
		{
			get
			{
				return this._user1;
			}
			set
			{
				if(this._user1 != value)
				{
					this.OnPropertyChanging("Owner");
					this._user1 = value;
					this.OnPropertyChanged("Owner");
				}
			}
		}
		
		private IList<Category> _categories = new List<Category>();
		[Collection(InverseProperty = "Spring")]
		[Storage("_categories")]
		public virtual IList<Category> Categories
		{
			get
			{
				return this._categories;
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
