using System;
using System.Collections.Generic;
using System.Text;

namespace Jayatas.Omilos.Functions.Common.Common
{
	/// <summary>
	/// 
	/// </summary>
	public struct Utilities
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T GetOrDefaultEnvironmentValue<T>(string key, T defaultValue)
		{
			try
			{
				var parsedValue = (T)Convert.ChangeType(Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process), typeof(T));
				return parsedValue == null ? defaultValue : parsedValue;
			}
			catch (Exception)
			{
			}

			return defaultValue;
		}
	}
}