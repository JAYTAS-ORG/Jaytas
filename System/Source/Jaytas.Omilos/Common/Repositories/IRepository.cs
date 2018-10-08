using Jaytas.Omilos.Common.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Jaytas.Omilos.Common.Repositories
{
	/// <summary>
	/// Interface for repository.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TBaseEntityType">The base entity type like (long, Guid..) </typeparam>
	/// <seealso cref="T:IDisposable"/>
	public interface IRepository<TEntity, TBaseEntityType> : IDisposable where TEntity : class, IBaseEntity<TBaseEntityType> where TBaseEntityType : struct
	{
		/// <summary>
		/// Creates the specified <paramref name="entity"/> .
		/// </summary>
		/// <param name="entity">The <paramref name="entity"/> .</param>
		/// <returns>A DomainId.</returns>
		TBaseEntityType Add(TEntity entity);

		/// <summary>
		/// Creates the specified <paramref name="entities"/> .
		/// </summary>
		/// <param name="entities">The <paramref name="entities"/> .</param>
		/// <returns>A DomainId.</returns>
		void Add(IEnumerable<TEntity> entities);

		/// <summary>
		/// Updates the specified <paramref name="entity"/> .
		/// </summary>
		/// <param name="entity">The <paramref name="entity"/> .</param>
		void Update(TEntity entity);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		void Update(IEnumerable<TEntity> entity);

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		void Delete(TBaseEntityType id);

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="identifiers">The identifiers.</param>
		void Delete(IEnumerable<TBaseEntityType> identifiers);

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="expression">The identifiers.</param>
		void Delete(Expression<Func<TEntity, bool>> expression);

		/// <summary>
		/// Gets the specified domain identifier.
		/// </summary>
		/// <param name="id">The domain identifier.</param>
		/// <returns>The by identifier.</returns>
		TEntity Get(TBaseEntityType id);

		/// <summary>
		/// Gets many.
		/// </summary>
		/// <param name="expression">The <paramref name="expression"/> .</param>
		/// <returns>
		/// An enumerator that allows <see langword="foreach"/> to be used to process the entities in
		/// this collection.
		/// </returns>
		IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
	}
}
