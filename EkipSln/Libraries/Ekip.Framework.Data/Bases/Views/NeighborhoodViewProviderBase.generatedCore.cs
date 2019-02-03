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
	/// This class is the base class for any <see cref="NeighborhoodViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class NeighborhoodViewProviderBaseCore : EntityViewProviderBase<NeighborhoodView>
	{
		#region Custom Methods
		
		
		#region NeighborhoodView_GetByNeighborhoodId
		
		/// <summary>
		///	This method wrap the 'NeighborhoodView_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;NeighborhoodView&gt;"/> instance.</returns>
		public VList<NeighborhoodView> GetByNeighborhoodId(System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(null, 0, int.MaxValue , neighborhoodId);
		}
		
		/// <summary>
		///	This method wrap the 'NeighborhoodView_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;NeighborhoodView&gt;"/> instance.</returns>
		public VList<NeighborhoodView> GetByNeighborhoodId(int start, int pageLength, System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(null, start, pageLength , neighborhoodId);
		}
				
		/// <summary>
		///	This method wrap the 'NeighborhoodView_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;NeighborhoodView&gt;"/> instance.</returns>
		public VList<NeighborhoodView> GetByNeighborhoodId(TransactionManager transactionManager, System.Int32? neighborhoodId)
		{
			return GetByNeighborhoodId(transactionManager, 0, int.MaxValue , neighborhoodId);
		}
		
		/// <summary>
		///	This method wrap the 'NeighborhoodView_GetByNeighborhoodId' stored procedure. 
		/// </summary>
		/// <param name="neighborhoodId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;NeighborhoodView&gt;"/> instance.</returns>
		public abstract VList<NeighborhoodView> GetByNeighborhoodId(TransactionManager transactionManager, int start, int pageLength, System.Int32? neighborhoodId);
		
		#endregion

		
		#region NeighborhoodView_GetByTownId
		
		/// <summary>
		///	This method wrap the 'NeighborhoodView_GetByTownId' stored procedure. 
		/// </summary>
		/// <param name="townId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;NeighborhoodView&gt;"/> instance.</returns>
		public VList<NeighborhoodView> GetByTownId(System.Int32? townId)
		{
			return GetByTownId(null, 0, int.MaxValue , townId);
		}
		
		/// <summary>
		///	This method wrap the 'NeighborhoodView_GetByTownId' stored procedure. 
		/// </summary>
		/// <param name="townId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;NeighborhoodView&gt;"/> instance.</returns>
		public VList<NeighborhoodView> GetByTownId(int start, int pageLength, System.Int32? townId)
		{
			return GetByTownId(null, start, pageLength , townId);
		}
				
		/// <summary>
		///	This method wrap the 'NeighborhoodView_GetByTownId' stored procedure. 
		/// </summary>
		/// <param name="townId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;NeighborhoodView&gt;"/> instance.</returns>
		public VList<NeighborhoodView> GetByTownId(TransactionManager transactionManager, System.Int32? townId)
		{
			return GetByTownId(transactionManager, 0, int.MaxValue , townId);
		}
		
		/// <summary>
		///	This method wrap the 'NeighborhoodView_GetByTownId' stored procedure. 
		/// </summary>
		/// <param name="townId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;NeighborhoodView&gt;"/> instance.</returns>
		public abstract VList<NeighborhoodView> GetByTownId(TransactionManager transactionManager, int start, int pageLength, System.Int32? townId);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;NeighborhoodView&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;NeighborhoodView&gt;"/></returns>
		protected static VList&lt;NeighborhoodView&gt; Fill(DataSet dataSet, VList<NeighborhoodView> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<NeighborhoodView>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;NeighborhoodView&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<NeighborhoodView>"/></returns>
		protected static VList&lt;NeighborhoodView&gt; Fill(DataTable dataTable, VList<NeighborhoodView> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					NeighborhoodView c = new NeighborhoodView();
					c.TownId = (Convert.IsDBNull(row["TownId"]))?(int)0:(System.Int32)row["TownId"];
					c.TownName = (Convert.IsDBNull(row["TownName"]))?string.Empty:(System.String)row["TownName"];
					c.NeighborhoodId = (Convert.IsDBNull(row["NeighborhoodId"]))?(int)0:(System.Int32)row["NeighborhoodId"];
					c.NeighborhoodName = (Convert.IsDBNull(row["NeighborhoodName"]))?string.Empty:(System.String)row["NeighborhoodName"];
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
		/// Fill an <see cref="VList&lt;NeighborhoodView&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;NeighborhoodView&gt;"/></returns>
		protected VList<NeighborhoodView> Fill(IDataReader reader, VList<NeighborhoodView> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					NeighborhoodView entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<NeighborhoodView>("NeighborhoodView",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new NeighborhoodView();
					}
					
					entity.SuppressEntityEvents = true;

					entity.TownId = (System.Int32)reader[((int)NeighborhoodViewColumn.TownId)];
					//entity.TownId = (Convert.IsDBNull(reader["TownId"]))?(int)0:(System.Int32)reader["TownId"];
					entity.TownName = (System.String)reader[((int)NeighborhoodViewColumn.TownName)];
					//entity.TownName = (Convert.IsDBNull(reader["TownName"]))?string.Empty:(System.String)reader["TownName"];
					entity.NeighborhoodId = (System.Int32)reader[((int)NeighborhoodViewColumn.NeighborhoodId)];
					//entity.NeighborhoodId = (Convert.IsDBNull(reader["NeighborhoodId"]))?(int)0:(System.Int32)reader["NeighborhoodId"];
					entity.NeighborhoodName = (System.String)reader[((int)NeighborhoodViewColumn.NeighborhoodName)];
					//entity.NeighborhoodName = (Convert.IsDBNull(reader["NeighborhoodName"]))?string.Empty:(System.String)reader["NeighborhoodName"];
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
		/// Refreshes the <see cref="NeighborhoodView"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NeighborhoodView"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, NeighborhoodView entity)
		{
			reader.Read();
			entity.TownId = (System.Int32)reader[((int)NeighborhoodViewColumn.TownId)];
			//entity.TownId = (Convert.IsDBNull(reader["TownId"]))?(int)0:(System.Int32)reader["TownId"];
			entity.TownName = (System.String)reader[((int)NeighborhoodViewColumn.TownName)];
			//entity.TownName = (Convert.IsDBNull(reader["TownName"]))?string.Empty:(System.String)reader["TownName"];
			entity.NeighborhoodId = (System.Int32)reader[((int)NeighborhoodViewColumn.NeighborhoodId)];
			//entity.NeighborhoodId = (Convert.IsDBNull(reader["NeighborhoodId"]))?(int)0:(System.Int32)reader["NeighborhoodId"];
			entity.NeighborhoodName = (System.String)reader[((int)NeighborhoodViewColumn.NeighborhoodName)];
			//entity.NeighborhoodName = (Convert.IsDBNull(reader["NeighborhoodName"]))?string.Empty:(System.String)reader["NeighborhoodName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="NeighborhoodView"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NeighborhoodView"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, NeighborhoodView entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TownId = (Convert.IsDBNull(dataRow["TownId"]))?(int)0:(System.Int32)dataRow["TownId"];
			entity.TownName = (Convert.IsDBNull(dataRow["TownName"]))?string.Empty:(System.String)dataRow["TownName"];
			entity.NeighborhoodId = (Convert.IsDBNull(dataRow["NeighborhoodId"]))?(int)0:(System.Int32)dataRow["NeighborhoodId"];
			entity.NeighborhoodName = (Convert.IsDBNull(dataRow["NeighborhoodName"]))?string.Empty:(System.String)dataRow["NeighborhoodName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region NeighborhoodViewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NeighborhoodView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NeighborhoodViewFilterBuilder : SqlFilterBuilder<NeighborhoodViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NeighborhoodViewFilterBuilder class.
		/// </summary>
		public NeighborhoodViewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NeighborhoodViewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NeighborhoodViewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NeighborhoodViewFilterBuilder

	#region NeighborhoodViewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NeighborhoodView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NeighborhoodViewParameterBuilder : ParameterizedSqlFilterBuilder<NeighborhoodViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NeighborhoodViewParameterBuilder class.
		/// </summary>
		public NeighborhoodViewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NeighborhoodViewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NeighborhoodViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NeighborhoodViewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NeighborhoodViewParameterBuilder
	
	#region NeighborhoodViewSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NeighborhoodView"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class NeighborhoodViewSortBuilder : SqlSortBuilder<NeighborhoodViewColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NeighborhoodViewSqlSortBuilder class.
		/// </summary>
		public NeighborhoodViewSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion NeighborhoodViewSortBuilder

} // end namespace
