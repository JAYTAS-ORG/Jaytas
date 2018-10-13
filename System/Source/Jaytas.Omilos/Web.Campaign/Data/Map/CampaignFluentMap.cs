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
	public class CampaignFluentMap : BaseLongEntityConfiguration<DomainModel.Campaign>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CampaignFluentMap" /> class.
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="schema"></param>
		/// <param name="isDatabaseGenerated"></param>
		public CampaignFluentMap(string tableName, string schema, bool isDatabaseGenerated)
				: base(tableName, schema, isDatabaseGenerated, new Common.Domain.DefaultAuditableBaseFieldMapper())
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public override void Configure(EntityTypeBuilder<DomainModel.Campaign> builder)
		{
			base.Configure(builder);

			builder.Property(col => col.CampaignId)
				 .HasColumnName(nameof(DomainModel.Campaign.CampaignId))
				 .IsRequired();

			builder.Property(col => col.SubscriptionId)
				 .HasColumnName(nameof(DomainModel.Campaign.SubscriptionId))
				 .IsRequired();

			builder.Property(col => col.GroupId)
				 .HasColumnName(nameof(DomainModel.Campaign.GroupId));

			builder.Property(col => col.Name)
				 .HasColumnName(nameof(DomainModel.Campaign.Name))
				 .HasMaxLength(150)
				 .IsRequired();

			builder.Property(col => col.NotificationChannels)
				 .HasColumnName(nameof(DomainModel.Campaign.NotificationChannels))
				 .IsRequired();

			builder.Property(col => col.IsWelcomeMessageRequired)
				 .HasColumnName(nameof(DomainModel.Campaign.IsWelcomeMessageRequired))
				 .IsRequired();

			builder.Property(col => col.IsRemainderMessageRequired)
				 .HasColumnName(nameof(DomainModel.Campaign.IsRemainderMessageRequired))
				 .IsRequired();

			builder.Property(col => col.IsOverDueMessageRequired)
				 .HasColumnName(nameof(DomainModel.Campaign.IsOverDueMessageRequired))
				 .IsRequired();

			builder.Property(col => col.Status)
				 .HasColumnName(nameof(DomainModel.Campaign.Status))
				 .IsRequired();

			builder.Property(col => col.CampaignManagerMailId)
				 .HasColumnName(nameof(DomainModel.Campaign.CampaignManagerMailId))
				 .HasMaxLength(255);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public override void ConfigureKey(EntityTypeBuilder<DomainModel.Campaign> builder)
		{
			base.ConfigureKey(builder);

		}
	}
}
