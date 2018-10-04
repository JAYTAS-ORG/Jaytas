using AutoMapper;
using Jaytas.Omilos.Common.Enumerations;
using Jaytas.Omilos.Common.Exceptions;
using Jaytas.Omilos.Common.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Web.Mapping.Profiles
{
	/// <summary>
	/// Registers the globally shared AutoMapper rules necessary for proper microservice functionality, i.e. to call the Authorization microservice.
	/// </summary>
	/// <seealso cref="AutoMapper.Profile" />
	public class GlobalMappingProfile : Profile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GlobalMappingProfile"/> class.
		/// </summary>
		public GlobalMappingProfile()
		{
			// create the singleton instance to be used for all maps
			FreindlyErrorTypeConverter _errorTypeConverter = new FreindlyErrorTypeConverter();
			CreateMap<ApiErrors, FriendlyError>().ConvertUsing(_errorTypeConverter);
			CreateMap<BusinessValidationException, FriendlyError>().ConvertUsing(_errorTypeConverter);
		}

		/// <summary>
		/// Gets the name of the profile.
		/// </summary>
		/// <value>
		/// The name of the profile.
		/// </value>
		public override string ProfileName => typeof(GlobalMappingProfile).FullName;
	}
}
