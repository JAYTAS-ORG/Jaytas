using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Subscription.Business.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IContactProvider : Providers.ICrudByFieldBaseProvider<DomainModel.Contact, long, Guid>
	{
	}
}
