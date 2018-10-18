using Jaytas.Omilos.Web.Providers;
using Jaytas.Omilos.Web.Service.Subscription.Business.Interfaces;
using Jaytas.Omilos.Web.Service.Subscription.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Subscription.Business
{
	/// <summary>
	/// 
	/// </summary>
	public class SubscriptionProvider : CrudByFieldBaseProvider<DomainModel.Subscription, ISubscriptionRepository, long, Guid>, ISubscriptionProvider
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="subscriptionRepository"></param>
		public SubscriptionProvider(ISubscriptionRepository subscriptionRepository) : base(subscriptionRepository)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async override Task AssertEntityToCreateIsValidAsync(IEnumerable<DomainModel.Subscription> domains)
		{
			//throw new NotImplementedException();
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identifiers"></param>
		/// <returns></returns>
		public async override Task AssertEntityToDeleteIsValidAsync(IEnumerable<Guid> identifiers)
		{
			//throw new NotImplementedException();
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async override Task AssertEntityToUpdateIsValidAsync(IEnumerable<DomainModel.Subscription> domains)
		{
			//throw new NotImplementedException();
			await Task.CompletedTask;
		}
	}
}
