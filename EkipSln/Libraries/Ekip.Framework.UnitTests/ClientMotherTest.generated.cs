﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 5 Şubat 2019 Salı
	Important: Do not modify this file. Edit the file ClientMotherTest.cs instead.
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
    /// Provides tests for the and <see cref="ClientMother"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ClientMotherTest
    {
    	// the ClientMother instance used to test the repository.
		protected ClientMother mock;
		
		// the TList<ClientMother> instance used to test the repository.
		protected TList<ClientMother> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the ClientMother Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ClientMother entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientMotherProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ClientMotherProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all ClientMother objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ClientMotherProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ClientMotherProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ClientMotherProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all ClientMother children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ClientMotherProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ClientMotherProvider.DeepLoading += new EntityProviderBaseCore<ClientMother, ClientMotherKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ClientMotherProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ClientMother instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ClientMotherProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock ClientMother entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientMother mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientMotherProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ClientMotherProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ClientMotherProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock ClientMother entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ClientMother)CreateMockInstance(tm);
				DataRepository.ClientMotherProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ClientMotherProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ClientMotherProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ClientMother entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientMother.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock ClientMother entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientMother.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ClientMother>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ClientMother collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientMotherCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<ClientMother> mockCollection = new TList<ClientMother>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ClientMother> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a ClientMother collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientMotherCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ClientMother>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ClientMother> mockCollection = (TList<ClientMother>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ClientMother> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientMother entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientMotherProvider.Insert(tm, entity);
				
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
				ClientMother entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientMotherProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				ClientMother t0 = DataRepository.ClientMotherProvider.GetByMotherId(tm, entity.MotherId);
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
				
				ClientMother entity = mock.Copy() as ClientMother;
				entity = (ClientMother)mock.Clone();
				Assert.IsTrue(ClientMother.ValueEquals(entity, mock), "Clone is not working");
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
				ClientMother mock = CreateMockInstance(tm);
				bool result = DataRepository.ClientMotherProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ClientMotherQuery query = new ClientMotherQuery();
			
				query.AppendEquals(ClientMotherColumn.MotherId, mock.MotherId.ToString());
				if(mock.FullName != null)
					query.AppendEquals(ClientMotherColumn.FullName, mock.FullName.ToString());
				if(mock.Title != null)
					query.AppendEquals(ClientMotherColumn.Title, mock.Title.ToString());
				if(mock.Email != null)
					query.AppendEquals(ClientMotherColumn.Email, mock.Email.ToString());
				if(mock.Fax != null)
					query.AppendEquals(ClientMotherColumn.Fax, mock.Fax.ToString());
				if(mock.HomePhone != null)
					query.AppendEquals(ClientMotherColumn.HomePhone, mock.HomePhone.ToString());
				if(mock.BusinessPhone != null)
					query.AppendEquals(ClientMotherColumn.BusinessPhone, mock.BusinessPhone.ToString());
				if(mock.MobilePhone != null)
					query.AppendEquals(ClientMotherColumn.MobilePhone, mock.MobilePhone.ToString());
				if(mock.JobId != null)
					query.AppendEquals(ClientMotherColumn.JobId, mock.JobId.ToString());
				if(mock.Notes != null)
					query.AppendEquals(ClientMotherColumn.Notes, mock.Notes.ToString());
				query.AppendEquals(ClientMotherColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(ClientMotherColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(ClientMotherColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(ClientMotherColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(ClientMotherColumn.Active, mock.Active.ToString());
				query.AppendEquals(ClientMotherColumn.Deleted, mock.Deleted.ToString());
				
				TList<ClientMother> results = DataRepository.ClientMotherProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed ClientMother Entity with mock values.
		///</summary>
		static public ClientMother CreateMockInstance_Generated(TransactionManager tm)
		{		
			ClientMother mock = new ClientMother();
						
			mock.FullName = TestUtility.Instance.RandomString(24, false);;
			mock.Title = TestUtility.Instance.RandomString(24, false);;
			mock.Email = TestUtility.Instance.RandomString(49, false);;
			mock.Fax = TestUtility.Instance.RandomString(24, false);;
			mock.HomePhone = TestUtility.Instance.RandomString(24, false);;
			mock.BusinessPhone = TestUtility.Instance.RandomString(24, false);;
			mock.MobilePhone = TestUtility.Instance.RandomString(24, false);;
			mock.JobId = TestUtility.Instance.RandomNumber();
			mock.Notes = TestUtility.Instance.RandomString(249, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
		
			// create a temporary collection and add the item to it
			TList<ClientMother> tempMockCollection = new TList<ClientMother>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (ClientMother)mock;
		}
		
		
		///<summary>
		///  Update the Typed ClientMother Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ClientMother mock)
		{
			mock.FullName = TestUtility.Instance.RandomString(24, false);;
			mock.Title = TestUtility.Instance.RandomString(24, false);;
			mock.Email = TestUtility.Instance.RandomString(49, false);;
			mock.Fax = TestUtility.Instance.RandomString(24, false);;
			mock.HomePhone = TestUtility.Instance.RandomString(24, false);;
			mock.BusinessPhone = TestUtility.Instance.RandomString(24, false);;
			mock.MobilePhone = TestUtility.Instance.RandomString(24, false);;
			mock.JobId = TestUtility.Instance.RandomNumber();
			mock.Notes = TestUtility.Instance.RandomString(249, false);;
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
