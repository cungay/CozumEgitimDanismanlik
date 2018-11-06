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
	/// This class is the base class for any <see cref="WippsiViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class WippsiViewProviderBaseCore : EntityViewProviderBase<WippsiView>
	{
		#region Custom Methods
		
		
		#region WippsiView_GetByClientID
		
		/// <summary>
		///	This method wrap the 'WippsiView_GetByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;WippsiView&gt;"/> instance.</returns>
		public VList<WippsiView> GetByClientID(System.Int32? clientId)
		{
			return GetByClientID(null, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'WippsiView_GetByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;WippsiView&gt;"/> instance.</returns>
		public VList<WippsiView> GetByClientID(int start, int pageLength, System.Int32? clientId)
		{
			return GetByClientID(null, start, pageLength , clientId);
		}
				
		/// <summary>
		///	This method wrap the 'WippsiView_GetByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;WippsiView&gt;"/> instance.</returns>
		public VList<WippsiView> GetByClientID(TransactionManager transactionManager, System.Int32? clientId)
		{
			return GetByClientID(transactionManager, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'WippsiView_GetByClientID' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;WippsiView&gt;"/> instance.</returns>
		public abstract VList<WippsiView> GetByClientID(TransactionManager transactionManager, int start, int pageLength, System.Int32? clientId);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;WippsiView&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;WippsiView&gt;"/></returns>
		protected static VList&lt;WippsiView&gt; Fill(DataSet dataSet, VList<WippsiView> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<WippsiView>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;WippsiView&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<WippsiView>"/></returns>
		protected static VList&lt;WippsiView&gt; Fill(DataTable dataTable, VList<WippsiView> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					WippsiView c = new WippsiView();
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
		/// Fill an <see cref="VList&lt;WippsiView&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;WippsiView&gt;"/></returns>
		protected VList<WippsiView> Fill(IDataReader reader, VList<WippsiView> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					WippsiView entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<WippsiView>("WippsiView",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new WippsiView();
					}
					
					entity.SuppressEntityEvents = true;

					entity.SeanceId = (System.Int32)reader[((int)WippsiViewColumn.SeanceId)];
					//entity.SeanceId = (Convert.IsDBNull(reader["SeanceID"]))?(int)0:(System.Int32)reader["SeanceID"];
					entity.ClientId = (System.Int32)reader[((int)WippsiViewColumn.ClientId)];
					//entity.ClientId = (Convert.IsDBNull(reader["ClientID"]))?(int)0:(System.Int32)reader["ClientID"];
					entity.CreateDate = (reader.IsDBNull(((int)WippsiViewColumn.CreateDate)))?null:(System.DateTime?)reader[((int)WippsiViewColumn.CreateDate)];
					//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreateDate"];
					entity.SeanceDate = (reader.IsDBNull(((int)WippsiViewColumn.SeanceDate)))?null:(System.DateTime?)reader[((int)WippsiViewColumn.SeanceDate)];
					//entity.SeanceDate = (Convert.IsDBNull(reader["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)reader["SeanceDate"];
					entity.SeanceTime = (reader.IsDBNull(((int)WippsiViewColumn.SeanceTime)))?null:(System.TimeSpan?)reader[((int)WippsiViewColumn.SeanceTime)];
					//entity.SeanceTime = (Convert.IsDBNull(reader["SeanceTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)reader["SeanceTime"];
					entity.SeanceStatusId = (System.Byte)reader[((int)WippsiViewColumn.SeanceStatusId)];
					//entity.SeanceStatusId = (Convert.IsDBNull(reader["SeanceStatusId"]))?(byte)0:(System.Byte)reader["SeanceStatusId"];
					entity.SeanceAdvisorId = (System.Int32)reader[((int)WippsiViewColumn.SeanceAdvisorId)];
					//entity.SeanceAdvisorId = (Convert.IsDBNull(reader["SeanceAdvisorID"]))?(int)0:(System.Int32)reader["SeanceAdvisorID"];
					entity.SeanceAdvisorName = (reader.IsDBNull(((int)WippsiViewColumn.SeanceAdvisorName)))?null:(System.String)reader[((int)WippsiViewColumn.SeanceAdvisorName)];
					//entity.SeanceAdvisorName = (Convert.IsDBNull(reader["SeanceAdvisorName"]))?string.Empty:(System.String)reader["SeanceAdvisorName"];
					entity.TestDate = (reader.IsDBNull(((int)WippsiViewColumn.TestDate)))?null:(System.DateTime?)reader[((int)WippsiViewColumn.TestDate)];
					//entity.TestDate = (Convert.IsDBNull(reader["TestDate"]))?DateTime.MinValue:(System.DateTime?)reader["TestDate"];
					entity.TestAdvisorId = (reader.IsDBNull(((int)WippsiViewColumn.TestAdvisorId)))?null:(System.Int32?)reader[((int)WippsiViewColumn.TestAdvisorId)];
					//entity.TestAdvisorId = (Convert.IsDBNull(reader["TestAdvisorID"]))?(int)0:(System.Int32?)reader["TestAdvisorID"];
					entity.TestAdvisorName = (reader.IsDBNull(((int)WippsiViewColumn.TestAdvisorName)))?null:(System.String)reader[((int)WippsiViewColumn.TestAdvisorName)];
					//entity.TestAdvisorName = (Convert.IsDBNull(reader["TestAdvisorName"]))?string.Empty:(System.String)reader["TestAdvisorName"];
					entity.TotalVerbalScore = (reader.IsDBNull(((int)WippsiViewColumn.TotalVerbalScore)))?null:(System.Int32?)reader[((int)WippsiViewColumn.TotalVerbalScore)];
					//entity.TotalVerbalScore = (Convert.IsDBNull(reader["TotalVerbalScore"]))?(int)0:(System.Int32?)reader["TotalVerbalScore"];
					entity.TotalPerformanceScore = (reader.IsDBNull(((int)WippsiViewColumn.TotalPerformanceScore)))?null:(System.Int32?)reader[((int)WippsiViewColumn.TotalPerformanceScore)];
					//entity.TotalPerformanceScore = (Convert.IsDBNull(reader["TotalPerformanceScore"]))?(int)0:(System.Int32?)reader["TotalPerformanceScore"];
					entity.TotalScore = (reader.IsDBNull(((int)WippsiViewColumn.TotalScore)))?null:(System.Int32?)reader[((int)WippsiViewColumn.TotalScore)];
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
		/// Refreshes the <see cref="WippsiView"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="WippsiView"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, WippsiView entity)
		{
			reader.Read();
			entity.SeanceId = (System.Int32)reader[((int)WippsiViewColumn.SeanceId)];
			//entity.SeanceId = (Convert.IsDBNull(reader["SeanceID"]))?(int)0:(System.Int32)reader["SeanceID"];
			entity.ClientId = (System.Int32)reader[((int)WippsiViewColumn.ClientId)];
			//entity.ClientId = (Convert.IsDBNull(reader["ClientID"]))?(int)0:(System.Int32)reader["ClientID"];
			entity.CreateDate = (reader.IsDBNull(((int)WippsiViewColumn.CreateDate)))?null:(System.DateTime?)reader[((int)WippsiViewColumn.CreateDate)];
			//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreateDate"];
			entity.SeanceDate = (reader.IsDBNull(((int)WippsiViewColumn.SeanceDate)))?null:(System.DateTime?)reader[((int)WippsiViewColumn.SeanceDate)];
			//entity.SeanceDate = (Convert.IsDBNull(reader["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)reader["SeanceDate"];
			entity.SeanceTime = (reader.IsDBNull(((int)WippsiViewColumn.SeanceTime)))?null:(System.TimeSpan?)reader[((int)WippsiViewColumn.SeanceTime)];
			//entity.SeanceTime = (Convert.IsDBNull(reader["SeanceTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)reader["SeanceTime"];
			entity.SeanceStatusId = (System.Byte)reader[((int)WippsiViewColumn.SeanceStatusId)];
			//entity.SeanceStatusId = (Convert.IsDBNull(reader["SeanceStatusId"]))?(byte)0:(System.Byte)reader["SeanceStatusId"];
			entity.SeanceAdvisorId = (System.Int32)reader[((int)WippsiViewColumn.SeanceAdvisorId)];
			//entity.SeanceAdvisorId = (Convert.IsDBNull(reader["SeanceAdvisorID"]))?(int)0:(System.Int32)reader["SeanceAdvisorID"];
			entity.SeanceAdvisorName = (reader.IsDBNull(((int)WippsiViewColumn.SeanceAdvisorName)))?null:(System.String)reader[((int)WippsiViewColumn.SeanceAdvisorName)];
			//entity.SeanceAdvisorName = (Convert.IsDBNull(reader["SeanceAdvisorName"]))?string.Empty:(System.String)reader["SeanceAdvisorName"];
			entity.TestDate = (reader.IsDBNull(((int)WippsiViewColumn.TestDate)))?null:(System.DateTime?)reader[((int)WippsiViewColumn.TestDate)];
			//entity.TestDate = (Convert.IsDBNull(reader["TestDate"]))?DateTime.MinValue:(System.DateTime?)reader["TestDate"];
			entity.TestAdvisorId = (reader.IsDBNull(((int)WippsiViewColumn.TestAdvisorId)))?null:(System.Int32?)reader[((int)WippsiViewColumn.TestAdvisorId)];
			//entity.TestAdvisorId = (Convert.IsDBNull(reader["TestAdvisorID"]))?(int)0:(System.Int32?)reader["TestAdvisorID"];
			entity.TestAdvisorName = (reader.IsDBNull(((int)WippsiViewColumn.TestAdvisorName)))?null:(System.String)reader[((int)WippsiViewColumn.TestAdvisorName)];
			//entity.TestAdvisorName = (Convert.IsDBNull(reader["TestAdvisorName"]))?string.Empty:(System.String)reader["TestAdvisorName"];
			entity.TotalVerbalScore = (reader.IsDBNull(((int)WippsiViewColumn.TotalVerbalScore)))?null:(System.Int32?)reader[((int)WippsiViewColumn.TotalVerbalScore)];
			//entity.TotalVerbalScore = (Convert.IsDBNull(reader["TotalVerbalScore"]))?(int)0:(System.Int32?)reader["TotalVerbalScore"];
			entity.TotalPerformanceScore = (reader.IsDBNull(((int)WippsiViewColumn.TotalPerformanceScore)))?null:(System.Int32?)reader[((int)WippsiViewColumn.TotalPerformanceScore)];
			//entity.TotalPerformanceScore = (Convert.IsDBNull(reader["TotalPerformanceScore"]))?(int)0:(System.Int32?)reader["TotalPerformanceScore"];
			entity.TotalScore = (reader.IsDBNull(((int)WippsiViewColumn.TotalScore)))?null:(System.Int32?)reader[((int)WippsiViewColumn.TotalScore)];
			//entity.TotalScore = (Convert.IsDBNull(reader["TotalScore"]))?(int)0:(System.Int32?)reader["TotalScore"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="WippsiView"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="WippsiView"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, WippsiView entity)
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

	#region WippsiViewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WippsiView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WippsiViewFilterBuilder : SqlFilterBuilder<WippsiViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WippsiViewFilterBuilder class.
		/// </summary>
		public WippsiViewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WippsiViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WippsiViewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WippsiViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WippsiViewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WippsiViewFilterBuilder

	#region WippsiViewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WippsiView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WippsiViewParameterBuilder : ParameterizedSqlFilterBuilder<WippsiViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WippsiViewParameterBuilder class.
		/// </summary>
		public WippsiViewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WippsiViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WippsiViewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WippsiViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WippsiViewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WippsiViewParameterBuilder
	
	#region WippsiViewSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WippsiView"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WippsiViewSortBuilder : SqlSortBuilder<WippsiViewColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WippsiViewSqlSortBuilder class.
		/// </summary>
		public WippsiViewSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WippsiViewSortBuilder

} // end namespace
