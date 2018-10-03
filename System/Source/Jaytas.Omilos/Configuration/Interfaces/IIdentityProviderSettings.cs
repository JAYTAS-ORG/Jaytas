using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Configuration.Interfaces
{
	public interface IIdentityProviderSettings
	{
		string AccessTokenUri { get; set; }

		string UserUri { get; set; }

		string AppId { get; set; }

		string AppSecret { get; set; }
	}
}