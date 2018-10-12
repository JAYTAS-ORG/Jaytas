using Jaytas.Omilos.Data.EntityFramework.Interfaces;
using Jaytas.Omilos.Web.Account.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Data.Repositories.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IRoleRepository : IBaseEntityRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Role>> GetAllAsync();
	}
}
