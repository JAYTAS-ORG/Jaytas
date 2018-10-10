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
	public class RoleRepository : BaseEntityRepository<IUserDbContext>, IRoleRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="userDbContext"></param>
		public RoleRepository(IUserDbContext userDbContext) : base(userDbContext)
		{
		}

		#region Default

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public int Add(Role entity)
		{
			DbContext.Roles.Add(entity);
			DbContext.SaveChanges();
			return entity.Id;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entities"></param>
		public void Add(IEnumerable<Role> entities)
		{
			DbContext.Roles.AddRange(entities);
			DbContext.SaveChanges();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
			var roleEntity = Get(id);
			DbContext.Roles.Remove(roleEntity);
			DbContext.SaveChanges();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identifiers"></param>
		public void Delete(IEnumerable<int> identifiers)
		{
			var roleEntities = DbContext.Roles.Where(Role => identifiers.Contains(Role.Id)).ToList();
			DbContext.Roles.RemoveRange(roleEntities);
			DbContext.SaveChanges();
		}

		public void Delete(Expression<Func<Role, bool>> expression)
		{
			var entities = this.Get(expression).Select(x => x.Id);
			Delete(entities);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public int ExecuteNonQuery(string query, params object[] parameters)
		{
			return DbContext.Database.ExecuteSqlCommand(query, parameters);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public IEnumerable<Role> ExecuteQuery(string query, params object[] parameters)
		{
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public T ExecuteScalar<T>(string query, params object[] parameters)
		{
			return default(T);
			//return DbContext.Database.SqlQuery<T>(query, parameters).FirstOrDefault();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Role Get(int id)
		{
			return DbContext.Roles.Single(role => role.Id == id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public IEnumerable<Role> Get(Expression<Func<Role, bool>> expression)
		{
			return DbContext.Roles.Where(expression);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		public void Update(Role entity)
		{
			DbContext.Roles.Attach(entity);
			EntityEntry<DomainModel.Role> currentRole = DbContext.Entry(entity);
			currentRole.State = EntityState.Modified;
			DbContext.SaveChanges();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		public void Update(IEnumerable<Role> entities)
		{
			foreach (var entity in entities)
			{
				DbContext.Roles.Attach(entity);
				EntityEntry<DomainModel.Role> currentRole = DbContext.Entry(entity);
				currentRole.State = EntityState.Modified;
			}
			DbContext.SaveChanges();
		}
		#endregion


		#region Custom

		#endregion
	}
}
