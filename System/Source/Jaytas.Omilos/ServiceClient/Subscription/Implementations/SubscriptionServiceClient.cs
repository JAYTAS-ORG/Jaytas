using Jaytas.Omilos.ServiceClient.Subscription.Interfaces;
using Jaytas.Omilos.Web.Service.Models.Subscription;
using Jaytas.Omilos.Web.Service.Models.Subscription.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jaytas.Omilos.ServiceClient.Subscription.Implementations
{
	/// <summary>
	/// 
	/// </summary>
	public class SubscriptionServiceClient : ISubscriptionServiceClient
	{
		readonly ISubscriptionClient _subscriptionClient;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="subscriptionClient"></param>
		public SubscriptionServiceClient(ISubscriptionClient subscriptionClient)
		{
			_subscriptionClient = subscriptionClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identifierFilters"></param>
		/// <returns></returns>
		public async Task<IEnumerable<SubscriptionWithGroupSummary>> GetSubscriptionsAndGroupSummaryByIdAsync(List<IdentifierFilter> identifierFilters)
		{
			return await _subscriptionClient.GetSubscriptionsAndGroupSummaryById(identifierFilters);
		}
	}
}
