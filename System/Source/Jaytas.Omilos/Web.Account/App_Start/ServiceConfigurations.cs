using Jaytas.Omilos.Caching.Interfaces;
using Jaytas.Omilos.Caching.Providers;
using Jaytas.Omilos.Common.Helpers;
using Jaytas.Omilos.Configuration.Interfaces;
using Jaytas.Omilos.Configuration.Providers;
using Jaytas.Omilos.Security.TokenProvider;
using Jaytas.Omilos.Web.Account.Business;
using Jaytas.Omilos.Web.Account.Data.DbContext;
using Jaytas.Omilos.Web.Account.Data.Repositories;
using Microsoft.EntityFrameworkCore;
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
			IBaseConfiguration configurationProvider = null;

			services.AddDbContextPool<IUserDbContext, UserDbContext>((serviceProvider, options) =>
			{
				configurationProvider = serviceProvider.GetService<IBaseConfiguration>();
				options.UseMySql(configurationProvider.DatabaseConnectionIdentifier.RootConnection,
								 builderOptions => builderOptions.ServerVersion(new Version(5, 7), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql));
			});

			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IRoleProvider, RoleProvider>();
		}
	}
}