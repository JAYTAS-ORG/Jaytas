using System;
using System.Collections.Generic;
using System.Text;

namespace Jaytas.Omilos.Common
{
	public partial struct Constants
	{
		/// <summary>
		/// 
		/// </summary>
		public struct Schemas
		{
			/// <summary>
			/// 
			/// </summary>
			public const String Dbo = "dbo";

			/// <summary>
			/// Schema for Account Management
			/// </summary>
			public const String Account = "account";
		}

		public struct Tables
		{
			public const string Role = "role";

			public const string User = "user";

			public const string UserLoginDetail = "user_logindetail";

			public const string UserRole = "user_role";
		}

		/// <summary>
		/// 
		/// </summary>
		public struct DefaultFieldMappings
		{
			/// <summary>
			/// 
			/// </summary>
			public const string CreatedDate = "CreatedDate";

			/// <summary>
			/// 
			/// </summary>
			public const string CreatedBy = "CreatedBy";

			/// <summary>
			/// 
			/// </summary>
			public const string ModifiedDate = "ModifiedDate";

			/// <summary>
			/// 
			/// </summary>
			public const string ModifiedBy = "ModifiedBy";

			/// <summary>
			/// 
			/// </summary>
			public const string PrimaryKey = "Id";
		}

		public struct LoginDetailFeildMappings
		{
			/// <summary>
			/// 
			/// </summary>
			public const string PrimaryKey = "UserId";
		}
	}
}
