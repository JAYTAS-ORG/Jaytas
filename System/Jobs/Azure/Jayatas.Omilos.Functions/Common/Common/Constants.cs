using System;
using System.Collections.Generic;
using System.Text;

namespace Jayatas.Omilos.Functions.Common.Common
{
	/// <summary>
	/// 
	/// </summary>
	public struct Constants
	{
		/// <summary>
		/// 
		/// </summary>
		public struct ConfigKeys
		{
			public const string EnvironmentName = "Jayatas.Omilos.EnvironmentName";

			public const string SmsNotificationInterval = "Jayatas.Omilos.SmsNotificationInterval";

			public const string LoadCampaignSmsRemainderInterval = "Jayatas.Omilos.LoadCampaignSmsRemainderInterval";

			public const string OmilosDbConnection = "Jayatas.Omilos.Database.Connection";

			public const string TwilioAccountId = "Jayatas.Omilos.Twilio.AccountId";

			public const string TwilioAccountSecret = "Jayatas.Omilos.Twilio.AccountSecret";

			public const string TwilioPhoneNumber = "Jayatas.Omilos.Twilio.PhoneNumber";

			public const string OmilosIntegrationConnection = "Jayatas.Omilos.Integration.Connection";

			public const string OmilosCampaignManagement = "Jayatas.Omilos.Integration.Topic.CampaignManagement";
		}

		public struct StoreProcedures
		{
			public struct GetSmsNotification
			{
				public const string Name = "notification.uspGetSmsNotification";

				public struct Parameters
				{
					public const string Status = "@notification_status";

					public const string NotificationDate = "@notification_Date";

					public const string NotificationTime = "@notification_Time";
				}
			}

			public struct GenerateCampaignInstances
			{
				public const string Name = "campaign.uspGenerateCampaignInstances";

				public struct Parameters
				{
					public const string CampaignId = "@campaignId";
				}
			}

			public struct LoadSmsNotificationForCampaignRemainder
			{
				public const string Name = "campaign.uspLoadSmsNotificationForCampaignRemainder";

				public struct Parameters
				{
					public const string CampaignId = "@campaignId";
				}
			}
		}

		public struct NameResolverKeys
		{
			public const string SmsNotificationInterval = "%" + ConfigKeys.SmsNotificationInterval + "%";

			public const string CampaignManagementTopic = "%" + ConfigKeys.OmilosCampaignManagement + "%";

			public const string LoadCampaignSmsRemainderInterval = "%" + ConfigKeys.LoadCampaignSmsRemainderInterval + "%";
		}

		public struct Subscriptions
		{
			public const string Published = "Published";

			public const string LoadTodaysNotificationsOnDemand = "LoadTodaysNotificationsOnDemand";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct MessageProperties
		{
			/// <summary>
			/// RequestId
			/// </summary>
			public const string RequestId = "RequestId";

			/// <summary>
			/// MessageType
			/// </summary>
			public const string Type = "Type";

			/// <summary>
			/// 
			/// </summary>
			public struct CampaignManagement
			{
				public const string EventType = "EventType";

				public const string CampaignIdentifier = "CampaignIdentifier";

				public struct AdditionalProperties
				{
					public const string CampaignStartDate = "CampaignStartDate";

					public const string CampaignStartTime = "CampaignStartTime";

					public const string CampaignTimeZone = "CampaignTimeZone";
				}
			}
		}

		public struct TimeZoneInformation
		{
			public const string Est = "EST";

			public const string Pst = "PST";

			public const string Cst = "CST";

			public const string Mst = "MST";

			public static readonly Dictionary<string, TimeZoneInfo> TimeZoneMapping = new Dictionary<string, TimeZoneInfo>
				{
					{ Est,  TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")},
					{ Pst,  TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")},
					{ Cst,  TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")},
					{ Mst,  TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time")}
				};
		}
	}
}