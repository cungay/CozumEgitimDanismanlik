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
	/// This class is the base class for any <see cref="WiscrViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class WiscrViewProviderBaseCore : EntityViewProviderBase<WiscrView>
	{
		#region Custom Methods
		
		
		#region WiscrView_GetByClientID
		
		/// <summary>
		///	This method wrap the 'WiscrView_GetByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;WiscrView&gt;"/> instance.</returns>
		public VList<WiscrView> GetByClientID(System.Int32? clientId)
		{
			return GetByClientID(null, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'WiscrView_GetByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;WiscrView&gt;"/> instance.</returns>
		public VList<WiscrView> GetByClientID(int start, int pageLength, System.Int32? clientId)
		{
			return GetByClientID(null, start, pageLength , clientId);
		}
				
		/// <summary>
		///	This method wrap the 'WiscrView_GetByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;WiscrView&gt;"/> instance.</returns>
		public VList<WiscrView> GetByClientID(TransactionManager transactionManager, System.Int32? clientId)
		{
			return GetByClientID(transactionManager, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'WiscrView_GetByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;WiscrView&gt;"/> instance.</returns>
		public abstract VList<WiscrView> GetByClientID(TransactionManager transactionManager, int start, int pageLength, System.Int32? clientId);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;WiscrView&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;WiscrView&gt;"/></returns>
		protected static VList&lt;WiscrView&gt; Fill(DataSet dataSet, VList<WiscrView> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<WiscrView>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;WiscrView&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<WiscrView>"/></returns>
		protected static VList&lt;WiscrView&gt; Fill(DataTable dataTable, VList<WiscrView> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					WiscrView c = new WiscrView();
					c.SeanceId = (Convert.IsDBNull(row["SeanceID"]))?(int)0:(System.Int32)row["SeanceID"];
					c.ClientId = (Convert.IsDBNull(row["ClientID"]))?(int)0:(System.Int32)row["ClientID"];
					c.CreateDate = (Convert.IsDBNull(row["CreateDate"]))?DateTime.MinValue:(System.DateTime?)row["CreateDate"];
					c.SeanceDate = (Convert.IsDBNull(row["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)row["SeanceDate"];
					c.SeanceTime = (Convert.IsDBNull(row["SeanceTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)row["SeanceTime"];
					c.SeanceStatusId = (Convert.IsDBNull(row["SeanceStatusId"]))?(byte)0:(System.Byte)row["SeanceStatusId"];
					c.SeanceAdvisorId = (Convert.IsDBNull(row["SeanceAdvisorID"]))?(int)0:(System.Int32)row["SeanceAdvisorID"];
					c.SeanceAdvisorName = (Convert.IsDBNull(row["SeanceAdvisorName"]))?string.Empty:(System.String)row["SeanceAdvisorName"];
					c.TestDate = (Convert.IsDBNull(row["TestDate"]))?DateTime.MinValue:(System.DateTime?)row["TestDate"];
					c.TestAdvisorId = (Convert.IsDBNull(row["TestAdvisorID"]))?(int)0:(System.Int32?)row["TestAdvisorID"];
					c.TestAdvisorName = (Convert.IsDBNull(row["TestAdvisorName"]))?string.Empty:(System.String)row["TestAdvisorName"];
					c.TotalVerbalScore = (Convert.IsDBNull(row["TotalVerbalScore"]))?(int)0:(System.Int32?)row["TotalVerbalScore"];
					c.TotalPerformanceScore = (Convert.IsDBNull(row["TotalPerformanceScore"]))?(int)0:(System.Int32?)row["TotalPerformanceScore"];
					c.TotalScore = (Convert.IsDBNull(row["TotalScore"]))?(int)0:(System.Int32?)row["TotalScore"];
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
		/// Fill an <see cref="VList&lt;WiscrView&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;WiscrView&gt;"/></returns>
		protected VList<WiscrView> Fill(IDataReader reader, VList<WiscrView> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					WiscrView entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<WiscrView>("WiscrView",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new WiscrView();
					}
					
					entity.SuppressEntityEvents = true;

					entity.SeanceId = (System.Int32)reader[((int)WiscrViewColumn.SeanceId)];
					//entity.SeanceId = (Convert.IsDBNull(reader["SeanceID"]))?(int)0:(System.Int32)reader["SeanceID"];
					entity.ClientId = (System.Int32)reader[((int)WiscrViewColumn.ClientId)];
					//entity.ClientId = (Convert.IsDBNull(reader["ClientID"]))?(int)0:(System.Int32)reader["ClientID"];
					entity.CreateDate = (reader.IsDBNull(((int)WiscrViewColumn.CreateDate)))?null:(System.DateTime?)reader[((int)WiscrViewColumn.CreateDate)];
					//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreateDate"];
					entity.SeanceDate = (reader.IsDBNull(((int)WiscrViewColumn.SeanceDate)))?null:(System.DateTime?)reader[((int)WiscrViewColumn.SeanceDate)];
					//entity.SeanceDate = (Convert.IsDBNull(reader["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)reader["SeanceDate"];
					entity.SeanceTime = (reader.IsDBNull(((int)WiscrViewColumn.SeanceTime)))?null:(System.TimeSpan?)reader[((int)WiscrViewColumn.SeanceTime)];
					//entity.SeanceTime = (Convert.IsDBNull(reader["SeanceTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)reader["SeanceTime"];
					entity.SeanceStatusId = (System.Byte)reader[((int)WiscrViewColumn.SeanceStatusId)];
					//entity.SeanceStatusId = (Convert.IsDBNull(reader["SeanceStatusId"]))?(byte)0:(System.Byte)reader["SeanceStatusId"];
					entity.SeanceAdvisorId = (System.Int32)reader[((int)WiscrViewColumn.SeanceAdvisorId)];
					//entity.SeanceAdvisorId = (Convert.IsDBNull(reader["SeanceAdvisorID"]))?(int)0:(System.Int32)reader["SeanceAdvisorID"];
					entity.SeanceAdvisorName = (reader.IsDBNull(((int)WiscrViewColumn.SeanceAdvisorName)))?null:(System.String)reader[((int)WiscrViewColumn.SeanceAdvisorName)];
					//entity.SeanceAdvisorName = (Convert.IsDBNull(reader["SeanceAdvisorName"]))?string.Empty:(System.String)reader["SeanceAdvisorName"];
					entity.TestDate = (reader.IsDBNull(((int)WiscrViewColumn.TestDate)))?null:(System.DateTime?)reader[((int)WiscrViewColumn.TestDate)];
					//entity.TestDate = (Convert.IsDBNull(reader["TestDate"]))?DateTime.MinValue:(System.DateTime?)reader["TestDate"];
					entity.TestAdvisorId = (reader.IsDBNull(((int)WiscrViewColumn.TestAdvisorId)))?null:(System.Int32?)reader[((int)WiscrViewColumn.TestAdvisorId)];
					//entity.TestAdvisorId = (Convert.IsDBNull(reader["TestAdvisorID"]))?(int)0:(System.Int32?)reader["TestAdvisorID"];
					entity.TestAdvisorName = (reader.IsDBNull(((int)WiscrViewColumn.TestAdvisorName)))?null:(System.String)reader[((int)WiscrViewColumn.TestAdvisorName)];
					//entity.TestAdvisorName = (Convert.IsDBNull(reader["TestAdvisorName"]))?string.Empty:(System.String)reader["TestAdvisorName"];
					entity.TotalVerbalScore = (reader.IsDBNull(((int)WiscrViewColumn.TotalVerbalScore)))?null:(System.Int32?)reader[((int)WiscrViewColumn.TotalVerbalScore)];
					//entity.TotalVerbalScore = (Convert.IsDBNull(reader["TotalVerbalScore"]))?(int)0:(System.Int32?)reader["TotalVerbalScore"];
					entity.TotalPerformanceScore = (reader.IsDBNull(((int)WiscrViewColumn.TotalPerformanceScore)))?null:(System.Int32?)reader[((int)WiscrViewColumn.TotalPerformanceScore)];
					//entity.TotalPerformanceScore = (Convert.IsDBNull(reader["TotalPerformanceScore"]))?(int)0:(System.Int32?)reader["TotalPerformanceScore"];
					entity.TotalScore = (reader.IsDBNull(((int)WiscrViewColumn.TotalScore)))?null:(System.Int32?)reader[((int)WiscrViewColumn.TotalScore)];
					//entity.TotalScore = (Convert.IsDBNull(reader["TotalScore"]))?(int)0:(System.Int32?)reader["TotalScore"];
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
		/// Refreshes the <see cref="WiscrView"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="WiscrView"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, WiscrView entity)
		{
			reader.Read();
			entity.SeanceId = (System.Int32)reader[((int)WiscrViewColumn.SeanceId)];
			//entity.SeanceId = (Convert.IsDBNull(reader["SeanceID"]))?(int)0:(System.Int32)reader["SeanceID"];
			entity.ClientId = (System.Int32)reader[((int)WiscrViewColumn.ClientId)];
			//entity.ClientId = (Convert.IsDBNull(reader["ClientID"]))?(int)0:(System.Int32)reader["ClientID"];
			entity.CreateDate = (reader.IsDBNull(((int)WiscrViewColumn.CreateDate)))?null:(System.DateTime?)reader[((int)WiscrViewColumn.CreateDate)];
			//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreateDate"];
			entity.SeanceDate = (reader.IsDBNull(((int)WiscrViewColumn.SeanceDate)))?null:(System.DateTime?)reader[((int)WiscrViewColumn.SeanceDate)];
			//entity.SeanceDate = (Convert.IsDBNull(reader["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)reader["SeanceDate"];
			entity.SeanceTime = (reader.IsDBNull(((int)WiscrViewColumn.SeanceTime)))?null:(System.TimeSpan?)reader[((int)WiscrViewColumn.SeanceTime)];
			//entity.SeanceTime = (Convert.IsDBNull(reader["SeanceTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)reader["SeanceTime"];
			entity.SeanceStatusId = (System.Byte)reader[((int)WiscrViewColumn.SeanceStatusId)];
			//entity.SeanceStatusId = (Convert.IsDBNull(reader["SeanceStatusId"]))?(byte)0:(System.Byte)reader["SeanceStatusId"];
			entity.SeanceAdvisorId = (System.Int32)reader[((int)WiscrViewColumn.SeanceAdvisorId)];
			//entity.SeanceAdvisorId = (Convert.IsDBNull(reader["SeanceAdvisorID"]))?(int)0:(System.Int32)reader["SeanceAdvisorID"];
			entity.SeanceAdvisorName = (reader.IsDBNull(((int)WiscrViewColumn.SeanceAdvisorName)))?null:(System.String)reader[((int)WiscrViewColumn.SeanceAdvisorName)];
			//entity.SeanceAdvisorName = (Convert.IsDBNull(reader["SeanceAdvisorName"]))?string.Empty:(System.String)reader["SeanceAdvisorName"];
			entity.TestDate = (reader.IsDBNull(((int)WiscrViewColumn.TestDate)))?null:(System.DateTime?)reader[((int)WiscrViewColumn.TestDate)];
			//entity.TestDate = (Convert.IsDBNull(reader["TestDate"]))?DateTime.MinValue:(System.DateTime?)reader["TestDate"];
			entity.TestAdvisorId = (reader.IsDBNull(((int)WiscrViewColumn.TestAdvisorId)))?null:(System.Int32?)reader[((int)WiscrViewColumn.TestAdvisorId)];
			//entity.TestAdvisorId = (Convert.IsDBNull(reader["TestAdvisorID"]))?(int)0:(System.Int32?)reader["TestAdvisorID"];
			entity.TestAdvisorName = (reader.IsDBNull(((int)WiscrViewColumn.TestAdvisorName)))?null:(System.String)reader[((int)WiscrViewColumn.TestAdvisorName)];
			//entity.TestAdvisorName = (Convert.IsDBNull(reader["TestAdvisorName"]))?string.Empty:(System.String)reader["TestAdvisorName"];
			entity.TotalVerbalScore = (reader.IsDBNull(((int)WiscrViewColumn.TotalVerbalScore)))?null:(System.Int32?)reader[((int)WiscrViewColumn.TotalVerbalScore)];
			//entity.TotalVerbalScore = (Convert.IsDBNull(reader["TotalVerbalScore"]))?(int)0:(System.Int32?)reader["TotalVerbalScore"];
			entity.TotalPerformanceScore = (reader.IsDBNull(((int)WiscrViewColumn.TotalPerformanceScore)))?null:(System.Int32?)reader[((int)WiscrViewColumn.TotalPerformanceScore)];
			//entity.TotalPerformanceScore = (Convert.IsDBNull(reader["TotalPerformanceScore"]))?(int)0:(System.Int32?)reader["TotalPerformanceScore"];
			entity.TotalScore = (reader.IsDBNull(((int)WiscrViewColumn.TotalScore)))?null:(System.Int32?)reader[((int)WiscrViewColumn.TotalScore)];
			//entity.TotalScore = (Convert.IsDBNull(reader["TotalScore"]))?(int)0:(System.Int32?)reader["TotalScore"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="WiscrView"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="WiscrView"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, WiscrView entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SeanceId = (Convert.IsDBNull(dataRow["SeanceID"]))?(int)0:(System.Int32)dataRow["SeanceID"];
			entity.ClientId = (Convert.IsDBNull(dataRow["ClientID"]))?(int)0:(System.Int32)dataRow["ClientID"];
			entity.CreateDate = (Convert.IsDBNull(dataRow["CreateDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["CreateDate"];
			entity.SeanceDate = (Convert.IsDBNull(dataRow["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["SeanceDate"];
			entity.SeanceTime = (Convert.IsDBNull(dataRow["SeanceTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)dataRow["SeanceTime"];
			entity.SeanceStatusId = (Convert.IsDBNull(dataRow["SeanceStatusId"]))?(byte)0:(System.Byte)dataRow["SeanceStatusId"];
			entity.SeanceAdvisorId = (Convert.IsDBNull(dataRow["SeanceAdvisorID"]))?(int)0:(System.Int32)dataRow["SeanceAdvisorID"];
			entity.SeanceAdvisorName = (Convert.IsDBNull(dataRow["SeanceAdvisorName"]))?string.Empty:(System.String)dataRow["SeanceAdvisorName"];
			entity.TestDate = (Convert.IsDBNull(dataRow["TestDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["TestDate"];
			entity.TestAdvisorId = (Convert.IsDBNull(dataRow["TestAdvisorID"]))?(int)0:(System.Int32?)dataRow["TestAdvisorID"];
			entity.TestAdvisorName = (Convert.IsDBNull(dataRow["TestAdvisorName"]))?string.Empty:(System.String)dataRow["TestAdvisorName"];
			entity.TotalVerbalScore = (Convert.IsDBNull(dataRow["TotalVerbalScore"]))?(int)0:(System.Int32?)dataRow["TotalVerbalScore"];
			entity.TotalPerformanceScore = (Convert.IsDBNull(dataRow["TotalPerformanceScore"]))?(int)0:(System.Int32?)dataRow["TotalPerformanceScore"];
			entity.TotalScore = (Convert.IsDBNull(dataRow["TotalScore"]))?(int)0:(System.Int32?)dataRow["TotalScore"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region WiscrViewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WiscrView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WiscrViewFilterBuilder : SqlFilterBuilder<WiscrViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WiscrViewFilterBuilder class.
		/// </summary>
		public WiscrViewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WiscrViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WiscrViewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WiscrViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WiscrViewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WiscrViewFilterBuilder

	#region WiscrViewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WiscrView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WiscrViewParameterBuilder : ParameterizedSqlFilterBuilder<WiscrViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WiscrViewParameterBuilder class.
		/// </summary>
		public WiscrViewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WiscrViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WiscrViewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WiscrViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WiscrViewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WiscrViewParameterBuilder
	
	#region WiscrViewSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WiscrView"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WiscrViewSortBuilder : SqlSortBuilder<WiscrViewColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WiscrViewSqlSortBuilder class.
		/// </summary>
		public WiscrViewSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WiscrViewSortBuilder

} // end namespace
