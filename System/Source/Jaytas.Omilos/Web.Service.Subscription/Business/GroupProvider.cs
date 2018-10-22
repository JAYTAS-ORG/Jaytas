using Jaytas.Omilos.Common.Extensions;
using Jaytas.Omilos.Web.Providers;
using Jaytas.Omilos.Web.Service.Subscription.Business.Interfaces;
using Jaytas.Omilos.Web.Service.Subscription.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jaytas.Omilos.Web.Service.Subscription.Business
{
	/// <summary>
	/// 
	/// </summary>
	public class GroupProvider : CrudByFieldBaseProvider<DomainModel.Group, IGroupRepository, long, Guid>, IGroupProvider
	{
		IContactRepository _contactRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="groupRepository"></param>
		/// <param name="contactRepository"></param>
		public GroupProvider(IGroupRepository groupRepository, IContactRepository contactRepository) : base(groupRepository)
		{
			_contactRepository = contactRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async override Task AssertEntityToCreateIsValidAsync(IEnumerable<DomainModel.Group> domains)
		{
			//throw new NotImplementedException();
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="identifiers"></param>
		/// <returns></returns>
		public async override Task AssertEntityToDeleteIsValidAsync(IEnumerable<Guid> identifiers)
		{
			//throw new NotImplementedException();
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="domains"></param>
		/// <returns></returns>
		public async override Task AssertEntityToUpdateIsValidAsync(IEnumerable<DomainModel.Group> domains)
		{
			//throw new NotImplementedException();
			await Task.CompletedTask;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		public async Task<IEnumerable<DomainModel.GroupContactAssociation>> GetContacts(Guid groupId)
		{
			var group = await Repository.GetAsync(groupId);

			return group.GroupContactAssociations;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="contacts"></param>
		/// <returns></returns>
		public async Task AddContactsToGroup(Guid groupId, IEnumerable<Guid> contacts)
		{
			var group = await Repository.GetAsync(groupId);
			var contactsFilterExpression = contacts.WhereContains<DomainModel.Contact, IEnumerable<Guid>>(nameof(DomainModel.Contact.ExposedId));
			Expression<Func<DomainModel.Contact, bool>> contactsSubscriptionFilterExpression = contact => contact.SubscriptionId == group.SubscriptionId;

			var filteredcontacts = await _contactRepository.GetAsync(contactsSubscriptionFilterExpression.And(contactsFilterExpression));

			var groupContactAssociations = from contact in filteredcontacts
										   let groupInternalId = @group.Id
										   select new DomainModel.GroupContactAssociation
										   {
											   GroupId = groupInternalId,
											   ContactId = contact.Id
										   };

			await Repository.AddContactsAsync(groupContactAssociations);
		}
	}
}
