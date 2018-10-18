using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Jaytas.Omilos.Web.Service.Campaign.Business.Interfaces;
using Jaytas.Omilos.Common;
using Jaytas.Omilos.Web.Controllers;
using Jaytas.Omilos.Web.Controllers.Commands;
using Jaytas.Omilos.Web.Service.Campaign.DomainModel;
using Jaytas.Omilos.Web.Service.Models.Campaign;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaytas.Omilos.Common.Web;
using System.Net;

namespace Web.Service.Campaign.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route(Constants.Route.Campaign.RootPath)]
	public class CampaignController : CrudByFieldBaseApiController<Jaytas.Omilos.Web.Service.Campaign.DomainModel.Campaign,
																   Jaytas.Omilos.Web.Service.Models.Campaign.Campaign,
																   Command<Jaytas.Omilos.Web.Service.Models.Campaign.Campaign, Guid>,
																   Guid, long>
	{
		readonly ICampaignProvider _campaignProvider;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="campaignProvider"></param>
		/// <param name="mapper"></param>
		public CampaignController(ICampaignProvider campaignProvider, IMapper mapper) : base (mapper)
		{
			_campaignProvider = campaignProvider;
		}

		/// <summary>
		/// Gets campaign.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		[Route(Constants.Route.Crud.Get, Name = Constants.Route.Campaign.Name.GetById)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Jaytas.Omilos.Web.Service.Models.Campaign.Campaign), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Get(Guid subscriptionId, Guid id)
		{
			return await GetOrStatusCodeAsync(id).ConfigureAwait(true);
		}

		/// <summary>
		/// Gets all the campaign for the logged in user.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		[Route(Constants.Route.Campaign.MyCampaigns)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(IEnumerable<Jaytas.Omilos.Web.Service.Models.Campaign.Campaign>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> MyCampaings()
		{
			return await GetAllOrStatusCodeAsync().ConfigureAwait(true);
		}

		/// <summary>
		/// Creates campaign.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route(Constants.Route.Crud.Create)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Post(Guid subscriptionId, [FromBody] Jaytas.Omilos.Web.Service.Models.Campaign.Campaign campaign)
		{
			campaign.SubscriptionId = subscriptionId;
			return await PostOrStatusCodeAsync(campaign, Constants.Route.Campaign.Name.GetById).ConfigureAwait(true);
		}

		/// <summary>
		/// Updates campaign.
		/// </summary>
		/// <returns></returns>
		[HttpPut]
		[Route(Constants.Route.Crud.Update)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Update(Guid subscriptionId, Guid id, [FromBody] Jaytas.Omilos.Web.Service.Models.Campaign.Campaign campaign)
		{
			return await PutOrStatusCodeAsync(campaign, id).ConfigureAwait(true);
		}

		/// <summary>
		/// Deletes campaign.
		/// </summary>
		/// <returns></returns>
		[HttpDelete]
		[Route(Constants.Route.Crud.Delete)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Delete(Guid subscriptionId, Guid id)
		{
			return await DeleteOrStatusCodeAsync(id).ConfigureAwait(true);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		protected async override Task<Guid> CreateAsync(Jaytas.Omilos.Web.Service.Campaign.DomainModel.Campaign model)
		{
			return await _campaignProvider.CreateAsync(model);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="resourceId"></param>
		/// <returns></returns>
		protected override Command<Jaytas.Omilos.Web.Service.Models.Campaign.Campaign, Guid> CreateCommand(Jaytas.Omilos.Web.Service.Models.Campaign.Campaign model, Guid resourceId)
		{
			return new Command<Jaytas.Omilos.Web.Service.Models.Campaign.Campaign, Guid>(model, resourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task DeleteAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.Campaign, Guid> command)
		{
			await _campaignProvider.DeleteAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<IEnumerable<Jaytas.Omilos.Web.Service.Campaign.DomainModel.Campaign>> GetAllAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.Campaign, Guid> command)
		{
			return await _campaignProvider.GetMyCampaigns();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<Jaytas.Omilos.Web.Service.Campaign.DomainModel.Campaign> GetByIdAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.Campaign, Guid> command)
		{
			return await _campaignProvider.GetAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		protected async override Task UpdateAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.Campaign, Guid> command, Jaytas.Omilos.Web.Service.Campaign.DomainModel.Campaign model)
		{
			await _campaignProvider.UpdateAsync(model);
		}
	}
}