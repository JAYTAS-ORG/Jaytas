using Jaytas.Omilos.Common.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Business
{
	/// <summary>
	/// This interface should implement in order to provide <see cref="DomainModel.Role"/>s.
	/// </summary>
	public interface IRoleProvider : IProvider<DomainModel.Role, int>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<DomainModel.Role>> GetRoles();
	}
}
