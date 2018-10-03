using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Configuration.Interfaces
{
	public interface IBaseConfiguration
	{
		/// <summary>
		/// 
		/// </summary>
		IIdentityProviderSettings FaceBookAuthenticationSettings { get; }

		/// <summary>
		/// 
		/// </summary>
		IIdentityProviderSettings GoogleAuthenticationSettings { get; }
	}
}