using Jaytas.Omilos.Common.Enumerations;
using Jaytas.Omilos.Configuration.Interfaces;
using Jaytas.Omilos.Security.ExternalAuthentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Security.ExternalAuthentication.Providers
{
	/// <summary>
	/// 
	/// </summary>
	public class FacebookIdentityProvider : IExternalIdentityProvider
	{
		readonly IIdentityProviderSettings _identityProviderSettings;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identityProviderSettings"></param>
		public FacebookIdentityProvider(IIdentityProviderSettings identityProviderSettings)
		{
			_identityProviderSettings = identityProviderSettings;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="externalIdentityProvider"></param>
		/// <returns></returns>
		public bool CanProcess(ExternalIdentityProviders externalIdentityProvider)
		{
			return ExternalIdentityProviders.Facebook == externalIdentityProvider;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public string GetTokenByCode(string code)
		{
			throw new NotImplementedException();
		}
	}
}
