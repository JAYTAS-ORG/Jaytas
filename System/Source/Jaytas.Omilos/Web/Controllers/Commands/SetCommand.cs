using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Web.Controllers.Commands
{
	/// <summary>
	/// Represents a command for Resources that belong to a set/collection.  This helps bridge the gap between
	/// RESTful interfaces and business layers by providing an extension point for properties that do not exist 
	/// on our Api contracts.
	/// </summary>
	/// <typeparam name="TModel">The type of the model.</typeparam>
	/// <typeparam name="TModelBaseType">The base Model type.</typeparam>
	public class SetCommand<TModel, TModelBaseType> : Command<TModel, TModelBaseType> where TModelBaseType : struct
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="SetCommand{TModel, TModelBaseType}" /> class.
		/// </summary>
		/// <param name="resource">The model.</param>
		/// <param name="setId">The set identifier.</param>
		public SetCommand(TModel resource, TModelBaseType setId) : this(resource, setId, default(TModelBaseType))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SetCommand{TModel, TModelBaseType}"/> class.
		/// </summary>
		/// <param name="resource">The resource.</param>
		/// <param name="setId">The set identifier.</param>
		/// <param name="resourceId">The identifier.</param>
		public SetCommand(TModel resource, TModelBaseType setId, TModelBaseType resourceId) : base(resource, resourceId)
		{
			SetId = setId;
		}

		/// <summary>
		/// Gets or sets the identifier for the parent/set that this Resource belongs to.
		/// <remarks>This ID is necessary because our Api models do not expose an ID property, 
		/// instead, the ID is provided in the URL routes.</remarks>
		/// </summary>
		/// <value>
		/// The set identifier this Resource belongs to.
		/// </value>
		public TModelBaseType SetId { get; set; }
	}
}
