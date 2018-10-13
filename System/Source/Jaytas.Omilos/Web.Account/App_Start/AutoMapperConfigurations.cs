﻿using AutoMapper;
using Jaytas.Omilos.Web.Mapping.Profiles;
using Jaytas.Omilos.Web.Service.Models.Account;
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
				CreateMap<string, SigninResponse>().ForMember(response => response.AccessToken, domain => domain.MapFrom(dom => dom));

				CreateMap<UserData, DomainModel.User>().ConvertUsing(Map);
				CreateMap<UserData, DomainModel.UserLoginDetail>().ConstructUsing(MapLoginDetail);

				CreateMap<DomainModel.User, User>()
						.ForMember(api => api.UserId, domain => domain.MapFrom(dom => dom.GraphId))
						.ForMember(api => api.FirstName, domain => domain.MapFrom(dom => dom.FirstName))
						.ForMember(api => api.LastName, domain => domain.MapFrom(dom => dom.LastName))
						.ForMember(api => api.Email, domain => domain.MapFrom(dom => dom.EmailId));
			}

			/// <summary>
			/// Gets the name of the profile.
			/// </summary>
			/// <value>
			/// The name of the profile.
			/// </value>
			public override string ProfileName => typeof(WebProfile).FullName;

			/// <summary>
			/// 
			/// </summary>
			/// <param name="userData"></param>
			/// <returns></returns>
			private DomainModel.User Map(UserData userData)
			{
				var user = new DomainModel.User
				{
					GraphId = Guid.NewGuid(),
					EmailId = userData.Email,
					IsActive = true,
					UserLoginDetail = MapLoginDetail(userData)
				};

				return user;
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="userData"></param>
			/// <returns></returns>
			private DomainModel.UserLoginDetail MapLoginDetail(UserData userData)
			{
				var userLoginDetail = new DomainModel.UserLoginDetail();

				if (userData.ExternalIdentityProvider == Common.Enumerations.ExternalIdentityProviders.Facebook)
				{
					userLoginDetail.FacebookId = userData.Id;
				}

				if (userData.ExternalIdentityProvider == Common.Enumerations.ExternalIdentityProviders.Google)
				{
					userLoginDetail.GoogleId = userData.Id;
				}

				return userLoginDetail;
			}
		}
	}
}
