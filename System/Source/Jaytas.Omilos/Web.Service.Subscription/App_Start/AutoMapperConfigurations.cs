using AutoMapper;
using Jaytas.Omilos.Web.Mapping.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Subscription.App_Start
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
				CreateMap<DomainModel.Subscription, Models.Subscription.Subscription>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				CreateMap<Models.Subscription.Subscription, DomainModel.Subscription>().ForMember(dom => dom.ExposedId, api => api.MapFrom(model => model.Id));
				CreateMap<DomainModel.Subscription, Models.Subscription.SubscriptionWithGroupSummary>()
														.ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId))
														.ForMember(api => api.GroupSummary, dom => dom.ResolveUsing(Map));

				CreateMap<DomainModel.Group, Models.Subscription.Group>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				CreateMap<Models.Subscription.Group, DomainModel.Group>().ForMember(dom => dom.ExposedId, api => api.MapFrom(model => model.Id));

				CreateMap<DomainModel.Contact, Models.Subscription.Contact>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				CreateMap<Models.Subscription.Contact, DomainModel.Contact>().ForMember(dom => dom.ExposedId, api => api.MapFrom(model => model.Id));
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
			/// <param name="subscription"></param>
			/// <returns></returns>
			private Models.Subscription.GroupSummary Map(DomainModel.Subscription subscription)
			{
				if(subscription.Groups == null || subscription.Groups.Count() < 1)
				{
					return null;
				}

				var group = subscription.Groups.First();
				return new Models.Subscription.GroupSummary
				{
					Id = group.ExposedId,
					Name = group.Name,
					NumberOfContacts = group.GroupContactAssociations.Count()
				};
			}
		}
	}
}
