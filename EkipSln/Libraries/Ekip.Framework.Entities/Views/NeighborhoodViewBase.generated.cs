﻿/*
	File generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Haziran 2019 Salı
	Important: Do not modify this file. Edit the file NeighborhoodView.cs instead.
*/
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace Ekip.Framework.Entities
{
	///<summary>
	/// An object representation of the 'NeighborhoodView' view. [No description found in the database]	
	///</summary>
	[DataContract]
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("NeighborhoodViewBase")]
	public abstract partial class NeighborhoodViewBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// TownId : 
		/// </summary>
		private System.Int32		  _townId = (int)0;
		
		/// <summary>
		/// TownName : 
		/// </summary>
		private System.String		  _townName = string.Empty;
		
		/// <summary>
		/// NeighborhoodId : 
		/// </summary>
		private System.Int32		  _neighborhoodId = (int)0;
		
		/// <summary>
		/// NeighborhoodName : 
		/// </summary>
		private System.String		  _neighborhoodName = string.Empty;
		
		/// <summary>
		/// Object that contains data to associate with this object
		/// </summary>
		private object _tag;
		
		/// <summary>
		/// Suppresses Entity Events from Firing, 
		/// useful when loading the entities from the database.
		/// </summary>
	    [NonSerialized] 
		private bool suppressEntityEvents = false;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="NeighborhoodViewBase"/> instance.
		///</summary>
		public NeighborhoodViewBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="NeighborhoodViewBase"/> instance.
		///</summary>
		///<param name="_townId"></param>
		///<param name="_townName"></param>
		///<param name="_neighborhoodId"></param>
		///<param name="_neighborhoodName"></param>
		public NeighborhoodViewBase(System.Int32 _townId, System.String _townName, System.Int32 _neighborhoodId, System.String _neighborhoodName)
		{
			this._townId = _townId;
			this._townName = _townName;
			this._neighborhoodId = _neighborhoodId;
			this._neighborhoodName = _neighborhoodName;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="NeighborhoodView"/> instance.
		///</summary>
		///<param name="_townId"></param>
		///<param name="_townName"></param>
		///<param name="_neighborhoodId"></param>
		///<param name="_neighborhoodName"></param>
		public static NeighborhoodView CreateNeighborhoodView(System.Int32 _townId, System.String _townName, System.Int32 _neighborhoodId, System.String _neighborhoodName)
		{
			NeighborhoodView newNeighborhoodView = new NeighborhoodView();
			newNeighborhoodView.TownId = _townId;
			newNeighborhoodView.TownName = _townName;
			newNeighborhoodView.NeighborhoodId = _neighborhoodId;
			newNeighborhoodView.NeighborhoodName = _neighborhoodName;
			return newNeighborhoodView;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the TownId property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 TownId
		{
			get
			{
				return this._townId; 
			}
			set
			{
				if (_townId == value)
					return;
					
				this._townId = value;
				this._isDirty = true;
				
				OnPropertyChanged("TownId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the TownName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String TownName
		{
			get
			{
				return this._townName; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "TownName does not allow null values.");
				if (_townName == value)
					return;
					
				this._townName = value;
				this._isDirty = true;
				
				OnPropertyChanged("TownName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the NeighborhoodId property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 NeighborhoodId
		{
			get
			{
				return this._neighborhoodId; 
			}
			set
			{
				if (_neighborhoodId == value)
					return;
					
				this._neighborhoodId = value;
				this._isDirty = true;
				
				OnPropertyChanged("NeighborhoodId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the NeighborhoodName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String NeighborhoodName
		{
			get
			{
				return this._neighborhoodName; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "NeighborhoodName does not allow null values.");
				if (_neighborhoodName == value)
					return;
					
				this._neighborhoodName = value;
				this._isDirty = true;
				
				OnPropertyChanged("NeighborhoodName");
			}
		}
		
		
		/// <summary>
		///     Gets or sets the object that contains supplemental data about this object.
		/// </summary>
		/// <value>Object</value>
		[System.ComponentModel.Bindable(false)]
		[LocalizableAttribute(false)]
		[DescriptionAttribute("Object containing data to be associated with this object")]
		public virtual object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				if (this._tag == value)
					return;
		
				this._tag = value;
			}
		}
	
		/// <summary>
		/// Determines whether this entity is to suppress events while set to true.
		/// </summary>
		[System.ComponentModel.Bindable(false)]
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool SuppressEntityEvents
		{	
			get
			{
				return suppressEntityEvents;
			}
			set
			{
				suppressEntityEvents = value;
			}	
		}

		private bool _isDeleted = false;
		/// <summary>
		/// Gets a value indicating if object has been <see cref="MarkToDelete"/>. ReadOnly.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDeleted
		{
			get { return this._isDeleted; }
		}


		private bool _isDirty = false;
		/// <summary>
		///	Gets a value indicating  if the object has been modified from its original state.
		/// </summary>
		///<value>True if object has been modified from its original state; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDirty
		{
			get { return this._isDirty; }
		}
		

		private bool _isNew = true;
		/// <summary>
		///	Gets a value indicating if the object is new.
		/// </summary>
		///<value>True if objectis new; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsNew
		{
			get { return this._isNew; }
			set { this._isNew = value; }
		}

		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public string ViewName
		{
			get { return "NeighborhoodView"; }
		}

		
		#endregion
		
		#region Methods	
		
		/// <summary>
		/// Accepts the changes made to this object by setting each flags to false.
		/// </summary>
		public virtual void AcceptChanges()
		{
			this._isDeleted = false;
			this._isDirty = false;
			this._isNew = false;
			OnPropertyChanged(string.Empty);
		}
		
		
		///<summary>
		///  Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public virtual void CancelChanges()
		{
			throw new NotSupportedException("Method currently not Supported.");
		}
		
		///<summary>
		///   Marks entity to be deleted.
		///</summary>
		public virtual void MarkToDelete()
		{
			this._isDeleted = true;
		}
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed NeighborhoodViewBase Entity 
		///</summary>
		public virtual NeighborhoodViewBase Copy()
		{
			//shallow copy entity
			NeighborhoodView copy = new NeighborhoodView();
				copy.TownId = this.TownId;
				copy.TownName = this.TownName;
				copy.NeighborhoodId = this.NeighborhoodId;
				copy.NeighborhoodName = this.NeighborhoodName;
			copy.AcceptChanges();
			return (NeighborhoodView)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Deep Copy of this entity.
		///</summary>
		public object Clone(){
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		#endregion
		
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="NeighborhoodViewBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(NeighborhoodViewBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="NeighborhoodViewBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="NeighborhoodViewBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="NeighborhoodViewBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(NeighborhoodViewBase Object1, NeighborhoodViewBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.TownId != Object2.TownId)
				equal = false;
			if (Object1.TownName != Object2.TownName)
				equal = false;
			if (Object1.NeighborhoodId != Object2.NeighborhoodId)
				equal = false;
			if (Object1.NeighborhoodName != Object2.NeighborhoodName)
				equal = false;
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}
	
		#endregion
		
		#region INotifyPropertyChanged Members
		
		/// <summary>
      /// Event to indicate that a property has changed.
      /// </summary>
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="propertyName">The name of the property that has changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{ 
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="e">PropertyChangedEventArgs</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (!SuppressEntityEvents)
			{
				if (null != PropertyChanged)
				{
					PropertyChanged(this, e);
				}
			}
		}
		
		#endregion
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static object GetPropertyValueByName(NeighborhoodView entity, string propertyName)
		{
			switch (propertyName)
			{
				case "TownId":
					return entity.TownId;
				case "TownName":
					return entity.TownName;
				case "NeighborhoodId":
					return entity.NeighborhoodId;
				case "NeighborhoodName":
					return entity.NeighborhoodName;
			}
			return null;
		}
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public object GetPropertyValueByName(string propertyName)
		{			
			return GetPropertyValueByName(this as NeighborhoodView, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{5}{4}- TownId: {0}{4}- TownName: {1}{4}- NeighborhoodId: {2}{4}- NeighborhoodName: {3}{4}", 
				this.TownId,
				this.TownName,
				this.NeighborhoodId,
				this.NeighborhoodName,
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the NeighborhoodView columns.
	/// </summary>
	[Serializable]
	public enum NeighborhoodViewColumn
	{
		/// <summary>
		/// TownId : 
		/// </summary>
		[EnumTextValue("TownId")]
		[ColumnEnum("TownId", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		TownId,
		/// <summary>
		/// TownName : 
		/// </summary>
		[EnumTextValue("TownName")]
		[ColumnEnum("TownName", typeof(System.String), System.Data.DbType.String, false, false, false, 250)]
		TownName,
		/// <summary>
		/// NeighborhoodId : 
		/// </summary>
		[EnumTextValue("NeighborhoodId")]
		[ColumnEnum("NeighborhoodId", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		NeighborhoodId,
		/// <summary>
		/// NeighborhoodName : 
		/// </summary>
		[EnumTextValue("NeighborhoodName")]
		[ColumnEnum("NeighborhoodName", typeof(System.String), System.Data.DbType.String, false, false, false, 250)]
		NeighborhoodName
	}//End enum

} // end namespace
