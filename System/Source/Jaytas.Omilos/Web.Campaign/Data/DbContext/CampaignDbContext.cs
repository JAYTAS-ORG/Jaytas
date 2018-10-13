using Jaytas.Omilos.Data.EntityFramework.BaseImplementations;
using Jaytas.Omilos.Web.Service.Campaign.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Campaign.Data.DbContext
{
	public class CampaignDbContext : MicroServiceDbContext<CampaignDbContext>, ICampaignDbContext
	{
		/// <summary>
		/// Constructor which sets the db Initializer.
		/// </summary>
		/// <param name="options">Db context options.</param>
		public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public DbSet<DomainModel.Campaign> Campaigns { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DbSet<CampaignInstance> CampaignInstances { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DbSet<CampaignInstanceException> CampaignInstanceExceptions { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DbSet<MessageTemplate> MessageTemplates { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DbSet<Schedule> Schedules { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DbSet<RecurrencePattern> RecurrencePatterns { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
