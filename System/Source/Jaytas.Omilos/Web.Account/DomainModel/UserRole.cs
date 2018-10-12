﻿using Jaytas.Omilos.Common.Domain;
using System;

namespace Jaytas.Omilos.Web.Account.DomainModel
{
	/// <summary>
	/// UserRole Entity representation of database table.
	/// </summary>
	public class UserRole : LongEntity
	{
		/// <summary>
		/// UserId property represenation of database column.
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// RoleId property represenation of database column.
		/// </summary>
		public int RoleId { get; set; }

		/// <summary>
		/// Scope property represenation of database column.
		/// </summary>
		public string Scope { get; set; }

		/// <summary>
		/// StartDate property represenation of database column.
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// EndDate property represenation of database column.
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Role Entity represenation of database table.
		/// </summary>
		public virtual Role Role { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual User User { get; set; }
	}
}
