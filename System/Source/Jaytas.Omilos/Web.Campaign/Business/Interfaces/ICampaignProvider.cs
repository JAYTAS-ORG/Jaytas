using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaytas.Omilos.Common.Domain.Interfaces;
using Jaytas.Omilos.Web;

namespace Jaytas.Omilos.Web.Service.Campaign.Business.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface ICampaignProvider : Providers.ICrudByFieldBaseProvider<DomainModel.Campaign, long, Guid>
	{

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<DomainModel.Campaign>> GetMyCampaigns();
	}
}
