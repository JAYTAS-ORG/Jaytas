using AutoMapper;
using Jaytas.Omilos.Web.Mapping.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.App_Start
{
	/// <summary>
	/// 
	/// </summary>
	public class AutoMapperConfigurations
	{
		/// <summary>
		/// Registers both middle tier and web tier maps since our portal is currently running as a two-
		/// tier system (web &amp; data).
		/// </summary>
		/// <returns>Mapper</returns>
		public static IMapper RegisterMaps()
		{
			var mapperConfiguration = new MapperConfiguration(config =>
			{
				config.AddProfile(new GlobalMappingProfile());
				config.AddProfile(new WebProfile());
			});

			return mapperConfiguration.CreateMapper();
		}

		/// <summary>
		/// Registers the mappings used by the web tier to go to and from business models.
		/// </summary>
		///
		/// <seealso cref="T:AutoMapper.Profile"/>
		internal class WebProfile : Profile
		{
			public WebProfile()
			{
			}

			/// <summary>
			/// Gets the name of the profile.
			/// </summary>
			/// <value>
			/// The name of the profile.
			/// </value>
			public override string ProfileName => typeof(WebProfile).FullName;
		}
	}
}
