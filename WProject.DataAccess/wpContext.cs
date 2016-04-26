﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
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
using WProject.DataAccess;

namespace WProject.DataAccess	
{
	[NamingSettings(SourceStrategy = NamingSourceStrategy.Property, RemoveLeadingUnderscores = true, ResolveReservedWords = true, UseDelimitedSQL = true, WordBreak = "_")]
	public partial class wpContext : OpenAccessContext, IwpContextUnitOfWork
	{
		private static string connectionStringName = @"WProjectConnectionString";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = AttributesMetadataSource.FromContext(typeof(wpContext));
		
		public wpContext()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public wpContext(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public wpContext(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public wpContext(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public wpContext(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<UserInGroup> UserInGroups 
		{
			get
			{
				return this.GetAll<UserInGroup>();
			}
		}
		
		public IQueryable<User> Users 
		{
			get
			{
				return this.GetAll<User>();
			}
		}
		
		public IQueryable<TaskTag> TaskTags 
		{
			get
			{
				return this.GetAll<TaskTag>();
			}
		}
		
		public IQueryable<TaskHistory> TaskHistories 
		{
			get
			{
				return this.GetAll<TaskHistory>();
			}
		}
		
		public IQueryable<TaskDependency> TaskDependencies 
		{
			get
			{
				return this.GetAll<TaskDependency>();
			}
		}
		
		public IQueryable<TaskAttachement> TaskAttachements 
		{
			get
			{
				return this.GetAll<TaskAttachement>();
			}
		}
		
		public IQueryable<Task> Tasks 
		{
			get
			{
				return this.GetAll<Task>();
			}
		}
		
		public IQueryable<Spring> Springs 
		{
			get
			{
				return this.GetAll<Spring>();
			}
		}
		
		public IQueryable<ProjectSetting> ProjectSettings 
		{
			get
			{
				return this.GetAll<ProjectSetting>();
			}
		}
		
		public IQueryable<Project> Projects 
		{
			get
			{
				return this.GetAll<Project>();
			}
		}
		
		public IQueryable<Log> Logs 
		{
			get
			{
				return this.GetAll<Log>();
			}
		}
		
		public IQueryable<Group> Groups 
		{
			get
			{
				return this.GetAll<Group>();
			}
		}
		
		public IQueryable<File> Files 
		{
			get
			{
				return this.GetAll<File>();
			}
		}
		
		public IQueryable<DictItem> DictItems 
		{
			get
			{
				return this.GetAll<DictItem>();
			}
		}
		
		public IQueryable<Category> Categories 
		{
			get
			{
				return this.GetAll<Category>();
			}
		}
		
		public IQueryable<Backlog> Backlogs 
		{
			get
			{
				return this.GetAll<Backlog>();
			}
		}
		
		public IQueryable<AppSetting> AppSettings 
		{
			get
			{
				return this.GetAll<AppSetting>();
			}
		}
		
		public IQueryable<ActiveSession> ActiveSessions 
		{
			get
			{
				return this.GetAll<ActiveSession>();
			}
		}
		
		public IQueryable<AccessObject> AccessObjects 
		{
			get
			{
				return this.GetAll<AccessObject>();
			}
		}
		
		public IQueryable<Access> Accesses 
		{
			get
			{
				return this.GetAll<Access>();
			}
		}
		
		public IQueryable<ProjectMember> ProjectMembers 
		{
			get
			{
				return this.GetAll<ProjectMember>();
			}
		}
		
		public IQueryable<TaskDiscution> TaskDiscutions 
		{
			get
			{
				return this.GetAll<TaskDiscution>();
			}
		}
		
		public IQueryable<TaskComment> TaskComments 
		{
			get
			{
				return this.GetAll<TaskComment>();
			}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MySql";
			backend.ProviderName = "MySql.Data.MySqlClient";
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}
		
		/// <summary>
		/// Allows you to customize the BackendConfiguration of wpContext.
		/// </summary>
		/// <param name="config">The BackendConfiguration of wpContext.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface IwpContextUnitOfWork : IUnitOfWork
	{
		IQueryable<UserInGroup> UserInGroups
		{
			get;
		}
		IQueryable<User> Users
		{
			get;
		}
		IQueryable<TaskTag> TaskTags
		{
			get;
		}
		IQueryable<TaskHistory> TaskHistories
		{
			get;
		}
		IQueryable<TaskDependency> TaskDependencies
		{
			get;
		}
		IQueryable<TaskAttachement> TaskAttachements
		{
			get;
		}
		IQueryable<Task> Tasks
		{
			get;
		}
		IQueryable<Spring> Springs
		{
			get;
		}
		IQueryable<ProjectSetting> ProjectSettings
		{
			get;
		}
		IQueryable<Project> Projects
		{
			get;
		}
		IQueryable<Log> Logs
		{
			get;
		}
		IQueryable<Group> Groups
		{
			get;
		}
		IQueryable<File> Files
		{
			get;
		}
		IQueryable<DictItem> DictItems
		{
			get;
		}
		IQueryable<Category> Categories
		{
			get;
		}
		IQueryable<Backlog> Backlogs
		{
			get;
		}
		IQueryable<AppSetting> AppSettings
		{
			get;
		}
		IQueryable<ActiveSession> ActiveSessions
		{
			get;
		}
		IQueryable<AccessObject> AccessObjects
		{
			get;
		}
		IQueryable<Access> Accesses
		{
			get;
		}
		IQueryable<ProjectMember> ProjectMembers
		{
			get;
		}
		IQueryable<TaskDiscution> TaskDiscutions
		{
			get;
		}
		IQueryable<TaskComment> TaskComments
		{
			get;
		}
	}
}
#pragma warning restore 1591
