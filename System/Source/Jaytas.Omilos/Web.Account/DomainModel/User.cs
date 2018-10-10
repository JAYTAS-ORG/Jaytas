using Jaytas.Omilos.Common.Domain;
using System;
using System.Collections.Generic;

namespace Jaytas.Omilos.Web.Account.DomainModel
{
	/// <summary>
	/// User Entity representation of database table.
	/// </summary>
	public partial class User : AuditableLongEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="User" /> class and also UerRoles.
		/// </summary>
		public User()
		{
			UserRoles = new HashSet<UserRole>();
		}

		/// <summary>
		/// GraphId property represenation of database column.
		/// </summary>
		public Guid GraphId { get; set; }

		/// <summary>
		/// FirstName property represenation of database column.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// LastName property represenation of database column.
		/// </summary>
		public string LastName { get; set; }
		
		/// <summary>
		/// Email property represenation of database column.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Culture property represenation of database column.
		/// </summary>
		public string Culture { get; set; }

		/// <summary>
		/// IsActive property represenation of database column.
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// UserRoles Entity represenation of database Table.
		/// </summary>
		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
