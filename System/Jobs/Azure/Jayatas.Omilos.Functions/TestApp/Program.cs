using Jayatas.Omilos.Functions.Notification.SendSmsNotification;
using System;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
			var centralZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
			var pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
			var mountainZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");

			var utcTime = DateTime.UtcNow;
			var localTime = DateTime.Now;

			Console.WriteLine("UTC Time :" + utcTime);
			Console.WriteLine("Local Time :" + localTime);
			Console.WriteLine("EST Time :" + TimeZoneInfo.ConvertTime(utcTime, easternZone));
			Console.WriteLine("CST Time :" + TimeZoneInfo.ConvertTime(utcTime, centralZone));
			Console.WriteLine("PST Time :" + TimeZoneInfo.ConvertTime(utcTime, pacificZone));
			Console.WriteLine("MST Time :" + TimeZoneInfo.ConvertTime(utcTime, mountainZone));

			Console.WriteLine("Hello World!");
			SendSmsNotification.Run(null, null);
			Console.ReadLine();
		}
	}
}
