using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Common
{
	public partial struct Constants
	{
		public struct Secrets
		{
			public struct AuthTokenProviderSettings
			{
				public struct JwtBearer
				{
					public const string SettingsSectionName = "Secrets:JwtBearerToken";

					public const int ExpiryTimeInMinutes = 60;
				}
			}
			
			public struct IdentityProviderSettings
			{
				public struct Facebook
				{
					public const string SettingsSectionName = "Secrets:Identity:Facebook";

					public const string GraphBaseUri = "https://graph.facebook.com";

					public const string AccessTokenUri = "/v3.1/oauth/access_token";

					public const string UserUri = "/me";
				}

				public struct Google
				{
					public const string SettingsSectionName = "Secrets:Identity:Google";

					public const string GraphBaseUri = "";

					public const string AccessTokenUri = "";

					public const string UserUri = "";
				}

				public struct RequestParameters
				{
					public const string ClientId = "client_id";

					public const string ClientSecret = "client_secret";

					public const string Code = "code";

					public const string State = "state";

					public const string RedirectUri = "redirect_uri";

					public const string Fields = "fields";
				}

				public struct ResponseParameters
				{
					public const string AccessToken = "access_token";

					public const string TokenType = "token_type";

					public const string ExpiresIn = "expires_in";
				}

				public struct Scope
				{
					public const string Email = "email";
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