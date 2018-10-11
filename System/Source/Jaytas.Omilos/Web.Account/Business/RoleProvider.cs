﻿using Jaytas.Omilos.Web.Account.Data.Repositories;
using Jaytas.Omilos.Web.Account.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Business
{
	/// <summary>
	/// 
	/// </summary>
	public class RoleProvider : IRoleProvider
	{
		IRoleRepository _repository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		public RoleProvider(IRoleRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Role>> GetRoles()
		{
			return await _repository.GetAllRolesAsync();
		}
	}
}