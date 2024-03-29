﻿using System;
using System.Text;

using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Ekip.Framework.Entities
{
	/// <summary>
	/// Provides a unified way of converting types of values to other types, as well as for accessing standard values and subproperties.
	/// Used by the nettiers strongly typed collection, so they can be saved in ViewState.
	/// </summary>
	public class GenericTypeConverter : TypeConverter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericTypeConverter"/> class.
		/// </summary>
		public GenericTypeConverter()
		{
		}
		
		/// <summary>
		/// Returns whether this converter can convert the object to the specified type.
		/// </summary>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if(destinationType == typeof(InstanceDescriptor))
				return true;
				
			return base.CanConvertTo(context,destinationType);
		}
		
		/// <summary>
		/// Converts the given value object to the specified type.
		/// </summary>
		public override object ConvertTo(ITypeDescriptorContext context,
		              System.Globalization.CultureInfo culture,
		              object val,Type destinationType)
		{
			if(destinationType == typeof(InstanceDescriptor))
			{
				Type valueType = val.GetType();
				ConstructorInfo ci = valueType.GetConstructor(System.Type.EmptyTypes);
				return new InstanceDescriptor(ci,null,false);
			}
			return base.ConvertTo(context,culture,val,destinationType);
		}
	}
}
