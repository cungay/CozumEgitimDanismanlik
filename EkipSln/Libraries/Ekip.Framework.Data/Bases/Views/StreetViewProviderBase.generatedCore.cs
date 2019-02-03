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
	/// This class is the base class for any <see cref="StreetViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class StreetViewProviderBaseCore : EntityViewProviderBase<StreetView>
	{
		#region Custom Methods
		
		
		#region StreetView_GetByNeighborhoodId
		
		/// <summary>
		///	This method wrap the 'StreetView_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;StreetView&gt;"/> instance.</returns>
		public VList<StreetView> GetByNeighborhoodId(System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(null, 0, int.MaxValue , neighborhoodId);
		}
		
		/// <summary>
		///	This method wrap the 'StreetView_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;StreetView&gt;"/> instance.</returns>
		public VList<StreetView> GetByNeighborhoodId(int start, int pageLength, System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(null, start, pageLength , neighborhoodId);
		}
				
		/// <summary>
		///	This method wrap the 'StreetView_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;StreetView&gt;"/> instance.</returns>
		public VList<StreetView> GetByNeighborhoodId(TransactionManager transactionManager, System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(transactionManager, 0, int.MaxValue , neighborhoodId);
		}
		
		/// <summary>
		///	This method wrap the 'StreetView_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;StreetView&gt;"/> instance.</returns>
		public abstract VList<StreetView> GetByNeighborhoodId(TransactionManager transactionManager, int start, int pageLength, System.Int32? neighborhoodId);
		
		#endregion

		
		#region StreetView_GetByStreetId
		
		/// <summary>
		///	This method wrap the 'StreetView_GetByStreetId' stored procedure. 
		/// </summary>
		/// <param name="streetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;StreetView&gt;"/> instance.</returns>
		public VList<StreetView> GetByStreetId(System.Int32? streetId)
		{
			return GetByStreetId(null, 0, int.MaxValue , streetId);
		}
		
		/// <summary>
		///	This method wrap the 'StreetView_GetByStreetId' stored procedure. 
		/// </summary>
		/// <param name="streetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;StreetView&gt;"/> instance.</returns>
		public VList<StreetView> GetByStreetId(int start, int pageLength, System.Int32? streetId)
		{
			return GetByStreetId(null, start, pageLength , streetId);
		}
				
		/// <summary>
		///	This method wrap the 'StreetView_GetByStreetId' stored procedure. 
		/// </summary>
		/// <param name="streetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;StreetView&gt;"/> instance.</returns>
		public VList<StreetView> GetByStreetId(TransactionManager transactionManager, System.Int32? streetId)
		{
			return GetByStreetId(transactionManager, 0, int.MaxValue , streetId);
		}
		
		/// <summary>
		///	This method wrap the 'StreetView_GetByStreetId' stored procedure. 
		/// </summary>
		/// <param name="streetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;StreetView&gt;"/> instance.</returns>
		public abstract VList<StreetView> GetByStreetId(TransactionManager transactionManager, int start, int pageLength, System.Int32? streetId);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;StreetView&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;StreetView&gt;"/></returns>
		protected static VList&lt;StreetView&gt; Fill(DataSet dataSet, VList<StreetView> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<StreetView>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;StreetView&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<StreetView>"/></returns>
		protected static VList&lt;StreetView&gt; Fill(DataTable dataTable, VList<StreetView> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					StreetView c = new StreetView();
					c.NeighborhoodId = (Convert.IsDBNull(row["NeighborhoodId"]))?(int)0:(System.Int32)row["NeighborhoodId"];
					c.NeighborhoodName = (Convert.IsDBNull(row["NeighborhoodName"]))?string.Empty:(System.String)row["NeighborhoodName"];
					c.StreetId = (Convert.IsDBNull(row["StreetId"]))?(int)0:(System.Int32)row["StreetId"];
					c.StreetName = (Convert.IsDBNull(row["StreetName"]))?string.Empty:(System.String)row["StreetName"];
					c.ZipCode = (Convert.IsDBNull(row["ZipCode"]))?string.Empty:(System.String)row["ZipCode"];
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
		/// Fill an <see cref="VList&lt;StreetView&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;StreetView&gt;"/></returns>
		protected VList<StreetView> Fill(IDataReader reader, VList<StreetView> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					StreetView entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<StreetView>("StreetView",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new StreetView();
					}
					
					entity.SuppressEntityEvents = true;

					entity.NeighborhoodId = (System.Int32)reader[((int)StreetViewColumn.NeighborhoodId)];
					//entity.NeighborhoodId = (Convert.IsDBNull(reader["NeighborhoodId"]))?(int)0:(System.Int32)reader["NeighborhoodId"];
					entity.NeighborhoodName = (System.String)reader[((int)StreetViewColumn.NeighborhoodName)];
					//entity.NeighborhoodName = (Convert.IsDBNull(reader["NeighborhoodName"]))?string.Empty:(System.String)reader["NeighborhoodName"];
					entity.StreetId = (System.Int32)reader[((int)StreetViewColumn.StreetId)];
					//entity.StreetId = (Convert.IsDBNull(reader["StreetId"]))?(int)0:(System.Int32)reader["StreetId"];
					entity.StreetName = (System.String)reader[((int)StreetViewColumn.StreetName)];
					//entity.StreetName = (Convert.IsDBNull(reader["StreetName"]))?string.Empty:(System.String)reader["StreetName"];
					entity.ZipCode = (System.String)reader[((int)StreetViewColumn.ZipCode)];
					//entity.ZipCode = (Convert.IsDBNull(reader["ZipCode"]))?string.Empty:(System.String)reader["ZipCode"];
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
		/// Refreshes the <see cref="StreetView"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="StreetView"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, StreetView entity)
		{
			reader.Read();
			entity.NeighborhoodId = (System.Int32)reader[((int)StreetViewColumn.NeighborhoodId)];
			//entity.NeighborhoodId = (Convert.IsDBNull(reader["NeighborhoodId"]))?(int)0:(System.Int32)reader["NeighborhoodId"];
			entity.NeighborhoodName = (System.String)reader[((int)StreetViewColumn.NeighborhoodName)];
			//entity.NeighborhoodName = (Convert.IsDBNull(reader["NeighborhoodName"]))?string.Empty:(System.String)reader["NeighborhoodName"];
			entity.StreetId = (System.Int32)reader[((int)StreetViewColumn.StreetId)];
			//entity.StreetId = (Convert.IsDBNull(reader["StreetId"]))?(int)0:(System.Int32)reader["StreetId"];
			entity.StreetName = (System.String)reader[((int)StreetViewColumn.StreetName)];
			//entity.StreetName = (Convert.IsDBNull(reader["StreetName"]))?string.Empty:(System.String)reader["StreetName"];
			entity.ZipCode = (System.String)reader[((int)StreetViewColumn.ZipCode)];
			//entity.ZipCode = (Convert.IsDBNull(reader["ZipCode"]))?string.Empty:(System.String)reader["ZipCode"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="StreetView"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="StreetView"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, StreetView entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NeighborhoodId = (Convert.IsDBNull(dataRow["NeighborhoodId"]))?(int)0:(System.Int32)dataRow["NeighborhoodId"];
			entity.NeighborhoodName = (Convert.IsDBNull(dataRow["NeighborhoodName"]))?string.Empty:(System.String)dataRow["NeighborhoodName"];
			entity.StreetId = (Convert.IsDBNull(dataRow["StreetId"]))?(int)0:(System.Int32)dataRow["StreetId"];
			entity.StreetName = (Convert.IsDBNull(dataRow["StreetName"]))?string.Empty:(System.String)dataRow["StreetName"];
			entity.ZipCode = (Convert.IsDBNull(dataRow["ZipCode"]))?string.Empty:(System.String)dataRow["ZipCode"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region StreetViewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StreetView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StreetViewFilterBuilder : SqlFilterBuilder<StreetViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StreetViewFilterBuilder class.
		/// </summary>
		public StreetViewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StreetViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StreetViewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StreetViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StreetViewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StreetViewFilterBuilder

	#region StreetViewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StreetView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StreetViewParameterBuilder : ParameterizedSqlFilterBuilder<StreetViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StreetViewParameterBuilder class.
		/// </summary>
		public StreetViewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StreetViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StreetViewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StreetViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StreetViewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StreetViewParameterBuilder
	
	#region StreetViewSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="StreetView"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class StreetViewSortBuilder : SqlSortBuilder<StreetViewColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StreetViewSqlSortBuilder class.
		/// </summary>
		public StreetViewSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion StreetViewSortBuilder

} // end namespace
