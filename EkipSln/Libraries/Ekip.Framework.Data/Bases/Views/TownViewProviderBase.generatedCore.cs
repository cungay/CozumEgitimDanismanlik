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
	/// This class is the base class for any <see cref="TownViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class TownViewProviderBaseCore : EntityViewProviderBase<TownView>
	{
		#region Custom Methods
		
		
		#region TownView_GetByProvinceId
		
		/// <summary>
		///	This method wrap the 'TownView_GetByProvinceId' stored procedure. 
		/// </summary>
		/// <param name="provinceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;TownView&gt;"/> instance.</returns>
		public VList<TownView> GetByProvinceId(System.Int32? provinceId)
		{
			return GetByProvinceId(null, 0, int.MaxValue , provinceId);
		}
		
		/// <summary>
		///	This method wrap the 'TownView_GetByProvinceId' stored procedure. 
		/// </summary>
		/// <param name="provinceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;TownView&gt;"/> instance.</returns>
		public VList<TownView> GetByProvinceId(int start, int pageLength, System.Int32? provinceId)
		{
			return GetByProvinceId(null, start, pageLength , provinceId);
		}
				
		/// <summary>
		///	This method wrap the 'TownView_GetByProvinceId' stored procedure. 
		/// </summary>
		/// <param name="provinceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;TownView&gt;"/> instance.</returns>
		public VList<TownView> GetByProvinceId(TransactionManager transactionManager, System.Int32? provinceId)
		{
			return GetByProvinceId(transactionManager, 0, int.MaxValue , provinceId);
		}
		
		/// <summary>
		///	This method wrap the 'TownView_GetByProvinceId' stored procedure. 
		/// </summary>
		/// <param name="provinceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;TownView&gt;"/> instance.</returns>
		public abstract VList<TownView> GetByProvinceId(TransactionManager transactionManager, int start, int pageLength, System.Int32? provinceId);
		
		#endregion

		
		#region TownView_GetByTownId
		
		/// <summary>
		///	This method wrap the 'TownView_GetByTownId' stored procedure. 
		/// </summary>
		/// <param name="townId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;TownView&gt;"/> instance.</returns>
		public VList<TownView> GetByTownId(System.Int32? townId)
		{
			return GetByTownId(null, 0, int.MaxValue , townId);
		}
		
		/// <summary>
		///	This method wrap the 'TownView_GetByTownId' stored procedure. 
		/// </summary>
		/// <param name="townId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;TownView&gt;"/> instance.</returns>
		public VList<TownView> GetByTownId(int start, int pageLength, System.Int32? townId)
		{
			return GetByTownId(null, start, pageLength , townId);
		}
				
		/// <summary>
		///	This method wrap the 'TownView_GetByTownId' stored procedure. 
		/// </summary>
		/// <param name="townId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;TownView&gt;"/> instance.</returns>
		public VList<TownView> GetByTownId(TransactionManager transactionManager, System.Int32? townId)
		{
			return GetByTownId(transactionManager, 0, int.MaxValue , townId);
		}
		
		/// <summary>
		///	This method wrap the 'TownView_GetByTownId' stored procedure. 
		/// </summary>
		/// <param name="townId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;TownView&gt;"/> instance.</returns>
		public abstract VList<TownView> GetByTownId(TransactionManager transactionManager, int start, int pageLength, System.Int32? townId);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;TownView&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;TownView&gt;"/></returns>
		protected static VList&lt;TownView&gt; Fill(DataSet dataSet, VList<TownView> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<TownView>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;TownView&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<TownView>"/></returns>
		protected static VList&lt;TownView&gt; Fill(DataTable dataTable, VList<TownView> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					TownView c = new TownView();
					c.ProvinceId = (Convert.IsDBNull(row["ProvinceId"]))?(int)0:(System.Int32)row["ProvinceId"];
					c.ProvinceName = (Convert.IsDBNull(row["ProvinceName"]))?string.Empty:(System.String)row["ProvinceName"];
					c.TownId = (Convert.IsDBNull(row["TownId"]))?(int)0:(System.Int32)row["TownId"];
					c.TownName = (Convert.IsDBNull(row["TownName"]))?string.Empty:(System.String)row["TownName"];
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
		/// Fill an <see cref="VList&lt;TownView&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;TownView&gt;"/></returns>
		protected VList<TownView> Fill(IDataReader reader, VList<TownView> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					TownView entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<TownView>("TownView",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new TownView();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProvinceId = (System.Int32)reader[((int)TownViewColumn.ProvinceId)];
					//entity.ProvinceId = (Convert.IsDBNull(reader["ProvinceId"]))?(int)0:(System.Int32)reader["ProvinceId"];
					entity.ProvinceName = (System.String)reader[((int)TownViewColumn.ProvinceName)];
					//entity.ProvinceName = (Convert.IsDBNull(reader["ProvinceName"]))?string.Empty:(System.String)reader["ProvinceName"];
					entity.TownId = (System.Int32)reader[((int)TownViewColumn.TownId)];
					//entity.TownId = (Convert.IsDBNull(reader["TownId"]))?(int)0:(System.Int32)reader["TownId"];
					entity.TownName = (System.String)reader[((int)TownViewColumn.TownName)];
					//entity.TownName = (Convert.IsDBNull(reader["TownName"]))?string.Empty:(System.String)reader["TownName"];
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
		/// Refreshes the <see cref="TownView"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="TownView"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, TownView entity)
		{
			reader.Read();
			entity.ProvinceId = (System.Int32)reader[((int)TownViewColumn.ProvinceId)];
			//entity.ProvinceId = (Convert.IsDBNull(reader["ProvinceId"]))?(int)0:(System.Int32)reader["ProvinceId"];
			entity.ProvinceName = (System.String)reader[((int)TownViewColumn.ProvinceName)];
			//entity.ProvinceName = (Convert.IsDBNull(reader["ProvinceName"]))?string.Empty:(System.String)reader["ProvinceName"];
			entity.TownId = (System.Int32)reader[((int)TownViewColumn.TownId)];
			//entity.TownId = (Convert.IsDBNull(reader["TownId"]))?(int)0:(System.Int32)reader["TownId"];
			entity.TownName = (System.String)reader[((int)TownViewColumn.TownName)];
			//entity.TownName = (Convert.IsDBNull(reader["TownName"]))?string.Empty:(System.String)reader["TownName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="TownView"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="TownView"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, TownView entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProvinceId = (Convert.IsDBNull(dataRow["ProvinceId"]))?(int)0:(System.Int32)dataRow["ProvinceId"];
			entity.ProvinceName = (Convert.IsDBNull(dataRow["ProvinceName"]))?string.Empty:(System.String)dataRow["ProvinceName"];
			entity.TownId = (Convert.IsDBNull(dataRow["TownId"]))?(int)0:(System.Int32)dataRow["TownId"];
			entity.TownName = (Convert.IsDBNull(dataRow["TownName"]))?string.Empty:(System.String)dataRow["TownName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region TownViewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TownView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TownViewFilterBuilder : SqlFilterBuilder<TownViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TownViewFilterBuilder class.
		/// </summary>
		public TownViewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TownViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TownViewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TownViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TownViewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TownViewFilterBuilder

	#region TownViewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TownView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TownViewParameterBuilder : ParameterizedSqlFilterBuilder<TownViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TownViewParameterBuilder class.
		/// </summary>
		public TownViewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TownViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TownViewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TownViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TownViewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TownViewParameterBuilder
	
	#region TownViewSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TownView"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TownViewSortBuilder : SqlSortBuilder<TownViewColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TownViewSqlSortBuilder class.
		/// </summary>
		public TownViewSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TownViewSortBuilder

} // end namespace
