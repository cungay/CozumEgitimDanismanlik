﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Aralık 2018 Salı
	Important: Do not modify this file. Edit the file ClientFatherTest.cs instead.
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
    /// Provides tests for the and <see cref="ClientFather"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ClientFatherTest
    {
    	// the ClientFather instance used to test the repository.
		protected ClientFather mock;
		
		// the TList<ClientFather> instance used to test the repository.
		protected TList<ClientFather> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the ClientFather Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ClientFather entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientFatherProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ClientFatherProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all ClientFather objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ClientFatherProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ClientFatherProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ClientFatherProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all ClientFather children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ClientFatherProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ClientFatherProvider.DeepLoading += new EntityProviderBaseCore<ClientFather, ClientFatherKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ClientFatherProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ClientFather instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ClientFatherProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock ClientFather entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientFather mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientFatherProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ClientFatherProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ClientFatherProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock ClientFather entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ClientFather)CreateMockInstance(tm);
				DataRepository.ClientFatherProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ClientFatherProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ClientFatherProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ClientFather entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientFather.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock ClientFather entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientFather.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ClientFather>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ClientFather collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientFatherCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<ClientFather> mockCollection = new TList<ClientFather>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ClientFather> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a ClientFather collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientFatherCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ClientFather>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ClientFather> mockCollection = (TList<ClientFather>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ClientFather> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientFather entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientFatherProvider.Insert(tm, entity);
				
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
				ClientFather entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientFatherProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				ClientFather t0 = DataRepository.ClientFatherProvider.GetByFatherId(tm, entity.FatherId);
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
				
				ClientFather entity = mock.Copy() as ClientFather;
				entity = (ClientFather)mock.Clone();
				Assert.IsTrue(ClientFather.ValueEquals(entity, mock), "Clone is not working");
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
				ClientFather mock = CreateMockInstance(tm);
				bool result = DataRepository.ClientFatherProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ClientFatherQuery query = new ClientFatherQuery();
			
				query.AppendEquals(ClientFatherColumn.FatherId, mock.FatherId.ToString());
				if(mock.FullName != null)
					query.AppendEquals(ClientFatherColumn.FullName, mock.FullName.ToString());
				if(mock.Title != null)
					query.AppendEquals(ClientFatherColumn.Title, mock.Title.ToString());
				if(mock.Email != null)
					query.AppendEquals(ClientFatherColumn.Email, mock.Email.ToString());
				if(mock.Fax != null)
					query.AppendEquals(ClientFatherColumn.Fax, mock.Fax.ToString());
				if(mock.HomePhone != null)
					query.AppendEquals(ClientFatherColumn.HomePhone, mock.HomePhone.ToString());
				if(mock.BusinessPhone != null)
					query.AppendEquals(ClientFatherColumn.BusinessPhone, mock.BusinessPhone.ToString());
				if(mock.MobilePhone != null)
					query.AppendEquals(ClientFatherColumn.MobilePhone, mock.MobilePhone.ToString());
				if(mock.JobId != null)
					query.AppendEquals(ClientFatherColumn.JobId, mock.JobId.ToString());
				query.AppendEquals(ClientFatherColumn.StatusId, mock.StatusId.ToString());
				if(mock.Notes != null)
					query.AppendEquals(ClientFatherColumn.Notes, mock.Notes.ToString());
				query.AppendEquals(ClientFatherColumn.CreateOn, mock.CreateOn.ToString());
				if(mock.UpdateOn != null)
					query.AppendEquals(ClientFatherColumn.UpdateOn, mock.UpdateOn.ToString());
				query.AppendEquals(ClientFatherColumn.UserId, mock.UserId.ToString());
				
				TList<ClientFather> results = DataRepository.ClientFatherProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed ClientFather Entity with mock values.
		///</summary>
		static public ClientFather CreateMockInstance_Generated(TransactionManager tm)
		{		
			ClientFather mock = new ClientFather();
						
			mock.FullName = TestUtility.Instance.RandomString(24, false);;
			mock.Title = TestUtility.Instance.RandomString(24, false);;
			mock.Email = TestUtility.Instance.RandomString(49, false);;
			mock.Fax = TestUtility.Instance.RandomString(24, false);;
			mock.HomePhone = TestUtility.Instance.RandomString(24, false);;
			mock.BusinessPhone = TestUtility.Instance.RandomString(24, false);;
			mock.MobilePhone = TestUtility.Instance.RandomString(24, false);;
			mock.JobId = TestUtility.Instance.RandomNumber();
			mock.StatusId = TestUtility.Instance.RandomByte();
			mock.Notes = TestUtility.Instance.RandomString(249, false);;
			mock.CreateOn = TestUtility.Instance.RandomDateTime();
			mock.UpdateOn = TestUtility.Instance.RandomDateTime();
			mock.UserId = TestUtility.Instance.RandomNumber();
			
		
			// create a temporary collection and add the item to it
			TList<ClientFather> tempMockCollection = new TList<ClientFather>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (ClientFather)mock;
		}
		
		
		///<summary>
		///  Update the Typed ClientFather Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ClientFather mock)
		{
			mock.FullName = TestUtility.Instance.RandomString(24, false);;
			mock.Title = TestUtility.Instance.RandomString(24, false);;
			mock.Email = TestUtility.Instance.RandomString(49, false);;
			mock.Fax = TestUtility.Instance.RandomString(24, false);;
			mock.HomePhone = TestUtility.Instance.RandomString(24, false);;
			mock.BusinessPhone = TestUtility.Instance.RandomString(24, false);;
			mock.MobilePhone = TestUtility.Instance.RandomString(24, false);;
			mock.JobId = TestUtility.Instance.RandomNumber();
			mock.StatusId = TestUtility.Instance.RandomByte();
			mock.Notes = TestUtility.Instance.RandomString(249, false);;
			mock.CreateOn = TestUtility.Instance.RandomDateTime();
			mock.UpdateOn = TestUtility.Instance.RandomDateTime();
			mock.UserId = TestUtility.Instance.RandomNumber();
			
		}
		#endregion
    }
}
