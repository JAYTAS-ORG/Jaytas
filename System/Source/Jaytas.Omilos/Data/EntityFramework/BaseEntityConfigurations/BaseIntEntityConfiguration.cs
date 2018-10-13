using Jaytas.Omilos.Common;
using Jaytas.Omilos.Common.Domain;
using Jaytas.Omilos.Common.Domain.Interfaces;
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
	public abstract class BaseIntEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : IntEntity
	{
		string _tableName, _schema;
		IBaseFieldMapper _baseFieldMapper;
		bool _isDatabaseGenerated;

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseLongEntityConfiguration{TEntity}"/> class.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="schema">The schema. dbo will be used if null or empty </param>
		/// <param name="isDatabaseGenerated">Value of this generated at database</param>
		protected BaseIntEntityConfiguration(string tableName, string schema, bool isDatabaseGenerated, IBaseFieldMapper baseFieldMapper)
		{
			_schema = string.IsNullOrWhiteSpace(schema) ? Constants.Schemas.Dbo : schema;
			_tableName = tableName;
			_baseFieldMapper = baseFieldMapper;
			_isDatabaseGenerated = isDatabaseGenerated;
		}

		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.ToTable(_tableName, _schema);

			// Default shared properties
			builder.Property(x => x.Id)
				.HasColumnName(_baseFieldMapper.Id)
				.IsRequired();

			if (_isDatabaseGenerated)
			{
				builder.Property(_baseFieldMapper.Id).ValueGeneratedOnAdd();
			}
			else
			{
				builder.Property(_baseFieldMapper.Id).ValueGeneratedNever();
			}

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
