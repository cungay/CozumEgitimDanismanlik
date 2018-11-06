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
	/// This class is the base class for any <see cref="ClientViewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ClientViewProviderBaseCore : EntityViewProviderBase<ClientView>
	{
		#region Custom Methods
		
		
		#region ClientView_Find
		
		/// <summary>
		///	This method wrap the 'ClientView_Find' stored procedure. 
		/// </summary>
		/// <param name="fileNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="middleName"> A <c>System.String</c> instance.</param>
		/// <param name="referance"> A <c>System.String</c> instance.</param>
		/// <param name="pediatrician"> A <c>System.String</c> instance.</param>
		/// <param name="blood"> A <c>System.Byte?</c> instance.</param>
		/// <param name="birthDate1"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="birthDate2"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstDate1"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstDate2"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.Byte?</c> instance.</param>
		/// <param name="ıdCard"> A <c>System.String</c> instance.</param>
		/// <param name="age1"> A <c>System.Int32?</c> instance.</param>
		/// <param name="age2"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mother"> A <c>System.String</c> instance.</param>
		/// <param name="motherPhone"> A <c>System.String</c> instance.</param>
		/// <param name="motherMobile"> A <c>System.String</c> instance.</param>
		/// <param name="motherEmail"> A <c>System.String</c> instance.</param>
		/// <param name="father"> A <c>System.String</c> instance.</param>
		/// <param name="fatherPhone"> A <c>System.String</c> instance.</param>
		/// <param name="fatherMobile"> A <c>System.String</c> instance.</param>
		/// <param name="fatherEmail"> A <c>System.String</c> instance.</param>
		/// <param name="addressLine"> A <c>System.String</c> instance.</param>
		/// <param name="cityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="districtId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="regionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advisorIdList"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ClientView&gt;"/> instance.</returns>
		public VList<ClientView> Find(System.Int32? fileNumber, System.String firstName, System.String lastName, System.String middleName, System.String referance, System.String pediatrician, System.Byte? blood, System.DateTime? birthDate1, System.DateTime? birthDate2, System.DateTime? firstDate1, System.DateTime? firstDate2, System.Byte? gender, System.String ıdCard, System.Int32? age1, System.Int32? age2, System.String mother, System.String motherPhone, System.String motherMobile, System.String motherEmail, System.String father, System.String fatherPhone, System.String fatherMobile, System.String fatherEmail, System.String addressLine, System.Int32? cityId, System.Int32? districtId, System.Int32? regionId, System.String advisorIdList)
		{
			return Find(null, 0, int.MaxValue , fileNumber, firstName, lastName, middleName, referance, pediatrician, blood, birthDate1, birthDate2, firstDate1, firstDate2, gender, ıdCard, age1, age2, mother, motherPhone, motherMobile, motherEmail, father, fatherPhone, fatherMobile, fatherEmail, addressLine, cityId, districtId, regionId, advisorIdList);
		}
		
		/// <summary>
		///	This method wrap the 'ClientView_Find' stored procedure. 
		/// </summary>
		/// <param name="fileNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="middleName"> A <c>System.String</c> instance.</param>
		/// <param name="referance"> A <c>System.String</c> instance.</param>
		/// <param name="pediatrician"> A <c>System.String</c> instance.</param>
		/// <param name="blood"> A <c>System.Byte?</c> instance.</param>
		/// <param name="birthDate1"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="birthDate2"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstDate1"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstDate2"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.Byte?</c> instance.</param>
		/// <param name="ıdCard"> A <c>System.String</c> instance.</param>
		/// <param name="age1"> A <c>System.Int32?</c> instance.</param>
		/// <param name="age2"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mother"> A <c>System.String</c> instance.</param>
		/// <param name="motherPhone"> A <c>System.String</c> instance.</param>
		/// <param name="motherMobile"> A <c>System.String</c> instance.</param>
		/// <param name="motherEmail"> A <c>System.String</c> instance.</param>
		/// <param name="father"> A <c>System.String</c> instance.</param>
		/// <param name="fatherPhone"> A <c>System.String</c> instance.</param>
		/// <param name="fatherMobile"> A <c>System.String</c> instance.</param>
		/// <param name="fatherEmail"> A <c>System.String</c> instance.</param>
		/// <param name="addressLine"> A <c>System.String</c> instance.</param>
		/// <param name="cityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="districtId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="regionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advisorIdList"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ClientView&gt;"/> instance.</returns>
		public VList<ClientView> Find(int start, int pageLength, System.Int32? fileNumber, System.String firstName, System.String lastName, System.String middleName, System.String referance, System.String pediatrician, System.Byte? blood, System.DateTime? birthDate1, System.DateTime? birthDate2, System.DateTime? firstDate1, System.DateTime? firstDate2, System.Byte? gender, System.String ıdCard, System.Int32? age1, System.Int32? age2, System.String mother, System.String motherPhone, System.String motherMobile, System.String motherEmail, System.String father, System.String fatherPhone, System.String fatherMobile, System.String fatherEmail, System.String addressLine, System.Int32? cityId, System.Int32? districtId, System.Int32? regionId, System.String advisorIdList)
		{
			return Find(null, start, pageLength , fileNumber, firstName, lastName, middleName, referance, pediatrician, blood, birthDate1, birthDate2, firstDate1, firstDate2, gender, ıdCard, age1, age2, mother, motherPhone, motherMobile, motherEmail, father, fatherPhone, fatherMobile, fatherEmail, addressLine, cityId, districtId, regionId, advisorIdList);
		}
				
		/// <summary>
		///	This method wrap the 'ClientView_Find' stored procedure. 
		/// </summary>
		/// <param name="fileNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="middleName"> A <c>System.String</c> instance.</param>
		/// <param name="referance"> A <c>System.String</c> instance.</param>
		/// <param name="pediatrician"> A <c>System.String</c> instance.</param>
		/// <param name="blood"> A <c>System.Byte?</c> instance.</param>
		/// <param name="birthDate1"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="birthDate2"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstDate1"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstDate2"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.Byte?</c> instance.</param>
		/// <param name="ıdCard"> A <c>System.String</c> instance.</param>
		/// <param name="age1"> A <c>System.Int32?</c> instance.</param>
		/// <param name="age2"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mother"> A <c>System.String</c> instance.</param>
		/// <param name="motherPhone"> A <c>System.String</c> instance.</param>
		/// <param name="motherMobile"> A <c>System.String</c> instance.</param>
		/// <param name="motherEmail"> A <c>System.String</c> instance.</param>
		/// <param name="father"> A <c>System.String</c> instance.</param>
		/// <param name="fatherPhone"> A <c>System.String</c> instance.</param>
		/// <param name="fatherMobile"> A <c>System.String</c> instance.</param>
		/// <param name="fatherEmail"> A <c>System.String</c> instance.</param>
		/// <param name="addressLine"> A <c>System.String</c> instance.</param>
		/// <param name="cityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="districtId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="regionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advisorIdList"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;ClientView&gt;"/> instance.</returns>
		public VList<ClientView> Find(TransactionManager transactionManager, System.Int32? fileNumber, System.String firstName, System.String lastName, System.String middleName, System.String referance, System.String pediatrician, System.Byte? blood, System.DateTime? birthDate1, System.DateTime? birthDate2, System.DateTime? firstDate1, System.DateTime? firstDate2, System.Byte? gender, System.String ıdCard, System.Int32? age1, System.Int32? age2, System.String mother, System.String motherPhone, System.String motherMobile, System.String motherEmail, System.String father, System.String fatherPhone, System.String fatherMobile, System.String fatherEmail, System.String addressLine, System.Int32? cityId, System.Int32? districtId, System.Int32? regionId, System.String advisorIdList)
		{
			return Find(transactionManager, 0, int.MaxValue , fileNumber, firstName, lastName, middleName, referance, pediatrician, blood, birthDate1, birthDate2, firstDate1, firstDate2, gender, ıdCard, age1, age2, mother, motherPhone, motherMobile, motherEmail, father, fatherPhone, fatherMobile, fatherEmail, addressLine, cityId, districtId, regionId, advisorIdList);
		}
		
		/// <summary>
		///	This method wrap the 'ClientView_Find' stored procedure. 
		/// </summary>
		/// <param name="fileNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="middleName"> A <c>System.String</c> instance.</param>
		/// <param name="referance"> A <c>System.String</c> instance.</param>
		/// <param name="pediatrician"> A <c>System.String</c> instance.</param>
		/// <param name="blood"> A <c>System.Byte?</c> instance.</param>
		/// <param name="birthDate1"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="birthDate2"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstDate1"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstDate2"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.Byte?</c> instance.</param>
		/// <param name="ıdCard"> A <c>System.String</c> instance.</param>
		/// <param name="age1"> A <c>System.Int32?</c> instance.</param>
		/// <param name="age2"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mother"> A <c>System.String</c> instance.</param>
		/// <param name="motherPhone"> A <c>System.String</c> instance.</param>
		/// <param name="motherMobile"> A <c>System.String</c> instance.</param>
		/// <param name="motherEmail"> A <c>System.String</c> instance.</param>
		/// <param name="father"> A <c>System.String</c> instance.</param>
		/// <param name="fatherPhone"> A <c>System.String</c> instance.</param>
		/// <param name="fatherMobile"> A <c>System.String</c> instance.</param>
		/// <param name="fatherEmail"> A <c>System.String</c> instance.</param>
		/// <param name="addressLine"> A <c>System.String</c> instance.</param>
		/// <param name="cityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="districtId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="regionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advisorIdList"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ClientView&gt;"/> instance.</returns>
		public abstract VList<ClientView> Find(TransactionManager transactionManager, int start, int pageLength, System.Int32? fileNumber, System.String firstName, System.String lastName, System.String middleName, System.String referance, System.String pediatrician, System.Byte? blood, System.DateTime? birthDate1, System.DateTime? birthDate2, System.DateTime? firstDate1, System.DateTime? firstDate2, System.Byte? gender, System.String ıdCard, System.Int32? age1, System.Int32? age2, System.String mother, System.String motherPhone, System.String motherMobile, System.String motherEmail, System.String father, System.String fatherPhone, System.String fatherMobile, System.String fatherEmail, System.String addressLine, System.Int32? cityId, System.Int32? districtId, System.Int32? regionId, System.String advisorIdList);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;ClientView&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ClientView&gt;"/></returns>
		protected static VList&lt;ClientView&gt; Fill(DataSet dataSet, VList<ClientView> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ClientView>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ClientView&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ClientView>"/></returns>
		protected static VList&lt;ClientView&gt; Fill(DataTable dataTable, VList<ClientView> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ClientView c = new ClientView();
					c.ClientId = (Convert.IsDBNull(row["ClientID"]))?(int)0:(System.Int32)row["ClientID"];
					c.FileNumber = (Convert.IsDBNull(row["FileNumber"]))?(int)0:(System.Int32)row["FileNumber"];
					c.FullName = (Convert.IsDBNull(row["FullName"]))?string.Empty:(System.String)row["FullName"];
					c.MiddleName = (Convert.IsDBNull(row["MiddleName"]))?string.Empty:(System.String)row["MiddleName"];
					c.Reference = (Convert.IsDBNull(row["Reference"]))?string.Empty:(System.String)row["Reference"];
					c.Pediatrician = (Convert.IsDBNull(row["Pediatrician"]))?string.Empty:(System.String)row["Pediatrician"];
					c.Blood = (Convert.IsDBNull(row["Blood"]))?(byte)0:(System.Byte)row["Blood"];
					c.BirthDate = (Convert.IsDBNull(row["BirthDate"]))?DateTime.MinValue:(System.DateTime?)row["BirthDate"];
					c.FirstContactDate = (Convert.IsDBNull(row["FirstContactDate"]))?DateTime.MinValue:(System.DateTime?)row["FirstContactDate"];
					c.Gender = (Convert.IsDBNull(row["Gender"]))?(byte)0:(System.Byte)row["Gender"];
					c.IdCard = (Convert.IsDBNull(row["IdCard"]))?string.Empty:(System.String)row["IdCard"];
					c.Age = (Convert.IsDBNull(row["Age"]))?(int)0:(System.Int32?)row["Age"];
					c.Mother = (Convert.IsDBNull(row["Mother"]))?string.Empty:(System.String)row["Mother"];
					c.MotherBusiness = (Convert.IsDBNull(row["MotherBusiness"]))?string.Empty:(System.String)row["MotherBusiness"];
					c.MotherEmail = (Convert.IsDBNull(row["MotherEmail"]))?string.Empty:(System.String)row["MotherEmail"];
					c.MotherMobile = (Convert.IsDBNull(row["MotherMobile"]))?string.Empty:(System.String)row["MotherMobile"];
					c.Father = (Convert.IsDBNull(row["Father"]))?string.Empty:(System.String)row["Father"];
					c.FatherBusiness = (Convert.IsDBNull(row["FatherBusiness"]))?string.Empty:(System.String)row["FatherBusiness"];
					c.FatherEmail = (Convert.IsDBNull(row["FatherEmail"]))?string.Empty:(System.String)row["FatherEmail"];
					c.FatherMobile = (Convert.IsDBNull(row["FatherMobile"]))?string.Empty:(System.String)row["FatherMobile"];
					c.AddressLine = (Convert.IsDBNull(row["AddressLine"]))?string.Empty:(System.String)row["AddressLine"];
					c.TitleId = (Convert.IsDBNull(row["TitleId"]))?(byte)0:(System.Byte?)row["TitleId"];
					c.CityName = (Convert.IsDBNull(row["CityName"]))?string.Empty:(System.String)row["CityName"];
					c.DistrictName = (Convert.IsDBNull(row["DistrictName"]))?string.Empty:(System.String)row["DistrictName"];
					c.Region = (Convert.IsDBNull(row["Region"]))?string.Empty:(System.String)row["Region"];
					c.CityId = (Convert.IsDBNull(row["CityID"]))?(int)0:(System.Int32?)row["CityID"];
					c.RegionId = (Convert.IsDBNull(row["RegionID"]))?(int)0:(System.Int32?)row["RegionID"];
					c.DistrictId = (Convert.IsDBNull(row["DistrictID"]))?(int)0:(System.Int32?)row["DistrictID"];
					c.AdvisorId = (Convert.IsDBNull(row["AdvisorID"]))?(int)0:(System.Int32?)row["AdvisorID"];
					c.AdvisorName = (Convert.IsDBNull(row["AdvisorName"]))?string.Empty:(System.String)row["AdvisorName"];
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
		/// Fill an <see cref="VList&lt;ClientView&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ClientView&gt;"/></returns>
		protected VList<ClientView> Fill(IDataReader reader, VList<ClientView> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ClientView entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ClientView>("ClientView",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ClientView();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ClientId = (System.Int32)reader[((int)ClientViewColumn.ClientId)];
					//entity.ClientId = (Convert.IsDBNull(reader["ClientID"]))?(int)0:(System.Int32)reader["ClientID"];
					entity.FileNumber = (System.Int32)reader[((int)ClientViewColumn.FileNumber)];
					//entity.FileNumber = (Convert.IsDBNull(reader["FileNumber"]))?(int)0:(System.Int32)reader["FileNumber"];
					entity.FullName = (System.String)reader[((int)ClientViewColumn.FullName)];
					//entity.FullName = (Convert.IsDBNull(reader["FullName"]))?string.Empty:(System.String)reader["FullName"];
					entity.MiddleName = (reader.IsDBNull(((int)ClientViewColumn.MiddleName)))?null:(System.String)reader[((int)ClientViewColumn.MiddleName)];
					//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
					entity.Reference = (reader.IsDBNull(((int)ClientViewColumn.Reference)))?null:(System.String)reader[((int)ClientViewColumn.Reference)];
					//entity.Reference = (Convert.IsDBNull(reader["Reference"]))?string.Empty:(System.String)reader["Reference"];
					entity.Pediatrician = (reader.IsDBNull(((int)ClientViewColumn.Pediatrician)))?null:(System.String)reader[((int)ClientViewColumn.Pediatrician)];
					//entity.Pediatrician = (Convert.IsDBNull(reader["Pediatrician"]))?string.Empty:(System.String)reader["Pediatrician"];
					entity.Blood = (System.Byte)reader[((int)ClientViewColumn.Blood)];
					//entity.Blood = (Convert.IsDBNull(reader["Blood"]))?(byte)0:(System.Byte)reader["Blood"];
					entity.BirthDate = (reader.IsDBNull(((int)ClientViewColumn.BirthDate)))?null:(System.DateTime?)reader[((int)ClientViewColumn.BirthDate)];
					//entity.BirthDate = (Convert.IsDBNull(reader["BirthDate"]))?DateTime.MinValue:(System.DateTime?)reader["BirthDate"];
					entity.FirstContactDate = (reader.IsDBNull(((int)ClientViewColumn.FirstContactDate)))?null:(System.DateTime?)reader[((int)ClientViewColumn.FirstContactDate)];
					//entity.FirstContactDate = (Convert.IsDBNull(reader["FirstContactDate"]))?DateTime.MinValue:(System.DateTime?)reader["FirstContactDate"];
					entity.Gender = (System.Byte)reader[((int)ClientViewColumn.Gender)];
					//entity.Gender = (Convert.IsDBNull(reader["Gender"]))?(byte)0:(System.Byte)reader["Gender"];
					entity.IdCard = (reader.IsDBNull(((int)ClientViewColumn.IdCard)))?null:(System.String)reader[((int)ClientViewColumn.IdCard)];
					//entity.IdCard = (Convert.IsDBNull(reader["IdCard"]))?string.Empty:(System.String)reader["IdCard"];
					entity.Age = (reader.IsDBNull(((int)ClientViewColumn.Age)))?null:(System.Int32?)reader[((int)ClientViewColumn.Age)];
					//entity.Age = (Convert.IsDBNull(reader["Age"]))?(int)0:(System.Int32?)reader["Age"];
					entity.Mother = (reader.IsDBNull(((int)ClientViewColumn.Mother)))?null:(System.String)reader[((int)ClientViewColumn.Mother)];
					//entity.Mother = (Convert.IsDBNull(reader["Mother"]))?string.Empty:(System.String)reader["Mother"];
					entity.MotherBusiness = (reader.IsDBNull(((int)ClientViewColumn.MotherBusiness)))?null:(System.String)reader[((int)ClientViewColumn.MotherBusiness)];
					//entity.MotherBusiness = (Convert.IsDBNull(reader["MotherBusiness"]))?string.Empty:(System.String)reader["MotherBusiness"];
					entity.MotherEmail = (reader.IsDBNull(((int)ClientViewColumn.MotherEmail)))?null:(System.String)reader[((int)ClientViewColumn.MotherEmail)];
					//entity.MotherEmail = (Convert.IsDBNull(reader["MotherEmail"]))?string.Empty:(System.String)reader["MotherEmail"];
					entity.MotherMobile = (reader.IsDBNull(((int)ClientViewColumn.MotherMobile)))?null:(System.String)reader[((int)ClientViewColumn.MotherMobile)];
					//entity.MotherMobile = (Convert.IsDBNull(reader["MotherMobile"]))?string.Empty:(System.String)reader["MotherMobile"];
					entity.Father = (reader.IsDBNull(((int)ClientViewColumn.Father)))?null:(System.String)reader[((int)ClientViewColumn.Father)];
					//entity.Father = (Convert.IsDBNull(reader["Father"]))?string.Empty:(System.String)reader["Father"];
					entity.FatherBusiness = (reader.IsDBNull(((int)ClientViewColumn.FatherBusiness)))?null:(System.String)reader[((int)ClientViewColumn.FatherBusiness)];
					//entity.FatherBusiness = (Convert.IsDBNull(reader["FatherBusiness"]))?string.Empty:(System.String)reader["FatherBusiness"];
					entity.FatherEmail = (reader.IsDBNull(((int)ClientViewColumn.FatherEmail)))?null:(System.String)reader[((int)ClientViewColumn.FatherEmail)];
					//entity.FatherEmail = (Convert.IsDBNull(reader["FatherEmail"]))?string.Empty:(System.String)reader["FatherEmail"];
					entity.FatherMobile = (reader.IsDBNull(((int)ClientViewColumn.FatherMobile)))?null:(System.String)reader[((int)ClientViewColumn.FatherMobile)];
					//entity.FatherMobile = (Convert.IsDBNull(reader["FatherMobile"]))?string.Empty:(System.String)reader["FatherMobile"];
					entity.AddressLine = (reader.IsDBNull(((int)ClientViewColumn.AddressLine)))?null:(System.String)reader[((int)ClientViewColumn.AddressLine)];
					//entity.AddressLine = (Convert.IsDBNull(reader["AddressLine"]))?string.Empty:(System.String)reader["AddressLine"];
					entity.TitleId = (reader.IsDBNull(((int)ClientViewColumn.TitleId)))?null:(System.Byte?)reader[((int)ClientViewColumn.TitleId)];
					//entity.TitleId = (Convert.IsDBNull(reader["TitleId"]))?(byte)0:(System.Byte?)reader["TitleId"];
					entity.CityName = (reader.IsDBNull(((int)ClientViewColumn.CityName)))?null:(System.String)reader[((int)ClientViewColumn.CityName)];
					//entity.CityName = (Convert.IsDBNull(reader["CityName"]))?string.Empty:(System.String)reader["CityName"];
					entity.DistrictName = (reader.IsDBNull(((int)ClientViewColumn.DistrictName)))?null:(System.String)reader[((int)ClientViewColumn.DistrictName)];
					//entity.DistrictName = (Convert.IsDBNull(reader["DistrictName"]))?string.Empty:(System.String)reader["DistrictName"];
					entity.Region = (reader.IsDBNull(((int)ClientViewColumn.Region)))?null:(System.String)reader[((int)ClientViewColumn.Region)];
					//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
					entity.CityId = (reader.IsDBNull(((int)ClientViewColumn.CityId)))?null:(System.Int32?)reader[((int)ClientViewColumn.CityId)];
					//entity.CityId = (Convert.IsDBNull(reader["CityID"]))?(int)0:(System.Int32?)reader["CityID"];
					entity.RegionId = (reader.IsDBNull(((int)ClientViewColumn.RegionId)))?null:(System.Int32?)reader[((int)ClientViewColumn.RegionId)];
					//entity.RegionId = (Convert.IsDBNull(reader["RegionID"]))?(int)0:(System.Int32?)reader["RegionID"];
					entity.DistrictId = (reader.IsDBNull(((int)ClientViewColumn.DistrictId)))?null:(System.Int32?)reader[((int)ClientViewColumn.DistrictId)];
					//entity.DistrictId = (Convert.IsDBNull(reader["DistrictID"]))?(int)0:(System.Int32?)reader["DistrictID"];
					entity.AdvisorId = (reader.IsDBNull(((int)ClientViewColumn.AdvisorId)))?null:(System.Int32?)reader[((int)ClientViewColumn.AdvisorId)];
					//entity.AdvisorId = (Convert.IsDBNull(reader["AdvisorID"]))?(int)0:(System.Int32?)reader["AdvisorID"];
					entity.AdvisorName = (reader.IsDBNull(((int)ClientViewColumn.AdvisorName)))?null:(System.String)reader[((int)ClientViewColumn.AdvisorName)];
					//entity.AdvisorName = (Convert.IsDBNull(reader["AdvisorName"]))?string.Empty:(System.String)reader["AdvisorName"];
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
		/// Refreshes the <see cref="ClientView"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ClientView"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ClientView entity)
		{
			reader.Read();
			entity.ClientId = (System.Int32)reader[((int)ClientViewColumn.ClientId)];
			//entity.ClientId = (Convert.IsDBNull(reader["ClientID"]))?(int)0:(System.Int32)reader["ClientID"];
			entity.FileNumber = (System.Int32)reader[((int)ClientViewColumn.FileNumber)];
			//entity.FileNumber = (Convert.IsDBNull(reader["FileNumber"]))?(int)0:(System.Int32)reader["FileNumber"];
			entity.FullName = (System.String)reader[((int)ClientViewColumn.FullName)];
			//entity.FullName = (Convert.IsDBNull(reader["FullName"]))?string.Empty:(System.String)reader["FullName"];
			entity.MiddleName = (reader.IsDBNull(((int)ClientViewColumn.MiddleName)))?null:(System.String)reader[((int)ClientViewColumn.MiddleName)];
			//entity.MiddleName = (Convert.IsDBNull(reader["MiddleName"]))?string.Empty:(System.String)reader["MiddleName"];
			entity.Reference = (reader.IsDBNull(((int)ClientViewColumn.Reference)))?null:(System.String)reader[((int)ClientViewColumn.Reference)];
			//entity.Reference = (Convert.IsDBNull(reader["Reference"]))?string.Empty:(System.String)reader["Reference"];
			entity.Pediatrician = (reader.IsDBNull(((int)ClientViewColumn.Pediatrician)))?null:(System.String)reader[((int)ClientViewColumn.Pediatrician)];
			//entity.Pediatrician = (Convert.IsDBNull(reader["Pediatrician"]))?string.Empty:(System.String)reader["Pediatrician"];
			entity.Blood = (System.Byte)reader[((int)ClientViewColumn.Blood)];
			//entity.Blood = (Convert.IsDBNull(reader["Blood"]))?(byte)0:(System.Byte)reader["Blood"];
			entity.BirthDate = (reader.IsDBNull(((int)ClientViewColumn.BirthDate)))?null:(System.DateTime?)reader[((int)ClientViewColumn.BirthDate)];
			//entity.BirthDate = (Convert.IsDBNull(reader["BirthDate"]))?DateTime.MinValue:(System.DateTime?)reader["BirthDate"];
			entity.FirstContactDate = (reader.IsDBNull(((int)ClientViewColumn.FirstContactDate)))?null:(System.DateTime?)reader[((int)ClientViewColumn.FirstContactDate)];
			//entity.FirstContactDate = (Convert.IsDBNull(reader["FirstContactDate"]))?DateTime.MinValue:(System.DateTime?)reader["FirstContactDate"];
			entity.Gender = (System.Byte)reader[((int)ClientViewColumn.Gender)];
			//entity.Gender = (Convert.IsDBNull(reader["Gender"]))?(byte)0:(System.Byte)reader["Gender"];
			entity.IdCard = (reader.IsDBNull(((int)ClientViewColumn.IdCard)))?null:(System.String)reader[((int)ClientViewColumn.IdCard)];
			//entity.IdCard = (Convert.IsDBNull(reader["IdCard"]))?string.Empty:(System.String)reader["IdCard"];
			entity.Age = (reader.IsDBNull(((int)ClientViewColumn.Age)))?null:(System.Int32?)reader[((int)ClientViewColumn.Age)];
			//entity.Age = (Convert.IsDBNull(reader["Age"]))?(int)0:(System.Int32?)reader["Age"];
			entity.Mother = (reader.IsDBNull(((int)ClientViewColumn.Mother)))?null:(System.String)reader[((int)ClientViewColumn.Mother)];
			//entity.Mother = (Convert.IsDBNull(reader["Mother"]))?string.Empty:(System.String)reader["Mother"];
			entity.MotherBusiness = (reader.IsDBNull(((int)ClientViewColumn.MotherBusiness)))?null:(System.String)reader[((int)ClientViewColumn.MotherBusiness)];
			//entity.MotherBusiness = (Convert.IsDBNull(reader["MotherBusiness"]))?string.Empty:(System.String)reader["MotherBusiness"];
			entity.MotherEmail = (reader.IsDBNull(((int)ClientViewColumn.MotherEmail)))?null:(System.String)reader[((int)ClientViewColumn.MotherEmail)];
			//entity.MotherEmail = (Convert.IsDBNull(reader["MotherEmail"]))?string.Empty:(System.String)reader["MotherEmail"];
			entity.MotherMobile = (reader.IsDBNull(((int)ClientViewColumn.MotherMobile)))?null:(System.String)reader[((int)ClientViewColumn.MotherMobile)];
			//entity.MotherMobile = (Convert.IsDBNull(reader["MotherMobile"]))?string.Empty:(System.String)reader["MotherMobile"];
			entity.Father = (reader.IsDBNull(((int)ClientViewColumn.Father)))?null:(System.String)reader[((int)ClientViewColumn.Father)];
			//entity.Father = (Convert.IsDBNull(reader["Father"]))?string.Empty:(System.String)reader["Father"];
			entity.FatherBusiness = (reader.IsDBNull(((int)ClientViewColumn.FatherBusiness)))?null:(System.String)reader[((int)ClientViewColumn.FatherBusiness)];
			//entity.FatherBusiness = (Convert.IsDBNull(reader["FatherBusiness"]))?string.Empty:(System.String)reader["FatherBusiness"];
			entity.FatherEmail = (reader.IsDBNull(((int)ClientViewColumn.FatherEmail)))?null:(System.String)reader[((int)ClientViewColumn.FatherEmail)];
			//entity.FatherEmail = (Convert.IsDBNull(reader["FatherEmail"]))?string.Empty:(System.String)reader["FatherEmail"];
			entity.FatherMobile = (reader.IsDBNull(((int)ClientViewColumn.FatherMobile)))?null:(System.String)reader[((int)ClientViewColumn.FatherMobile)];
			//entity.FatherMobile = (Convert.IsDBNull(reader["FatherMobile"]))?string.Empty:(System.String)reader["FatherMobile"];
			entity.AddressLine = (reader.IsDBNull(((int)ClientViewColumn.AddressLine)))?null:(System.String)reader[((int)ClientViewColumn.AddressLine)];
			//entity.AddressLine = (Convert.IsDBNull(reader["AddressLine"]))?string.Empty:(System.String)reader["AddressLine"];
			entity.TitleId = (reader.IsDBNull(((int)ClientViewColumn.TitleId)))?null:(System.Byte?)reader[((int)ClientViewColumn.TitleId)];
			//entity.TitleId = (Convert.IsDBNull(reader["TitleId"]))?(byte)0:(System.Byte?)reader["TitleId"];
			entity.CityName = (reader.IsDBNull(((int)ClientViewColumn.CityName)))?null:(System.String)reader[((int)ClientViewColumn.CityName)];
			//entity.CityName = (Convert.IsDBNull(reader["CityName"]))?string.Empty:(System.String)reader["CityName"];
			entity.DistrictName = (reader.IsDBNull(((int)ClientViewColumn.DistrictName)))?null:(System.String)reader[((int)ClientViewColumn.DistrictName)];
			//entity.DistrictName = (Convert.IsDBNull(reader["DistrictName"]))?string.Empty:(System.String)reader["DistrictName"];
			entity.Region = (reader.IsDBNull(((int)ClientViewColumn.Region)))?null:(System.String)reader[((int)ClientViewColumn.Region)];
			//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
			entity.CityId = (reader.IsDBNull(((int)ClientViewColumn.CityId)))?null:(System.Int32?)reader[((int)ClientViewColumn.CityId)];
			//entity.CityId = (Convert.IsDBNull(reader["CityID"]))?(int)0:(System.Int32?)reader["CityID"];
			entity.RegionId = (reader.IsDBNull(((int)ClientViewColumn.RegionId)))?null:(System.Int32?)reader[((int)ClientViewColumn.RegionId)];
			//entity.RegionId = (Convert.IsDBNull(reader["RegionID"]))?(int)0:(System.Int32?)reader["RegionID"];
			entity.DistrictId = (reader.IsDBNull(((int)ClientViewColumn.DistrictId)))?null:(System.Int32?)reader[((int)ClientViewColumn.DistrictId)];
			//entity.DistrictId = (Convert.IsDBNull(reader["DistrictID"]))?(int)0:(System.Int32?)reader["DistrictID"];
			entity.AdvisorId = (reader.IsDBNull(((int)ClientViewColumn.AdvisorId)))?null:(System.Int32?)reader[((int)ClientViewColumn.AdvisorId)];
			//entity.AdvisorId = (Convert.IsDBNull(reader["AdvisorID"]))?(int)0:(System.Int32?)reader["AdvisorID"];
			entity.AdvisorName = (reader.IsDBNull(((int)ClientViewColumn.AdvisorName)))?null:(System.String)reader[((int)ClientViewColumn.AdvisorName)];
			//entity.AdvisorName = (Convert.IsDBNull(reader["AdvisorName"]))?string.Empty:(System.String)reader["AdvisorName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ClientView"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ClientView"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ClientView entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ClientId = (Convert.IsDBNull(dataRow["ClientID"]))?(int)0:(System.Int32)dataRow["ClientID"];
			entity.FileNumber = (Convert.IsDBNull(dataRow["FileNumber"]))?(int)0:(System.Int32)dataRow["FileNumber"];
			entity.FullName = (Convert.IsDBNull(dataRow["FullName"]))?string.Empty:(System.String)dataRow["FullName"];
			entity.MiddleName = (Convert.IsDBNull(dataRow["MiddleName"]))?string.Empty:(System.String)dataRow["MiddleName"];
			entity.Reference = (Convert.IsDBNull(dataRow["Reference"]))?string.Empty:(System.String)dataRow["Reference"];
			entity.Pediatrician = (Convert.IsDBNull(dataRow["Pediatrician"]))?string.Empty:(System.String)dataRow["Pediatrician"];
			entity.Blood = (Convert.IsDBNull(dataRow["Blood"]))?(byte)0:(System.Byte)dataRow["Blood"];
			entity.BirthDate = (Convert.IsDBNull(dataRow["BirthDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["BirthDate"];
			entity.FirstContactDate = (Convert.IsDBNull(dataRow["FirstContactDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["FirstContactDate"];
			entity.Gender = (Convert.IsDBNull(dataRow["Gender"]))?(byte)0:(System.Byte)dataRow["Gender"];
			entity.IdCard = (Convert.IsDBNull(dataRow["IdCard"]))?string.Empty:(System.String)dataRow["IdCard"];
			entity.Age = (Convert.IsDBNull(dataRow["Age"]))?(int)0:(System.Int32?)dataRow["Age"];
			entity.Mother = (Convert.IsDBNull(dataRow["Mother"]))?string.Empty:(System.String)dataRow["Mother"];
			entity.MotherBusiness = (Convert.IsDBNull(dataRow["MotherBusiness"]))?string.Empty:(System.String)dataRow["MotherBusiness"];
			entity.MotherEmail = (Convert.IsDBNull(dataRow["MotherEmail"]))?string.Empty:(System.String)dataRow["MotherEmail"];
			entity.MotherMobile = (Convert.IsDBNull(dataRow["MotherMobile"]))?string.Empty:(System.String)dataRow["MotherMobile"];
			entity.Father = (Convert.IsDBNull(dataRow["Father"]))?string.Empty:(System.String)dataRow["Father"];
			entity.FatherBusiness = (Convert.IsDBNull(dataRow["FatherBusiness"]))?string.Empty:(System.String)dataRow["FatherBusiness"];
			entity.FatherEmail = (Convert.IsDBNull(dataRow["FatherEmail"]))?string.Empty:(System.String)dataRow["FatherEmail"];
			entity.FatherMobile = (Convert.IsDBNull(dataRow["FatherMobile"]))?string.Empty:(System.String)dataRow["FatherMobile"];
			entity.AddressLine = (Convert.IsDBNull(dataRow["AddressLine"]))?string.Empty:(System.String)dataRow["AddressLine"];
			entity.TitleId = (Convert.IsDBNull(dataRow["TitleId"]))?(byte)0:(System.Byte?)dataRow["TitleId"];
			entity.CityName = (Convert.IsDBNull(dataRow["CityName"]))?string.Empty:(System.String)dataRow["CityName"];
			entity.DistrictName = (Convert.IsDBNull(dataRow["DistrictName"]))?string.Empty:(System.String)dataRow["DistrictName"];
			entity.Region = (Convert.IsDBNull(dataRow["Region"]))?string.Empty:(System.String)dataRow["Region"];
			entity.CityId = (Convert.IsDBNull(dataRow["CityID"]))?(int)0:(System.Int32?)dataRow["CityID"];
			entity.RegionId = (Convert.IsDBNull(dataRow["RegionID"]))?(int)0:(System.Int32?)dataRow["RegionID"];
			entity.DistrictId = (Convert.IsDBNull(dataRow["DistrictID"]))?(int)0:(System.Int32?)dataRow["DistrictID"];
			entity.AdvisorId = (Convert.IsDBNull(dataRow["AdvisorID"]))?(int)0:(System.Int32?)dataRow["AdvisorID"];
			entity.AdvisorName = (Convert.IsDBNull(dataRow["AdvisorName"]))?string.Empty:(System.String)dataRow["AdvisorName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ClientViewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientViewFilterBuilder : SqlFilterBuilder<ClientViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientViewFilterBuilder class.
		/// </summary>
		public ClientViewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientViewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientViewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientViewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientViewFilterBuilder

	#region ClientViewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientView"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientViewParameterBuilder : ParameterizedSqlFilterBuilder<ClientViewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientViewParameterBuilder class.
		/// </summary>
		public ClientViewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientViewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientViewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientViewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientViewParameterBuilder
	
	#region ClientViewSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientView"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClientViewSortBuilder : SqlSortBuilder<ClientViewColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientViewSqlSortBuilder class.
		/// </summary>
		public ClientViewSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClientViewSortBuilder

} // end namespace
