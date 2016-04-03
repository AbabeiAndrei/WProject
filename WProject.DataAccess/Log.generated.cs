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
	[Table("log")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	[KeyGenerator(KeyGenerator.Autoinc)]
	public partial class Log : INotifyPropertyChanging, INotifyPropertyChanged
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
		
		private DateTime? _date;
		[Column("date", OpenAccessType = OpenAccessType.DateTime, IsNullable = true, Length = 6, Scale = 0, SqlType = "datetime")]
		[Storage("_date")]
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		public virtual DateTime? Date
		{
			get
			{
				return this._date;
			}
			set
			{
				if(this._date != value)
				{
					this.OnPropertyChanging("Date");
					this._date = value;
					this.OnPropertyChanged("Date");
				}
			}
		}
		
		private short? _entryType;
		[Column("entry_type", OpenAccessType = OpenAccessType.Byte, IsNullable = true, Length = 0, Scale = 0, SqlType = "tinyint")]
		[Storage("_entryType")]
		public virtual short? EntryType
		{
			get
			{
				return this._entryType;
			}
			set
			{
				if(this._entryType != value)
				{
					this.OnPropertyChanging("EntryType");
					this._entryType = value;
					this.OnPropertyChanged("EntryType");
				}
			}
		}
		
		private string _ip;
		[Column("ip", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 128, Scale = 0, SqlType = "nvarchar")]
		[Storage("_ip")]
		[System.ComponentModel.DataAnnotations.StringLength(128)]
		public virtual string Ip
		{
			get
			{
				return this._ip;
			}
			set
			{
				if(this._ip != value)
				{
					this.OnPropertyChanging("Ip");
					this._ip = value;
					this.OnPropertyChanged("Ip");
				}
			}
		}
		
		private int? _userId;
		[Column("user_id", OpenAccessType = OpenAccessType.Int32, IsNullable = true, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_userId")]
		public virtual int? UserId
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
		
		private int? _accessObjectId;
		[Column("access_object_id", OpenAccessType = OpenAccessType.Int32, IsNullable = true, Length = 0, Scale = 0, SqlType = "integer")]
		[Storage("_accessObjectId")]
		public virtual int? AccessObjectId
		{
			get
			{
				return this._accessObjectId;
			}
			set
			{
				if(this._accessObjectId != value)
				{
					this.OnPropertyChanging("AccessObjectId");
					this._accessObjectId = value;
					this.OnPropertyChanged("AccessObjectId");
				}
			}
		}
		
		private short? _action;
		[Column("action", OpenAccessType = OpenAccessType.Byte, IsNullable = true, Length = 0, Scale = 0, SqlType = "tinyint")]
		[Storage("_action")]
		public virtual short? Action
		{
			get
			{
				return this._action;
			}
			set
			{
				if(this._action != value)
				{
					this.OnPropertyChanging("Action");
					this._action = value;
					this.OnPropertyChanged("Action");
				}
			}
		}
		
		private string _details;
		[Column("details", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_details")]
		public virtual string Details
		{
			get
			{
				return this._details;
			}
			set
			{
				if(this._details != value)
				{
					this.OnPropertyChanging("Details");
					this._details = value;
					this.OnPropertyChanged("Details");
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
		
		private short? _important;
		[Column("important", OpenAccessType = OpenAccessType.Byte, IsNullable = true, Length = 0, Scale = 0, SqlType = "tinyint")]
		[Storage("_important")]
		public virtual short? Important
		{
			get
			{
				return this._important;
			}
			set
			{
				if(this._important != value)
				{
					this.OnPropertyChanging("Important");
					this._important = value;
					this.OnPropertyChanged("Important");
				}
			}
		}
		
		private AccessObject _accessObject;
		[ForeignKeyAssociation(ConstraintName = "log_access_object_FK_access_object_id", SharedFields = "AccessObjectId", TargetFields = "Id")]
		[Storage("_accessObject")]
		public virtual AccessObject AccessObject
		{
			get
			{
				return this._accessObject;
			}
			set
			{
				if(this._accessObject != value)
				{
					this.OnPropertyChanging("AccessObject");
					this._accessObject = value;
					this.OnPropertyChanged("AccessObject");
				}
			}
		}
		
		private User _user;
		[ForeignKeyAssociation(ConstraintName = "log_user_FK_user_id", SharedFields = "UserId", TargetFields = "Id")]
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
