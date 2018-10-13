﻿using Jaytas.Omilos.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Account.DomainModel
{
	/// <summary>
	/// 
	/// </summary>
	public class UserLoginDetail : LongEntity
	{		
		/// <summary>
		/// 
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Salt { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string FacebookId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string GoogleId { get; set; }

		/// <summary>
		/// User who owns this login details
		/// </summary>
		public virtual User User { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destination"></param>
		/// <returns></returns>
		public bool Equals(UserLoginDetail destination)
		{
			return FacebookId == destination.FacebookId &&
				   GoogleId == destination.GoogleId &&
				   Salt == destination.Salt &&
				   Password == destination.Password;
		}
	}
}