﻿
using System;
using System.Collections;

namespace Ekip.Framework.Entities
{
	/// <summary>
	/// Provide a generic comparer for our entity objects.
	/// </summary>
	public class EntityPropertyComparer : IComparer
	{
		private string PropertyName;

		/// <summary>
		/// Provides Comparison opreations.
		/// </summary>
		/// <param name="propertyName">The property to compare</param>
		public EntityPropertyComparer( string propertyName)
		{
			PropertyName = propertyName;
		}

		/// <summary>
		/// Compares 2 objects by their properties, given on the constructor
		/// </summary>
		/// <param name="x">First value to compare</param>
		/// <param name="y">Second value to compare</param>
		/// <returns></returns>
		public int Compare(object x, object y)
		{
			object a = x.GetType().GetProperty(PropertyName).GetValue(x, null);
			object b = y.GetType().GetProperty(PropertyName).GetValue(y, null);

			if ( a != null && b == null )
				return 1;

			if ( a == null && b != null )
				return -1;

			if ( a == null && b == null )
				return 0;

			return ((IComparable)a).CompareTo(b);
		}
	}
}
