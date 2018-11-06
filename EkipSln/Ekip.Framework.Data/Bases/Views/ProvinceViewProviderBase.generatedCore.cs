#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Ekip.Framework.Entities;
using Ekip.Framework.Data;

#endregion

namespace Ekip.Framework.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ProvinceViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ProvinceViewProviderBaseCore : EntityViewProviderBase<ProvinceView>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;ProvinceView&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ProvinceView&gt;"/></returns>
		protected static VList&lt;ProvinceView&gt; Fill(DataSet dataSet, VList<ProvinceView> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ProvinceView>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ProvinceView&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ProvinceView>"/></returns>
		protected static VList&lt;ProvinceView&gt; Fill(DataTable dataTable, VList<ProvinceView> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ProvinceView c = new ProvinceView();
					c.Id = (Convert.IsDBNull(row["Id"]))?(int)0:(System.Int32)row["Id"];
					c.RowNumber = (Convert.IsDBNull(row["RowNumber"]))?(int)0:(System.Int32)row["RowNumber"];
					c.AdminId = (Convert.IsDBNull(row["AdminId"]))?(long)0:(System.Int64)row["AdminId"];
					c.ObjectId = (Convert.IsDBNull(row["ObjectId"]))?(long)0:(System.Int64)row["ObjectId"];
					c.ParentId = (Convert.IsDBNull(row["ParentId"]))?(long)0:(System.Int64)row["ParentId"];
					c.PlateCode = (Convert.IsDBNull(row["PlateCode"]))?string.Empty:(System.String)row["PlateCode"];
					c.AreaId = (Convert.IsDBNull(row["AreaId"]))?(int)0:(System.Int32)row["AreaId"];
					c.PhoneCode = (Convert.IsDBNull(row["PhoneCode"]))?string.Empty:(System.String)row["PhoneCode"];
					c.ProvinceName = (Convert.IsDBNull(row["ProvinceName"]))?string.Empty:(System.String)row["ProvinceName"];
					c.Longitude = (Convert.IsDBNull(row["Longitude"]))?string.Empty:(System.String)row["Longitude"];
					c.Latitude = (Convert.IsDBNull(row["Latitude"]))?string.Empty:(System.String)row["Latitude"];
					c.Type = (Convert.IsDBNull(row["Type"]))?(int)0:(System.Int32)row["Type"];
					c.CreateDate = (Convert.IsDBNull(row["CreateDate"]))?DateTime.MinValue:(System.DateTime)row["CreateDate"];
					c.CreateTime = (Convert.IsDBNull(row["CreateTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan)row["CreateTime"];
					c.UpdateDate = (Convert.IsDBNull(row["UpdateDate"]))?DateTime.MinValue:(System.DateTime?)row["UpdateDate"];
					c.UpdateTime = (Convert.IsDBNull(row["UpdateTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)row["UpdateTime"];
					c.AreaName = (Convert.IsDBNull(row["AreaName"]))?string.Empty:(System.String)row["AreaName"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;ProvinceView&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ProvinceView&gt;"/></returns>
		protected VList<ProvinceView> Fill(IDataReader reader, VList<ProvinceView> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ProvinceView entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ProvinceView>("ProvinceView",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ProvinceView();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Id = (System.Int32)reader[((int)ProvinceViewColumn.Id)];
					//entity.Id = (Convert.IsDBNull(reader["Id"]))?(int)0:(System.Int32)reader["Id"];
					entity.RowNumber = (System.Int32)reader[((int)ProvinceViewColumn.RowNumber)];
					//entity.RowNumber = (Convert.IsDBNull(reader["RowNumber"]))?(int)0:(System.Int32)reader["RowNumber"];
					entity.AdminId = (System.Int64)reader[((int)ProvinceViewColumn.AdminId)];
					//entity.AdminId = (Convert.IsDBNull(reader["AdminId"]))?(long)0:(System.Int64)reader["AdminId"];
					entity.ObjectId = (System.Int64)reader[((int)ProvinceViewColumn.ObjectId)];
					//entity.ObjectId = (Convert.IsDBNull(reader["ObjectId"]))?(long)0:(System.Int64)reader["ObjectId"];
					entity.ParentId = (System.Int64)reader[((int)ProvinceViewColumn.ParentId)];
					//entity.ParentId = (Convert.IsDBNull(reader["ParentId"]))?(long)0:(System.Int64)reader["ParentId"];
					entity.PlateCode = (System.String)reader[((int)ProvinceViewColumn.PlateCode)];
					//entity.PlateCode = (Convert.IsDBNull(reader["PlateCode"]))?string.Empty:(System.String)reader["PlateCode"];
					entity.AreaId = (System.Int32)reader[((int)ProvinceViewColumn.AreaId)];
					//entity.AreaId = (Convert.IsDBNull(reader["AreaId"]))?(int)0:(System.Int32)reader["AreaId"];
					entity.PhoneCode = (System.String)reader[((int)ProvinceViewColumn.PhoneCode)];
					//entity.PhoneCode = (Convert.IsDBNull(reader["PhoneCode"]))?string.Empty:(System.String)reader["PhoneCode"];
					entity.ProvinceName = (System.String)reader[((int)ProvinceViewColumn.ProvinceName)];
					//entity.ProvinceName = (Convert.IsDBNull(reader["ProvinceName"]))?string.Empty:(System.String)reader["ProvinceName"];
					entity.Longitude = (System.String)reader[((int)ProvinceViewColumn.Longitude)];
					//entity.Longitude = (Convert.IsDBNull(reader["Longitude"]))?string.Empty:(System.String)reader["Longitude"];
					entity.Latitude = (System.String)reader[((int)ProvinceViewColumn.Latitude)];
					//entity.Latitude = (Convert.IsDBNull(reader["Latitude"]))?string.Empty:(System.String)reader["Latitude"];
					entity.Type = (System.Int32)reader[((int)ProvinceViewColumn.Type)];
					//entity.Type = (Convert.IsDBNull(reader["Type"]))?(int)0:(System.Int32)reader["Type"];
					entity.CreateDate = (System.DateTime)reader[((int)ProvinceViewColumn.CreateDate)];
					//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime)reader["CreateDate"];
					entity.CreateTime = (System.TimeSpan)reader[((int)ProvinceViewColumn.CreateTime)];
					//entity.CreateTime = (Convert.IsDBNull(reader["CreateTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan)reader["CreateTime"];
					entity.UpdateDate = (reader.IsDBNull(((int)ProvinceViewColumn.UpdateDate)))?null:(System.DateTime?)reader[((int)ProvinceViewColumn.UpdateDate)];
					//entity.UpdateDate = (Convert.IsDBNull(reader["UpdateDate"]))?DateTime.MinValue:(System.DateTime?)reader["UpdateDate"];
					entity.UpdateTime = (reader.IsDBNull(((int)ProvinceViewColumn.UpdateTime)))?null:(System.TimeSpan?)reader[((int)ProvinceViewColumn.UpdateTime)];
					//entity.UpdateTime = (Convert.IsDBNull(reader["UpdateTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)reader["UpdateTime"];
					entity.AreaName = (reader.IsDBNull(((int)ProvinceViewColumn.AreaName)))?null:(System.String)reader[((int)ProvinceViewColumn.AreaName)];
					//entity.AreaName = (Convert.IsDBNull(reader["AreaName"]))?string.Empty:(System.String)reader["AreaName"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="ProvinceView"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ProvinceView"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ProvinceView entity)
		{
			reader.Read();
			entity.Id = (System.Int32)reader[((int)ProvinceViewColumn.Id)];
			//entity.Id = (Convert.IsDBNull(reader["Id"]))?(int)0:(System.Int32)reader["Id"];
			entity.RowNumber = (System.Int32)reader[((int)ProvinceViewColumn.RowNumber)];
			//entity.RowNumber = (Convert.IsDBNull(reader["RowNumber"]))?(int)0:(System.Int32)reader["RowNumber"];
			entity.AdminId = (System.Int64)reader[((int)ProvinceViewColumn.AdminId)];
			//entity.AdminId = (Convert.IsDBNull(reader["AdminId"]))?(long)0:(System.Int64)reader["AdminId"];
			entity.ObjectId = (System.Int64)reader[((int)ProvinceViewColumn.ObjectId)];
			//entity.ObjectId = (Convert.IsDBNull(reader["ObjectId"]))?(long)0:(System.Int64)reader["ObjectId"];
			entity.ParentId = (System.Int64)reader[((int)ProvinceViewColumn.ParentId)];
			//entity.ParentId = (Convert.IsDBNull(reader["ParentId"]))?(long)0:(System.Int64)reader["ParentId"];
			entity.PlateCode = (System.String)reader[((int)ProvinceViewColumn.PlateCode)];
			//entity.PlateCode = (Convert.IsDBNull(reader["PlateCode"]))?string.Empty:(System.String)reader["PlateCode"];
			entity.AreaId = (System.Int32)reader[((int)ProvinceViewColumn.AreaId)];
			//entity.AreaId = (Convert.IsDBNull(reader["AreaId"]))?(int)0:(System.Int32)reader["AreaId"];
			entity.PhoneCode = (System.String)reader[((int)ProvinceViewColumn.PhoneCode)];
			//entity.PhoneCode = (Convert.IsDBNull(reader["PhoneCode"]))?string.Empty:(System.String)reader["PhoneCode"];
			entity.ProvinceName = (System.String)reader[((int)ProvinceViewColumn.ProvinceName)];
			//entity.ProvinceName = (Convert.IsDBNull(reader["ProvinceName"]))?string.Empty:(System.String)reader["ProvinceName"];
			entity.Longitude = (System.String)reader[((int)ProvinceViewColumn.Longitude)];
			//entity.Longitude = (Convert.IsDBNull(reader["Longitude"]))?string.Empty:(System.String)reader["Longitude"];
			entity.Latitude = (System.String)reader[((int)ProvinceViewColumn.Latitude)];
			//entity.Latitude = (Convert.IsDBNull(reader["Latitude"]))?string.Empty:(System.String)reader["Latitude"];
			entity.Type = (System.Int32)reader[((int)ProvinceViewColumn.Type)];
			//entity.Type = (Convert.IsDBNull(reader["Type"]))?(int)0:(System.Int32)reader["Type"];
			entity.CreateDate = (System.DateTime)reader[((int)ProvinceViewColumn.CreateDate)];
			//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime)reader["CreateDate"];
			entity.CreateTime = (System.TimeSpan)reader[((int)ProvinceViewColumn.CreateTime)];
			//entity.CreateTime = (Convert.IsDBNull(reader["CreateTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan)reader["CreateTime"];
			entity.UpdateDate = (reader.IsDBNull(((int)ProvinceViewColumn.UpdateDate)))?null:(System.DateTime?)reader[((int)ProvinceViewColumn.UpdateDate)];
			//entity.UpdateDate = (Convert.IsDBNull(reader["UpdateDate"]))?DateTime.MinValue:(System.DateTime?)reader["UpdateDate"];
			entity.UpdateTime = (reader.IsDBNull(((int)ProvinceViewColumn.UpdateTime)))?null:(System.TimeSpan?)reader[((int)ProvinceViewColumn.UpdateTime)];
			//entity.UpdateTime = (Convert.IsDBNull(reader["UpdateTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)reader["UpdateTime"];
			entity.AreaName = (reader.IsDBNull(((int)ProvinceViewColumn.AreaName)))?null:(System.String)reader[((int)ProvinceViewColumn.AreaName)];
			//entity.AreaName = (Convert.IsDBNull(reader["AreaName"]))?string.Empty:(System.String)reader["AreaName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ProvinceView"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ProvinceView"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ProvinceView entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (Convert.IsDBNull(dataRow["Id"]))?(int)0:(System.Int32)dataRow["Id"];
			entity.RowNumber = (Convert.IsDBNull(dataRow["RowNumber"]))?(int)0:(System.Int32)dataRow["RowNumber"];
			entity.AdminId = (Convert.IsDBNull(dataRow["AdminId"]))?(long)0:(System.Int64)dataRow["AdminId"];
			entity.ObjectId = (Convert.IsDBNull(dataRow["ObjectId"]))?(long)0:(System.Int64)dataRow["ObjectId"];
			entity.ParentId = (Convert.IsDBNull(dataRow["ParentId"]))?(long)0:(System.Int64)dataRow["ParentId"];
			entity.PlateCode = (Convert.IsDBNull(dataRow["PlateCode"]))?string.Empty:(System.String)dataRow["PlateCode"];
			entity.AreaId = (Convert.IsDBNull(dataRow["AreaId"]))?(int)0:(System.Int32)dataRow["AreaId"];
			entity.PhoneCode = (Convert.IsDBNull(dataRow["PhoneCode"]))?string.Empty:(System.String)dataRow["PhoneCode"];
			entity.ProvinceName = (Convert.IsDBNull(dataRow["ProvinceName"]))?string.Empty:(System.String)dataRow["ProvinceName"];
			entity.Longitude = (Convert.IsDBNull(dataRow["Longitude"]))?string.Empty:(System.String)dataRow["Longitude"];
			entity.Latitude = (Convert.IsDBNull(dataRow["Latitude"]))?string.Empty:(System.String)dataRow["Latitude"];
			entity.Type = (Convert.IsDBNull(dataRow["Type"]))?(int)0:(System.Int32)dataRow["Type"];
			entity.CreateDate = (Convert.IsDBNull(dataRow["CreateDate"]))?DateTime.MinValue:(System.DateTime)dataRow["CreateDate"];
			entity.CreateTime = (Convert.IsDBNull(dataRow["CreateTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan)dataRow["CreateTime"];
			entity.UpdateDate = (Convert.IsDBNull(dataRow["UpdateDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["UpdateDate"];
			entity.UpdateTime = (Convert.IsDBNull(dataRow["UpdateTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)dataRow["UpdateTime"];
			entity.AreaName = (Convert.IsDBNull(dataRow["AreaName"]))?string.Empty:(System.String)dataRow["AreaName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ProvinceViewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProvinceView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProvinceViewFilterBuilder : SqlFilterBuilder<ProvinceViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceViewFilterBuilder class.
		/// </summary>
		public ProvinceViewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProvinceViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProvinceViewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProvinceViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProvinceViewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProvinceViewFilterBuilder

	#region ProvinceViewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProvinceView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProvinceViewParameterBuilder : ParameterizedSqlFilterBuilder<ProvinceViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceViewParameterBuilder class.
		/// </summary>
		public ProvinceViewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProvinceViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProvinceViewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProvinceViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProvinceViewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProvinceViewParameterBuilder
	
	#region ProvinceViewSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProvinceView"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProvinceViewSortBuilder : SqlSortBuilder<ProvinceViewColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinceViewSqlSortBuilder class.
		/// </summary>
		public ProvinceViewSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProvinceViewSortBuilder

} // end namespace
