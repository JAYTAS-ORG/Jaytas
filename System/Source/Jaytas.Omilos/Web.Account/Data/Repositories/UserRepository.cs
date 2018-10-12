using Jaytas.Omilos.Web.Account.Data.DbContext;
using Jaytas.Omilos.Web.Account.Data.Repositories.Interfaces;
using Jaytas.Omilos.Web.Account.DomainModel;
using Jaytas.Omilos.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Data.Repositories
{
	/// <summary>
	/// 
	/// </summary>
	public class UserRepository : CrudBaseEntityRepository<IUserDbContext, User, long>, IUserRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="userDbContext"></param>
		public UserRepository(IUserDbContext userDbContext) : base(userDbContext, userDbContext.Users)
		{
		}
	}
}
