using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Jaytas.Omilos.Common;
using Jaytas.Omilos.Common.Web;
using Jaytas.Omilos.Web.Controllers;
using Jaytas.Omilos.Web.Controllers.Commands;
using Jaytas.Omilos.Web.Service.Campaign.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Service.Campaign.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route(Constants.Route.CampaignInstance.RootPath)]
	public class CampaignInstanceController : CrudByFieldBaseApiController<Jaytas.Omilos.Web.Service.Campaign.DomainModel.CampaignInstance,
																   Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance,
																   Command<Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance, Guid>,
																   Guid, long>
	{
		readonly ICampaignInstanceProvider _campaignInstaneProvider;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="campaignInstaneProvider"></param>
		/// <param name="mapper"></param>
		public CampaignInstanceController(ICampaignInstanceProvider campaignInstaneProvider, IMapper mapper) : base(mapper)
		{
			_campaignInstaneProvider = campaignInstaneProvider;
		}


		/// <summary>
		/// Gets campaign instance.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		[Route(Constants.Route.Crud.Get, Name = Constants.Route.CampaignInstance.Name.GetById)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Get(Guid subscriptionId, Guid campaignId, Guid id)
		{
			return await GetOrStatusCodeAsync(id).ConfigureAwait(true);
		}

		/// <summary>
		/// Creates campaign instance.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route(Constants.Route.Crud.Create)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Post(Guid subscriptionId, Guid campaignId, [FromBody] Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance campaignInstance)
		{
			return await PostOrStatusCodeAsync(campaignInstance, Constants.Route.CampaignInstance.Name.GetById).ConfigureAwait(true);
		}

		/// <summary>
		/// Updates campaign instance.
		/// </summary>
		/// <returns></returns>
		[HttpPut]
		[Route(Constants.Route.Crud.Update)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Update(Guid subscriptionId, Guid campaignId, Guid id, [FromBody] Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance campaignInstance)
		{
			return await PutOrStatusCodeAsync(campaignInstance, id).ConfigureAwait(true);
		}

		/// <summary>
		/// Deletes campaign instance.
		/// </summary>
		/// <returns></returns>
		[HttpDelete]
		[Route(Constants.Route.Crud.Delete)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Delete(Guid subscriptionId, Guid campaignId, Guid id)
		{
			return await DeleteOrStatusCodeAsync(id).ConfigureAwait(true);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		protected async override Task<Guid> CreateAsync(Jaytas.Omilos.Web.Service.Campaign.DomainModel.CampaignInstance model)
		{
			return await _campaignInstaneProvider.CreateAsync(model);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="resourceId"></param>
		/// <returns></returns>
		protected override Command<Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance, Guid> CreateCommand(Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance model, Guid resourceId)
		{
			return new Command<Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance, Guid>(model, resourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task DeleteAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance, Guid> command)
		{
			await _campaignInstaneProvider.DeleteAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<IEnumerable<Jaytas.Omilos.Web.Service.Campaign.DomainModel.CampaignInstance>> GetAllAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance, Guid> command)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<Jaytas.Omilos.Web.Service.Campaign.DomainModel.CampaignInstance> GetByIdAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance, Guid> command)
		{
			return await _campaignInstaneProvider.GetAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		protected async override Task UpdateAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.CampaignInstance, Guid> command, Jaytas.Omilos.Web.Service.Campaign.DomainModel.CampaignInstance model)
		{
			await _campaignInstaneProvider.UpdateAsync(model);
		}
	}
}