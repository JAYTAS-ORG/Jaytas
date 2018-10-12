using Jaytas.Omilos.Web.Account.Data.DbContext;
using Jaytas.Omilos.Web.Account.Data.Repositories.Interfaces;
using Jaytas.Omilos.Web.Account.DomainModel;
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
	public class UserRepository : IUserRepository
	{
		private IUserDbContext _userDbContext;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userDbContext"></param>
		public UserRepository(IUserDbContext userDbContext)
		{
			_userDbContext = userDbContext;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public long Add(User entity)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entities"></param>
		public void Add(IEnumerable<User> entities)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public void Delete(long id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identifiers"></param>
		public void Delete(IEnumerable<long> identifiers)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="expression"></param>
		public void Delete(Expression<Func<User, bool>> expression)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public User Get(long id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> Get(Expression<Func<User, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public void Update(User entity)
		{
			throw new NotImplementedException();
		}

		public void Update(IEnumerable<User> entity)
		{
			throw new NotImplementedException();
		}
	}
}
