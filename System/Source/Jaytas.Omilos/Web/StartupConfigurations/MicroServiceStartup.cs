using AutoMapper;
using Jaytas.Omilos.Common;
using Jaytas.Omilos.Security.TokenProvider;
using Jaytas.Omilos.Web.Extensions;
using Jaytas.Omilos.Web.Filters.Operations;
using Jaytas.Omilos.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace Jaytas.Omilos.Web.StartupConfigurations
{
	public abstract class MicroServiceStartup
	{
		/// <summary>
		/// 
		/// </summary>
		public static Guid Id;

		/// <summary>
		/// 
		/// </summary>
		IServiceProvider _serviceProvider;

		// This method gets called by the runtime. Use this method to add services to the container.
		public virtual void ConfigureServices(IServiceCollection services)
		{
			Id = Guid.NewGuid();

			//Adds Mapper Configurations
			services.AddMaps(ConfigureMaps);

			//Adds cusom types
			services.AddOmilosTypes(RegisterTypes);

			//Adds response compression
			services.AddResponseCompression();

			//Get registered services
			_serviceProvider = services.BuildServiceProvider();

			//Configures Swagger
			services.AddSwagger(ConfigureSwagger);

			//Add Bearer Configuration
			services.AddOmilosAuthentication(JwtBearerDefaults.AuthenticationScheme, ConfigureJwtBearerOptions);

			//Add Omilos Cors Policy
			services.AddOmilosCors(ConfigureCors);

			//Add custom middlewares
			services.AddTransient<RequestBootstrapMiddleware>();
			services.AddTransient<AuthorizationMiddleware>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// Use this method to configure the HTTP request pipeline.
		public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app.UseHsts();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseResponseCompression();

			app.UseRequestBootstrap();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint(Constants.Swagger.ApiVersions.V1.Endpoint, Constants.Swagger.ApiVersions.V1.Title);
			});

			app.UseMvcWithDefaultRoute();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected virtual void ConfigureJwtBearerOptions(JwtBearerOptions jwtBearerOptions)
		{
			jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,

				ValidIssuer = Constants.BearerOptions.TokenValidationParameters.Issuer,
				ValidAudience = Constants.BearerOptions.TokenValidationParameters.Audience,
				IssuerSigningKey = _serviceProvider.GetService<IAuthTokenProvider>().GetSecurityKey()
			};
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="corsOptions"></param>
		protected virtual void ConfigureCors(CorsOptions corsOptions)
		{
			var corsPolicyBuilder = new CorsPolicyBuilder(new CorsPolicy())
										.AllowAnyHeader()
										.AllowAnyMethod()
										.AllowAnyOrigin()
										.AllowCredentials()
										.WithExposedHeaders(HttpResponseHeader.Location.ToString(),
															Constants.SharedHttpHeaders.PagingTotal,
															Constants.SharedHttpHeaders.PagingFirst,
															Constants.SharedHttpHeaders.PagingLast);
			corsOptions.AddDefaultPolicy(corsPolicyBuilder.Build());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="swaggerGenOptions"></param>
		protected virtual void ConfigureSwagger(SwaggerGenOptions swaggerGenOptions)
		{
			swaggerGenOptions.SwaggerDoc(Constants.ApiVersions.V1, new Swashbuckle.AspNetCore.Swagger.Info
			{
				Version = Constants.Swagger.ApiVersions.V1.Version,
				Title = Constants.Swagger.ApiVersions.V1.Title,
				Description = Constants.Swagger.ApiVersions.V1.Description,
				TermsOfService = Constants.Swagger.ApiVersions.V1.TermsOfService,
				Contact = new Contact() { Name = Constants.Swagger.Contact.Name, Email = Constants.Swagger.Contact.Email, Url = Constants.Swagger.Contact.Url }
			});
			swaggerGenOptions.IncludeXmlComments(GetXmlCommentsPath());
			swaggerGenOptions.DescribeAllEnumsAsStrings();
			swaggerGenOptions.OperationFilter<MultipleOperationsWithSameVerbFilter>();
		}

		/// <summary>
		/// Gets API version route string.
		/// </summary>
		/// <returns>
		/// The API version string, e.g. 'v1'.
		/// </returns>
		protected virtual string GetApiVersion()
		{
			return Constants.ApiVersions.V1;
		}

		/// <summary>
		/// Gets Api name.
		/// </summary>
		/// <returns>
		/// The Api name.
		/// </returns>
		protected virtual string GetApiName()
		{
			return string.Concat(GetMicroServiceAssembly().GetName().Name, Constants.Characters.Space, Constants.Common.Api);
		}

		/// <summary>
		/// Gets the Xml Comments Path.
		/// </summary>
		/// <returns>
		/// The XML comments path.
		/// </returns>
		protected virtual string GetXmlCommentsPath()
		{
			var commentsFileName = GetMicroServiceAssembly().GetName().Name + Constants.FileExtensions.Xml;
			return Path.Combine(AppContext.BaseDirectory, commentsFileName);
		}

		/// <summary>
		/// Registers all of the AutoMapper DTO maps.
		/// </summary>
		protected abstract IMapper ConfigureMaps();

		/// <summary>
		/// Registers all the custom types used by API
		/// </summary>
		/// <param name="services">services collection</param>
		protected abstract void RegisterTypes(IServiceCollection services);

		/// <summary>
		/// Returns the microservice specific assembly so that XML documentation paths and
		/// Api names can be derived.
		/// </summary>
		/// <returns></returns>
		protected abstract Assembly GetMicroServiceAssembly();
	}
}