using Jaytas.Omilos.Data.EntityFramework.BaseEntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Campaign.Data.Map
{
	/// <summary>
	/// 
	/// </summary>
	public class ScheduleFluentMap : BaseLongEntityConfiguration<DomainModel.Schedule>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScheduleFluentMap" /> class.
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="schema"></param>
		/// <param name="isDatabaseGenerated"></param>
		public ScheduleFluentMap(string tableName, string schema, bool isDatabaseGenerated)
				: base(tableName, schema, isDatabaseGenerated, new Common.Domain.DefaultAuditableBaseFieldMapper())
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public override void Configure(EntityTypeBuilder<DomainModel.Schedule> builder)
		{
			base.Configure(builder);

			builder.Property(col => col.ScheduleId)
				 .HasColumnName(nameof(DomainModel.Schedule.ScheduleId))
				 .IsRequired();

			builder.Property(col => col.CampaignId)
				 .HasColumnName(nameof(DomainModel.Schedule.CampaignId))
				 .IsRequired();

			builder.Property(col => col.IsRecurrence)
				 .HasColumnName(nameof(DomainModel.Schedule.IsRecurrence))
				 .IsRequired();

			builder.Property(col => col.StartDate)
				 .HasColumnName(nameof(DomainModel.Schedule.StartDate))
				 .IsRequired();

			builder.Property(col => col.EndDate)
				 .HasColumnName(nameof(DomainModel.Schedule.EndDate))
				 .IsRequired();

			builder.Property(col => col.StartTime)
				 .HasColumnName(nameof(DomainModel.Schedule.StartTime))
				 .IsRequired();

			builder.Property(col => col.EndTime)
				 .HasColumnName(nameof(DomainModel.Schedule.EndTime))
				 .IsRequired();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public override void ConfigureKey(EntityTypeBuilder<DomainModel.Schedule> builder)
		{
			base.ConfigureKey(builder);

		}
	}
}
