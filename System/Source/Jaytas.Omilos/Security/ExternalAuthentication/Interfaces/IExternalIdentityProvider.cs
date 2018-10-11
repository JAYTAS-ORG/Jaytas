using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Security.ExternalAuthentication.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IExternalIdentityProvider
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="externalIdentityProvider"></param>
		/// <returns></returns>
		bool CanProcess(Common.Enumerations.ExternalIdentityProviders externalIdentityProvider);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		string GetTokenByCode(string code);
	}
}
