using Jaytas.Omilos.Common.Domain;
using Jaytas.Omilos.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Campaign.DomainModel
{
	/// <summary>
	/// 
	/// </summary>
	public partial class MessageTemplate : LongEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public Guid MessageId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long CampaignId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public NotificationChannels NotificationChannel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string WelcomeMessage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string RemainderMessage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string OverDueMessage { get; set; }
	}
}
