﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Jaytas.Omilos.Common;
using Jaytas.Omilos.Common.Web;
using Jaytas.Omilos.Web.Controllers;
using Jaytas.Omilos.Web.Controllers.Commands;
using Jaytas.Omilos.Web.Service.Campaign.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Service.Campaign.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route(Constants.Route.Schedule.RootPath)]
	public class ScheduleController : CrudByFieldBaseApiController<Jaytas.Omilos.Web.Service.Campaign.DomainModel.Schedule,
																   Jaytas.Omilos.Web.Service.Models.Campaign.Schedule,
																   Command<Jaytas.Omilos.Web.Service.Models.Campaign.Schedule, Guid>,
																   Guid, long>
	{
		readonly IScheduleProvider _scheduleProvider;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scheduleProvider"></param>
		/// <param name="mapper"></param>
		public ScheduleController(IScheduleProvider scheduleProvider, IMapper mapper) : base(mapper)
		{
			_scheduleProvider = scheduleProvider;
		}


		/// <summary>
		/// Gets campaign Schedule.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route(Constants.Route.Crud.Get, Name = Constants.Route.Schedule.Name.GetById)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Jaytas.Omilos.Web.Service.Models.Campaign.Schedule), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Get(Guid subscriptionId, Guid campaignId, Guid id)
		{
			return await GetOrStatusCodeAsync(id).ConfigureAwait(true);
		}

		/// <summary>
		/// Creates campaign Schedule.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route(Constants.Route.Crud.Create)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Post(Guid subscriptionId, Guid campaignId, [FromBody] Jaytas.Omilos.Web.Service.Models.Campaign.Schedule schedule)
		{
			return await PostOrStatusCodeAsync(schedule, Constants.Route.Schedule.Name.GetById).ConfigureAwait(true);
		}

		/// <summary>
		/// Updates campaign Schedule.
		/// </summary>
		/// <returns></returns>
		[HttpPut]
		[Route(Constants.Route.Crud.Update)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Update(Guid subscriptionId, Guid campaignId, Guid id, [FromBody] Jaytas.Omilos.Web.Service.Models.Campaign.Schedule schedule)
		{
			return await PutOrStatusCodeAsync(schedule, id).ConfigureAwait(true);
		}

		/// <summary>
		/// Deletes campaign Schedule.
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
		protected async override Task<Guid> CreateAsync(Jaytas.Omilos.Web.Service.Campaign.DomainModel.Schedule model)
		{
			return await _scheduleProvider.CreateAsync(model);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="resourceId"></param>
		/// <returns></returns>
		protected override Command<Jaytas.Omilos.Web.Service.Models.Campaign.Schedule, Guid> CreateCommand(Jaytas.Omilos.Web.Service.Models.Campaign.Schedule model, Guid resourceId)
		{
			return new Command<Jaytas.Omilos.Web.Service.Models.Campaign.Schedule, Guid>(model, resourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task DeleteAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.Schedule, Guid> command)
		{
			await _scheduleProvider.DeleteAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<IEnumerable<Jaytas.Omilos.Web.Service.Campaign.DomainModel.Schedule>> GetAllAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.Schedule, Guid> command)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<Jaytas.Omilos.Web.Service.Campaign.DomainModel.Schedule> GetByIdAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.Schedule, Guid> command)
		{
			return await _scheduleProvider.GetAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		protected async override Task UpdateAsync(Command<Jaytas.Omilos.Web.Service.Models.Campaign.Schedule, Guid> command, Jaytas.Omilos.Web.Service.Campaign.DomainModel.Schedule model)
		{
			await _scheduleProvider.UpdateAsync(model);
		}
	}
}