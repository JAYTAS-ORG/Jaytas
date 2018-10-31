using System;
using System.Collections.Generic;
using System.Text;

namespace Jayatas.Omilos.Functions.Common.Common
{
	public class ConfigurationManager
	{
		private static string _environmentName;

		public static string EnvironmentName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_environmentName))
				{
					_environmentName = Utilities.GetOrDefaultEnvironmentValue<string>(Constants.ConfigKeys.EnvironmentName, null);
				}
				return _environmentName;
			}
		}

		private static string _omilosConnection;

		public static string OmilosConnection
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_omilosConnection))
				{
					_omilosConnection = Utilities.GetOrDefaultEnvironmentValue<string>(Constants.ConfigKeys.OmilosDbConnection, null);
				}
				return _omilosConnection;
			}
		}

		private static string _twilioAccountId;

		public static string TwilioAccountId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_twilioAccountId))
				{
					_twilioAccountId = Utilities.GetOrDefaultEnvironmentValue<string>(Constants.ConfigKeys.TwilioAccountId, null);
				}
				return _twilioAccountId;
			}
		}

		private static string _twilioAccountSecret;

		public static string TwilioAccountSecret
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_twilioAccountSecret))
				{
					_twilioAccountSecret = Utilities.GetOrDefaultEnvironmentValue<string>(Constants.ConfigKeys.TwilioAccountSecret, null);
				}
				return _twilioAccountSecret;
			}
		}

		private static string _twilioPhoneNumber;

		public static string TwilioPhoneNumber
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_twilioPhoneNumber))
				{
					_twilioPhoneNumber = Utilities.GetOrDefaultEnvironmentValue<string>(Constants.ConfigKeys.TwilioPhoneNumber, null);
				}
				return _twilioPhoneNumber;
			}
		}
	}
}