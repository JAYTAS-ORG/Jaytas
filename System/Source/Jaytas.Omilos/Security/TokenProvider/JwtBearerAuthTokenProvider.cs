using System;
using System.Collections.Generic;
using System.Text;
using Jaytas.Omilos.Configuration.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Jaytas.Omilos.Security.TokenProvider
{
	/// <summary>
	/// 
	/// </summary>
	public class JwtBearerAuthTokenProvider : IAuthTokenProvider
	{
		IBaseConfiguration _baseConfiguration;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseConfiguration"></param>
		public JwtBearerAuthTokenProvider(IBaseConfiguration baseConfiguration)
		{
			_baseConfiguration = baseConfiguration;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public SymmetricSecurityKey GetSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_baseConfiguration.JwtBearerAuthTokenProviderSettings.SingingSecret));
		}


		public string GetToken()
		{
			throw new NotImplementedException();
		}
	}
}
