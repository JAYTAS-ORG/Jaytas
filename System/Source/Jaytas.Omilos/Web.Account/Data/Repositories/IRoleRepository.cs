using Jaytas.Omilos.Common.Repositories;
using Jaytas.Omilos.Web.Account.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Data.Repositories
{
	/// <summary>
	/// 
	/// </summary>
	public interface IRoleRepository : IBaseRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Role>> GetAllRolesAsync();
	}
}
