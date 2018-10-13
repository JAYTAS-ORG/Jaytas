using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Common
{
	public partial struct Constants
	{
		/// <summary>
		/// 
		/// </summary>
		public struct Schemas
		{
			/// <summary>
			/// 
			/// </summary>
			public struct Dbo
			{
				public const string Name = "dbo";
			}

			/// <summary>
			/// Schema for Account Management
			/// </summary>
			public struct Account
			{
				/// <summary>
				/// 
				/// </summary>
				public const string Name = "account";

				/// <summary>
				/// 
				/// </summary>
				public struct Tables
				{
					public const string Role = "role";

					public const string User = "user";

					public const string UserLoginDetail = "user_logindetail";

					public const string UserRole = "user_role";
				}
			}

			/// <summary>
			/// Schema for Campaign Management
			/// </summary>
			public struct Campaign
			{
				/// <summary>
				/// 
				/// </summary>
				public const string Name = "campaign";

				/// <summary>
				/// 
				/// </summary>
				public struct Tables
				{
					public const string Campaign = "campaign";

					public const string CampaignInstance = "campaign_instance";

					public const string CampaignInstanceException = "campaign_instance_exception";

					public const string MessageTemplate = "message_template";

					public const string Schedule = "schedule";

					public const string ScheduleRecurrencePattern = "schedule_recurrencepattern";
				}
			}

		}


		/// <summary>
		/// 
		/// </summary>
		public struct DefaultFieldMappings
		{
			/// <summary>
			/// 
			/// </summary>
			public const string CreatedDate = "CreatedDate";

			/// <summary>
			/// 
			/// </summary>
			public const string CreatedBy = "CreatedBy";

			/// <summary>
			/// 
			/// </summary>
			public const string ModifiedDate = "ModifiedDate";

			/// <summary>
			/// 
			/// </summary>
			public const string ModifiedBy = "ModifiedBy";

			/// <summary>
			/// 
			/// </summary>
			public const string PrimaryKey = "Id";
		}

		public struct CustomFeildMappings
		{
			/// <summary>
			/// 
			/// </summary>
			public const string UserId = "UserId";

			/// <summary>
			/// 
			/// </summary>
			public const string ScheduleId = "ScheduleId";
		}
	}
}
