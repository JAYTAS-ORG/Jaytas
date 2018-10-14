using Jaytas.Omilos.Web.Providers;
using Jaytas.Omilos.Web.Service.Campaign.Business.Interfaces;
using Jaytas.Omilos.Web.Service.Campaign.Data.Repositories.Interfaces;
using Jaytas.Omilos.Web.Service.Campaign.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Campaign.Business
{
	/// <summary>
	/// 
	/// </summary>
	public class CampaignProvider : CrudByFieldBaseProvider<DomainModel.Campaign, ICampaignRepository, long, Guid>, ICampaignProvider
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="campaignRepository"></param>
		public CampaignProvider(ICampaignRepository campaignRepository) : base(campaignRepository)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async override Task AssertEntityToCreateIsValidAsync(IEnumerable<DomainModel.Campaign> domains)
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
		public async override Task AssertEntityToUpdateIsValidAsync(IEnumerable<DomainModel.Campaign> domains)
		{
			//throw new NotImplementedException();
			await Task.CompletedTask;
		}
	}
}
