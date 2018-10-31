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

			public const string OmilosDbConnection = "Jayatas.Omilos.Database.Connection";

			public const string TwilioAccountId = "Jayatas.Omilos.Twilio.AccountId";

			public const string TwilioAccountSecret = "Jayatas.Omilos.Twilio.AccountSecret";

			public const string TwilioPhoneNumber = "Jayatas.Omilos.Twilio.PhoneNumber";
		}

		public struct StoreProcedures
		{
			public struct GetSmsNotification
			{
				public const string Name = "notification.uspGetSmsNotification";

				public struct Parameters
				{
					public const string Status = "@status";

					public const string NotificationDate = "@notificationDate";

					public const string NotificationTime = "@notificationTime";
				}
			}
		}

		public struct NameResolverKeys
		{
			public const string SmsNotificationInterval = "%" + ConfigKeys.SmsNotificationInterval + "%";
		}
	}
}