using Jaytas.Omilos.Configuration.Interfaces;
using Jaytas.Omilos.Web.Service.Campaign.Data.DbContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaytas.Omilos.Web.Service.Campaign.Data.Repositories;
using Jaytas.Omilos.Web.Service.Campaign.Data.Repositories.Interfaces;
using Jaytas.Omilos.Web.Service.Campaign.Business;
using Jaytas.Omilos.Web.Service.Campaign.Business.Interfaces;

namespace Jaytas.Omilos.Web.Service.Campaign.App_Start
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
			services.AddDbContextPool<ICampaignDbContext, CampaignDbContext>((serviceProvider, options) =>
			{
				configurationProvider = serviceProvider.GetService<IBaseConfiguration>();
				options.UseLazyLoadingProxies();
				options.UseMySql(configurationProvider.DatabaseConnectionIdentifier.RootConnection,
								 builderOptions => builderOptions.ServerVersion(new Version(5, 7), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql));
			});

			services.AddScoped<ICampaignRepository, CampaignRepository>();
			services.AddScoped<ICampaignInstanceRepository, CampaignInstanceRepository>();
			services.AddScoped<ICampaignInstanceExceptionRepository, CampaignInstanceExceptionRepository>();
			services.AddScoped<IMessageTemplateRepository, MessageTemplateRepository>();
			services.AddScoped<IScheduleRepository, ScheduleRepository>();

			services.AddScoped<ICampaignProvider, CampaignProvider>();
			services.AddScoped<ICampaignInstanceProvider, CampaignInstanceProvider>();
			services.AddScoped<ICampaignInstanceExceptionProvider, CampaignInstanceExceptionProvider>();
			services.AddScoped<IMessageTemplateProvider, MessageTemplateProvider>();
			services.AddScoped<IScheduleProvider, ScheduleProvider>();
		}
	}
}
