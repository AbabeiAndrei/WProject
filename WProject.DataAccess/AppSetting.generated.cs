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
	[Table("app_setting")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	public partial class AppSetting : INotifyPropertyChanging, INotifyPropertyChanged
	{
		private int _id;
		[Column("id", OpenAccessType = OpenAccessType.Int32, IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "integer")]
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
		
		private string _key;
		[Column("key", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, Length = 128, Scale = 0, SqlType = "nvarchar")]
		[Storage("_key")]
		[System.ComponentModel.DataAnnotations.StringLength(128)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Key
		{
			get
			{
				return this._key;
			}
			set
			{
				if(this._key != value)
				{
					this.OnPropertyChanging("Key");
					this._key = value;
					this.OnPropertyChanged("Key");
				}
			}
		}
		
		private string _value;
		[Column("value", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_value")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				if(this._value != value)
				{
					this.OnPropertyChanging("Value");
					this._value = value;
					this.OnPropertyChanged("Value");
				}
			}
		}
		
		private DateTime? _lastUpdatedAt;
		[Column("last_updated_at", OpenAccessType = OpenAccessType.DateTime, IsNullable = true, Length = 0, Scale = 0, SqlType = "datetime")]
		[Storage("_lastUpdatedAt")]
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		public virtual DateTime? LastUpdatedAt
		{
			get
			{
				return this._lastUpdatedAt;
			}
			set
			{
				if(this._lastUpdatedAt != value)
				{
					this.OnPropertyChanging("LastUpdatedAt");
					this._lastUpdatedAt = value;
					this.OnPropertyChanged("LastUpdatedAt");
				}
			}
		}
		
		private int? _lastUpdatedById;
		[Column("last_updated_by", OpenAccessType = OpenAccessType.Int32, IsNullable = true, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_lastUpdatedById")]
		public virtual int? LastUpdatedById
		{
			get
			{
				return this._lastUpdatedById;
			}
			set
			{
				if(this._lastUpdatedById != value)
				{
					this.OnPropertyChanging("LastUpdatedById");
					this._lastUpdatedById = value;
					this.OnPropertyChanged("LastUpdatedById");
				}
			}
		}
		
		private string _comment;
		[Column("comment", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_comment")]
		public virtual string Comment
		{
			get
			{
				return this._comment;
			}
			set
			{
				if(this._comment != value)
				{
					this.OnPropertyChanging("Comment");
					this._comment = value;
					this.OnPropertyChanged("Comment");
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
		
		private User _user;
		[ForeignKeyAssociation(ConstraintName = "app_setting_user_FK_last_updated_by", SharedFields = "LastUpdatedById", TargetFields = "Id")]
		[Storage("_user")]
		public virtual User LastUpdatedBy
		{
			get
			{
				return this._user;
			}
			set
			{
				if(this._user != value)
				{
					this.OnPropertyChanging("LastUpdatedBy");
					this._user = value;
					this.OnPropertyChanged("LastUpdatedBy");
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
