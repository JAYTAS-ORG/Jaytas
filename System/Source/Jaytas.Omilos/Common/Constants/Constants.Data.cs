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
			/// Schema for User Management
			/// </summary>
			public const String User = "User";

			/// <summary>
			/// Schema for Campaign Management
			/// </summary>
			public const String Campaign = "Campaign";
		}

		/// <summary>
		/// Entity Framework supported column types in use
		/// </summary>
		public struct ColumnTypes
		{
			/// <summary>
			/// The variable length Unicode character array
			/// </summary>
			public const string NVarChar = "nvarchar";

			/// <summary>
			/// The variable length 8-bit character array
			/// </summary>
			public const string VarChar = "VARCHAR";

			/// <summary>
			/// The 1-bit character
			/// </summary>
			public const string Char = "char";

			/// <summary>
			/// The unique identifier
			/// </summary>
			public const string Guid = "uniqueidentifier";

			/// <summary>
			/// The 32 bit precision Date Time
			/// </summary>
			public const string DateTime = "datetime";

			/// <summary>
			/// The 64 bit precision Date Time
			/// </summary>
			public const string DateTime2 = "datetime2";

			/// <summary>
			/// The 32-bit number type
			/// </summary>
			public const string Int = "int";

			/// <summary>
			/// The 16-bit number type
			/// </summary>
			public const string Tinyint = "tinyint";

			/// <summary>
			/// The 16-bit number type
			/// </summary>
			public const string Short = "smallint";

			/// <summary>
			/// The 64-bit number type
			/// </summary>
			public const string Long = "bigint";

			/// <summary>
			/// The bit
			/// </summary>
			public const string Bit = "bit";

			/// <summary>
			/// The VarBinary
			/// </summary>
			public const string VarBinary = "varbinary";

			/// <summary>
			/// The Decimal
			/// </summary>
			public const string Decimal = "decimal";

			/// <summary>
			/// The timespan
			/// </summary>
			public const string TimeSpan = "time";

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
	}
}
