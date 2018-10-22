using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Subscription.Business.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IGroupProvider : Providers.ICrudByFieldBaseProvider<DomainModel.Group, long, Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		Task<IEnumerable<DomainModel.GroupContactAssociation>> GetContacts(Guid groupId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="contacts"></param>
		/// <returns></returns>
		Task AddContactsToGroup(Guid groupId, IEnumerable<Guid> contacts);
	}
}
