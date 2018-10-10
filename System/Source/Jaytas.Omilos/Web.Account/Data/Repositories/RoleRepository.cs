using Jaytas.Omilos.Common.Disposable;
using Jaytas.Omilos.Data.EntityFramework.BaseImplementations;
using Jaytas.Omilos.Web.Account.Data.DbContext;
using Jaytas.Omilos.Web.Account.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Data.Repositories
{
	/// <summary>
	/// Repostiory layer for Role.
	/// </summary>
	public class RoleRepository : Disposable, IRoleRepository
	{
		IUserDbContext _userDbContext;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userDbContext"></param>
		public RoleRepository(IUserDbContext userDbContext)
		{
			_userDbContext = userDbContext;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Role>> GetAllRolesAsync()
		{
			return await _userDbContext.Roles.ToListAsync();
		}

		/// <summary>
		/// Dispose implementation.
		/// </summary>
		protected override void DisposeImplementation()
		{
			using (_userDbContext) { }

			base.DisposeImplementation();
		}
	}
}
