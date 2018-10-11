﻿using System.Reflection;
using AutoMapper;
using Jaytas.Omilos.Web.Account.App_Start;
using Jaytas.Omilos.Web.StartupConfigurations;
using Microsoft.Extensions.DependencyInjection;

namespace Jaytas.Omilos.Web.Account
{
	/// <summary>
	/// 
	/// </summary>
	public class Startup : MicroServiceStartup
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override IMapper ConfigureMaps()
		{
			return AutoMapperConfigurations.RegisterMaps();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="services"></param>
		protected override void RegisterTypes(IServiceCollection services)
		{
			base.RegisterTypes(services);
			ServiceConfigurations.RegisterTypes(services);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override Assembly GetMicroServiceAssembly()
		{
			return Assembly.GetExecutingAssembly();
		}
	}
}