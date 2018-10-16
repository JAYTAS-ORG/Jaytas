﻿using System;
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
	[Route(Constants.Route.MessageTemplate.RootPath)]
	public class MessageTemplateController : CrudByFieldBaseApiController<Jaytas.Omilos.Web.Service.Campaign.DomainModel.MessageTemplate,
																   Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate,
																   Command<Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate, Guid>,
																   Guid, long>
	{
		readonly IMessageTemplateProvider _messageTemplateProvider;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="messageTemplateProvider"></param>
		/// <param name="mapper"></param>
		public MessageTemplateController(IMessageTemplateProvider messageTemplateProvider, IMapper mapper) : base(mapper)
		{
			_messageTemplateProvider = messageTemplateProvider;
		}

		/// <summary>
		/// Gets campaign MessageTemplate.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		[Route(Constants.Route.Crud.Get, Name = Constants.Route.MessageTemplate.Name.GetById)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Get(Guid subscriptionId, Guid campaignId, Guid id)
		{
			return await GetOrStatusCodeAsync(id).ConfigureAwait(true);
		}

		/// <summary>
		/// Creates campaign MessageTemplate.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route(Constants.Route.Crud.Create)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Post(Guid subscriptionId, Guid campaignId, [FromBody] Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate messageTemplate)
		{
			return await PostOrStatusCodeAsync(messageTemplate, Constants.Route.MessageTemplate.Name.GetById).ConfigureAwait(true);
		}

		/// <summary>
		/// Updates campaign MessageTemplate.
		/// </summary>
		/// <returns></returns>
		[HttpPut]
		[Route(Constants.Route.Crud.Update)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Update(Guid subscriptionId, Guid campaignId, Guid id, [FromBody] Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate messageTemplate)
		{
			return await PutOrStatusCodeAsync(messageTemplate, id).ConfigureAwait(true);
		}

		/// <summary>
		/// Deletes campaign MessageTemplate.
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
		protected async override Task<Guid> CreateAsync(Jaytas.Omilos.Web.Service.Campaign.DomainModel.MessageTemplate model)
		{
			return await _messageTemplateProvider.CreateAsync(model);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="resourceId"></param>
		/// <returns></returns>
		protected override Command<Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate, Guid> CreateCommand(Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate model, Guid resourceId)
		{
			return new Command<Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate, Guid>(model, resourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task DeleteAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate, Guid> command)
		{
			await _messageTemplateProvider.DeleteAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<IEnumerable<Jaytas.Omilos.Web.Service.Campaign.DomainModel.MessageTemplate>> GetAllAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate, Guid> command)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<Jaytas.Omilos.Web.Service.Campaign.DomainModel.MessageTemplate> GetByIdAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate, Guid> command)
		{
			return await _messageTemplateProvider.GetAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		protected async override Task UpdateAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.MessageTemplate, Guid> command, Jaytas.Omilos.Web.Service.Campaign.DomainModel.MessageTemplate model)
		{
			await _messageTemplateProvider.UpdateAsync(model);
		}
	}
}