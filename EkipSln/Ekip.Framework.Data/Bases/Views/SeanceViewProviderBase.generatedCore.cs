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
	/// This class is the base class for any <see cref="SeanceViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class SeanceViewProviderBaseCore : EntityViewProviderBase<SeanceView>
	{
		#region Custom Methods
		
		
		#region SeanceView_GetList
		
		/// <summary>
		///	This method wrap the 'SeanceView_GetList' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;SeanceView&gt;"/> instance.</returns>
		public VList<SeanceView> GetList(System.Int32? clientId)
		{
			return GetList(null, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'SeanceView_GetList' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;SeanceView&gt;"/> instance.</returns>
		public VList<SeanceView> GetList(int start, int pageLength, System.Int32? clientId)
		{
			return GetList(null, start, pageLength , clientId);
		}
				
		/// <summary>
		///	This method wrap the 'SeanceView_GetList' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;SeanceView&gt;"/> instance.</returns>
		public VList<SeanceView> GetList(TransactionManager transactionManager, System.Int32? clientId)
		{
			return GetList(transactionManager, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'SeanceView_GetList' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;SeanceView&gt;"/> instance.</returns>
		public abstract VList<SeanceView> GetList(TransactionManager transactionManager, int start, int pageLength, System.Int32? clientId);
		
		#endregion

		
		#region SeanceView_GetByClientId
		
		/// <summary>
		///	This method wrap the 'SeanceView_GetByClientId' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;SeanceView&gt;"/> instance.</returns>
		public VList<SeanceView> GetByClientId(System.Int32? clientId)
		{
			return GetByClientId(null, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'SeanceView_GetByClientId' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;SeanceView&gt;"/> instance.</returns>
		public VList<SeanceView> GetByClientId(int start, int pageLength, System.Int32? clientId)
		{
			return GetByClientId(null, start, pageLength , clientId);
		}
				
		/// <summary>
		///	This method wrap the 'SeanceView_GetByClientId' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;SeanceView&gt;"/> instance.</returns>
		public VList<SeanceView> GetByClientId(TransactionManager transactionManager, System.Int32? clientId)
		{
			return GetByClientId(transactionManager, 0, int.MaxValue , clientId);
		}
		
		/// <summary>
		///	This method wrap the 'SeanceView_GetByClientId' stored procedure. 
		/// </summary>
		/// <param name="clientId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;SeanceView&gt;"/> instance.</returns>
		public abstract VList<SeanceView> GetByClientId(TransactionManager transactionManager, int start, int pageLength, System.Int32? clientId);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;SeanceView&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;SeanceView&gt;"/></returns>
		protected static VList&lt;SeanceView&gt; Fill(DataSet dataSet, VList<SeanceView> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<SeanceView>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;SeanceView&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<SeanceView>"/></returns>
		protected static VList&lt;SeanceView&gt; Fill(DataTable dataTable, VList<SeanceView> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					SeanceView c = new SeanceView();
					c.ClientId = (Convert.IsDBNull(row["ClientID"]))?(int)0:(System.Int32)row["ClientID"];
					c.SeanceId = (Convert.IsDBNull(row["SeanceID"]))?(int)0:(System.Int32)row["SeanceID"];
					c.AdvisorId = (Convert.IsDBNull(row["AdvisorID"]))?(int)0:(System.Int32?)row["AdvisorID"];
					c.FileNumber = (Convert.IsDBNull(row["FileNumber"]))?(int)0:(System.Int32)row["FileNumber"];
					c.FirstContactDate = (Convert.IsDBNull(row["FirstContactDate"]))?DateTime.MinValue:(System.DateTime?)row["FirstContactDate"];
					c.ClientName = (Convert.IsDBNull(row["ClientName"]))?string.Empty:(System.String)row["ClientName"];
					c.Gender = (Convert.IsDBNull(row["Gender"]))?string.Empty:(System.String)row["Gender"];
					c.BirthDate = (Convert.IsDBNull(row["BirthDate"]))?DateTime.MinValue:(System.DateTime?)row["BirthDate"];
					c.Pediatrician = (Convert.IsDBNull(row["Pediatrician"]))?string.Empty:(System.String)row["Pediatrician"];
					c.SeanceNote = (Convert.IsDBNull(row["SeanceNote"]))?string.Empty:(System.String)row["SeanceNote"];
					c.SeanceDate = (Convert.IsDBNull(row["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)row["SeanceDate"];
					c.SeanceTime = (Convert.IsDBNull(row["SeanceTime"]))?string.Empty:(System.String)row["SeanceTime"];
					c.SeanceStatus = (Convert.IsDBNull(row["SeanceStatus"]))?(byte)0:(System.Byte)row["SeanceStatus"];
					c.Advisor = (Convert.IsDBNull(row["Advisor"]))?string.Empty:(System.String)row["Advisor"];
					c.Father = (Convert.IsDBNull(row["Father"]))?string.Empty:(System.String)row["Father"];
					c.FatherHome = (Convert.IsDBNull(row["FatherHome"]))?string.Empty:(System.String)row["FatherHome"];
					c.FatherMobile = (Convert.IsDBNull(row["FatherMobile"]))?string.Empty:(System.String)row["FatherMobile"];
					c.FatherBusiness = (Convert.IsDBNull(row["FatherBusiness"]))?string.Empty:(System.String)row["FatherBusiness"];
					c.FatherEmail = (Convert.IsDBNull(row["FatherEmail"]))?string.Empty:(System.String)row["FatherEmail"];
					c.Mother = (Convert.IsDBNull(row["Mother"]))?string.Empty:(System.String)row["Mother"];
					c.MotherHome = (Convert.IsDBNull(row["MotherHome"]))?string.Empty:(System.String)row["MotherHome"];
					c.MotherMobile = (Convert.IsDBNull(row["MotherMobile"]))?string.Empty:(System.String)row["MotherMobile"];
					c.MotherBusiness = (Convert.IsDBNull(row["MotherBusiness"]))?string.Empty:(System.String)row["MotherBusiness"];
					c.MotherEmail = (Convert.IsDBNull(row["MotherEmail"]))?string.Empty:(System.String)row["MotherEmail"];
					c.ReasonIdList = (Convert.IsDBNull(row["ReasonIdList"]))?string.Empty:(System.String)row["ReasonIdList"];
					c.ReasonValueList = (Convert.IsDBNull(row["ReasonValueList"]))?string.Empty:(System.String)row["ReasonValueList"];
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
		/// Fill an <see cref="VList&lt;SeanceView&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;SeanceView&gt;"/></returns>
		protected VList<SeanceView> Fill(IDataReader reader, VList<SeanceView> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					SeanceView entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<SeanceView>("SeanceView",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new SeanceView();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ClientId = (System.Int32)reader[((int)SeanceViewColumn.ClientId)];
					//entity.ClientId = (Convert.IsDBNull(reader["ClientID"]))?(int)0:(System.Int32)reader["ClientID"];
					entity.SeanceId = (System.Int32)reader[((int)SeanceViewColumn.SeanceId)];
					//entity.SeanceId = (Convert.IsDBNull(reader["SeanceID"]))?(int)0:(System.Int32)reader["SeanceID"];
					entity.AdvisorId = (reader.IsDBNull(((int)SeanceViewColumn.AdvisorId)))?null:(System.Int32?)reader[((int)SeanceViewColumn.AdvisorId)];
					//entity.AdvisorId = (Convert.IsDBNull(reader["AdvisorID"]))?(int)0:(System.Int32?)reader["AdvisorID"];
					entity.FileNumber = (System.Int32)reader[((int)SeanceViewColumn.FileNumber)];
					//entity.FileNumber = (Convert.IsDBNull(reader["FileNumber"]))?(int)0:(System.Int32)reader["FileNumber"];
					entity.FirstContactDate = (reader.IsDBNull(((int)SeanceViewColumn.FirstContactDate)))?null:(System.DateTime?)reader[((int)SeanceViewColumn.FirstContactDate)];
					//entity.FirstContactDate = (Convert.IsDBNull(reader["FirstContactDate"]))?DateTime.MinValue:(System.DateTime?)reader["FirstContactDate"];
					entity.ClientName = (System.String)reader[((int)SeanceViewColumn.ClientName)];
					//entity.ClientName = (Convert.IsDBNull(reader["ClientName"]))?string.Empty:(System.String)reader["ClientName"];
					entity.Gender = (reader.IsDBNull(((int)SeanceViewColumn.Gender)))?null:(System.String)reader[((int)SeanceViewColumn.Gender)];
					//entity.Gender = (Convert.IsDBNull(reader["Gender"]))?string.Empty:(System.String)reader["Gender"];
					entity.BirthDate = (reader.IsDBNull(((int)SeanceViewColumn.BirthDate)))?null:(System.DateTime?)reader[((int)SeanceViewColumn.BirthDate)];
					//entity.BirthDate = (Convert.IsDBNull(reader["BirthDate"]))?DateTime.MinValue:(System.DateTime?)reader["BirthDate"];
					entity.Pediatrician = (reader.IsDBNull(((int)SeanceViewColumn.Pediatrician)))?null:(System.String)reader[((int)SeanceViewColumn.Pediatrician)];
					//entity.Pediatrician = (Convert.IsDBNull(reader["Pediatrician"]))?string.Empty:(System.String)reader["Pediatrician"];
					entity.SeanceNote = (reader.IsDBNull(((int)SeanceViewColumn.SeanceNote)))?null:(System.String)reader[((int)SeanceViewColumn.SeanceNote)];
					//entity.SeanceNote = (Convert.IsDBNull(reader["SeanceNote"]))?string.Empty:(System.String)reader["SeanceNote"];
					entity.SeanceDate = (reader.IsDBNull(((int)SeanceViewColumn.SeanceDate)))?null:(System.DateTime?)reader[((int)SeanceViewColumn.SeanceDate)];
					//entity.SeanceDate = (Convert.IsDBNull(reader["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)reader["SeanceDate"];
					entity.SeanceTime = (reader.IsDBNull(((int)SeanceViewColumn.SeanceTime)))?null:(System.String)reader[((int)SeanceViewColumn.SeanceTime)];
					//entity.SeanceTime = (Convert.IsDBNull(reader["SeanceTime"]))?string.Empty:(System.String)reader["SeanceTime"];
					entity.SeanceStatus = (System.Byte)reader[((int)SeanceViewColumn.SeanceStatus)];
					//entity.SeanceStatus = (Convert.IsDBNull(reader["SeanceStatus"]))?(byte)0:(System.Byte)reader["SeanceStatus"];
					entity.Advisor = (reader.IsDBNull(((int)SeanceViewColumn.Advisor)))?null:(System.String)reader[((int)SeanceViewColumn.Advisor)];
					//entity.Advisor = (Convert.IsDBNull(reader["Advisor"]))?string.Empty:(System.String)reader["Advisor"];
					entity.Father = (reader.IsDBNull(((int)SeanceViewColumn.Father)))?null:(System.String)reader[((int)SeanceViewColumn.Father)];
					//entity.Father = (Convert.IsDBNull(reader["Father"]))?string.Empty:(System.String)reader["Father"];
					entity.FatherHome = (reader.IsDBNull(((int)SeanceViewColumn.FatherHome)))?null:(System.String)reader[((int)SeanceViewColumn.FatherHome)];
					//entity.FatherHome = (Convert.IsDBNull(reader["FatherHome"]))?string.Empty:(System.String)reader["FatherHome"];
					entity.FatherMobile = (reader.IsDBNull(((int)SeanceViewColumn.FatherMobile)))?null:(System.String)reader[((int)SeanceViewColumn.FatherMobile)];
					//entity.FatherMobile = (Convert.IsDBNull(reader["FatherMobile"]))?string.Empty:(System.String)reader["FatherMobile"];
					entity.FatherBusiness = (reader.IsDBNull(((int)SeanceViewColumn.FatherBusiness)))?null:(System.String)reader[((int)SeanceViewColumn.FatherBusiness)];
					//entity.FatherBusiness = (Convert.IsDBNull(reader["FatherBusiness"]))?string.Empty:(System.String)reader["FatherBusiness"];
					entity.FatherEmail = (reader.IsDBNull(((int)SeanceViewColumn.FatherEmail)))?null:(System.String)reader[((int)SeanceViewColumn.FatherEmail)];
					//entity.FatherEmail = (Convert.IsDBNull(reader["FatherEmail"]))?string.Empty:(System.String)reader["FatherEmail"];
					entity.Mother = (reader.IsDBNull(((int)SeanceViewColumn.Mother)))?null:(System.String)reader[((int)SeanceViewColumn.Mother)];
					//entity.Mother = (Convert.IsDBNull(reader["Mother"]))?string.Empty:(System.String)reader["Mother"];
					entity.MotherHome = (reader.IsDBNull(((int)SeanceViewColumn.MotherHome)))?null:(System.String)reader[((int)SeanceViewColumn.MotherHome)];
					//entity.MotherHome = (Convert.IsDBNull(reader["MotherHome"]))?string.Empty:(System.String)reader["MotherHome"];
					entity.MotherMobile = (reader.IsDBNull(((int)SeanceViewColumn.MotherMobile)))?null:(System.String)reader[((int)SeanceViewColumn.MotherMobile)];
					//entity.MotherMobile = (Convert.IsDBNull(reader["MotherMobile"]))?string.Empty:(System.String)reader["MotherMobile"];
					entity.MotherBusiness = (reader.IsDBNull(((int)SeanceViewColumn.MotherBusiness)))?null:(System.String)reader[((int)SeanceViewColumn.MotherBusiness)];
					//entity.MotherBusiness = (Convert.IsDBNull(reader["MotherBusiness"]))?string.Empty:(System.String)reader["MotherBusiness"];
					entity.MotherEmail = (reader.IsDBNull(((int)SeanceViewColumn.MotherEmail)))?null:(System.String)reader[((int)SeanceViewColumn.MotherEmail)];
					//entity.MotherEmail = (Convert.IsDBNull(reader["MotherEmail"]))?string.Empty:(System.String)reader["MotherEmail"];
					entity.ReasonIdList = (reader.IsDBNull(((int)SeanceViewColumn.ReasonIdList)))?null:(System.String)reader[((int)SeanceViewColumn.ReasonIdList)];
					//entity.ReasonIdList = (Convert.IsDBNull(reader["ReasonIdList"]))?string.Empty:(System.String)reader["ReasonIdList"];
					entity.ReasonValueList = (reader.IsDBNull(((int)SeanceViewColumn.ReasonValueList)))?null:(System.String)reader[((int)SeanceViewColumn.ReasonValueList)];
					//entity.ReasonValueList = (Convert.IsDBNull(reader["ReasonValueList"]))?string.Empty:(System.String)reader["ReasonValueList"];
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
		/// Refreshes the <see cref="SeanceView"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SeanceView"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, SeanceView entity)
		{
			reader.Read();
			entity.ClientId = (System.Int32)reader[((int)SeanceViewColumn.ClientId)];
			//entity.ClientId = (Convert.IsDBNull(reader["ClientID"]))?(int)0:(System.Int32)reader["ClientID"];
			entity.SeanceId = (System.Int32)reader[((int)SeanceViewColumn.SeanceId)];
			//entity.SeanceId = (Convert.IsDBNull(reader["SeanceID"]))?(int)0:(System.Int32)reader["SeanceID"];
			entity.AdvisorId = (reader.IsDBNull(((int)SeanceViewColumn.AdvisorId)))?null:(System.Int32?)reader[((int)SeanceViewColumn.AdvisorId)];
			//entity.AdvisorId = (Convert.IsDBNull(reader["AdvisorID"]))?(int)0:(System.Int32?)reader["AdvisorID"];
			entity.FileNumber = (System.Int32)reader[((int)SeanceViewColumn.FileNumber)];
			//entity.FileNumber = (Convert.IsDBNull(reader["FileNumber"]))?(int)0:(System.Int32)reader["FileNumber"];
			entity.FirstContactDate = (reader.IsDBNull(((int)SeanceViewColumn.FirstContactDate)))?null:(System.DateTime?)reader[((int)SeanceViewColumn.FirstContactDate)];
			//entity.FirstContactDate = (Convert.IsDBNull(reader["FirstContactDate"]))?DateTime.MinValue:(System.DateTime?)reader["FirstContactDate"];
			entity.ClientName = (System.String)reader[((int)SeanceViewColumn.ClientName)];
			//entity.ClientName = (Convert.IsDBNull(reader["ClientName"]))?string.Empty:(System.String)reader["ClientName"];
			entity.Gender = (reader.IsDBNull(((int)SeanceViewColumn.Gender)))?null:(System.String)reader[((int)SeanceViewColumn.Gender)];
			//entity.Gender = (Convert.IsDBNull(reader["Gender"]))?string.Empty:(System.String)reader["Gender"];
			entity.BirthDate = (reader.IsDBNull(((int)SeanceViewColumn.BirthDate)))?null:(System.DateTime?)reader[((int)SeanceViewColumn.BirthDate)];
			//entity.BirthDate = (Convert.IsDBNull(reader["BirthDate"]))?DateTime.MinValue:(System.DateTime?)reader["BirthDate"];
			entity.Pediatrician = (reader.IsDBNull(((int)SeanceViewColumn.Pediatrician)))?null:(System.String)reader[((int)SeanceViewColumn.Pediatrician)];
			//entity.Pediatrician = (Convert.IsDBNull(reader["Pediatrician"]))?string.Empty:(System.String)reader["Pediatrician"];
			entity.SeanceNote = (reader.IsDBNull(((int)SeanceViewColumn.SeanceNote)))?null:(System.String)reader[((int)SeanceViewColumn.SeanceNote)];
			//entity.SeanceNote = (Convert.IsDBNull(reader["SeanceNote"]))?string.Empty:(System.String)reader["SeanceNote"];
			entity.SeanceDate = (reader.IsDBNull(((int)SeanceViewColumn.SeanceDate)))?null:(System.DateTime?)reader[((int)SeanceViewColumn.SeanceDate)];
			//entity.SeanceDate = (Convert.IsDBNull(reader["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)reader["SeanceDate"];
			entity.SeanceTime = (reader.IsDBNull(((int)SeanceViewColumn.SeanceTime)))?null:(System.String)reader[((int)SeanceViewColumn.SeanceTime)];
			//entity.SeanceTime = (Convert.IsDBNull(reader["SeanceTime"]))?string.Empty:(System.String)reader["SeanceTime"];
			entity.SeanceStatus = (System.Byte)reader[((int)SeanceViewColumn.SeanceStatus)];
			//entity.SeanceStatus = (Convert.IsDBNull(reader["SeanceStatus"]))?(byte)0:(System.Byte)reader["SeanceStatus"];
			entity.Advisor = (reader.IsDBNull(((int)SeanceViewColumn.Advisor)))?null:(System.String)reader[((int)SeanceViewColumn.Advisor)];
			//entity.Advisor = (Convert.IsDBNull(reader["Advisor"]))?string.Empty:(System.String)reader["Advisor"];
			entity.Father = (reader.IsDBNull(((int)SeanceViewColumn.Father)))?null:(System.String)reader[((int)SeanceViewColumn.Father)];
			//entity.Father = (Convert.IsDBNull(reader["Father"]))?string.Empty:(System.String)reader["Father"];
			entity.FatherHome = (reader.IsDBNull(((int)SeanceViewColumn.FatherHome)))?null:(System.String)reader[((int)SeanceViewColumn.FatherHome)];
			//entity.FatherHome = (Convert.IsDBNull(reader["FatherHome"]))?string.Empty:(System.String)reader["FatherHome"];
			entity.FatherMobile = (reader.IsDBNull(((int)SeanceViewColumn.FatherMobile)))?null:(System.String)reader[((int)SeanceViewColumn.FatherMobile)];
			//entity.FatherMobile = (Convert.IsDBNull(reader["FatherMobile"]))?string.Empty:(System.String)reader["FatherMobile"];
			entity.FatherBusiness = (reader.IsDBNull(((int)SeanceViewColumn.FatherBusiness)))?null:(System.String)reader[((int)SeanceViewColumn.FatherBusiness)];
			//entity.FatherBusiness = (Convert.IsDBNull(reader["FatherBusiness"]))?string.Empty:(System.String)reader["FatherBusiness"];
			entity.FatherEmail = (reader.IsDBNull(((int)SeanceViewColumn.FatherEmail)))?null:(System.String)reader[((int)SeanceViewColumn.FatherEmail)];
			//entity.FatherEmail = (Convert.IsDBNull(reader["FatherEmail"]))?string.Empty:(System.String)reader["FatherEmail"];
			entity.Mother = (reader.IsDBNull(((int)SeanceViewColumn.Mother)))?null:(System.String)reader[((int)SeanceViewColumn.Mother)];
			//entity.Mother = (Convert.IsDBNull(reader["Mother"]))?string.Empty:(System.String)reader["Mother"];
			entity.MotherHome = (reader.IsDBNull(((int)SeanceViewColumn.MotherHome)))?null:(System.String)reader[((int)SeanceViewColumn.MotherHome)];
			//entity.MotherHome = (Convert.IsDBNull(reader["MotherHome"]))?string.Empty:(System.String)reader["MotherHome"];
			entity.MotherMobile = (reader.IsDBNull(((int)SeanceViewColumn.MotherMobile)))?null:(System.String)reader[((int)SeanceViewColumn.MotherMobile)];
			//entity.MotherMobile = (Convert.IsDBNull(reader["MotherMobile"]))?string.Empty:(System.String)reader["MotherMobile"];
			entity.MotherBusiness = (reader.IsDBNull(((int)SeanceViewColumn.MotherBusiness)))?null:(System.String)reader[((int)SeanceViewColumn.MotherBusiness)];
			//entity.MotherBusiness = (Convert.IsDBNull(reader["MotherBusiness"]))?string.Empty:(System.String)reader["MotherBusiness"];
			entity.MotherEmail = (reader.IsDBNull(((int)SeanceViewColumn.MotherEmail)))?null:(System.String)reader[((int)SeanceViewColumn.MotherEmail)];
			//entity.MotherEmail = (Convert.IsDBNull(reader["MotherEmail"]))?string.Empty:(System.String)reader["MotherEmail"];
			entity.ReasonIdList = (reader.IsDBNull(((int)SeanceViewColumn.ReasonIdList)))?null:(System.String)reader[((int)SeanceViewColumn.ReasonIdList)];
			//entity.ReasonIdList = (Convert.IsDBNull(reader["ReasonIdList"]))?string.Empty:(System.String)reader["ReasonIdList"];
			entity.ReasonValueList = (reader.IsDBNull(((int)SeanceViewColumn.ReasonValueList)))?null:(System.String)reader[((int)SeanceViewColumn.ReasonValueList)];
			//entity.ReasonValueList = (Convert.IsDBNull(reader["ReasonValueList"]))?string.Empty:(System.String)reader["ReasonValueList"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="SeanceView"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SeanceView"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, SeanceView entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ClientId = (Convert.IsDBNull(dataRow["ClientID"]))?(int)0:(System.Int32)dataRow["ClientID"];
			entity.SeanceId = (Convert.IsDBNull(dataRow["SeanceID"]))?(int)0:(System.Int32)dataRow["SeanceID"];
			entity.AdvisorId = (Convert.IsDBNull(dataRow["AdvisorID"]))?(int)0:(System.Int32?)dataRow["AdvisorID"];
			entity.FileNumber = (Convert.IsDBNull(dataRow["FileNumber"]))?(int)0:(System.Int32)dataRow["FileNumber"];
			entity.FirstContactDate = (Convert.IsDBNull(dataRow["FirstContactDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["FirstContactDate"];
			entity.ClientName = (Convert.IsDBNull(dataRow["ClientName"]))?string.Empty:(System.String)dataRow["ClientName"];
			entity.Gender = (Convert.IsDBNull(dataRow["Gender"]))?string.Empty:(System.String)dataRow["Gender"];
			entity.BirthDate = (Convert.IsDBNull(dataRow["BirthDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["BirthDate"];
			entity.Pediatrician = (Convert.IsDBNull(dataRow["Pediatrician"]))?string.Empty:(System.String)dataRow["Pediatrician"];
			entity.SeanceNote = (Convert.IsDBNull(dataRow["SeanceNote"]))?string.Empty:(System.String)dataRow["SeanceNote"];
			entity.SeanceDate = (Convert.IsDBNull(dataRow["SeanceDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["SeanceDate"];
			entity.SeanceTime = (Convert.IsDBNull(dataRow["SeanceTime"]))?string.Empty:(System.String)dataRow["SeanceTime"];
			entity.SeanceStatus = (Convert.IsDBNull(dataRow["SeanceStatus"]))?(byte)0:(System.Byte)dataRow["SeanceStatus"];
			entity.Advisor = (Convert.IsDBNull(dataRow["Advisor"]))?string.Empty:(System.String)dataRow["Advisor"];
			entity.Father = (Convert.IsDBNull(dataRow["Father"]))?string.Empty:(System.String)dataRow["Father"];
			entity.FatherHome = (Convert.IsDBNull(dataRow["FatherHome"]))?string.Empty:(System.String)dataRow["FatherHome"];
			entity.FatherMobile = (Convert.IsDBNull(dataRow["FatherMobile"]))?string.Empty:(System.String)dataRow["FatherMobile"];
			entity.FatherBusiness = (Convert.IsDBNull(dataRow["FatherBusiness"]))?string.Empty:(System.String)dataRow["FatherBusiness"];
			entity.FatherEmail = (Convert.IsDBNull(dataRow["FatherEmail"]))?string.Empty:(System.String)dataRow["FatherEmail"];
			entity.Mother = (Convert.IsDBNull(dataRow["Mother"]))?string.Empty:(System.String)dataRow["Mother"];
			entity.MotherHome = (Convert.IsDBNull(dataRow["MotherHome"]))?string.Empty:(System.String)dataRow["MotherHome"];
			entity.MotherMobile = (Convert.IsDBNull(dataRow["MotherMobile"]))?string.Empty:(System.String)dataRow["MotherMobile"];
			entity.MotherBusiness = (Convert.IsDBNull(dataRow["MotherBusiness"]))?string.Empty:(System.String)dataRow["MotherBusiness"];
			entity.MotherEmail = (Convert.IsDBNull(dataRow["MotherEmail"]))?string.Empty:(System.String)dataRow["MotherEmail"];
			entity.ReasonIdList = (Convert.IsDBNull(dataRow["ReasonIdList"]))?string.Empty:(System.String)dataRow["ReasonIdList"];
			entity.ReasonValueList = (Convert.IsDBNull(dataRow["ReasonValueList"]))?string.Empty:(System.String)dataRow["ReasonValueList"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region SeanceViewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceViewFilterBuilder : SqlFilterBuilder<SeanceViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceViewFilterBuilder class.
		/// </summary>
		public SeanceViewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceViewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceViewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceViewFilterBuilder

	#region SeanceViewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeanceViewParameterBuilder : ParameterizedSqlFilterBuilder<SeanceViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceViewParameterBuilder class.
		/// </summary>
		public SeanceViewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeanceViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeanceViewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeanceViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeanceViewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeanceViewParameterBuilder
	
	#region SeanceViewSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeanceView"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SeanceViewSortBuilder : SqlSortBuilder<SeanceViewColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeanceViewSqlSortBuilder class.
		/// </summary>
		public SeanceViewSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SeanceViewSortBuilder

} // end namespace
