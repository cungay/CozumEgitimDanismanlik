﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 5 Şubat 2019 Salı
	Important: Do not modify this file. Edit the file StreetTest.cs instead.
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
    /// Provides tests for the and <see cref="Street"/> objects (entity, collection and repository).
    /// </summary>
   public partial class StreetTest
    {
    	// the Street instance used to test the repository.
		protected Street mock;
		
		// the TList<Street> instance used to test the repository.
		protected TList<Street> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the Street Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock Street entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.StreetProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.StreetProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Street objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.StreetProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.StreetProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.StreetProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Street children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.StreetProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.StreetProvider.DeepLoading += new EntityProviderBaseCore<Street, StreetKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.StreetProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Street instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.StreetProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Street entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Street mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.StreetProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.StreetProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.StreetProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Street entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Street)CreateMockInstance(tm);
				DataRepository.StreetProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.StreetProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.StreetProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Street entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Street.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Street entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Street.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Street>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Street collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_StreetCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Street> mockCollection = new TList<Street>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Street> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Street collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_StreetCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Street>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Street> mockCollection = (TList<Street>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Street> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Street entity = CreateMockInstance(tm);
				bool result = DataRepository.StreetProvider.Insert(tm, entity);
				
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
				Street entity = CreateMockInstance(tm);
				bool result = DataRepository.StreetProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				TList<Street> t0 = DataRepository.StreetProvider.GetByNeighborhoodId(tm, entity.NeighborhoodId);
				Street t1 = DataRepository.StreetProvider.GetByStreetId(tm, entity.StreetId);
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
				
				Street entity = mock.Copy() as Street;
				entity = (Street)mock.Clone();
				Assert.IsTrue(Street.ValueEquals(entity, mock), "Clone is not working");
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
				Street mock = CreateMockInstance(tm);
				bool result = DataRepository.StreetProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				StreetQuery query = new StreetQuery();
			
				query.AppendEquals(StreetColumn.StreetId, mock.StreetId.ToString());
				query.AppendEquals(StreetColumn.AdminId, mock.AdminId.ToString());
				query.AppendEquals(StreetColumn.ObjectId, mock.ObjectId.ToString());
				query.AppendEquals(StreetColumn.RowNumber, mock.RowNumber.ToString());
				query.AppendEquals(StreetColumn.NeighborhoodId, mock.NeighborhoodId.ToString());
				query.AppendEquals(StreetColumn.StreetName, mock.StreetName.ToString());
				query.AppendEquals(StreetColumn.Longitude, mock.Longitude.ToString());
				query.AppendEquals(StreetColumn.Latitude, mock.Latitude.ToString());
				query.AppendEquals(StreetColumn.ZipCode, mock.ZipCode.ToString());
				query.AppendEquals(StreetColumn.CreateDate, mock.CreateDate.ToString());
				query.AppendEquals(StreetColumn.CreateTime, mock.CreateTime.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(StreetColumn.UpdateDate, mock.UpdateDate.ToString());
				if(mock.UpdateTime != null)
					query.AppendEquals(StreetColumn.UpdateTime, mock.UpdateTime.ToString());
				query.AppendEquals(StreetColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(StreetColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(StreetColumn.Active, mock.Active.ToString());
				query.AppendEquals(StreetColumn.Deleted, mock.Deleted.ToString());
				
				TList<Street> results = DataRepository.StreetProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Street Entity with mock values.
		///</summary>
		static public Street CreateMockInstance_Generated(TransactionManager tm)
		{		
			Street mock = new Street();
						
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.StreetName = TestUtility.Instance.RandomString(124, false);;
			mock.Longitude = TestUtility.Instance.RandomString(9, false);;
			mock.Latitude = TestUtility.Instance.RandomString(9, false);;
			mock.ZipCode = TestUtility.Instance.RandomString(10, false);;
			mock.CreateDate = TestUtility.Instance.RandomDate();
			mock.CreateTime = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDate();
			mock.UpdateTime = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			//OneToOneRelationship
			Neighborhood mockNeighborhoodByNeighborhoodId = NeighborhoodTest.CreateMockInstance(tm);
			DataRepository.NeighborhoodProvider.Insert(tm, mockNeighborhoodByNeighborhoodId);
			mock.NeighborhoodId = mockNeighborhoodByNeighborhoodId.NeighborhoodId;
		
			// create a temporary collection and add the item to it
			TList<Street> tempMockCollection = new TList<Street>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Street)mock;
		}
		
		
		///<summary>
		///  Update the Typed Street Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Street mock)
		{
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.StreetName = TestUtility.Instance.RandomString(124, false);;
			mock.Longitude = TestUtility.Instance.RandomString(9, false);;
			mock.Latitude = TestUtility.Instance.RandomString(9, false);;
			mock.ZipCode = TestUtility.Instance.RandomString(10, false);;
			mock.CreateDate = TestUtility.Instance.RandomDate();
			mock.CreateTime = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDate();
			mock.UpdateTime = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			//OneToOneRelationship
			Neighborhood mockNeighborhoodByNeighborhoodId = NeighborhoodTest.CreateMockInstance(tm);
			DataRepository.NeighborhoodProvider.Insert(tm, mockNeighborhoodByNeighborhoodId);
			mock.NeighborhoodId = mockNeighborhoodByNeighborhoodId.NeighborhoodId;
					
		}
		#endregion
    }
}
