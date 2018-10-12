using Jaytas.Omilos.ServiceClient.User.Interfaces;
using Jaytas.Omilos.Web.Account.Business.Interfaces;
using Jaytas.Omilos.Web.Service.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.Business
{
	/// <summary>
	/// 
	/// </summary>
	public class AccountProvider : IAccountProvider
	{
		readonly IFacebookUserServiceClient _facebookUserServiceClient;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="facebookUserServiceClient"></param>
		public AccountProvider(IFacebookUserServiceClient facebookUserServiceClient)
		{
			_facebookUserServiceClient = facebookUserServiceClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="signinRequest"></param>
		/// <returns></returns>
		public async Task<string> AcquireFacebookAccessToken(ExternalSigninRequest signinRequest)
		{
			var user = await _facebookUserServiceClient.WhoAmIByCodeAsync(signinRequest.Code);
			return "";
		}
	}
}
