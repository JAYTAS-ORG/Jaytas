using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jaytas.Omilos.Common.Domain.Interfaces;
using Jaytas.Omilos.Data.EntityFramework.BaseImplementations;
using Jaytas.Omilos.Data.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jaytas.Omilos.Web.Repositories
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TBaseEntityType"></typeparam>
	public abstract class CrudBaseEntityRepository<TContext, TEntity, TBaseEntityType> : BaseEntityRepository<TContext>, ICrudBaseEntityRepository<TEntity, TBaseEntityType>
							where TEntity : class,
								  IBaseEntity<TBaseEntityType> where TBaseEntityType : struct
							where TContext : IDbContext
	{
		DbSet<TEntity> _dbSet;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbContext"></param>
		/// <param name="dbSet"></param>
		public CrudBaseEntityRepository(TContext dbContext, DbSet<TEntity> dbSet) : base(dbContext)
		{
			_dbSet = dbSet;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public virtual async Task<TBaseEntityType> AddAsync(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			return entity.Id;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entities"></param>
		/// <returns></returns>
		public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await _dbSet.AddRangeAsync(entities);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="expression"></param>
		public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> expression)
		{
			var entities = await GetAsync(expression);
			_dbSet.RemoveRange(entities);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public virtual Task DeleteAsync(TEntity entity)
		{
			_dbSet.Remove(entity);
			return Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task DeleteAsync(TBaseEntityType id)
		{
			var entity = await GetAsync(id);
			await DeleteAsync(entity);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task<TEntity> GetAsync(TBaseEntityType id)
		{
			return await _dbSet.FindAsync(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await _dbSet.Where(expression).ToListAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public virtual async Task UpdateAsync(TEntity entity)
		{
			_dbSet.Update(entity);
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entities"></param>
		/// <returns></returns>
		public virtual async Task UpdateAsync(IEnumerable<TEntity> entities)
		{
			_dbSet.UpdateRange(entities);
			await Task.CompletedTask;
		}
	}
}
