using Jaytas.Omilos.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Configuration.Interfaces
{
	public abstract class BaseConfiguration : IBaseConfiguration
	{
		protected IConfiguration _configuration;

		protected BaseConfiguration(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// 
		/// </summary>
		public IIdentityProviderSettings FaceBookAuthenticationSettings { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public IIdentityProviderSettings GoogleAuthenticationSettings { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public string DefaultRootDatabaseConnectionIdentifier { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public string DefaultRootIntegrationConnectionIdentifier { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public string DefaultRootCacheConnectionIdentifier { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		protected void ParseConfiguration()
		{
			LoadAuthenticationSettings();
			LoadConnectionIdentifierSettings();
		}

		/// <summary>
		/// 
		/// </summary>
		private void LoadAuthenticationSettings()
		{
			FaceBookAuthenticationSettings = _configuration.GetSection(Constants.Secrets.IdentityProviderSettings.Facebook.SettingsSectionName).Get<Models.FacebookIdentityProviderSettings>();
			GoogleAuthenticationSettings = _configuration.GetSection(Constants.Secrets.IdentityProviderSettings.Google.SettingsSectionName).Get<Models.GoogleIdentityProviderSettings>();
		}

		/// <summary>
		/// 
		/// </summary>
		private void LoadConnectionIdentifierSettings()
		{
			DefaultRootDatabaseConnectionIdentifier = _configuration.GetSection(Constants.Secrets.ConnectionIdentifierSettings.Database.Default).Get<Models.ConnectionIdentifierSettings>().RootConnection;
			DefaultRootIntegrationConnectionIdentifier = _configuration.GetSection(Constants.Secrets.ConnectionIdentifierSettings.Integration.Default).Get<Models.ConnectionIdentifierSettings>().RootConnection;
			DefaultRootCacheConnectionIdentifier = _configuration.GetSection(Constants.Secrets.ConnectionIdentifierSettings.Cache.Default).Get<Models.ConnectionIdentifierSettings>().RootConnection;
		}
	}
}