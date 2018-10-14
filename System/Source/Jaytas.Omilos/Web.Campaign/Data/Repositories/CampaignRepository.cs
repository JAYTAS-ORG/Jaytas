using Jaytas.Omilos.Web.Repositories;
using Jaytas.Omilos.Web.Service.Campaign.Data.DbContext;
using Jaytas.Omilos.Web.Service.Campaign.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Campaign.Data.Repositories
{
	/// <summary>
	/// 
	/// </summary>
	public class CampaignRepository : CrudBaseEntityRepository<ICampaignDbContext, DomainModel.Campaign, long>, ICampaignRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="campaignDbContext"></param>
		public CampaignRepository(ICampaignDbContext campaignDbContext) : base(campaignDbContext, campaignDbContext.Campaigns)
		{
		}
	}
}
