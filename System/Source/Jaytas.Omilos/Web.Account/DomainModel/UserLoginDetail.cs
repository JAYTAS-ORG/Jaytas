using Jaytas.Omilos.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.DomainModel
{
	/// <summary>
	/// 
	/// </summary>
	public class UserLoginDetail : LongEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public long UserId { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Salt { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string FacebookId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string GoogleId { get; set; }

		/// <summary>
		/// User who owns this login details
		/// </summary>
		public User User { get; set; }
	}
}
