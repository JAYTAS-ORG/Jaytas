using Jaytas.Omilos.Common.Enumerations;
using Jaytas.Omilos.Configuration.Interfaces;
using Jaytas.Omilos.Security.ExternalAuthentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Security.ExternalAuthentication.Providers
{
	/// <summary>
	/// 
	/// </summary>
	public class GoogleIdentityProvider : IExternalIdentityProvider
	{
		readonly IIdentityProviderSettings _identityProviderSettings;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identityProviderSettings"></param>
		public GoogleIdentityProvider(IIdentityProviderSettings identityProviderSettings)
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
			return ExternalIdentityProviders.Google == externalIdentityProvider;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public async Task<string> AcquireTokenByCodeAsync(string code)
		{
			throw new NotImplementedException();
		}
	}
}
