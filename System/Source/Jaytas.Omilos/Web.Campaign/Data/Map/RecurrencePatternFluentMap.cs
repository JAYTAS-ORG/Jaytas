using Jaytas.Omilos.Common;
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
	public class RecurrencePatternFluentMap : BaseLongEntityConfiguration<DomainModel.RecurrencePattern>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CampaignFluentMap" /> class.
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="schema"></param>
		/// <param name="isDatabaseGenerated"></param>
		public RecurrencePatternFluentMap(string tableName, string schema, bool isDatabaseGenerated)
				: base(tableName, schema, isDatabaseGenerated, new Common.Domain.CustomBaseFieldMapper(Constants.CustomFeildMappings.ScheduleId))
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public override void Configure(EntityTypeBuilder<DomainModel.RecurrencePattern> builder)
		{
			builder.ToTable(TableName, Schema);

			builder.Property(col => col.Id)
				.HasColumnName(Constants.CustomFeildMappings.ScheduleId)
				.IsRequired();

			builder.Property(col => col.RecurringType)
				 .HasColumnName(nameof(DomainModel.RecurrencePattern.RecurringType))
				 .IsRequired();

			builder.Property(col => col.SeparationCount)
				 .HasColumnName(nameof(DomainModel.RecurrencePattern.SeparationCount));

			builder.Property(col => col.MaxNumberOfOccurrences)
				 .HasColumnName(nameof(DomainModel.RecurrencePattern.MaxNumberOfOccurrences));

			builder.Property(col => col.DayOfWeek)
				 .HasColumnName(nameof(DomainModel.RecurrencePattern.DayOfWeek));

			builder.Property(col => col.WeekOfMonth)
				 .HasColumnName(nameof(DomainModel.RecurrencePattern.WeekOfMonth));

			builder.Property(col => col.DayOfMonth)
				 .HasColumnName(nameof(DomainModel.RecurrencePattern.DayOfMonth));

			builder.Property(col => col.MonthOfYear)
				 .HasColumnName(nameof(DomainModel.RecurrencePattern.MonthOfYear));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public override void ConfigureKey(EntityTypeBuilder<DomainModel.RecurrencePattern> builder)
		{
		}
	}
}
