﻿
/*
	File generated by NetTiers templates [www.nettiers.net]
	Generated on : 15 Ocak 2019 Salı
	Important: Do not modify this file. Edit the file CalenderAge.cs instead.
*/

#region using directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using Ekip.Framework.Entities.Validation;
#endregion

namespace Ekip.Framework.Entities
{
	///<summary>
	/// An object representation of the 'CalenderAge' table. [No description found the database]	
	///</summary>
	[DataContract]
	[DataObject, CLSCompliant(true)]
	public abstract partial class CalenderAgeBase : EntityBase, ICalenderAge, IEntityId<CalenderAgeKey>, System.IComparable, System.ICloneable, ICloneableEx, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		[DataMember]
		private CalenderAgeEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		[DataMember]
		private CalenderAgeEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private CalenderAgeEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		private TList<CalenderAge> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>
		public event CalenderAgeEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		public event CalenderAgeEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="CalenderAgeBase"/> instance.
		///</summary>
		public CalenderAgeBase()
		{
			this.entityData = new CalenderAgeEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="CalenderAgeBase"/> instance.
		///</summary>
		///<param name="_ageValue"></param>
		public CalenderAgeBase(System.String _ageValue)
		{
			this.entityData = new CalenderAgeEntityData();
			this.backupData = null;

			this.AgeValue = _ageValue;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="CalenderAge"/> instance.
		///</summary>
		///<param name="_ageValue"></param>
		public static CalenderAge CreateCalenderAge(System.String _ageValue)
		{
			CalenderAge newCalenderAge = new CalenderAge();
			newCalenderAge.AgeValue = _ageValue;
			return newCalenderAge;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the CalenderAgeId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		
		




		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 CalenderAgeId
		{
			get
			{
				return this.entityData.CalenderAgeId; 
			}
			
			set
			{
				if (this.entityData.CalenderAgeId == value)
					return;
				
                OnPropertyChanging("CalenderAgeId");                    
				OnColumnChanging(CalenderAgeColumn.CalenderAgeId, this.entityData.CalenderAgeId);
				this.entityData.CalenderAgeId = value;
				this.EntityId.CalenderAgeId = value;
				if ( !this._deserializing && this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(CalenderAgeColumn.CalenderAgeId, this.entityData.CalenderAgeId);
				OnPropertyChanged("CalenderAgeId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the AgeValue property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		
		




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false, 50)]
		public virtual System.String AgeValue
		{
			get
			{
				return this.entityData.AgeValue; 
			}
			
			set
			{
				if (this.entityData.AgeValue == value)
					return;
				
                OnPropertyChanging("AgeValue");                    
				OnColumnChanging(CalenderAgeColumn.AgeValue, this.entityData.AgeValue);
				this.entityData.AgeValue = value;
				if ( !this._deserializing && this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(CalenderAgeColumn.AgeValue, this.entityData.AgeValue);
				OnPropertyChanged("AgeValue");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
		#endregion Children Collections
		
		#endregion
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule( CommonRules.NotNull,
				new ValidationRuleArgs("AgeValue", "Age Value"));
			ValidationRules.AddRule( CommonRules.StringMaxLength, 
				new CommonRules.MaxLengthRuleArgs("AgeValue", "Age Value", 50));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "CalenderAge"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"CalenderAgeId", "AgeValue"};
			}
		}
		#endregion 
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as CalenderAgeEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (CalenderAge) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<CalenderAge>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as CalenderAge);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed CalenderAge Entity 
		///</summary>
		protected virtual CalenderAge Copy(IDictionary existingCopies)
		{
			if (existingCopies == null)
			{
				// This is the root of the tree to be copied!
				existingCopies = new Hashtable();
			}

			//shallow copy entity
			CalenderAge copy = new CalenderAge();
			existingCopies.Add(this, copy);
			copy.SuppressEntityEvents = true;
				copy.CalenderAgeId = this.CalenderAgeId;
				copy.AgeValue = this.AgeValue;
			
		
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}		
		
		
		
		///<summary>
		///  Returns a Typed CalenderAge Entity 
		///</summary>
		public virtual CalenderAge Copy()
		{
			return this.Copy(null);	
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy(null);
		}
		
		///<summary>
		/// ICloneableEx.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone(IDictionary existingCopies)
		{
			return this.Copy(existingCopies);
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x, IDictionary existingCopies)
		{
			if (x == null)
				return null;
			
			if (x is ICloneableEx)
			{
				// Return a deep copy of the object
				return ((ICloneableEx)x).Clone(existingCopies);
			}
			else if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable or IClonableEx Interface.");
		}
		
		
		///<summary>
		///  Returns a Typed CalenderAge Entity which is a deep copy of the current entity.
		///</summary>
		public virtual CalenderAge DeepCopy()
		{
			return EntityHelper.Clone<CalenderAge>(this as CalenderAge);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as CalenderAgeEntityData;
			}
			else
			{
				//Since this had no _originalData, then just reset the entityData with a new one.  entityData cannot be null.
				this.entityData = new CalenderAgeEntityData();
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as CalenderAgeEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(CalenderAgeColumn column)
		{
			switch(column)
			{
					case CalenderAgeColumn.CalenderAgeId:
					return entityData.CalenderAgeId != _originalData.CalenderAgeId;
					case CalenderAgeColumn.AgeValue:
					return entityData.AgeValue != _originalData.AgeValue;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="columnName">The column name.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public override bool IsPropertyChanged(string columnName)
		{
			return 	IsPropertyChanged(EntityHelper.GetEnumValue< CalenderAgeColumn >(columnName));
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if data has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.CalenderAgeId != _originalData.CalenderAgeId;
			result = result || entityData.AgeValue != _originalData.AgeValue;
			return result;
		}	
		
		///<summary>
		///  Returns a CalenderAge Entity with the original data.
		///</summary>
		public CalenderAge GetOriginalEntity()
		{
			if (_originalData != null)
				return CreateCalenderAge(
				_originalData.AgeValue
				);
				
			return (CalenderAge)this.Clone();
		}
		#endregion
	
	#region Value Semantics Instance Equality
        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object using value semantics.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="CalenderAgeBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			// Cast exception if Object1 is null or DbNull
			if (Object1 != null && Object1 != DBNull.Value && Object1 is CalenderAgeBase)
				return ValueEquals(this, (CalenderAgeBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="CalenderAgeBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.CalenderAgeId.GetHashCode() ^ 
					this.AgeValue.GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object using value semantics.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="CalenderAgeBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(CalenderAgeBase toObject)
		{
			if (toObject == null)
				return false;
			return ValueEquals(this, toObject);
		}
		#endregion
		
		///<summary>
		/// Determines whether the specified <see cref="CalenderAgeBase"/> instances are considered equal using value semantics.
		///</summary>
		///<param name="Object1">The first <see cref="CalenderAgeBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="CalenderAgeBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool ValueEquals(CalenderAgeBase Object1, CalenderAgeBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.CalenderAgeId != Object2.CalenderAgeId)
				equal = false;
			if (Object1.AgeValue != Object2.AgeValue)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((CalenderAgeBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static CalenderAgeComparer GetComparer()
        {
            return new CalenderAgeComparer();
        }
        */

        // Comparer delegates back to CalenderAge
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(CalenderAge rhs, CalenderAgeColumn which)
        {
            switch (which)
            {
            	
            	
            	case CalenderAgeColumn.CalenderAgeId:
            		return this.CalenderAgeId.CompareTo(rhs.CalenderAgeId);
            		
            		                 
            	
            	
            	case CalenderAgeColumn.AgeValue:
            		return this.AgeValue.CompareTo(rhs.AgeValue);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public virtual void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<CalenderAgeKey> Members
		
		// member variable for the EntityId property
		private CalenderAgeKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual CalenderAgeKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new CalenderAgeKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) ]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
		}
		#endregion 
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = new System.Text.StringBuilder("CalenderAge")
					.Append("|").Append( this.CalenderAgeId.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{3}{2}- CalenderAgeId: {0}{2}- AgeValue: {1}{2}{4}", 
				this.CalenderAgeId,
				this.AgeValue,
				System.Environment.NewLine, 
				this.GetType(),
				this.Error.Length == 0 ? string.Empty : string.Format("- Error: {0}\n",this.Error));
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'CalenderAge' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DataContract]
	internal protected class CalenderAgeEntityData : ICloneable, ICloneableEx
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
		/// <summary>			
		/// CalenderAgeId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "CalenderAge"</remarks>
		[DataMember]
		public System.Int32 CalenderAgeId;
			
		#endregion
		
		#region Non Primary key(s)
		
		/// <summary>
		/// AgeValue : 
		/// </summary>
		[DataMember]
		public System.String AgeValue = string.Empty;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
        
		#endregion Variable Declarations

		#region Data Properties

		#endregion Data Properties
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			CalenderAgeEntityData _tmp = new CalenderAgeEntityData();
						
			_tmp.CalenderAgeId = this.CalenderAgeId;
			
			_tmp.AgeValue = this.AgeValue;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone(IDictionary existingCopies)
		{
			if (existingCopies == null)
				existingCopies = new Hashtable();
				
			CalenderAgeEntityData _tmp = new CalenderAgeEntityData();
						
			_tmp.CalenderAgeId = this.CalenderAgeId;
			
			_tmp.AgeValue = this.AgeValue;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false)]
		[DataMember]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct

		#endregion
		
				
		
		#region DataContract serialization
		
		bool _deserializing = false;
		
		/// <summary>
		/// Called before deserializing the type.
		/// </summary>
		[OnDeserializingAttribute]
		private void Initialize_BeforeDeserializing(StreamingContext context)
		{
			this._deserializing = true;
		
			this.entityData = new CalenderAgeEntityData();
			this.backupData = null;
			
			AddValidationRules();
		}
		
		/// <summary>
		/// Called after deserializing the type.
		/// </summary>
		[OnDeserializedAttribute ]
		private void Initialize_Deserialized(StreamingContext context)
		{
			this._deserializing = false;
		}
				
		#endregion
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CalenderAgeColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanging(CalenderAgeColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CalenderAgeColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanged(CalenderAgeColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CalenderAgeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanging(CalenderAgeColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
                EntityManager.StopTracking(entityTrackingKey);
                
			if (!SuppressEntityEvents)
			{
				CalenderAgeEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new CalenderAgeEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CalenderAgeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanged(CalenderAgeColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				CalenderAgeEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new CalenderAgeEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region CalenderAgeEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="CalenderAge"/> object.
	/// </remarks>
	public class CalenderAgeEventArgs : System.EventArgs
	{
		private CalenderAgeColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the CalenderAgeEventArgs class.
		///</summary>
		public CalenderAgeEventArgs(CalenderAgeColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the CalenderAgeEventArgs class.
		///</summary>
		public CalenderAgeEventArgs(CalenderAgeColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The CalenderAgeColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="CalenderAgeColumn" />
		public CalenderAgeColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all CalenderAge related events.
	///</summary>
	public delegate void CalenderAgeEventHandler(object sender, CalenderAgeEventArgs e);
	
	#region CalenderAgeComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class CalenderAgeComparer : System.Collections.Generic.IComparer<CalenderAge>
	{
		CalenderAgeColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:CalenderAgeComparer"/> class.
        /// </summary>
		public CalenderAgeComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CalenderAgeComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public CalenderAgeComparer(CalenderAgeColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <see cref="CalenderAge"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <see cref="CalenderAge"/> to compare.</param>
        /// <param name="b">The second <c>CalenderAge</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(CalenderAge a, CalenderAge b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(CalenderAge entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(CalenderAge a, CalenderAge b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public CalenderAgeColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region CalenderAgeKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="CalenderAge"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class CalenderAgeKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the CalenderAgeKey class.
		/// </summary>
		public CalenderAgeKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the CalenderAgeKey class.
		/// </summary>
		public CalenderAgeKey(CalenderAgeBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.CalenderAgeId = entity.CalenderAgeId;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the CalenderAgeKey class.
		/// </summary>
		public CalenderAgeKey(System.Int32 _calenderAgeId)
		{
			#region Init Properties

			this.CalenderAgeId = _calenderAgeId;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private CalenderAgeBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public CalenderAgeBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the CalenderAgeId property
		private System.Int32 _calenderAgeId;
		
		/// <summary>
		/// Gets or sets the CalenderAgeId property.
		/// </summary>
		public System.Int32 CalenderAgeId
		{
			get { return _calenderAgeId; }
			set
			{
				if ( this.Entity != null )
					this.Entity.CalenderAgeId = value;
				
				_calenderAgeId = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				CalenderAgeId = ( values["CalenderAgeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CalenderAgeId"], typeof(System.Int32)) : (int)0;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("CalenderAgeId", CalenderAgeId);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("CalenderAgeId: {0}{1}",
								CalenderAgeId,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region CalenderAgeColumn Enum
	
	/// <summary>
	/// Enumerate the CalenderAge columns.
	/// </summary>
	[Serializable]
	public enum CalenderAgeColumn : int
	{
		/// <summary>
		/// CalenderAgeId : 
		/// </summary>
		[EnumTextValue("Calender Age Id")]
		[ColumnEnum("CalenderAgeId", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		CalenderAgeId = 1,
		/// <summary>
		/// AgeValue : 
		/// </summary>
		[EnumTextValue("Age Value")]
		[ColumnEnum("AgeValue", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 50)]
		AgeValue = 2
	}//End enum

	#endregion CalenderAgeColumn Enum

} // end namespace