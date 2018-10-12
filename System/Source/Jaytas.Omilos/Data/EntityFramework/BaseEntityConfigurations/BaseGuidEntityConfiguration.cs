using Jaytas.Omilos.Common;
using Jaytas.Omilos.Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Data.EntityFramework.BaseEntityConfigurations
{
	/// <summary>
	/// A data model configuration.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{TEntity}"/>
	public abstract class BaseGuidEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : GuidEntity
	{
		string _tableName, _schema;

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseGuidEntityConfiguration{TEntity}"/> class.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="schema">The schema.</param>
		protected BaseGuidEntityConfiguration(string tableName, string schema)
		{
			_tableName = tableName;
			_schema = string.IsNullOrWhiteSpace(schema) ? Constants.Schemas.Dbo : schema;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.ToTable(_tableName, _schema);

			// Default shared properties
			builder.Property(x => x.Id)
				   .HasColumnName(nameof(GuidEntity.Id))
				   .IsRequired()
				   .ValueGeneratedNever();

			ConfigureKey(builder);
		}


		/// <summary>
		/// Configures the primary key for this table as just the Primitive Id.
		/// </summary>
		protected virtual void ConfigureKey(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(x => x.Id);
		}
	}
}
