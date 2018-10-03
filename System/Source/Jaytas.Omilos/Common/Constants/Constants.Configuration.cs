using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Common
{
	public partial struct Constants
	{
		public struct Secrets
		{
			public struct IdentityProviderSettings
			{
				public struct Facebook
				{
					public const string SettingsSectionName = "Secrets:Identity:Facebook";

					public const string AccessTokenUri = "https://graph.facebook.com/v3.1/oauth/access_token";

					public const string UserUri = "https://graph.facebook.com/me";
				}

				public struct Google
				{
					public const string SettingsSectionName = "Secrets:Identity:Google";

					public const string AccessTokenUri = "";

					public const string UserUri = "";
				}
			}

			public struct ConnectionIdentifierSettings
			{
				public struct Database
				{
					public const string Default = "Secrets:Database:Default";
				}

				public struct Integration
				{
					public const string Default = "Secrets:Integration:Default";
				}

				public struct Cache
				{
					public const string Default = "Secrets:Cache:Default";
				}
			}
		}
	}
}