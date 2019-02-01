﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 1 Şubat 2019 Cuma
	Important: Do not modify this file. Edit the file ClientAddressTest.cs instead.
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
    /// Provides tests for the and <see cref="ClientAddress"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ClientAddressTest
    {
    	// the ClientAddress instance used to test the repository.
		protected ClientAddress mock;
		
		// the TList<ClientAddress> instance used to test the repository.
		protected TList<ClientAddress> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the ClientAddress Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ClientAddress entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientAddressProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ClientAddressProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all ClientAddress objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ClientAddressProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ClientAddressProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ClientAddressProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all ClientAddress children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ClientAddressProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ClientAddressProvider.DeepLoading += new EntityProviderBaseCore<ClientAddress, ClientAddressKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ClientAddressProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ClientAddress instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ClientAddressProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock ClientAddress entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientAddress mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientAddressProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ClientAddressProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ClientAddressProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock ClientAddress entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ClientAddress)CreateMockInstance(tm);
				DataRepository.ClientAddressProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ClientAddressProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ClientAddressProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ClientAddress entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientAddress.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock ClientAddress entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientAddress.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ClientAddress>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ClientAddress collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientAddressCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<ClientAddress> mockCollection = new TList<ClientAddress>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ClientAddress> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a ClientAddress collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientAddressCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ClientAddress>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ClientAddress> mockCollection = (TList<ClientAddress>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ClientAddress> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientAddress entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientAddressProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientAddress entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientAddressProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				ClientAddress t0 = DataRepository.ClientAddressProvider.GetByAddressId(tm, entity.AddressId);
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
				
				ClientAddress entity = mock.Copy() as ClientAddress;
				entity = (ClientAddress)mock.Clone();
				Assert.IsTrue(ClientAddress.ValueEquals(entity, mock), "Clone is not working");
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
				ClientAddress mock = CreateMockInstance(tm);
				bool result = DataRepository.ClientAddressProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ClientAddressQuery query = new ClientAddressQuery();
			
				query.AppendEquals(ClientAddressColumn.AddressId, mock.AddressId.ToString());
				query.AppendEquals(ClientAddressColumn.TitleId, mock.TitleId.ToString());
				if(mock.AddressLine != null)
					query.AppendEquals(ClientAddressColumn.AddressLine, mock.AddressLine.ToString());
				if(mock.ProvinceId != null)
					query.AppendEquals(ClientAddressColumn.ProvinceId, mock.ProvinceId.ToString());
				if(mock.TownId != null)
					query.AppendEquals(ClientAddressColumn.TownId, mock.TownId.ToString());
				if(mock.NeighborhoodId != null)
					query.AppendEquals(ClientAddressColumn.NeighborhoodId, mock.NeighborhoodId.ToString());
				if(mock.StreetId != null)
					query.AppendEquals(ClientAddressColumn.StreetId, mock.StreetId.ToString());
				if(mock.Phone1 != null)
					query.AppendEquals(ClientAddressColumn.Phone1, mock.Phone1.ToString());
				if(mock.Phone2 != null)
					query.AppendEquals(ClientAddressColumn.Phone2, mock.Phone2.ToString());
				if(mock.Mobile != null)
					query.AppendEquals(ClientAddressColumn.Mobile, mock.Mobile.ToString());
				query.AppendEquals(ClientAddressColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(ClientAddressColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(ClientAddressColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(ClientAddressColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(ClientAddressColumn.Active, mock.Active.ToString());
				query.AppendEquals(ClientAddressColumn.Deleted, mock.Deleted.ToString());
				
				TList<ClientAddress> results = DataRepository.ClientAddressProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed ClientAddress Entity with mock values.
		///</summary>
		static public ClientAddress CreateMockInstance_Generated(TransactionManager tm)
		{		
			ClientAddress mock = new ClientAddress();
						
			mock.TitleId = TestUtility.Instance.RandomByte();
			mock.AddressLine = TestUtility.Instance.RandomString(499, false);;
			mock.ProvinceId = TestUtility.Instance.RandomNumber();
			mock.TownId = TestUtility.Instance.RandomNumber();
			mock.NeighborhoodId = TestUtility.Instance.RandomNumber();
			mock.StreetId = TestUtility.Instance.RandomNumber();
			mock.Phone1 = TestUtility.Instance.RandomString(24, false);;
			mock.Phone2 = TestUtility.Instance.RandomString(24, false);;
			mock.Mobile = TestUtility.Instance.RandomString(24, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
		
			// create a temporary collection and add the item to it
			TList<ClientAddress> tempMockCollection = new TList<ClientAddress>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (ClientAddress)mock;
		}
		
		
		///<summary>
		///  Update the Typed ClientAddress Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ClientAddress mock)
		{
			mock.TitleId = TestUtility.Instance.RandomByte();
			mock.AddressLine = TestUtility.Instance.RandomString(499, false);;
			mock.ProvinceId = TestUtility.Instance.RandomNumber();
			mock.TownId = TestUtility.Instance.RandomNumber();
			mock.NeighborhoodId = TestUtility.Instance.RandomNumber();
			mock.StreetId = TestUtility.Instance.RandomNumber();
			mock.Phone1 = TestUtility.Instance.RandomString(24, false);;
			mock.Phone2 = TestUtility.Instance.RandomString(24, false);;
			mock.Mobile = TestUtility.Instance.RandomString(24, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
		}
		#endregion
    }
}
