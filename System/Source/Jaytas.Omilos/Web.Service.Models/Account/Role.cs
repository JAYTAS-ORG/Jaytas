using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Web.Service.Models.Account
{
	/// <summary>
	/// 
	/// </summary>
	public class Role
	{
		/// <summary>
		/// 
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Description property represenation of database column.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// IsActive property represenation of database column.
		/// </summary>
		public bool IsActive { get; set; }
	}
}
