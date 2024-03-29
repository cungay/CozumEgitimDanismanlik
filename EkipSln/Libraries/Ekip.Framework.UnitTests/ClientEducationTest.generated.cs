﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Haziran 2019 Salı
	Important: Do not modify this file. Edit the file ClientEducationTest.cs instead.
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
    /// Provides tests for the and <see cref="ClientEducation"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ClientEducationTest
    {
    	// the ClientEducation instance used to test the repository.
		protected ClientEducation mock;
		
		// the TList<ClientEducation> instance used to test the repository.
		protected TList<ClientEducation> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the ClientEducation Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ClientEducation entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientEducationProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ClientEducationProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all ClientEducation objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ClientEducationProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ClientEducationProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ClientEducationProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all ClientEducation children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ClientEducationProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ClientEducationProvider.DeepLoading += new EntityProviderBaseCore<ClientEducation, ClientEducationKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ClientEducationProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ClientEducation instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ClientEducationProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock ClientEducation entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientEducation mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ClientEducationProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ClientEducationProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ClientEducationProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock ClientEducation entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ClientEducation)CreateMockInstance(tm);
				DataRepository.ClientEducationProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ClientEducationProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ClientEducationProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ClientEducation entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientEducation.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock ClientEducation entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientEducation.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ClientEducation>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ClientEducation collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientEducationCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<ClientEducation> mockCollection = new TList<ClientEducation>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ClientEducation> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a ClientEducation collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ClientEducationCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ClientEducation>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ClientEducation> mockCollection = (TList<ClientEducation>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ClientEducation> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientEducation entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientEducationProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<ClientEducation> t0 = DataRepository.ClientEducationProvider.GetByClientId(tm, entity.ClientId, 0, 10);
				TList<ClientEducation> t1 = DataRepository.ClientEducationProvider.GetBySchoolId(tm, entity.SchoolId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ClientEducation entity = CreateMockInstance(tm);
				bool result = DataRepository.ClientEducationProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				ClientEducation t0 = DataRepository.ClientEducationProvider.GetByEducationId(tm, entity.EducationId);
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
				
				ClientEducation entity = mock.Copy() as ClientEducation;
				entity = (ClientEducation)mock.Clone();
				Assert.IsTrue(ClientEducation.ValueEquals(entity, mock), "Clone is not working");
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
				ClientEducation mock = CreateMockInstance(tm);
				bool result = DataRepository.ClientEducationProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ClientEducationQuery query = new ClientEducationQuery();
			
				query.AppendEquals(ClientEducationColumn.EducationId, mock.EducationId.ToString());
				query.AppendEquals(ClientEducationColumn.ClientId, mock.ClientId.ToString());
				query.AppendEquals(ClientEducationColumn.SchoolId, mock.SchoolId.ToString());
				query.AppendEquals(ClientEducationColumn.ClassRoom, mock.ClassRoom.ToString());
				if(mock.TeacherId != null)
					query.AppendEquals(ClientEducationColumn.TeacherId, mock.TeacherId.ToString());
				if(mock.Notes != null)
					query.AppendEquals(ClientEducationColumn.Notes, mock.Notes.ToString());
				query.AppendEquals(ClientEducationColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(ClientEducationColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(ClientEducationColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(ClientEducationColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(ClientEducationColumn.Active, mock.Active.ToString());
				query.AppendEquals(ClientEducationColumn.Deleted, mock.Deleted.ToString());
				
				TList<ClientEducation> results = DataRepository.ClientEducationProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed ClientEducation Entity with mock values.
		///</summary>
		static public ClientEducation CreateMockInstance_Generated(TransactionManager tm)
		{		
			ClientEducation mock = new ClientEducation();
						
			mock.ClassRoom = TestUtility.Instance.RandomString(24, false);;
			mock.TeacherId = TestUtility.Instance.RandomNumber();
			mock.Notes = TestUtility.Instance.RandomString(249, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			//OneToOneRelationship
			Client mockClientByClientId = ClientTest.CreateMockInstance(tm);
			DataRepository.ClientProvider.Insert(tm, mockClientByClientId);
			mock.ClientId = mockClientByClientId.ClientId;
			//OneToOneRelationship
			School mockSchoolBySchoolId = SchoolTest.CreateMockInstance(tm);
			DataRepository.SchoolProvider.Insert(tm, mockSchoolBySchoolId);
			mock.SchoolId = mockSchoolBySchoolId.SchoolId;
		
			// create a temporary collection and add the item to it
			TList<ClientEducation> tempMockCollection = new TList<ClientEducation>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (ClientEducation)mock;
		}
		
		
		///<summary>
		///  Update the Typed ClientEducation Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ClientEducation mock)
		{
			mock.ClassRoom = TestUtility.Instance.RandomString(24, false);;
			mock.TeacherId = TestUtility.Instance.RandomNumber();
			mock.Notes = TestUtility.Instance.RandomString(249, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			//OneToOneRelationship
			Client mockClientByClientId = ClientTest.CreateMockInstance(tm);
			DataRepository.ClientProvider.Insert(tm, mockClientByClientId);
			mock.ClientId = mockClientByClientId.ClientId;
					
			//OneToOneRelationship
			School mockSchoolBySchoolId = SchoolTest.CreateMockInstance(tm);
			DataRepository.SchoolProvider.Insert(tm, mockSchoolBySchoolId);
			mock.SchoolId = mockSchoolBySchoolId.SchoolId;
					
		}
		#endregion
    }
}
