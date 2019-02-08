﻿/*
	File generated by NetTiers templates [www.nettiers.net]
	Generated on : 5 Şubat 2019 Salı
	Important: Do not modify this file. Edit the file ProvinceView.cs instead.
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
	/// An object representation of the 'ProvinceView' view. [No description found in the database]	
	///</summary>
	[DataContract]
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("ProvinceViewBase")]
	public abstract partial class ProvinceViewBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// Id : 
		/// </summary>
		private System.Int32		  _ıd = (int)0;
		
		/// <summary>
		/// RowNumber : 
		/// </summary>
		private System.Int32		  _rowNumber = (int)0;
		
		/// <summary>
		/// AdminId : 
		/// </summary>
		private System.Int64		  _adminId = (long)0;
		
		/// <summary>
		/// ObjectId : 
		/// </summary>
		private System.Int64		  _objectId = (long)0;
		
		/// <summary>
		/// ParentId : 
		/// </summary>
		private System.Int64		  _parentId = (long)0;
		
		/// <summary>
		/// PlateCode : 
		/// </summary>
		private System.String		  _plateCode = string.Empty;
		
		/// <summary>
		/// AreaId : 
		/// </summary>
		private System.Int32		  _areaId = (int)0;
		
		/// <summary>
		/// PhoneCode : 
		/// </summary>
		private System.String		  _phoneCode = string.Empty;
		
		/// <summary>
		/// ProvinceName : 
		/// </summary>
		private System.String		  _provinceName = string.Empty;
		
		/// <summary>
		/// Longitude : 
		/// </summary>
		private System.String		  _longitude = string.Empty;
		
		/// <summary>
		/// Latitude : 
		/// </summary>
		private System.String		  _latitude = string.Empty;
		
		/// <summary>
		/// Type : 
		/// </summary>
		private System.Int32		  _type = (int)0;
		
		/// <summary>
		/// CreateDate : 
		/// </summary>
		private System.DateTime		  _createDate = DateTime.MinValue;
		
		/// <summary>
		/// CreateTime : 
		/// </summary>
		private System.TimeSpan		  _createTime = new TimeSpan(1,0,0,0,0);
		
		/// <summary>
		/// UpdateDate : 
		/// </summary>
		private System.DateTime?		  _updateDate = null;
		
		/// <summary>
		/// UpdateTime : 
		/// </summary>
		private System.TimeSpan?		  _updateTime = null;
		
		/// <summary>
		/// CreateUserId : 
		/// </summary>
		private System.Int32		  _createUserId = (int)0;
		
		/// <summary>
		/// UpdateUserId : 
		/// </summary>
		private System.Int32?		  _updateUserId = null;
		
		/// <summary>
		/// Active : 
		/// </summary>
		private System.Boolean		  _active = false;
		
		/// <summary>
		/// Deleted : 
		/// </summary>
		private System.Boolean		  _deleted = false;
		
		/// <summary>
		/// AreaName : 
		/// </summary>
		private System.String		  _areaName = null;
		
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
		/// Creates a new <see cref="ProvinceViewBase"/> instance.
		///</summary>
		public ProvinceViewBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="ProvinceViewBase"/> instance.
		///</summary>
		///<param name="_ıd"></param>
		///<param name="_rowNumber"></param>
		///<param name="_adminId"></param>
		///<param name="_objectId"></param>
		///<param name="_parentId"></param>
		///<param name="_plateCode"></param>
		///<param name="_areaId"></param>
		///<param name="_phoneCode"></param>
		///<param name="_provinceName"></param>
		///<param name="_longitude"></param>
		///<param name="_latitude"></param>
		///<param name="_type"></param>
		///<param name="_createDate"></param>
		///<param name="_createTime"></param>
		///<param name="_updateDate"></param>
		///<param name="_updateTime"></param>
		///<param name="_createUserId"></param>
		///<param name="_updateUserId"></param>
		///<param name="_active"></param>
		///<param name="_deleted"></param>
		///<param name="_areaName"></param>
		public ProvinceViewBase(System.Int32 _ıd, System.Int32 _rowNumber, System.Int64 _adminId, System.Int64 _objectId, System.Int64 _parentId, System.String _plateCode, System.Int32 _areaId, System.String _phoneCode, System.String _provinceName, System.String _longitude, System.String _latitude, System.Int32 _type, System.DateTime _createDate, System.TimeSpan _createTime, System.DateTime? _updateDate, System.TimeSpan? _updateTime, System.Int32 _createUserId, System.Int32? _updateUserId, System.Boolean _active, System.Boolean _deleted, System.String _areaName)
		{
			this._ıd = _ıd;
			this._rowNumber = _rowNumber;
			this._adminId = _adminId;
			this._objectId = _objectId;
			this._parentId = _parentId;
			this._plateCode = _plateCode;
			this._areaId = _areaId;
			this._phoneCode = _phoneCode;
			this._provinceName = _provinceName;
			this._longitude = _longitude;
			this._latitude = _latitude;
			this._type = _type;
			this._createDate = _createDate;
			this._createTime = _createTime;
			this._updateDate = _updateDate;
			this._updateTime = _updateTime;
			this._createUserId = _createUserId;
			this._updateUserId = _updateUserId;
			this._active = _active;
			this._deleted = _deleted;
			this._areaName = _areaName;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ProvinceView"/> instance.
		///</summary>
		///<param name="_ıd"></param>
		///<param name="_rowNumber"></param>
		///<param name="_adminId"></param>
		///<param name="_objectId"></param>
		///<param name="_parentId"></param>
		///<param name="_plateCode"></param>
		///<param name="_areaId"></param>
		///<param name="_phoneCode"></param>
		///<param name="_provinceName"></param>
		///<param name="_longitude"></param>
		///<param name="_latitude"></param>
		///<param name="_type"></param>
		///<param name="_createDate"></param>
		///<param name="_createTime"></param>
		///<param name="_updateDate"></param>
		///<param name="_updateTime"></param>
		///<param name="_createUserId"></param>
		///<param name="_updateUserId"></param>
		///<param name="_active"></param>
		///<param name="_deleted"></param>
		///<param name="_areaName"></param>
		public static ProvinceView CreateProvinceView(System.Int32 _ıd, System.Int32 _rowNumber, System.Int64 _adminId, System.Int64 _objectId, System.Int64 _parentId, System.String _plateCode, System.Int32 _areaId, System.String _phoneCode, System.String _provinceName, System.String _longitude, System.String _latitude, System.Int32 _type, System.DateTime _createDate, System.TimeSpan _createTime, System.DateTime? _updateDate, System.TimeSpan? _updateTime, System.Int32 _createUserId, System.Int32? _updateUserId, System.Boolean _active, System.Boolean _deleted, System.String _areaName)
		{
			ProvinceView newProvinceView = new ProvinceView();
			newProvinceView.Id = _ıd;
			newProvinceView.RowNumber = _rowNumber;
			newProvinceView.AdminId = _adminId;
			newProvinceView.ObjectId = _objectId;
			newProvinceView.ParentId = _parentId;
			newProvinceView.PlateCode = _plateCode;
			newProvinceView.AreaId = _areaId;
			newProvinceView.PhoneCode = _phoneCode;
			newProvinceView.ProvinceName = _provinceName;
			newProvinceView.Longitude = _longitude;
			newProvinceView.Latitude = _latitude;
			newProvinceView.Type = _type;
			newProvinceView.CreateDate = _createDate;
			newProvinceView.CreateTime = _createTime;
			newProvinceView.UpdateDate = _updateDate;
			newProvinceView.UpdateTime = _updateTime;
			newProvinceView.CreateUserId = _createUserId;
			newProvinceView.UpdateUserId = _updateUserId;
			newProvinceView.Active = _active;
			newProvinceView.Deleted = _deleted;
			newProvinceView.AreaName = _areaName;
			return newProvinceView;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the Id property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 Id
		{
			get
			{
				return this._ıd; 
			}
			set
			{
				if (_ıd == value)
					return;
					
				this._ıd = value;
				this._isDirty = true;
				
				OnPropertyChanged("Id");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the RowNumber property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 RowNumber
		{
			get
			{
				return this._rowNumber; 
			}
			set
			{
				if (_rowNumber == value)
					return;
					
				this._rowNumber = value;
				this._isDirty = true;
				
				OnPropertyChanged("RowNumber");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the AdminId property. 
		///		
		/// </summary>
		/// <value>This type is bigint</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int64 AdminId
		{
			get
			{
				return this._adminId; 
			}
			set
			{
				if (_adminId == value)
					return;
					
				this._adminId = value;
				this._isDirty = true;
				
				OnPropertyChanged("AdminId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the ObjectId property. 
		///		
		/// </summary>
		/// <value>This type is bigint</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int64 ObjectId
		{
			get
			{
				return this._objectId; 
			}
			set
			{
				if (_objectId == value)
					return;
					
				this._objectId = value;
				this._isDirty = true;
				
				OnPropertyChanged("ObjectId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the ParentId property. 
		///		
		/// </summary>
		/// <value>This type is bigint</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int64 ParentId
		{
			get
			{
				return this._parentId; 
			}
			set
			{
				if (_parentId == value)
					return;
					
				this._parentId = value;
				this._isDirty = true;
				
				OnPropertyChanged("ParentId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the PlateCode property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String PlateCode
		{
			get
			{
				return this._plateCode; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "PlateCode does not allow null values.");
				if (_plateCode == value)
					return;
					
				this._plateCode = value;
				this._isDirty = true;
				
				OnPropertyChanged("PlateCode");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the AreaId property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 AreaId
		{
			get
			{
				return this._areaId; 
			}
			set
			{
				if (_areaId == value)
					return;
					
				this._areaId = value;
				this._isDirty = true;
				
				OnPropertyChanged("AreaId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the PhoneCode property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String PhoneCode
		{
			get
			{
				return this._phoneCode; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "PhoneCode does not allow null values.");
				if (_phoneCode == value)
					return;
					
				this._phoneCode = value;
				this._isDirty = true;
				
				OnPropertyChanged("PhoneCode");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the ProvinceName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String ProvinceName
		{
			get
			{
				return this._provinceName; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "ProvinceName does not allow null values.");
				if (_provinceName == value)
					return;
					
				this._provinceName = value;
				this._isDirty = true;
				
				OnPropertyChanged("ProvinceName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Longitude property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Longitude
		{
			get
			{
				return this._longitude; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "Longitude does not allow null values.");
				if (_longitude == value)
					return;
					
				this._longitude = value;
				this._isDirty = true;
				
				OnPropertyChanged("Longitude");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Latitude property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Latitude
		{
			get
			{
				return this._latitude; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "Latitude does not allow null values.");
				if (_latitude == value)
					return;
					
				this._latitude = value;
				this._isDirty = true;
				
				OnPropertyChanged("Latitude");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Type property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 Type
		{
			get
			{
				return this._type; 
			}
			set
			{
				if (_type == value)
					return;
					
				this._type = value;
				this._isDirty = true;
				
				OnPropertyChanged("Type");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CreateDate property. 
		///		
		/// </summary>
		/// <value>This type is date</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime CreateDate
		{
			get
			{
				return this._createDate; 
			}
			set
			{
				if (_createDate == value)
					return;
					
				this._createDate = value;
				this._isDirty = true;
				
				OnPropertyChanged("CreateDate");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CreateTime property. 
		///		
		/// </summary>
		/// <value>This type is time</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.TimeSpan CreateTime
		{
			get
			{
				return this._createTime; 
			}
			set
			{
				if (_createTime == value)
					return;
					
				this._createTime = value;
				this._isDirty = true;
				
				OnPropertyChanged("CreateTime");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the UpdateDate property. 
		///		
		/// </summary>
		/// <value>This type is date</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return DateTime.MinValue. It is up to the developer
		/// to check the value of IsUpdateDateNull() and perform business logic appropriately.
		/// </remarks>
		[DataMember]
		[XmlElement(IsNullable=true)]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime? UpdateDate
		{
			get
			{
				return this._updateDate; 
			}
			set
			{
				if (_updateDate == value && UpdateDate != null )
					return;
					
				this._updateDate = value;
				this._isDirty = true;
				
				OnPropertyChanged("UpdateDate");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the UpdateTime property. 
		///		
		/// </summary>
		/// <value>This type is time</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return new TimeSpan(1,0,0,0,0). It is up to the developer
		/// to check the value of IsUpdateTimeNull() and perform business logic appropriately.
		/// </remarks>
		[DataMember]
		[XmlElement(IsNullable=true)]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.TimeSpan? UpdateTime
		{
			get
			{
				return this._updateTime; 
			}
			set
			{
				if (_updateTime == value && UpdateTime != null )
					return;
					
				this._updateTime = value;
				this._isDirty = true;
				
				OnPropertyChanged("UpdateTime");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CreateUserId property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 CreateUserId
		{
			get
			{
				return this._createUserId; 
			}
			set
			{
				if (_createUserId == value)
					return;
					
				this._createUserId = value;
				this._isDirty = true;
				
				OnPropertyChanged("CreateUserId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the UpdateUserId property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsUpdateUserIdNull() and perform business logic appropriately.
		/// </remarks>
		[DataMember]
		[XmlElement(IsNullable=true)]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32? UpdateUserId
		{
			get
			{
				return this._updateUserId; 
			}
			set
			{
				if (_updateUserId == value && UpdateUserId != null )
					return;
					
				this._updateUserId = value;
				this._isDirty = true;
				
				OnPropertyChanged("UpdateUserId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Active property. 
		///		
		/// </summary>
		/// <value>This type is bit</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Boolean Active
		{
			get
			{
				return this._active; 
			}
			set
			{
				if (_active == value)
					return;
					
				this._active = value;
				this._isDirty = true;
				
				OnPropertyChanged("Active");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Deleted property. 
		///		
		/// </summary>
		/// <value>This type is bit</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DataMember]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Boolean Deleted
		{
			get
			{
				return this._deleted; 
			}
			set
			{
				if (_deleted == value)
					return;
					
				this._deleted = value;
				this._isDirty = true;
				
				OnPropertyChanged("Deleted");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the AreaName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DataMember]
		[XmlElement(IsNullable=true)]
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String AreaName
		{
			get
			{
				return this._areaName; 
			}
			set
			{
				if (_areaName == value)
					return;
					
				this._areaName = value;
				this._isDirty = true;
				
				OnPropertyChanged("AreaName");
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
			get { return "ProvinceView"; }
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
		///  Returns a Typed ProvinceViewBase Entity 
		///</summary>
		public virtual ProvinceViewBase Copy()
		{
			//shallow copy entity
			ProvinceView copy = new ProvinceView();
				copy.Id = this.Id;
				copy.RowNumber = this.RowNumber;
				copy.AdminId = this.AdminId;
				copy.ObjectId = this.ObjectId;
				copy.ParentId = this.ParentId;
				copy.PlateCode = this.PlateCode;
				copy.AreaId = this.AreaId;
				copy.PhoneCode = this.PhoneCode;
				copy.ProvinceName = this.ProvinceName;
				copy.Longitude = this.Longitude;
				copy.Latitude = this.Latitude;
				copy.Type = this.Type;
				copy.CreateDate = this.CreateDate;
				copy.CreateTime = this.CreateTime;
				copy.UpdateDate = this.UpdateDate;
				copy.UpdateTime = this.UpdateTime;
				copy.CreateUserId = this.CreateUserId;
				copy.UpdateUserId = this.UpdateUserId;
				copy.Active = this.Active;
				copy.Deleted = this.Deleted;
				copy.AreaName = this.AreaName;
			copy.AcceptChanges();
			return (ProvinceView)copy;
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
		///<returns>true if toObject is a <see cref="ProvinceViewBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ProvinceViewBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="ProvinceViewBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="ProvinceViewBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ProvinceViewBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(ProvinceViewBase Object1, ProvinceViewBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.Id != Object2.Id)
				equal = false;
			if (Object1.RowNumber != Object2.RowNumber)
				equal = false;
			if (Object1.AdminId != Object2.AdminId)
				equal = false;
			if (Object1.ObjectId != Object2.ObjectId)
				equal = false;
			if (Object1.ParentId != Object2.ParentId)
				equal = false;
			if (Object1.PlateCode != Object2.PlateCode)
				equal = false;
			if (Object1.AreaId != Object2.AreaId)
				equal = false;
			if (Object1.PhoneCode != Object2.PhoneCode)
				equal = false;
			if (Object1.ProvinceName != Object2.ProvinceName)
				equal = false;
			if (Object1.Longitude != Object2.Longitude)
				equal = false;
			if (Object1.Latitude != Object2.Latitude)
				equal = false;
			if (Object1.Type != Object2.Type)
				equal = false;
			if (Object1.CreateDate != Object2.CreateDate)
				equal = false;
			if (Object1.CreateTime != Object2.CreateTime)
				equal = false;
			if (Object1.UpdateDate != null && Object2.UpdateDate != null )
			{
				if (Object1.UpdateDate != Object2.UpdateDate)
					equal = false;
			}
			else if (Object1.UpdateDate == null ^ Object1.UpdateDate == null )
			{
				equal = false;
			}
			if (Object1.UpdateTime != null && Object2.UpdateTime != null )
			{
				if (Object1.UpdateTime != Object2.UpdateTime)
					equal = false;
			}
			else if (Object1.UpdateTime == null ^ Object1.UpdateTime == null )
			{
				equal = false;
			}
			if (Object1.CreateUserId != Object2.CreateUserId)
				equal = false;
			if (Object1.UpdateUserId != null && Object2.UpdateUserId != null )
			{
				if (Object1.UpdateUserId != Object2.UpdateUserId)
					equal = false;
			}
			else if (Object1.UpdateUserId == null ^ Object1.UpdateUserId == null )
			{
				equal = false;
			}
			if (Object1.Active != Object2.Active)
				equal = false;
			if (Object1.Deleted != Object2.Deleted)
				equal = false;
			if (Object1.AreaName != null && Object2.AreaName != null )
			{
				if (Object1.AreaName != Object2.AreaName)
					equal = false;
			}
			else if (Object1.AreaName == null ^ Object1.AreaName == null )
			{
				equal = false;
			}
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
		public static object GetPropertyValueByName(ProvinceView entity, string propertyName)
		{
			switch (propertyName)
			{
				case "Id":
					return entity.Id;
				case "RowNumber":
					return entity.RowNumber;
				case "AdminId":
					return entity.AdminId;
				case "ObjectId":
					return entity.ObjectId;
				case "ParentId":
					return entity.ParentId;
				case "PlateCode":
					return entity.PlateCode;
				case "AreaId":
					return entity.AreaId;
				case "PhoneCode":
					return entity.PhoneCode;
				case "ProvinceName":
					return entity.ProvinceName;
				case "Longitude":
					return entity.Longitude;
				case "Latitude":
					return entity.Latitude;
				case "Type":
					return entity.Type;
				case "CreateDate":
					return entity.CreateDate;
				case "CreateTime":
					return entity.CreateTime;
				case "UpdateDate":
					return entity.UpdateDate;
				case "UpdateTime":
					return entity.UpdateTime;
				case "CreateUserId":
					return entity.CreateUserId;
				case "UpdateUserId":
					return entity.UpdateUserId;
				case "Active":
					return entity.Active;
				case "Deleted":
					return entity.Deleted;
				case "AreaName":
					return entity.AreaName;
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
			return GetPropertyValueByName(this as ProvinceView, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{22}{21}- Id: {0}{21}- RowNumber: {1}{21}- AdminId: {2}{21}- ObjectId: {3}{21}- ParentId: {4}{21}- PlateCode: {5}{21}- AreaId: {6}{21}- PhoneCode: {7}{21}- ProvinceName: {8}{21}- Longitude: {9}{21}- Latitude: {10}{21}- Type: {11}{21}- CreateDate: {12}{21}- CreateTime: {13}{21}- UpdateDate: {14}{21}- UpdateTime: {15}{21}- CreateUserId: {16}{21}- UpdateUserId: {17}{21}- Active: {18}{21}- Deleted: {19}{21}- AreaName: {20}{21}", 
				this.Id,
				this.RowNumber,
				this.AdminId,
				this.ObjectId,
				this.ParentId,
				this.PlateCode,
				this.AreaId,
				this.PhoneCode,
				this.ProvinceName,
				this.Longitude,
				this.Latitude,
				this.Type,
				this.CreateDate,
				this.CreateTime,
				(this.UpdateDate == null) ? string.Empty : this.UpdateDate.ToString(),
			     
				(this.UpdateTime == null) ? string.Empty : this.UpdateTime.ToString(),
			     
				this.CreateUserId,
				(this.UpdateUserId == null) ? string.Empty : this.UpdateUserId.ToString(),
			     
				this.Active,
				this.Deleted,
				(this.AreaName == null) ? string.Empty : this.AreaName.ToString(),
			     
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the ProvinceView columns.
	/// </summary>
	[Serializable]
	public enum ProvinceViewColumn
	{
		/// <summary>
		/// Id : 
		/// </summary>
		[EnumTextValue("Id")]
		[ColumnEnum("Id", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		Id,
		/// <summary>
		/// RowNumber : 
		/// </summary>
		[EnumTextValue("RowNumber")]
		[ColumnEnum("RowNumber", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		RowNumber,
		/// <summary>
		/// AdminId : 
		/// </summary>
		[EnumTextValue("AdminId")]
		[ColumnEnum("AdminId", typeof(System.Int64), System.Data.DbType.Int64, false, false, false)]
		AdminId,
		/// <summary>
		/// ObjectId : 
		/// </summary>
		[EnumTextValue("ObjectId")]
		[ColumnEnum("ObjectId", typeof(System.Int64), System.Data.DbType.Int64, false, false, false)]
		ObjectId,
		/// <summary>
		/// ParentId : 
		/// </summary>
		[EnumTextValue("ParentId")]
		[ColumnEnum("ParentId", typeof(System.Int64), System.Data.DbType.Int64, false, false, false)]
		ParentId,
		/// <summary>
		/// PlateCode : 
		/// </summary>
		[EnumTextValue("PlateCode")]
		[ColumnEnum("PlateCode", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 2)]
		PlateCode,
		/// <summary>
		/// AreaId : 
		/// </summary>
		[EnumTextValue("AreaId")]
		[ColumnEnum("AreaId", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		AreaId,
		/// <summary>
		/// PhoneCode : 
		/// </summary>
		[EnumTextValue("PhoneCode")]
		[ColumnEnum("PhoneCode", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 3)]
		PhoneCode,
		/// <summary>
		/// ProvinceName : 
		/// </summary>
		[EnumTextValue("ProvinceName")]
		[ColumnEnum("ProvinceName", typeof(System.String), System.Data.DbType.String, false, false, false, 250)]
		ProvinceName,
		/// <summary>
		/// Longitude : 
		/// </summary>
		[EnumTextValue("Longitude")]
		[ColumnEnum("Longitude", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 10)]
		Longitude,
		/// <summary>
		/// Latitude : 
		/// </summary>
		[EnumTextValue("Latitude")]
		[ColumnEnum("Latitude", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 10)]
		Latitude,
		/// <summary>
		/// Type : 
		/// </summary>
		[EnumTextValue("Type")]
		[ColumnEnum("Type", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		Type,
		/// <summary>
		/// CreateDate : 
		/// </summary>
		[EnumTextValue("CreateDate")]
		[ColumnEnum("CreateDate", typeof(System.DateTime), System.Data.DbType.Date, false, false, false)]
		CreateDate,
		/// <summary>
		/// CreateTime : 
		/// </summary>
		[EnumTextValue("CreateTime")]
		[ColumnEnum("CreateTime", typeof(System.TimeSpan), System.Data.DbType.Time, false, false, false)]
		CreateTime,
		/// <summary>
		/// UpdateDate : 
		/// </summary>
		[EnumTextValue("UpdateDate")]
		[ColumnEnum("UpdateDate", typeof(System.DateTime), System.Data.DbType.Date, false, false, true)]
		UpdateDate,
		/// <summary>
		/// UpdateTime : 
		/// </summary>
		[EnumTextValue("UpdateTime")]
		[ColumnEnum("UpdateTime", typeof(System.TimeSpan), System.Data.DbType.Time, false, false, true)]
		UpdateTime,
		/// <summary>
		/// CreateUserId : 
		/// </summary>
		[EnumTextValue("CreateUserId")]
		[ColumnEnum("CreateUserId", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		CreateUserId,
		/// <summary>
		/// UpdateUserId : 
		/// </summary>
		[EnumTextValue("UpdateUserId")]
		[ColumnEnum("UpdateUserId", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		UpdateUserId,
		/// <summary>
		/// Active : 
		/// </summary>
		[EnumTextValue("Active")]
		[ColumnEnum("Active", typeof(System.Boolean), System.Data.DbType.Boolean, false, false, false)]
		Active,
		/// <summary>
		/// Deleted : 
		/// </summary>
		[EnumTextValue("Deleted")]
		[ColumnEnum("Deleted", typeof(System.Boolean), System.Data.DbType.Boolean, false, false, false)]
		Deleted,
		/// <summary>
		/// AreaName : 
		/// </summary>
		[EnumTextValue("AreaName")]
		[ColumnEnum("AreaName", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		AreaName
	}//End enum

} // end namespace
