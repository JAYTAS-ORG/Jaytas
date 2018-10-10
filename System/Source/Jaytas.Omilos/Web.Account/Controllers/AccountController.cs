using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jaytas.Omilos.Common;
using Jaytas.Omilos.Web.Controllers;
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mapper"></param>
		public AccountController(IMapper mapper) : base(mapper)
		{
		}
	}
}