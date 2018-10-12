using Jaytas.Omilos.Common;
using Jaytas.Omilos.Data.EntityFramework.BaseImplementations;
using Jaytas.Omilos.Web.Account.Data.Map;
using Jaytas.Omilos.Web.Account.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Data.DbContext
{
	/// <summary>
	/// DbContext for the User Management Web API
	/// </summary>
	public class UserDbContext : MicroServiceDbContext<UserDbContext>, IUserDbContext
	{
		/// <summary>
		/// Constructor which sets the db Initializer.
		/// </summary>
		/// <param name="options">Represents the Identity of the logged in user.</param>
		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
		{
		}

		/// <summary>
		/// DbSet for Roles entity.
		/// </summary>
		public virtual DbSet<Role> Roles { get; set; }

		/// <summary>
		/// DbSet for Users entity.
		/// </summary>
		public virtual DbSet<User> Users { get; set; }

		/// <summary>
		/// DbSet for UserRole entity.
		/// </summary>
		public virtual DbSet<UserRole> UserRoles { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new RoleFluentMap(Constants.Tables.Role, Constants.Schemas.Account, true));
			modelBuilder.ApplyConfiguration(new UserFluentMap(Constants.Tables.User, Constants.Schemas.Account, true));
			//modelBuilder.ApplyConfiguration(new UserLoginDetailFluentMap(Constants.Tables.UserLoginDetail, Constants.Schemas.Account, true));
			modelBuilder.ApplyConfiguration(new UserRoleFluentMap(Constants.Tables.UserRole, Constants.Schemas.Account, true));
		}
	}
}
