using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Security.TokenProvider
{
	public interface ITokenProvider
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		SymmetricSecurityKey GetSecurityKey();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		string GetToken();
	}
}
