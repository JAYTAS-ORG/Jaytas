using AutoMapper;
using Jaytas.Omilos.Web.Mapping.Profiles;
using System.Collections.Generic;

namespace Jaytas.Omilos.Web.Service.Campaign.App_Start
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
				CreateMap<DomainModel.Campaign, Models.Campaign.Campaign>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				CreateMap<Models.Campaign.Campaign, DomainModel.Campaign>().ForMember(dom => dom.ExposedId, api => api.MapFrom(model => model.Id));
				CreateMap<DomainModel.Campaign, Models.Campaign.CampaignSummary>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				
				CreateMap<DomainModel.CampaignInstance, Models.Campaign.CampaignInstance>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				CreateMap<Models.Campaign.CampaignInstance, DomainModel.CampaignInstance>().ForMember(dom => dom.ExposedId, api => api.MapFrom(model => model.Id));

				CreateMap<DomainModel.CampaignInstanceException, Models.Campaign.CampaignInstanceException>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				CreateMap<Models.Campaign.CampaignInstanceException, DomainModel.CampaignInstanceException>().ForMember(dom => dom.ExposedId, api => api.MapFrom(model => model.Id));

				CreateMap<DomainModel.MessageTemplate, Models.Campaign.MessageTemplate>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				CreateMap<Models.Campaign.MessageTemplate, DomainModel.MessageTemplate>().ForMember(dom => dom.ExposedId, api => api.MapFrom(model => model.Id));

				CreateMap<DomainModel.Schedule, Models.Campaign.Schedule>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));
				CreateMap<Models.Campaign.Schedule, DomainModel.Schedule>().ForMember(dom => dom.ExposedId, api => api.MapFrom(model => model.Id));
				CreateMap<DomainModel.Schedule, Models.Campaign.ScheduleSummary>().ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.ExposedId));

				CreateMap<Models.Subscription.SubscriptionWithGroupSummary, Models.Subscription.Subscription>();
				CreateMap<Models.Subscription.SubscriptionWithGroupSummary, Models.Subscription.GroupSummary>()
													.ForMember(api => api.Id, domain => domain.MapFrom(dom => dom.GroupSummary.Id))
													.ForMember(api => api.Name, domain => domain.MapFrom(dom => dom.GroupSummary.Name))
													.ForMember(api => api.NumberOfContacts, domain => domain.MapFrom(dom => dom.GroupSummary.NumberOfContacts));
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
