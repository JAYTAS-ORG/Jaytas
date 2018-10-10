using Jaytas.Omilos.Web.Account.Data.Repositories;
using Jaytas.Omilos.Web.Account.DomainModel;
using Jaytas.Omilos.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Business
{
	/// <summary>
	/// 
	/// </summary>
	public class RoleProvider : CrudBaseProvider<Role, IRoleRepository, int>, IRoleProvider
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		public RoleProvider(IRoleRepository repository) : base(repository)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async override Task AssertEntityToCreateIsValidAsync(IEnumerable<Role> domains)
		{
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identifiers"></param>
		/// <returns></returns>
		public async override Task AssertEntityToDeleteIsValidAsync(IEnumerable<int> identifiers)
		{
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async override Task AssertEntityToUpdateIsValidAsync(IEnumerable<Role> domains)
		{
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<DomainModel.Role>> GetRoles()
		{
			return await Task.FromResult(Repository.Get(x => true).ToList());
		}
	}
}
