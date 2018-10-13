using Jaytas.Omilos.Common.Domain;
using Jaytas.Omilos.Common.Enumerations;

namespace Jaytas.Omilos.Web.Service.Campaign.DomainModel
{
	/// <summary>
	/// 
	/// </summary>
	public partial class RecurrencePattern : LongEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public RecurringType RecurringType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? SeparationCount { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? MaxNumberOfOccurrences { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int? DayOfWeek { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? WeekOfMonth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? DayOfMonth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? MonthOfYear { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Schedule Schedule { get; set; }
	}
}
