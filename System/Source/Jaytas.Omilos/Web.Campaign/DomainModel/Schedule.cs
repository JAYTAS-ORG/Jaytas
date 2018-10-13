﻿using Jaytas.Omilos.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Campaign.DomainModel
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Schedule : LongEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public Guid ScheduleId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long CampaignId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsRecurrence { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public TimeSpan StartTime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public TimeSpan EndTime { get; set; }
	}
}
