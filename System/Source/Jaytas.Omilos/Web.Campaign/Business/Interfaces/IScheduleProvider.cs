﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Campaign.Business.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IScheduleProvider : Providers.ICrudByFieldBaseProvider<DomainModel.Schedule, long, Guid>
	{
	}
}
