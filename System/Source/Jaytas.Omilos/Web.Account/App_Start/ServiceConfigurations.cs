using Jaytas.Omilos.Caching.Interfaces;
using Jaytas.Omilos.Caching.Providers;
using Jaytas.Omilos.Common.Helpers;
using Jaytas.Omilos.Configuration.Interfaces;
using Jaytas.Omilos.Configuration.Providers;
using Jaytas.Omilos.Security.TokenProvider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.App_Start
{
	/// <summary>
	/// 
	/// </summary>
	public class ServiceConfigurations
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="services"></param>
		public static void RegisterTypes(IServiceCollection services)
		{
			services.AddSingleton<IBaseConfiguration, DefaultConfigurationProvider>();
			services.AddSingleton<IAuthTokenProvider, JwtBearerAuthTokenProvider>();
			services.AddSingleton<ICachePolicyProvider, StaticCachePolicyProvider>();
			services.AddSingleton<IResourceUrlBuilder, ResourceUrlBuilder>();
			services.AddSingleton<ICacheProvider>((serviceProvider) =>
			{
				var configuration = serviceProvider.GetService<IBaseConfiguration>();
				var cachePolicyProvider = serviceProvider.GetService<ICachePolicyProvider>();

				return new RedisCacheProvider(cachePolicyProvider, configuration.CacheConnectionIdentifier.RootConnection);
			});
		}
	}
}
