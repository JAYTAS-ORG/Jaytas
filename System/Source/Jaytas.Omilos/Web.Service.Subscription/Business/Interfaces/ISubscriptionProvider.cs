using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Subscription.Business.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface ISubscriptionProvider : Providers.ICrudByFieldBaseProvider<DomainModel.Subscription, long, Guid>
	{
	}
}
