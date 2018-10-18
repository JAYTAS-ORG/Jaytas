using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Subscription.DomainModel
{
	/// <summary>
	/// 
	/// </summary>
	public class GroupContactAssociation
	{
		/// <summary>
		/// 
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long ContactId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool HasOptedOut { get; set; }
	}
}
