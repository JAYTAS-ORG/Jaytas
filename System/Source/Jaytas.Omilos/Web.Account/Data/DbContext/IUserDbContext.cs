using Jaytas.Omilos.Data.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Data.DbContext
{
	/// <summary>
	/// User API IDbContext.
	/// </summary>
	public interface IUserDbContext : IDbContext
	{
		/// <summary>
		/// DbSet for the Roles table.
		/// </summary>
		DbSet<DomainModel.Role> Roles { get; set; }
	}
}
