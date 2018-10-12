﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Jaytas.Omilos.Common;
using Jaytas.Omilos.Common.Web;
using Jaytas.Omilos.Web.Account.Business.Interfaces;
using Jaytas.Omilos.Web.Controllers;
using Jaytas.Omilos.Web.Service.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Account.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route(Constants.Route.Account.RootPath)]
	public class AccountController : BaseApiController
	{
		readonly IAccountProvider _accountProvider;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="accountProvider"></param>
		public AccountController(IMapper mapper, IAccountProvider accountProvider) : base(mapper)
		{
			_accountProvider = accountProvider;
		}

		/// <summary>
		/// Gets all the roles from the table.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route(Constants.Route.Account.FacebookSignin)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(FriendlyError), (int)HttpStatusCode.InternalServerError)]
		[ProducesResponseType(typeof(SigninResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> FacebookSignin([FromBody] ExternalSigninRequest signinRequest)
		{
			return await ExecuteWithExceptionHandlingAsync<string, SigninResponse>(() => _accountProvider.AcquireFacebookAccessToken(signinRequest));
		}
	}
}