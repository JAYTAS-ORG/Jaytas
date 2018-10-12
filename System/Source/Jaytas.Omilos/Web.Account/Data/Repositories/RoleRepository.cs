using Jaytas.Omilos.Common.Disposable;
using Jaytas.Omilos.Data.EntityFramework.BaseImplementations;
using Jaytas.Omilos.Data.EntityFramework.Interfaces;
using Jaytas.Omilos.Web.Account.Data.DbContext;
using Jaytas.Omilos.Web.Account.Data.Repositories.Interfaces;
using Jaytas.Omilos.Web.Account.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Data.Repositories
{
	/// <summary>
	/// Repostiory layer for Role.
	/// </summary>
	public class RoleRepository : BaseEntityRepository<IUserDbContext>, IRoleRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="userDbContext"></param>
		public RoleRepository(IUserDbContext userDbContext) : base(userDbContext)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Role>> GetAllAsync()
		{
			return await DbContext.Roles.ToListAsync();
		}
	}
}
