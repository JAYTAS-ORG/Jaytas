﻿using Jaytas.Omilos.Common;
using Jaytas.Omilos.Data.EntityFramework.BaseEntityConfigurations;
using Jaytas.Omilos.Web.Account.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Jaytas.Omilos.Common.Constants;

namespace Jaytas.Omilos.Web.Account.Data.Map
{
	/// <summary>
	/// 
	/// </summary>
	public class UserLoginDetailFluentMap : BaseLongEntityConfiguration<UserLoginDetail>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RoleFluentMap" /> class.
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="schema"></param>
		/// <param name="isDatabaseGenerated"></param>
		public UserLoginDetailFluentMap(string tableName, string schema, bool isDatabaseGenerated) 
				: base(tableName, schema, isDatabaseGenerated, new Common.Domain.CustomBaseFieldMapper(LoginDetailFeildMappings.PrimaryKey))
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public override void Configure(EntityTypeBuilder<UserLoginDetail> builder)
		{
			builder.ToTable(TableName, Schema);

			builder.Property(col => col.Id)
				.HasColumnName(LoginDetailFeildMappings.PrimaryKey)
				.IsRequired();
			
			builder.Property(col => col.Salt)
				 .HasColumnName(nameof(UserLoginDetail.Salt))
				 .HasMaxLength(50);

			builder.Property(col => col.Password)
				 .HasColumnName(nameof(UserLoginDetail.Password))
				 .HasMaxLength(100);

			builder.Property(col => col.FacebookId)
				 .HasColumnName(nameof(UserLoginDetail.FacebookId));

			builder.Property(col => col.GoogleId)
				 .HasColumnName(nameof(UserLoginDetail.GoogleId));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		public override void ConfigureKey(EntityTypeBuilder<UserLoginDetail> builder)
		{
			builder.HasOne(user => user.User)
				   .WithOne(user => user.UserLoginDetail)
				   .HasForeignKey<User>(user => user.Id);
		}
	}
}