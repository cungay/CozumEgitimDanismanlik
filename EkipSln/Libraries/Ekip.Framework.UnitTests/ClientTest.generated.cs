﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 1 Şubat 2019 Cuma
	Important: Do not modify this file. Edit the file ClientTest.cs instead.
*/

#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Ekip.Framework.Entities;
using Ekip.Framework.Data;
using Ekip.Framework.Data.Bases;

#endregion

namespace Ekip.Framework.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="Client"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ClientTest
    {
    	// the Client instance used to test the repository.
		protected Client mock;
		
		// the TList<Client> instance used to test the repository.
		protected TList<Client> mockCollection;
		
		protected static TransactionManager CreateTransaction()
		{
			TransactionManager transactionManager = null;
			if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
			}			
			return transactionManager;
		}
		       
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>        
        static public void Init_Generated()
        {		
        	System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the Client Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		static public void CleanUp_Generated()
        {   		
			System.Console.WriteLine("All Tests Completed");
			System.Console.WriteLine();
        }
    
    
		/// <summary>
		/// Inserts a mock Client entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ClientProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Client objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ClientProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ClientProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ClientProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Client children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ClientProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ClientProvider.DeepLoading += new EntityProviderBaseCore<Client, ClientKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ClientProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Client instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ClientProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Client entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Client mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ClientProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ClientProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Client entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Client)CreateMockInstance(tm);
				DataRepository.ClientProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ClientProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ClientProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Client entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Client.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Client entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Client.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Client>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Client collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Client> mockCollection = new TList<Client>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Client> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Client collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Client>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Client> mockCollection = (TList<Client>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Client> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Client entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<Client> t0 = DataRepository.ClientProvider.GetByAddressId(tm, entity.AddressId, 0, 10);
				TList<Client> t1 = DataRepository.ClientProvider.GetByFatherId(tm, entity.FatherId, 0, 10);
				TList<Client> t2 = DataRepository.ClientProvider.GetByMotherId(tm, entity.MotherId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Client entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				Client t0 = DataRepository.ClientProvider.GetByFileNumber(tm, entity.FileNumber);
				Client t1 = DataRepository.ClientProvider.GetByClientId(tm, entity.ClientId);
			}
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				
				Client entity = mock.Copy() as Client;
				entity = (Client)mock.Clone();
				Assert.IsTrue(Client.ValueEquals(entity, mock), "Clone is not working");
			}
		}
		
		/// <summary>
		/// Test Find using the Query class
		/// </summary>
		private void Step_30_TestFindByQuery_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Insert Mock Instance
				Client mock = CreateMockInstance(tm);
				bool result = DataRepository.ClientProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ClientQuery query = new ClientQuery();
			
				query.AppendEquals(ClientColumn.ClientId, mock.ClientId.ToString());
				query.AppendEquals(ClientColumn.FileNumber, mock.FileNumber.ToString());
				query.AppendEquals(ClientColumn.FirstContactDate, mock.FirstContactDate.ToString());
				query.AppendEquals(ClientColumn.FirstContactAge, mock.FirstContactAge.ToString());
				query.AppendEquals(ClientColumn.CurrentAge, mock.CurrentAge.ToString());
				query.AppendEquals(ClientColumn.BirthDate, mock.BirthDate.ToString());
				if(mock.CalendarAgeId != null)
					query.AppendEquals(ClientColumn.CalendarAgeId, mock.CalendarAgeId.ToString());
				query.AppendEquals(ClientColumn.FullName, mock.FullName.ToString());
				if(mock.MiddleName != null)
					query.AppendEquals(ClientColumn.MiddleName, mock.MiddleName.ToString());
				if(mock.Reference != null)
					query.AppendEquals(ClientColumn.Reference, mock.Reference.ToString());
				query.AppendEquals(ClientColumn.MotherId, mock.MotherId.ToString());
				query.AppendEquals(ClientColumn.FatherId, mock.FatherId.ToString());
				if(mock.AddressId != null)
					query.AppendEquals(ClientColumn.AddressId, mock.AddressId.ToString());
				if(mock.IdCard != null)
					query.AppendEquals(ClientColumn.IdCard, mock.IdCard.ToString());
				query.AppendEquals(ClientColumn.Gender, mock.Gender.ToString());
				query.AppendEquals(ClientColumn.Blood, mock.Blood.ToString());
				if(mock.Pediatrician != null)
					query.AppendEquals(ClientColumn.Pediatrician, mock.Pediatrician.ToString());
				query.AppendEquals(ClientColumn.CountOfChild, mock.CountOfChild.ToString());
				query.AppendEquals(ClientColumn.FamilyStatus, mock.FamilyStatus.ToString());
				if(mock.Notes != null)
					query.AppendEquals(ClientColumn.Notes, mock.Notes.ToString());
				query.AppendEquals(ClientColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(ClientColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(ClientColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(ClientColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(ClientColumn.Active, mock.Active.ToString());
				query.AppendEquals(ClientColumn.Deleted, mock.Deleted.ToString());
				
				TList<Client> results = DataRepository.ClientProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Client Entity with mock values.
		///</summary>
		static public Client CreateMockInstance_Generated(TransactionManager tm)
		{		
			Client mock = new Client();
						
			mock.FileNumber = TestUtility.Instance.RandomNumber();
			mock.FirstContactDate = TestUtility.Instance.RandomDateTime();
			mock.FirstContactAge = TestUtility.Instance.RandomNumber();
			mock.CurrentAge = TestUtility.Instance.RandomNumber();
			mock.BirthDate = TestUtility.Instance.RandomDateTime();
			mock.CalendarAgeId = TestUtility.Instance.RandomNumber();
			mock.FullName = TestUtility.Instance.RandomString(49, false);;
			mock.MiddleName = TestUtility.Instance.RandomString(49, false);;
			mock.Reference = TestUtility.Instance.RandomString(124, false);;
			mock.IdCard = TestUtility.Instance.RandomString(4, false);;
			mock.Gender = TestUtility.Instance.RandomByte();
			mock.Blood = TestUtility.Instance.RandomByte();
			mock.Pediatrician = TestUtility.Instance.RandomString(49, false);;
			mock.CountOfChild = TestUtility.Instance.RandomNumber();
			mock.FamilyStatus = TestUtility.Instance.RandomByte();
			mock.Notes = TestUtility.Instance.RandomString(2, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<ClientAddress> _collection0 = DataRepository.ClientAddressProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.AddressId = _collection0[0].AddressId;
						
			}
			int count1 = 0;
			TList<ClientFather> _collection1 = DataRepository.ClientFatherProvider.GetPaged(tm, 0, 10, out count1);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.FatherId = _collection1[0].FatherId;
						
			}
			int count2 = 0;
			TList<ClientMother> _collection2 = DataRepository.ClientMotherProvider.GetPaged(tm, 0, 10, out count2);
			//_collection2.Shuffle();
			if (_collection2.Count > 0)
			{
				mock.MotherId = _collection2[0].MotherId;
						
			}
		
			// create a temporary collection and add the item to it
			TList<Client> tempMockCollection = new TList<Client>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Client)mock;
		}
		
		
		///<summary>
		///  Update the Typed Client Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Client mock)
		{
			mock.FileNumber = TestUtility.Instance.RandomNumber();
			mock.FirstContactDate = TestUtility.Instance.RandomDateTime();
			mock.FirstContactAge = TestUtility.Instance.RandomNumber();
			mock.CurrentAge = TestUtility.Instance.RandomNumber();
			mock.BirthDate = TestUtility.Instance.RandomDateTime();
			mock.CalendarAgeId = TestUtility.Instance.RandomNumber();
			mock.FullName = TestUtility.Instance.RandomString(49, false);;
			mock.MiddleName = TestUtility.Instance.RandomString(49, false);;
			mock.Reference = TestUtility.Instance.RandomString(124, false);;
			mock.IdCard = TestUtility.Instance.RandomString(4, false);;
			mock.Gender = TestUtility.Instance.RandomByte();
			mock.Blood = TestUtility.Instance.RandomByte();
			mock.Pediatrician = TestUtility.Instance.RandomString(49, false);;
			mock.CountOfChild = TestUtility.Instance.RandomNumber();
			mock.FamilyStatus = TestUtility.Instance.RandomByte();
			mock.Notes = TestUtility.Instance.RandomString(2, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<ClientAddress> _collection0 = DataRepository.ClientAddressProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.AddressId = _collection0[0].AddressId;
			}
			int count1 = 0;
			TList<ClientFather> _collection1 = DataRepository.ClientFatherProvider.GetPaged(tm, 0, 10, out count1);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.FatherId = _collection1[0].FatherId;
			}
			int count2 = 0;
			TList<ClientMother> _collection2 = DataRepository.ClientMotherProvider.GetPaged(tm, 0, 10, out count2);
			//_collection2.Shuffle();
			if (_collection2.Count > 0)
			{
				mock.MotherId = _collection2[0].MotherId;
			}
		}
		#endregion
    }
}
