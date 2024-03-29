﻿#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Ekip.Framework.Entities;
#endregion

namespace Ekip.Framework.Data
{
    /// <summary>
    /// Represents a SQL filter builder expression enumeration.
    /// </summary>
    [CLSCompliant(true)]
    public enum StringBuilderExpression
    {
        /// <summary>
        /// Append
        /// </summary>
        Append = 1,
        /// <summary>
        /// AppendEquals
        /// </summary>
        AppendEquals,
        /// <summary>
        /// AppendNotEquals
        /// </summary>
        AppendNotEquals,
        /// <summary>
        /// AppendIn
        /// </summary>
        AppendIn,
        /// <summary>
        /// AppendNotIn
        /// </summary>
        AppendNotIn,
        /// <summary>
        /// AppendInQuery
        /// </summary>
        AppendInQuery,
        /// <summary>
        /// AppendNotInQuery
        /// </summary>
        AppendNotInQuery,
        /// <summary>
        /// AppendRange
        /// </summary>
        AppendRange,
        /// <summary>
        /// AppendNotRange
        /// </summary>
        AppendNotRange,
        /// <summary>
        /// AppendIsNull
        /// </summary>
        AppendIsNull,
        /// <summary>
        /// AppendIsNotNull
        /// </summary>
        AppendIsNotNull,
        /// <summary>
        /// AppendGreaterThan
        /// </summary>
        AppendGreaterThan,
        /// <summary>
        /// AppendGreaterThanOrEqual
        /// </summary>
        AppendGreaterThanOrEqual,
        /// <summary>
        /// AppendLessThan
        /// </summary>
        AppendLessThan,
        /// <summary>
        /// AppendLessThanOrEqual
        /// </summary>
        AppendLessThanOrEqual,
        /// <summary>
        /// AppendStartsWith
        /// </summary>
        AppendStartsWith,
        /// <summary>
        /// AppendEndsWith
        /// </summary>
        AppendEndsWith,
        /// <summary>
        /// AppendContains
        /// </summary>
        AppendContains,
        /// <summary>
        /// AppendNotContains
        /// </summary>
        AppendNotContains,
        /// <summary>
        /// AppendLike
        /// </summary>
        AppendLike,
        /// <summary>
        /// AppendLike
        /// </summary>
        AppendNotLike

    }

    /// <summary>
    /// Represents a SQL filter expression.
    /// </summary>
    [CLSCompliant(true)]
    public class SqlStringBuilder
    {
        #region Declarations

        private StringBuilder sql = new StringBuilder();
        private int _groupCount = 0;

        #endregion Declarations

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SqlStringBuilder class.
        /// </summary>
        public SqlStringBuilder()
        {
            this.junction = SqlUtil.AND;
            this.ignoreCase = false;
        }

        /// <summary>
        /// Initializes a new instance of the SqlStringBuilder class.
        /// </summary>
        /// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
        public SqlStringBuilder(bool ignoreCase)
        {
            this.junction = SqlUtil.AND;
            this.ignoreCase = ignoreCase;
        }

        /// <summary>
        /// Initializes a new instance of the SqlStringBuilder class.
        /// </summary>
        /// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
        /// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
        public SqlStringBuilder(bool ignoreCase, bool useAnd)
        {
            this.junction = useAnd ? SqlUtil.AND : SqlUtil.OR;
            this.ignoreCase = ignoreCase;
        }

        #endregion Constructors

        #region Append

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder Append(string column, string searchText)
        {
            return Append(this.junction, column, searchText, this.ignoreCase);
        }

        /// <summary>
        /// Appends the specified column and search text to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder Append(string column, string searchText, bool ignoreCase)
        {
            return Append(this.junction, column, searchText, ignoreCase);
        }

        /// <summary>
        /// Appends the specified column and search text to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder Append(string junction, string column, string searchText, bool ignoreCase)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                AppendInternal(junction, Parse(column, searchText, ignoreCase));
            }

            return this;
        }

        #endregion Append

        #region AppendEquals

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendEquals(string column, string value)
        {
            return AppendEquals(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendEquals(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, column, "=", SqlUtil.Encode(value, true));
            }

            return this;
        }

        #endregion AppendEquals

        #region AppendNotEquals

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// as a NOT EQUALS expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotEquals(string column, string value)
        {
            return AppendNotEquals(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter
        /// as a NOT EQUALS expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotEquals(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, column, "<>", SqlUtil.Encode(value, true));
            }

            return this;
        }

        #endregion AppendNotEquals

        #region AppendIn

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendIn(string column, string[] values)
        {
            return AppendIn(this.junction, column, values, true);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendIn(string column, string[] values, bool encode)
        {
            return AppendIn(this.junction, column, values, encode);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendIn(string junction, string column, string[] values)
        {
            return AppendIn(junction, column, values, true);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendIn(string junction, string column, string[] values, bool encode)
        {
            if (values != null && values.Length > 0)
            {
                string sqlString = GetInQueryValues(values, encode);

                if (!string.IsNullOrEmpty(sqlString))
                {
                    AppendInQuery(junction, column, sqlString);
                }
            }

            return this;
        }

        #endregion AppendIn

        #region AppendNotIn

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotIn(string column, string[] values)
        {
            return AppendNotIn(this.junction, column, values, true);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotIn(string column, string[] values, bool encode)
        {
            return AppendNotIn(this.junction, column, values, encode);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotIn(string junction, string column, string[] values)
        {
            return AppendNotIn(junction, column, values, true);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotIn(string junction, string column, string[] values, bool encode)
        {
            if (values != null && values.Length > 0)
            {
                string sqlString = GetInQueryValues(values, encode);

                if (!string.IsNullOrEmpty(sqlString))
                {
                    AppendNotInQuery(junction, column, sqlString);
                }
            }

            return this;
        }

        #endregion AppendNotIn

        #region AppendInQuery

        /// <summary>
        /// Appends the specified sub-query to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendInQuery(string column, string query)
        {
            return AppendInQuery(this.junction, column, query);
        }

        /// <summary>
        /// Appends the specified sub-query to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendInQuery(string junction, string column, string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                AppendInternal(junction, column, "IN", "(" + query + ")");
            }

            return this;
        }

        #endregion AppendInQuery

        #region AppendNotInQuery

        /// <summary>
        /// Appends the specified sub-query to the current filter
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotInQuery(string column, string query)
        {
            return AppendNotInQuery(this.junction, column, query);
        }

        /// <summary>
        /// Appends the specified sub-query to the current filter
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotInQuery(string junction, string column, string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                AppendInternal(junction, column, "NOT IN", "(" + query + ")");
            }

            return this;
        }

        #endregion AppendNotInQuery

        #region AppendRange

        /// <summary>
        /// Appends the specified column and value range to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendRange(string column, string from, string to)
        {
            return AppendRange(this.junction, column, from, to);
        }

        /// <summary>
        /// Appends the specified column and value range to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendRange(string junction, string column, string from, string to)
        {
            if (!string.IsNullOrEmpty(from) || !string.IsNullOrEmpty(to))
            {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrEmpty(from))
                {
                    sb.AppendFormat("{0} >= {1}", column, SqlUtil.Encode(from, true));
                }
                if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                {
                    sb.AppendFormat(" {0} ", SqlUtil.AND);
                }
                if (!string.IsNullOrEmpty(to))
                {
                    sb.AppendFormat("{0} <= {1}", column, SqlUtil.Encode(to, true));
                }

                AppendInternal(junction, sb.ToString());
            }

            return this;
        }

        #endregion AppendRange

        #region AppendNotRange

        /// <summary>
        /// Appends the specified column and value not in range to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotRange(string column, string from, string to)
        {
            return AppendNotRange(this.junction, column, from, to);
        }

        /// <summary>
        /// Appends the specified column and value not in range to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotRange(string junction, string column, string from, string to)
        {
            if (!string.IsNullOrEmpty(from) || !string.IsNullOrEmpty(to))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("NOT (");
                if (!string.IsNullOrEmpty(from))
                {
                    sb.AppendFormat("{0} >= {1}", column, SqlUtil.Encode(from, true));
                }
                if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                {
                    sb.AppendFormat(" {0} ", SqlUtil.AND);
                }
                if (!string.IsNullOrEmpty(to))
                {
                    sb.AppendFormat("{0} <= {1}", column, SqlUtil.Encode(to, true));
                }
                sb.Append(")");

                AppendInternal(junction, sb.ToString());
            }

            return this;
        }

        #endregion AppendNotRange

        #region AppendIsNull

        /// <summary>
        /// Appends an IS NULL expression to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendIsNull(string column)
        {
            return AppendIsNull(this.junction, column);
        }

        /// <summary>
        /// Appends an IS NULL expression to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendIsNull(string junction, string column)
        {
            AppendInternal(junction, SqlUtil.IsNull(column));
            return this;
        }

        #endregion AppendIsNull

        #region AppendIsNotNull

        /// <summary>
        /// Appends an IS NOT NULL expression to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendIsNotNull(string column)
        {
            return AppendIsNotNull(this.junction, column);
        }

        /// <summary>
        /// Appends an IS NOT NULL expression to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendIsNotNull(string junction, string column)
        {
            AppendInternal(junction, SqlUtil.IsNotNull(column));
            return this;
        }

        #endregion AppendIsNotNull

        #region AppendGreaterThan

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendGreaterThan(string column, string value)
        {
            return AppendGreaterThan(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendGreaterThan(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, column, ">", SqlUtil.Encode(value, true));
            }

            return this;
        }

        #endregion AppendGreaterThan

        #region AppendGreaterThanOrEqual

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendGreaterThanOrEqual(string column, string value)
        {
            return AppendGreaterThanOrEqual(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendGreaterThanOrEqual(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, column, ">=", SqlUtil.Encode(value, true));
            }

            return this;
        }

        #endregion AppendGreaterThanOrEqual

        #region AppendLessThan

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendLessThan(string column, string value)
        {
            return AppendLessThan(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendLessThan(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, column, "<", SqlUtil.Encode(value, true));
            }

            return this;
        }

        #endregion AppendLessThan

        #region AppendLessThanOrEqual

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendLessThanOrEqual(string column, string value)
        {
            return AppendLessThanOrEqual(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendLessThanOrEqual(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, column, "<=", SqlUtil.Encode(value, true));
            }

            return this;
        }

        #endregion AppendLessThanOrEqual

        #region AppendStartsWith

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendStartsWith(string column, string value)
        {
            return AppendStartsWith(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendStartsWith(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, SqlUtil.StartsWith(column, value));
            }

            return this;
        }

        #endregion AppendStartsWith

        #region AppendEndsWith

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendEndsWith(string column, string value)
        {
            return AppendEndsWith(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendEndsWith(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, SqlUtil.EndsWith(column, value));
            }

            return this;
        }

        #endregion AppendEndsWith

        #region AppendContains

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendContains(string column, string value)
        {
            return AppendContains(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendContains(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, SqlUtil.Contains(column, value));
            }

            return this;
        }

        #endregion AppendContains

        #region AppendNotContains

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotContains(string column, string value)
        {
            return AppendNotContains(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotContains(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, SqlUtil.Contains(column, value));
            }
            return this;
        }

        #endregion AppendNotContains

        #region AppendLike

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendLike(string column, string value)
        {
            return AppendLike(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendLike(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, SqlUtil.Like(column, value));
            }

            return this;
        }

        #endregion AppendLike

        #region AppendNotLike

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotLike(string column, string value)
        {
            return AppendNotLike(this.junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder AppendNotLike(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                AppendInternal(junction, SqlUtil.NotLike(column, value));
            }

            return this;
        }
        #endregion

        #region AppendInternal

        /// <summary>
        /// Appends the SQL expression to the internal <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="junction">The junction.</param>
        /// <param name="column">The column.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="value">The value.</param>
        protected virtual void AppendInternal(string junction, string column, string compare, string value)
        {
            AppendInternal(junction, string.Format("[{0}] {1} {2}", column, compare, value));
        }

        /// <summary>
        /// Appends the SQL expression to the internal <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="junction">The junction.</param>
        /// <param name="query">The query.</param>
        protected virtual void AppendInternal(string junction, string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
#if DEBUG
                String end = System.Environment.NewLine;
#else
				String end = String.Empty;
#endif
                String format = (sql.Length > 0) ? " {0} ({1}){2}" : " ({1}){2}";
                sql.AppendFormat(format, junction, query, end);
            }
        }

        #endregion AppendInternal

        #region Methods

        /// <summary>
        /// Clears the internal string buffer.
        /// </summary>
        public virtual void Clear()
        {
            sql = new StringBuilder();
            _groupCount = 0;
        }

        /// <summary>
        /// Converts the value of this instance to a System.String.
        /// </summary>
        public override string ToString()
        {
            return sql.ToString().TrimEnd();
        }

        /// <summary>
        /// Converts the value of this instance to a System.String and
        /// prepends the specified junction if the expression is not empty.
        /// </summary>
        public virtual string ToString(string junction)
        {
            if (sql.Length > 0)
            {
                return new StringBuilder(" ").Append(junction).Append(" ").Append(ToString()).ToString();
            }

            return String.Empty;
        }

        /// <summary>
        /// Parses the specified searchText to create a SQL filter expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public virtual string Parse(string column, string searchText, bool ignoreCase)
        {
            return new SqlExpressionParser(column, ignoreCase).Parse(searchText);
        }

        /// <summary>
        /// Gets an encoded list of values for use with an IN clause.
        /// </summary>
        /// <param name="values">Comma string with the in parameters already in one string</param>
        /// <param name="encode">tells whether or not to enclose the parameters with ' and to replace ' with '' within the parameters.</param>
        /// <returns></returns>
        public virtual String GetInQueryValues(string values, bool encode)
        {
            if (encode)
            {
                String[] split = values.Split(',');
                values = SqlUtil.Encode(split, encode);
            }

            return values;
        }

        /// <summary>
        /// Gets an encoded list of values for use with an IN clause.
        /// </summary>
        /// <param name="values">String Array with the in parameters</param>
        /// <param name="encode">tells whether or not to enclose the parameters with ' and to replace ' with '' within the parameters.</param>
        /// <returns></returns>
        public virtual String GetInQueryValues(string[] values, bool encode)
        {
            string inQuery = string.Empty;

            inQuery = SqlUtil.Encode(values, encode);

            return inQuery;
        }

        /// <summary>
        /// Begins a new group of parameters by adding an open parenthesis "("
        /// </summary>
        public virtual void BeginGroup()
        {
            BeginGroup(Junction);
        }

        /// <summary>
        /// Begins a new groups of parameters using the specified junction operator
        /// </summary>
        /// <param name="junction">The junction operator to be used</param>
        public virtual void BeginGroup(string junction)
        {
            if (sql.Length > 0)
            {
                sql.AppendFormat("{0} (", junction);
            }
            else
            {
                sql.AppendFormat("(", junction);
            }
            _groupCount++;
        }

        /// <summary>
        /// Ends a group of parameters by add a closing parenthesis ")"
        /// </summary>
        public virtual void EndGroup()
        {
            if (_groupCount > 0)
            {
                sql.Append(")");
                _groupCount--;
            }
        }

        /// <summary>
        /// Makes sure that all groups have been ended (each call to BeginGroup has a corresponding EndGroup)
        /// </summary>
        internal virtual void EnsureGroups()
        {
            /*while (_groupCount > 0)
            {
               EndGroup();
            }*/
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// The Junction member variable.
        /// </summary>
        private String junction;

        /// <summary>
        /// Gets or sets the Junction property.
        /// </summary>
        public virtual String Junction
        {
            get { return junction; }
            set { junction = value; }
        }

        /// <summary>
        /// The IgnoreCase member variable.
        /// </summary>
        private bool ignoreCase;

        /// <summary>
        /// Gets or sets the IgnoreCase property.
        /// </summary>
        public virtual bool IgnoreCase
        {
            get { return ignoreCase; }
            set { ignoreCase = value; }
        }

        /// <summary>
        /// Gets or sets the length of the internal StringBuilder object.
        /// </summary>
        /// <value>The length.</value>
        public virtual int Length
        {
            get { return sql.Length; }
            set { sql.Length = value; }
        }

        #endregion Properties
    }

    /// <summary>
    /// Allows for building SQL filter expressions using strongly-typed
    /// column enumeration values.
    /// </summary>
    /// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
    [CLSCompliant(true)]
    public class SqlFilterBuilder<EntityColumn> : SqlStringBuilder
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SqlFilterBuilder class.
        /// </summary>
        public SqlFilterBuilder() : base() { }

        /// <summary>
        /// Initializes a new instance of the SqlFilterBuilder class.
        /// </summary>
        /// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
        public SqlFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

        /// <summary>
        /// Initializes a new instance of the SqlFilterBuilder class.
        /// </summary>
        /// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
        /// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
        public SqlFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

        #endregion Constructors

        #region Append

        /// <summary>
        /// Appends the specified column and search text to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> Append(EntityColumn column, string searchText)
        {
            return Append(this.Junction, column, searchText, this.IgnoreCase);
        }

        /// <summary>
        /// Appends the specified column and search text to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> Append(EntityColumn column, string searchText, bool ignoreCase)
        {
            return Append(this.Junction, column, searchText, ignoreCase);
        }

        /// <summary>
        /// Appends the specified column and search text to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> Append(string junction, EntityColumn column, string searchText, bool ignoreCase)
        {
            Append(junction, GetColumnName(column), searchText, ignoreCase);
            return this;
        }

        #endregion Append

        #region AppendEquals

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendEquals(EntityColumn column, string value)
        {
            return AppendEquals(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendEquals(string junction, EntityColumn column, string value)
        {
            AppendEquals(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendEquals

        #region AppendNotEquals

        /// <summary>
        /// Appends the specified column and value to the current filter
        /// as a NOT EQUALS expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotEquals(EntityColumn column, string value)
        {
            return AppendNotEquals(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// as a NOT EQUALS expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotEquals(string junction, EntityColumn column, string value)
        {
            AppendNotEquals(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendNotEquals

        #region AppendIn

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendIn(EntityColumn column, string[] values)
        {
            return AppendIn(this.Junction, column, values, true);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendIn(EntityColumn column, string[] values, bool encode)
        {
            return AppendIn(this.Junction, column, values, encode);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendIn(string junction, EntityColumn column, string[] values)
        {
            return AppendIn(junction, column, values, true);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendIn(string junction, EntityColumn column, string[] values, bool encode)
        {
            AppendIn(junction, GetColumnName(column), values, encode);
            return this;
        }

        #endregion AppendIn

        #region AppendNotIn

        /// <summary>
        /// Appends the specified column and list of values to the current filter
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotIn(EntityColumn column, string[] values)
        {
            return AppendNotIn(this.Junction, column, values, true);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotIn(EntityColumn column, string[] values, bool encode)
        {
            return AppendNotIn(this.Junction, column, values, encode);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotIn(string junction, EntityColumn column, string[] values)
        {
            return AppendNotIn(junction, column, values, true);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotIn(string junction, EntityColumn column, string[] values, bool encode)
        {
            AppendNotIn(junction, GetColumnName(column), values, encode);
            return this;
        }

        #endregion AppendIn

        #region AppendInQuery

        /// <summary>
        /// Appends the specified sub-query to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendInQuery(EntityColumn column, string query)
        {
            return AppendInQuery(this.Junction, column, query);
        }

        /// <summary>
        /// Appends the specified sub-query to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendInQuery(string junction, EntityColumn column, string query)
        {
            AppendInQuery(junction, GetColumnName(column), query);
            return this;
        }

        #endregion AppendInQuery

        #region AppendNotInQuery

        /// <summary>
        /// Appends the specified sub-query to the current filter.
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotInQuery(EntityColumn column, string query)
        {
            return AppendNotInQuery(this.Junction, column, query);
        }

        /// <summary>
        /// Appends the specified sub-query to the current filter
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotInQuery(string junction, EntityColumn column, string query)
        {
            AppendNotInQuery(junction, GetColumnName(column), query);
            return this;
        }

        #endregion AppendNotInQuery

        #region AppendIsNull

        /// <summary>
        /// Appends an IS NULL expression to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendIsNull(EntityColumn column)
        {
            return AppendIsNull(this.Junction, column);
        }

        /// <summary>
        /// Appends an IS NULL expression to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendIsNull(string junction, EntityColumn column)
        {
            AppendIsNull(junction, GetColumnName(column));
            return this;
        }

        #endregion AppendIsNull

        #region AppendIsNotNull

        /// <summary>
        /// Appends an IS NOT NULL expression to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendIsNotNull(EntityColumn column)
        {
            return AppendIsNotNull(this.Junction, column);
        }

        /// <summary>
        /// Appends an IS NOT NULL expression to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendIsNotNull(string junction, EntityColumn column)
        {
            AppendIsNotNull(junction, GetColumnName(column));
            return this;
        }

        #endregion AppendIsNotNull

        #region AppendRange

        /// <summary>
        /// Appends the specified column and value range to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendRange(EntityColumn column, string from, string to)
        {
            return AppendRange(this.Junction, column, from, to);
        }

        /// <summary>
        /// Appends the specified column and value range to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendRange(string junction, EntityColumn column, string from, string to)
        {
            AppendRange(junction, GetColumnName(column), from, to);
            return this;
        }

        #endregion AppendRange

        #region AppendNotRange

        /// <summary>
        /// Appends the specified column and value not in range to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotRange(EntityColumn column, string from, string to)
        {
            return AppendNotRange(this.Junction, column, from, to);
        }

        /// <summary>
        /// Appends the specified column and value not in range to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotRange(string junction, EntityColumn column, string from, string to)
        {
            AppendNotRange(junction, GetColumnName(column), from, to);
            return this;
        }

        #endregion AppendNotRange

        #region AppendGreaterThan

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendGreaterThan(EntityColumn column, string value)
        {
            return AppendGreaterThan(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendGreaterThan(string junction, EntityColumn column, string value)
        {
            AppendGreaterThan(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendGreaterThan

        #region AppendGreaterThanOrEqual

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendGreaterThanOrEqual(EntityColumn column, string value)
        {
            return AppendGreaterThanOrEqual(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendGreaterThanOrEqual(string junction, EntityColumn column, string value)
        {
            AppendGreaterThanOrEqual(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendGreaterThanOrEqual

        #region AppendLessThan

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendLessThan(EntityColumn column, string value)
        {
            return AppendLessThan(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendLessThan(string junction, EntityColumn column, string value)
        {
            AppendLessThan(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendLessThan

        #region AppendLessThanOrEqual

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendLessThanOrEqual(EntityColumn column, string value)
        {
            return AppendLessThanOrEqual(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendLessThanOrEqual(string junction, EntityColumn column, string value)
        {
            AppendLessThanOrEqual(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendLessThanOrEqual

        #region AppendStartsWith

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendStartsWith(EntityColumn column, string value)
        {
            return AppendStartsWith(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendStartsWith(string junction, EntityColumn column, string value)
        {
            AppendStartsWith(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendStartsWith

        #region AppendEndsWith

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendEndsWith(EntityColumn column, string value)
        {
            return AppendEndsWith(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendEndsWith(string junction, EntityColumn column, string value)
        {
            AppendEndsWith(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendEndsWith

        #region AppendContains

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendContains(EntityColumn column, string value)
        {
            return AppendContains(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendContains(string junction, EntityColumn column, string value)
        {
            AppendContains(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendContains

        #region AppendNotContains

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotContains(EntityColumn column, string value)
        {
            return AppendNotContains(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotContains(string junction, EntityColumn column, string value)
        {
            AppendNotContains(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendNotContains

        #region AppendLike

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendLike(EntityColumn column, string value)
        {
            return AppendLike(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendLike(string junction, EntityColumn column, string value)
        {
            AppendLike(junction, GetColumnName(column), value);
            return this;
        }

        #endregion AppendLike

        #region AppendNotLike

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotLike(EntityColumn column, string value)
        {
            return AppendNotLike(this.Junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual SqlFilterBuilder<EntityColumn> AppendNotLike(string junction, EntityColumn column, string value)
        {
            AppendNotLike(junction, GetColumnName(column), value);
            return this;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Gets the column name from the specified column enumeration value.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        protected virtual String GetColumnName(EntityColumn column)
        {
            String name = EntityHelper.GetAttribute<ColumnEnumAttribute>(column as Enum).Name;

            if (string.IsNullOrEmpty(name))
            {
                name = column.ToString();
            }

            return name;
        }

        #endregion Methods
    }

    /// <summary>
    /// Allows for building parameterized SQL filter expressions using strongly-typed
    /// column enumeration values.
    /// </summary>
    /// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
    [CLSCompliant(true)]
    public class ParameterizedSqlFilterBuilder<EntityColumn> : SqlFilterBuilder<EntityColumn>, IFilterParameterCollection
    {
        private bool _isDirty = true;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ParameterizedSqlFilterBuilder&lt;EntityColumn&gt; class.
        /// </summary>
        public ParameterizedSqlFilterBuilder() : base() { }

        /// <summary>
        /// Initializes a new instance of the ParameterizedSqlFilterBuilder&lt;EntityColumn&gt; class.
        /// </summary>
        /// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
        public ParameterizedSqlFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

        /// <summary>
        /// Initializes a new instance of the ParameterizedSqlFilterBuilder&lt;EntityColumn&gt; class.
        /// </summary>
        /// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
        /// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
        public ParameterizedSqlFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

        #endregion Constructors

        #region Append

        /// <summary>
        /// Appends the specified column and search text to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> Append(string junction, EntityColumn column, string searchText, bool ignoreCase)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.Append(junction, column, searchText, ignoreCase);
        }

        #endregion Append

        #region AppendEquals

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendEquals(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendEquals(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendEquals(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.Equals(value);
                AppendInternal(junction, column, "=", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendEquals

        #region AppendNotEquals

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// as a NOT EQUALS expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendNotEquals(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendNotEquals(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter
        /// as a NOT EQUALS expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendNotEquals(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.Equals(value);
                AppendInternal(junction, column, "<>", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendNotEquals

        #region AppendIn

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendIn(string junction, EntityColumn column, string[] values, bool encode)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendIn(junction, column, values, encode);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendIn(string junction, string column, string[] values, bool encode)
        {
            if(values != null && values.Length > 0)
            {
                string sqlQuery = GetInQueryValues(values, encode);

                if (!string.IsNullOrEmpty(sqlQuery))
                {
                    _isDirty = true;
                    AppendInQuery(junction, column, sqlQuery);
                }
            }

            return this;
        }

        #endregion AppendIn

        #region AppendNotIn

        /// <summary>
        /// Appends the specified column and list of values to the current filter.
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendNotIn(string junction, EntityColumn column, string[] values, bool encode)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendNotIn(junction, column, values, encode);
        }

        /// <summary>
        /// Appends the specified column and list of values to the current filter
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendNotIn(string junction, string column, string[] values, bool encode)
        {
            if (values != null && values.Length > 0)
            {
                string sqlQuery = GetInQueryValues(values, encode);

                if (!string.IsNullOrEmpty(sqlQuery))
                {
                    _isDirty = true;
                    AppendNotInQuery(junction, column, sqlQuery);
                }
            }

            return this;
        }

        #endregion AppendNotIn

        #region AppendInQuery

        /// <summary>
        /// Appends the specified sub-query to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendInQuery(string junction, EntityColumn column, string query)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendInQuery(junction, column, query);
        }

        #endregion AppendInQuery

        #region AppendNotInQuery

        /// <summary>
        /// Appends the specified sub-query to the current filter
        /// as a NOT IN expression.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendNotInQuery(string junction, EntityColumn column, string query)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendNotInQuery(junction, column, query);
        }

        #endregion AppendNotInQuery

        #region AppendRange

        /// <summary>
        /// Appends the specified column and value range to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendRange(string junction, EntityColumn column, string from, string to)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendRange(junction, column, from, to);
        }

        /// <summary>
        /// Appends the specified column and value range to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendRange(string junction, string column, string from, string to)
        {
            if (!string.IsNullOrEmpty(from) || !string.IsNullOrEmpty(to))
            {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrEmpty(from))
                {
                    sb.AppendFormat("{0} >= {1}", column, Parameters.GetParameter(from));
                }
                if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                {
                    sb.AppendFormat(" {0} ", SqlUtil.AND);
                }
                if (!string.IsNullOrEmpty(to))
                {
                    sb.AppendFormat("{0} <= {1}", column, Parameters.GetParameter(to));
                }

                _isDirty = true;
                AppendInternal(junction, sb.ToString());
            }

            return this;
        }

        #endregion AppendRange

        #region AppendNotRange

        /// <summary>
        /// Appends the specified column and value not in range to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendNotRange(string junction, EntityColumn column, string from, string to)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendNotRange(junction, column, from, to);
        }

        /// <summary>
        /// Appends the specified column and value not in range to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendNotRange(string junction, string column, string from, string to)
        {
            if (!string.IsNullOrEmpty(from) || !string.IsNullOrEmpty(to))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("NOT (");
                if (!string.IsNullOrEmpty(from))
                {
                    sb.AppendFormat("{0} >= {1}", column, Parameters.GetParameter(from));
                }
                if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                {
                    sb.AppendFormat(" {0} ", SqlUtil.AND);
                }
                if (!string.IsNullOrEmpty(to))
                {
                    sb.AppendFormat("{0} <= {1}", column, Parameters.GetParameter(to));
                }
                sb.Append(")");

                _isDirty = true;
                AppendInternal(junction, sb.ToString());
            }

            return this;
        }

        #endregion AppendNotRange

        #region AppendGreaterThan

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendGreaterThan(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendGreaterThan(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendGreaterThan(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.Equals(value);
                AppendInternal(junction, column, ">", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendGreaterThan

        #region AppendGreaterThanOrEqual

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendGreaterThanOrEqual(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendGreaterThanOrEqual(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendGreaterThanOrEqual(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.Equals(value);
                AppendInternal(junction, column, ">=", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendGreaterThanOrEqual

        #region AppendLessThan

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendLessThan(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendLessThan(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendLessThan(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.Equals(value);
                AppendInternal(junction, column, "<", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendLessThan

        #region AppendLessThanOrEqual

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendLessThanOrEqual(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendLessThanOrEqual(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendLessThanOrEqual(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.Equals(value);
                AppendInternal(junction, column, "<=", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendLessThanOrEqual

        #region AppendStartsWith

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendStartsWith(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendStartsWith(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendStartsWith(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.StartsWith(value);
                AppendInternal(junction, column, "LIKE", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendStartsWith

        #region AppendEndsWith

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendEndsWith(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendEndsWith(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendEndsWith(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.EndsWith(value);
                AppendInternal(junction, column, "LIKE", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendEndsWith

        #region AppendContains

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendContains(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendContains(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendContains(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.Contains(value);
                AppendInternal(junction, column, "LIKE", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendContains

        #region AppendNotContains

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendNotContains(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendNotContains(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendNotContains(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.NotContains(value);
                AppendInternal(junction, column, "NOT LIKE", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendNotContains

        #region AppendLike

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlFilterBuilder<EntityColumn> AppendLike(string junction, EntityColumn column, string value)
        {
            _isDirty = true;
            Parameters.SetCurrentColumn(column);
            return base.AppendLike(junction, column, value);
        }

        /// <summary>
        /// Appends the specified column and value to the current filter.
        /// </summary>
        /// <param name="junction"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override SqlStringBuilder AppendLike(string junction, string column, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _isDirty = true;
                value = SqlUtil.Like(value);
                AppendInternal(junction, column, "LIKE", Parameters.GetParameter(value));
            }

            return this;
        }

        #endregion AppendLike

        #region Methods

        /// <summary>
        /// Parses the specified searchText to create a SQL filter expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="searchText"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public override string Parse(string column, string searchText, bool ignoreCase)
        {
            ParameterizedSqlExpressionParser parser = new ParameterizedSqlExpressionParser(column, ignoreCase);
            parser.Parameters = this.Parameters;
            return parser.Parse(searchText);
        }

        /// <summary>
        /// Gets an encoded list of values for use with an IN clause.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public override String GetInQueryValues(string values, bool encode)
        {
            CommaDelimitedStringCollection csv = new CommaDelimitedStringCollection();
            String[] split = values.Split(',');
            String temp;

            foreach (string value in split)
            {
                temp = value.Trim();

                if (!string.IsNullOrEmpty(temp))
                {
                    csv.Add(Parameters.GetParameter(temp));
                }
            }

            return csv.ToString();
        }

        /// <summary>
        /// Gets the current collection of <see cref="SqlFilterParameter"/> objects and
        /// also sets the collection's FilterExpression property.
        /// </summary>
        /// <returns></returns>
        public virtual SqlFilterParameterCollection GetParameters()
        {
            EnsureGroups();
            _isDirty = false;
            Parameters.FilterExpression = this.ToString();

            return Parameters;
        }
        
        /// <summary>
        /// Clear the Parameters as well as the base
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            Parameters.Clear();
        }

        #endregion Methods

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
                if (parameters == null)
                {
                    parameters = new SqlFilterParameterCollection();
                }

                if (_isDirty)
                    GetParameters();

                return parameters;
            }
            set { parameters = value; }
        }

        #endregion Properties

        #region IFilterParameterCollection
        /// <summary>
        /// Gets a collection of <see cref="SqlFilterParameter"/> objects 
        /// </summary>
        /// <returns></returns>
        SqlFilterParameterCollection IFilterParameterCollection.GetParameters()
        {
            return GetParameters();
        }
        #endregion
    }

    /// <summary>
    /// A collection of <see cref="SqlFilterParameter"/> objects.
    /// </summary>
    [Serializable]
    [CLSCompliant(true)]
    public class SqlFilterParameterCollection : List<SqlFilterParameter>, IFilterParameterCollection
    {
        #region Methods

        /// <summary>
        /// Sets the CurrentColumn property.
        /// </summary>
        /// <param name="column"></param>
        public void SetCurrentColumn(Object column)
        {
            this.currentColumn = (Enum)column;
        }

        /// <summary>
        /// Gets the next parameter name for the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public String GetParameter(string value)
        {
            SqlFilterParameter parameter = new SqlFilterParameter(CurrentColumn, value, Count);
            Add(parameter);
            return parameter.Name;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// The CurrentColumn member variable.
        /// </summary>
        private Enum currentColumn;

        /// <summary>
        /// Gets the CurrentColumn property.
        /// </summary>
        public Enum CurrentColumn
        {
            get { return currentColumn; }
        }

        /// <summary>
        /// The FilterExpression member variable.
        /// </summary>
        private String filterExpression;

        /// <summary>
        /// Gets or sets the FilterExpression property.
        /// </summary>
        public String FilterExpression
        {
            get { return filterExpression; }
            set { filterExpression = value; }
        }

        #endregion Properties

        #region IFilterParameterCollection
        /// <summary>
        /// Gets a list of sql parameters for the filter 
        /// </summary>
        /// <returns></returns>
        SqlFilterParameterCollection IFilterParameterCollection.GetParameters()
        {
            return this;
        }
        #endregion
    }

    /// <summary>
    /// Represents the information needed for a database command parameter.
    /// </summary>
    [Serializable]
    [CLSCompliant(true)]
    public class SqlFilterParameter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SqlFilterParameter class.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public SqlFilterParameter(Enum column, string value, int index)
        {
            this.column = column;
            this.parameterValue = value;
            this.parameterIndex = index;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The Column member variable.
        /// </summary>
        private Enum column;

        /// <summary>
        /// Gets or sets the Column property.
        /// </summary>
        public Enum Column
        {
            get { return column; }
            set { column = value; }
        }

        /// <summary>
        /// The Value member variable.
        /// </summary>
        private String parameterValue;

        /// <summary>
        /// Gets or sets the Value property.
        /// </summary>
        public String Value
        {
            get { return parameterValue; }
            set { parameterValue = value; }
        }

        /// <summary>
        /// The Index member variable.
        /// </summary>
        private int parameterIndex;

        /// <summary>
        /// Gets the parameter index.
        /// </summary>
        public int Index
        {
            get { return parameterIndex; }
        }

		/// <summary>
		/// Gets the parameter name.
		/// </summary>
		public String Name
		{
			get { return String.Format("@Param{0}", Index); }
		}

        /// <summary>
        /// Gets the <see cref="System.Data.SqlDbType"/> for
        /// the current entity column enumeration value.
        /// </summary>
        public System.Data.DbType DbType
        {
            get
            {
                System.Data.DbType dbType = System.Data.DbType.String;

                if (column != null)
                {
                    ColumnEnumAttribute attribute = EntityHelper.GetAttribute<ColumnEnumAttribute>(column);

                    if (attribute != null)
                    {
                        dbType = attribute.DbType;
                    }
                }

                return dbType;
            }
        }

        /// <summary>
        /// Gets the <see cref="System.Type"/> for
        /// the current entity column enumeration value.
        /// </summary>
        public System.Type SystemType
        {
            get
            {
                System.Type type = typeof(string);

                if (column != null)
                {
                    ColumnEnumAttribute attribute = EntityHelper.GetAttribute<ColumnEnumAttribute>(column);

                    if (attribute != null)
                    {
                        type = attribute.SystemType;
                    }
                }

                return type;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the current value converted to the appropriate <see cref="System.Type"/>.
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            return EntityUtil.ChangeType(Value, SystemType);
        }

        #endregion Methods
    }

    ///<summary>
    ///  Represents a type which will contain a method to 
    ///  retrieve the A collection of <see cref="SqlFilterParameterCollection"/> 
    ///  objects to use dynamic and parameterized filters.
    ///</summary>
    public interface IFilterParameterCollection
    {
        /// <summary>
        /// Gets a collection of <see cref="SqlFilterParameter"/> objects
        /// </summary>
        /// <returns><see cref="SqlFilterParameterCollection"/> object</returns>
        SqlFilterParameterCollection GetParameters();
    }

    #region SqlSortBuilder

    /// <summary>
    /// Allows for building SQL OrderBy expressions using strongly-typed column enumeration values.
    /// </summary>
    /// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
    [CLSCompliant(true)]
    public class SqlSortBuilder<EntityColumn> : ISortColumnCollection
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SqlFilterBuilder class.
        /// </summary>
        public SqlSortBuilder() : base() { }

        #endregion

        #region Append

        /// <summary>
        /// Appends the specified column and sorts it by the specified SqlSortDirection 
        /// </summary>
        /// <param name="column">The column to sort</param>
        /// <param name="sortDirection">The specified column's sort direction</param>
        /// <returns></returns>
        public virtual void Append(Enum column, SqlSortDirection sortDirection)
        {
            AddColumn(column, sortDirection);
        }

        /// <summary>
        /// Appends the specified column and sorts it Ascending
        /// </summary>
        /// <param name="column">The column to sort</param>
        /// <returns></returns>
        public virtual void AppendASC(Enum column)
        {
            AddColumn(column, SqlSortDirection.ASC);
        }

        /// <summary>
        /// Appends the specified column and sorts it Descending
        /// </summary>
        /// <param name="column">The column to sort</param>
        /// <returns></returns>
        public virtual void AppendDESC(Enum column)
        {
            AddColumn(column, SqlSortDirection.DESC);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The Sort Columns member variable.
        /// </summary>
        private SqlSortColumnCollection sortColumns = new SqlSortColumnCollection();

        private bool _isDirty = true;

        /// <summary>
        /// Gets or sets the SortColumns property.
        /// </summary>
        public virtual SqlSortColumnCollection SortColumns
        {
            get
            {
                if (_isDirty)
                    GetSortColumns();

                return sortColumns;
            }
            set { sortColumns = value; }
        }

        #endregion

        #region Methods


        /// <summary>
        /// Adds a column to the sort builder
        /// </summary>
        /// <param name="column">The entity's column to sort by</param>
        /// <param name="sortDirection">The sort direction</param>
        private void AddColumn(Enum column, SqlSortDirection sortDirection)
        {
            sortColumns.Add(new SqlSortColumn(column, sortDirection));
        }

        /// <summary>
        /// Provides the actual SQL sort string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return sortColumns.ToString();
        }

        /// <summary>
        /// Gets the column name from the specified column enumeration value.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        protected virtual String GetColumnName(EntityColumn column)
        {
            String name = EntityHelper.GetAttribute<ColumnEnumAttribute>(column as Enum).Name;

            if (string.IsNullOrEmpty(name))
            {
                name = column.ToString();
            }

            return name;
        }

        /// <summary>
        /// Gets the current collection of <see cref="SqlFilterParameter"/> objects and
        /// also sets the collection's FilterExpression property.
        /// </summary>
        /// <returns></returns>
        public virtual SqlSortColumnCollection GetSortColumns()
        {
            _isDirty = false;
            SortColumns.SortExpression = ToString();

            return SortColumns;
        }
        #endregion Methods

        #region IFilterParameterCollection
        /// <summary>
        /// Gets a collection of <see cref="SqlFilterParameter"/> objects 
        /// </summary>
        /// <returns></returns>
        SqlSortColumnCollection ISortColumnCollection.GetSortColumns()
        {
            return GetSortColumns();
        }
        #endregion
    }

    /// <summary>
    /// A collection of <see cref="SqlSortColumn"/> objects.
    /// </summary>
    [Serializable]
    [CLSCompliant(true)]
    public class SqlSortColumnCollection : List<SqlSortColumn>, ISortColumnCollection
    {
        #region Methods

        /// <summary>
        /// Sets the CurrentColumn property.
        /// </summary>
        /// <param name="column"></param>
        public void SetCurrentColumn(Object column)
        {
            this._currentColumn = (Enum)column;
        }

        /// <summary>
        /// Provides the actual SQL sort string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Int32 count = 1;
            foreach (SqlSortColumn sc in this)
            {
                sb.Append(sc.Column).Append(" ").Append(sc.SortDirection);

                if (count++ < this.Count)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }
        #endregion Methods

        #region Properties

        /// <summary>
        /// The CurrentColumn member variable.
        /// </summary>
        private Enum _currentColumn;

        /// <summary>
        /// Gets the CurrentColumn property.
        /// </summary>
        public Enum CurrentColumn
        {
            get { return _currentColumn; }
        }

        /// <summary>
        /// The SortExpression member variable.
        /// </summary>
        private String sortExpression;

        /// <summary>
        /// Gets or sets the SortExpression property.
        /// </summary>
        public String SortExpression
        {
            get { return sortExpression; }
            set { sortExpression = value; }
        }

        #endregion Properties

        #region IFilterParameterCollection
        /// <summary>
        /// Gets a list of sql parameters for the filter 
        /// </summary>
        /// <returns></returns>
        SqlSortColumnCollection ISortColumnCollection.GetSortColumns()
        {
            return this;
        }
        #endregion
    }

    /// <summary>
    /// Represents the information of a sorted column.
    /// </summary>
    [Serializable]
    [CLSCompliant(true)]
    public class SqlSortColumn
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SqlSortColumn class.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="sortDirection"></param>
        public SqlSortColumn(Enum column, SqlSortDirection sortDirection)
        {
            this._column = column;
            this._sortDirection = sortDirection;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The Column member variable.
        /// </summary>
        private Enum _column;

        /// <summary>
        /// Gets or sets the Column property.
        /// </summary>
        public Enum Column
        {
            get { return _column; }
            set { _column = value; }
        }

        /// <summary>
        /// The Value member variable.
        /// </summary>
        private SqlSortDirection _sortDirection;

        /// <summary>
        /// Gets or sets the Value property.
        /// </summary>
        public SqlSortDirection SortDirection
        {
            get { return _sortDirection; }
            set { _sortDirection = value; }
        }

        #endregion Properties

    }

    ///<summary>
    ///  Represents a type which will contain a method to 
    ///  retrieve the A collection of <see cref="SqlSortColumnCollection"/> 
    ///  objects to generate an OrderBy clause.
    ///</summary>
    public interface ISortColumnCollection
    {
        /// <summary>
        /// Gets a collection of <see cref="SqlSortColumn"/> objects
        /// </summary>
        /// <returns><see cref="SqlSortColumnCollection"/> object</returns>
        SqlSortColumnCollection GetSortColumns();
    }

    #endregion
}