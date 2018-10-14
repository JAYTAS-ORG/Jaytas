using Jaytas.Omilos.Web.Repositories;
using Jaytas.Omilos.Web.Service.Campaign.Data.DbContext;
using Jaytas.Omilos.Web.Service.Campaign.Data.Repositories.Interfaces;
using Jaytas.Omilos.Web.Service.Campaign.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Campaign.Data.Repositories
{
	/// <summary>
	/// 
	/// </summary>
	public class CampaignInstanceExceptionRepository : CrudBaseEntityRepository<ICampaignDbContext, CampaignInstanceException, long>, ICampaignInstanceExceptionRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="campaignDbContext"></param>
		public CampaignInstanceExceptionRepository(ICampaignDbContext campaignDbContext) : base(campaignDbContext, campaignDbContext.CampaignInstanceExceptions)
		{
		}
	}
}
