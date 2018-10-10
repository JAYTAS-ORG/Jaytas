using AutoMapper;
using Jaytas.Omilos.Common;
using Jaytas.Omilos.Common.Web;
using Jaytas.Omilos.Web.Account.Business;
using Jaytas.Omilos.Web.Controllers;
using Jaytas.Omilos.Web.Controllers.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/Account/Role")]
	public class RoleController : BaseCrudApiController<DomainModel.Role, Service.Models.Account.Role, Command<Service.Models.Account.Role, int>, int>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RoleController" /> class.
		/// </summary>
		private readonly IRoleProvider _roleProvider;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="roleProvider"></param>
		/// <param name="mapper"></param>
		public RoleController(IRoleProvider roleProvider, IMapper mapper) : base(mapper)
		{
			_roleProvider = roleProvider;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		protected override Task<int> CreateAsync(DomainModel.Role model)
		{
			return _roleProvider.CreateAsync(model);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="resourceId"></param>
		/// <returns></returns>
		protected override Command<Service.Models.Account.Role, int> CreateCommand(Service.Models.Account.Role model, int resourceId)
		{
			return new Command<Service.Models.Account.Role, int>(model, resourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="setId"></param>
		/// <param name="resourceId"></param>
		/// <returns></returns>
		protected override Command<Service.Models.Account.Role, int> CreateCommand(Service.Models.Account.Role model, int setId, int resourceId)
		{
			return new Command<Service.Models.Account.Role, int>(model, resourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected override Task DeleteAsync(Command<Service.Models.Account.Role, int> command)
		{
			return _roleProvider.DeleteAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected override Task<IEnumerable<DomainModel.Role>> GetAllAsync(Command<Service.Models.Account.Role, int> command)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		protected async override Task<DomainModel.Role> GetByIdAsync(Command<Service.Models.Account.Role, int> command)
		{
			return await _roleProvider.GetAsync(command.ResourceId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		protected override Task UpdateAsync(Command<Service.Models.Account.Role, int> command, DomainModel.Role model)
		{
			return _roleProvider.UpdateAsync(model);
		}


		/// <summary>
		/// Get roles by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		[Route("{id}")]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Service.Models.Account.Role), (int) HttpStatusCode.OK)]
		public async Task<IActionResult> Get(int id)
		{
			return await GetOrStatusCodeAsync(id);
		}

		/// <summary>
		/// Gets all the roles from the table.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		[Route("GetRoles")]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(Service.Models.Account.Role), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetRoles()
		{
			return await ExecuteWithExceptionHandlingAsync(() => _roleProvider.GetRoles());
		}

	}
}
