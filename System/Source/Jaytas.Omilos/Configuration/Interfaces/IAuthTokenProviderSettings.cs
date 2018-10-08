using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Configuration.Interfaces
{
	public interface IAuthTokenProviderSettings
	{
		/// <summary>
		/// 
		/// </summary>
		string TokenSigningSecret { get; set; }

		/// <summary>
		/// 
		/// </summary>
		int ExpiryTimeInMinutes { get; set; }
	}
}
