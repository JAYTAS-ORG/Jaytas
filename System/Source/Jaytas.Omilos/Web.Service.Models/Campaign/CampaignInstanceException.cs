using Jaytas.Omilos.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Web.Service.Models.Campaign
{
	public class CampaignInstanceException : IHaveLinks
	{
		/// <summary>
		/// 
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsRescheduled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsCancelled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public TimeSpan? StartTime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public TimeSpan? EndTime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<Link> Links { get; set; } = new List<Link>();
	}
}
