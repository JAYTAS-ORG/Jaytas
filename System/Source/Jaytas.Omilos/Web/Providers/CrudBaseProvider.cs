using Jaytas.Omilos.Common.Domain.Interfaces;
using Jaytas.Omilos.Common.Providers;
using Jaytas.Omilos.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Providers
{
	/// <summary>
	/// Base provider class providing the default CRUD behaviors and extensibility for additional
	/// validation for the CRUD operations.
	/// </summary>
	/// <typeparam name="TEntity">The type of the t entity.</typeparam>
	/// <typeparam name="TRepository">The type of the t repository.</typeparam>
	/// <typeparam name="TBaseEntityType">the base enity type lile (Guid, int, long..)</typeparam>
	public abstract class CrudBaseProvider<TEntity, TRepository, TBaseEntityType> : IProvider<TEntity, TBaseEntityType>
		where TEntity : class, IBaseEntity<TBaseEntityType>
		where TRepository : class, IRepository<TEntity, TBaseEntityType>
		where TBaseEntityType : struct
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="CrudBaseProvider{TEntity, TRepository,TBaseEntityType}" /> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="messageFactory">factory class to create message</param>
		/// <param name="messageSenderFactory">message sender</param>
		protected CrudBaseProvider(TRepository repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// The repository.
		/// </summary>
		public TRepository Repository { get; }

		/// <summary>
		/// Asserts the entity to create is valid. If the entity is not valid, an appropriate
		/// Argument**Exception should be thrown containing a listing of all the validation errors.
		/// </summary>
		/// <param name="domains">The domain objects.</param>
		public abstract Task AssertEntityToCreateIsValidAsync(IEnumerable<TEntity> domains);

		/// <summary>
		/// Asserts the entity to create is valid. If the entity is not valid, an appropriate
		/// Argument**Exception should be thrown containing a listing of all the validation errors.
		/// </summary>
		/// <param name="domains">The domain objects.</param>
		public abstract Task AssertEntityToUpdateIsValidAsync(IEnumerable<TEntity> domains);

		/// <summary>
		/// Asserts the entity to create is valid. If the entity is not valid, an appropriate
		/// Argument**Exception should be thrown containing a listing of all the validation errors.
		/// </summary>
		/// <param name="identifiers">The identifiers</param>
		public abstract Task AssertEntityToDeleteIsValidAsync(IEnumerable<TBaseEntityType> identifiers);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domain"></param>
		/// <returns></returns>
		public async virtual Task<TBaseEntityType> CreateAsync(TEntity domain)
		{
			await AssertEntityToCreateIsValidAsync(new List<TEntity> { domain }).ConfigureAwait(true);

			return Repository.Add(domain);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async virtual Task CreateAsync(IEnumerable<TEntity> domains)
		{
			await AssertEntityToCreateIsValidAsync(domains).ConfigureAwait(true);

			Repository.Add(domains);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async virtual Task DeleteAsync(TBaseEntityType id)
		{
			await AssertEntityToDeleteIsValidAsync(new List<TBaseEntityType> { id }).ConfigureAwait(true);

			Repository.Delete(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identifiers"></param>
		/// <returns></returns>
		public async virtual Task DeleteAsync(IEnumerable<TBaseEntityType> identifiers)
		{
			await AssertEntityToDeleteIsValidAsync(identifiers).ConfigureAwait(true);

			Repository.Delete(identifiers);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<TEntity> GetAsync(TBaseEntityType id)
		{
			return await Task.FromResult<TEntity>(Repository.Get(id));
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="domain"></param>
		/// <returns></returns>
		public async virtual Task UpdateAsync(TEntity domain)
		{
			await AssertEntityToUpdateIsValidAsync(new List<TEntity> { domain }).ConfigureAwait(true);
			Repository.Update(domain);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async virtual Task UpdateAsync(IEnumerable<TEntity> domains)
		{
			await AssertEntityToUpdateIsValidAsync(domains).ConfigureAwait(true);
			Repository.Update(domains);
		}
	}
}
