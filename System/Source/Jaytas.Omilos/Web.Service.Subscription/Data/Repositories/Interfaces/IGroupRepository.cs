using Jaytas.Omilos.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Subscription.Data.Repositories.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IGroupRepository : ICrudByFieldBaseEntityRepository<DomainModel.Group, long, Guid>
	{
	}
}
