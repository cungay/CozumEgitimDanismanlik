﻿#region Using Directives
using System;
using System.Collections;
using System.Text;
#endregion

namespace Ekip.Framework.Data
{
	/// <summary>
	/// Parses search text into an expression that can
	/// be used in a SQL WHERE clause.
	/// </summary>
	[CLSCompliant(true)]
	public class SqlExpressionParser : ExpressionParserBase
	{
		#region Declarations

		private StringBuilder sql;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		public SqlExpressionParser(String propertyName)
			: this(propertyName, SqlComparisonType.Contains, false)
		{
		}

		/// <summary>
		/// Initializes a new instance of the SqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="ignoreCase"></param>
		public SqlExpressionParser(String propertyName, bool ignoreCase)
			: this(propertyName, SqlComparisonType.Contains, ignoreCase)
		{
		}

		/// <summary>
		/// Initializes a new instance of the SqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="comparisonType"></param>
		public SqlExpressionParser(String propertyName, SqlComparisonType comparisonType)
			: this(propertyName, comparisonType, false)
		{
		}

		/// <summary>
		/// Initializes a new instance of the SqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="comparisonType"></param>
		/// <param name="ignoreCase"></param>
		public SqlExpressionParser(String propertyName, SqlComparisonType comparisonType, bool ignoreCase)
			: base(propertyName, comparisonType, ignoreCase)
		{
		}

		#endregion

		#region ExpressionParserBase Members

		/// <summary>
		/// Appends "OR" to the SQL statement.
		/// </summary>
		protected override void AppendOr()
		{
			sql.AppendFormat(" {0} ", SqlUtil.OR);
		}

		/// <summary>
		/// Appends "AND" to the SQL statement.
		/// </summary>
		protected override void AppendAnd()
		{
			sql.AppendFormat(" {0} ", SqlUtil.AND);
		}

		/// <summary>
		/// Appends a space to the SQL statement.
		/// </summary>
		protected override void AppendSpace()
		{
			sql.Append(" ");
		}

		/// <summary>
		/// Appends a left parentheses to the SQL statement.
		/// </summary>
		protected override void OpenGrouping()
		{
			sql.Append(SqlUtil.LEFT);
		}

		/// <summary>
		/// Appends a right parentheses to the SQL statement.
		/// </summary>
		protected override void CloseGrouping()
		{
			sql.Append(SqlUtil.RIGHT);
		}

		/// <summary>
		/// Appends the specified search text to the SQL statement.
		/// </summary>
		/// <param name="searchText">The search text to append.</param>
		protected override void AppendSearchText(string searchText)
		{
			sql.Append(WrapWithSQL(PropertyName, searchText, IgnoreCase));
		}

		#endregion ExpressionParserBase Members

		#region Protected Methods

		/// <summary>
		/// Converts the search text into a valid search expression.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected virtual String WrapWithSQL(String propertyName, String value, bool ignoreCase)
		{
			SqlComparisonType compare = ComparisonType;
			String sql = String.Empty;

			// check for wildcards
			if ( String.IsNullOrEmpty(value) )
			{
				return sql;
			}
			else if ( value.Equals(SqlUtil.STAR) )
			{
				compare = SqlComparisonType.Like;
				value = SqlUtil.WILD;
			}
			else if ( value.StartsWith(SqlUtil.STAR) && value.EndsWith(SqlUtil.STAR) )
			{
				compare = SqlComparisonType.Contains;
				value = value.Substring(1, value.Length - 2);
			}
			else if ( value.EndsWith(SqlUtil.STAR) )
			{
				compare = SqlComparisonType.StartsWith;
				value = value.Substring(0, value.Length - 1);
			}
			else if ( value.StartsWith(SqlUtil.STAR) )
			{
				compare = SqlComparisonType.EndsWith;
				value = value.Substring(1, value.Length - 1);
			}
			else
			{
				compare = SqlComparisonType.Equals;
			}

			// make sure there are no embeded wildcards
			if ( value.IndexOf(SqlUtil.STAR) > -1 )
			{
				value = value.Replace(SqlUtil.STAR, SqlUtil.WILD);

				if ( compare == SqlComparisonType.Equals )
				{
					compare = SqlComparisonType.Like;
				}
			}
			// check for actual wild card character
			if ( compare == SqlComparisonType.Equals && value.IndexOf(SqlUtil.WILD) > -1 )
			{
				compare = SqlComparisonType.Like;
			}

			switch ( compare )
			{
				case SqlComparisonType.Contains:
					sql = Contains(propertyName, value, ignoreCase);
					break;
				case SqlComparisonType.StartsWith:
					sql = StartsWith(propertyName, value, ignoreCase);
					break;
				case SqlComparisonType.EndsWith:
					sql = EndsWith(propertyName, value, ignoreCase);
					break;
				case SqlComparisonType.Like:
					sql = Like(propertyName, value, ignoreCase);
					break;
				default:
					sql = Equals(propertyName, value, ignoreCase);
					break;
			}

			return sql;
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Contains"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected virtual String Contains(String column, String value, bool ignoreCase)
		{
			return SqlUtil.Contains(column, value, ignoreCase);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.StartsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected virtual String StartsWith(String column, String value, bool ignoreCase)
		{
			return SqlUtil.StartsWith(column, value, ignoreCase);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.EndsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected virtual String EndsWith(String column, String value, bool ignoreCase)
		{
			return SqlUtil.EndsWith(column, value, ignoreCase);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Like"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected virtual String Like(String column, String value, bool ignoreCase)
		{
			return SqlUtil.Like(column, value, ignoreCase);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Equals"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected virtual String Equals(String column, String value, bool ignoreCase)
		{
			return SqlUtil.Equals(column, value, ignoreCase);
		}

		#endregion

		#region Parse Method

		/// <summary>
		/// Parses the specified value into separate search terms.
		/// </summary>
		/// <param name="value">The search text.</param>
		/// <returns>Returns a parsed search phrase.</returns>
		public virtual String Parse(String value)
		{
			sql = new StringBuilder();
			ParseCore(value);
			return sql.ToString();
		}

		#endregion Parse Method
	}

	/// <summary>
	/// Parses search text into an expression that can
	/// be used in a parameterized SQL WHERE clause.
	/// </summary>
	[CLSCompliant(true)]
	public class ParameterizedSqlExpressionParser : SqlExpressionParser
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParameterizedSqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		public ParameterizedSqlExpressionParser(String propertyName)
			: this(propertyName, SqlComparisonType.Contains, false)
		{
		}

		/// <summary>
		/// Initializes a new instance of the ParameterizedSqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="ignoreCase"></param>
		public ParameterizedSqlExpressionParser(String propertyName, bool ignoreCase)
			: this(propertyName, SqlComparisonType.Contains, ignoreCase)
		{
		}

		/// <summary>
		/// Initializes a new instance of the ParameterizedSqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="comparisonType"></param>
		public ParameterizedSqlExpressionParser(String propertyName, SqlComparisonType comparisonType)
			: this(propertyName, comparisonType, false)
		{
		}

		/// <summary>
		/// Initializes a new instance of the ParameterizedSqlExpressionParser class.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="comparisonType"></param>
		/// <param name="ignoreCase"></param>
		public ParameterizedSqlExpressionParser(String propertyName, SqlComparisonType comparisonType, bool ignoreCase)
			: base(propertyName, comparisonType, ignoreCase)
		{
		}

		#endregion

		#region SqlExpressionParser Members

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Contains"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected override string Contains(string column, string value, bool ignoreCase)
		{
			value = SqlUtil.Contains(value);
			return SqlUtil.Like(column, Parameters.GetParameter(value), ignoreCase, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.StartsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected override string StartsWith(string column, string value, bool ignoreCase)
		{
			value = SqlUtil.StartsWith(value);
			return SqlUtil.Like(column, Parameters.GetParameter(value), ignoreCase, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.EndsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected override string EndsWith(string column, string value, bool ignoreCase)
		{
			value = SqlUtil.EndsWith(value);
			return SqlUtil.Like(column, Parameters.GetParameter(value), ignoreCase, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Like"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected override string Like(string column, string value, bool ignoreCase)
		{
			value = SqlUtil.Like(value);
			return SqlUtil.Like(column, Parameters.GetParameter(value), ignoreCase, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Equals"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		protected override string Equals(string column, string value, bool ignoreCase)
		{
			value = SqlUtil.Equals(value);
			return SqlUtil.Equals(column, Parameters.GetParameter(value), ignoreCase, false);
		}

		#endregion SqlExpressionParser Members

		#region Properties

		/// <summary>
		/// The Parameters member variable.
		/// </summary>
		private SqlFilterParameterCollection parameters;

		/// <summary>
		/// Gets or sets the Parameters property.
		/// </summary>
		public virtual SqlFilterParameterCollection Parameters
		{
			get
			{
				if ( parameters == null )
				{
					parameters = new SqlFilterParameterCollection();
				}

				return parameters;
			}
			set { parameters = value; }
		}

		#endregion Properties
	}
}
