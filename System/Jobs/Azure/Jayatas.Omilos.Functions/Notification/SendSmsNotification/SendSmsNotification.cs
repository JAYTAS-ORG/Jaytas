using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Jayatas.Omilos.Functions.Common.Common;
using Jayatas.Omilos.Functions.Common.Database;
using System.Collections.Generic;
using System.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace Jayatas.Omilos.Functions.Notification.SendSmsNotification
{
	/// <summary>
	/// 
	/// </summary>
	public static class SendSmsNotification
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="myTimer"></param>
		/// <param name="log"></param>
		[FunctionName(nameof(SendSmsNotification))]
		public static void Run([TimerTrigger(Constants.NameResolverKeys.SmsNotificationInterval)]TimerInfo myTimer, TraceWriter log)
		{
			var utcTimeSpan = DateTime.UtcNow.AddMinutes(30).TimeOfDay;

			log.Info("Timestamp : " + utcTimeSpan);

			var parameters = new Dictionary<string, object>
			{
				{ Constants.StoreProcedures.GetSmsNotification.Parameters.Status, 0 },
				{ Constants.StoreProcedures.GetSmsNotification.Parameters.NotificationDate, DateTime.UtcNow },
				{ Constants.StoreProcedures.GetSmsNotification.Parameters.NotificationTime, new TimeSpan(utcTimeSpan.Hours, utcTimeSpan.Minutes, 0) }
			};

			var pendingNotifications = MySqlUtilities.ExecuteQuery<NotificationModel>(ConfigurationManager.OmilosConnection,
																					  Constants.StoreProcedures.GetSmsNotification.Name,
																					  parameters).ToList();

			log.Info("Number of Notificaction to be sent :" + pendingNotifications.Count());

			if(!pendingNotifications.Any())
			{
				return;
			}

			var sendNotificationTask = Task.Run(() => SendNotificationsAsync(pendingNotifications));
			sendNotificationTask.Wait();

			var messageIds = sendNotificationTask.Result;

			log.Info(string.Join(",", messageIds));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pendingNotifications"></param>
		public static async Task<List<string>> SendNotificationsAsync(List<NotificationModel> pendingNotifications)
		{
			TwilioClient.Init(ConfigurationManager.TwilioAccountId, ConfigurationManager.TwilioAccountSecret);

			var messageIds = new List<string>();

			foreach (var pendingNotification in pendingNotifications)
			{
				var message = await MessageResource.CreateAsync(
											body: pendingNotification.Message,
											from: new Twilio.Types.PhoneNumber(ConfigurationManager.TwilioPhoneNumber),
											to: new Twilio.Types.PhoneNumber(pendingNotification.PhoneNumber));
				messageIds.Add(message.Sid);
			}

			return messageIds;
		}
	}
}