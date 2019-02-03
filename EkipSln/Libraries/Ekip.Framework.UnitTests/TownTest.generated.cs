﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 3 Şubat 2019 Pazar
	Important: Do not modify this file. Edit the file TownTest.cs instead.
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
    /// Provides tests for the and <see cref="Town"/> objects (entity, collection and repository).
    /// </summary>
   public partial class TownTest
    {
    	// the Town instance used to test the repository.
		protected Town mock;
		
		// the TList<Town> instance used to test the repository.
		protected TList<Town> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the Town Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock Town entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.TownProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.TownProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Town objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.TownProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.TownProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.TownProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Town children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.TownProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.TownProvider.DeepLoading += new EntityProviderBaseCore<Town, TownKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.TownProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Town instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.TownProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Town entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Town mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.TownProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.TownProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.TownProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Town entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Town)CreateMockInstance(tm);
				DataRepository.TownProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.TownProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.TownProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Town entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Town.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Town entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Town.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Town>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Town collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_TownCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Town> mockCollection = new TList<Town>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Town> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Town collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_TownCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Town>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Town> mockCollection = (TList<Town>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Town> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Town entity = CreateMockInstance(tm);
				bool result = DataRepository.TownProvider.Insert(tm, entity);
				
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
				Town entity = CreateMockInstance(tm);
				bool result = DataRepository.TownProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				TList<Town> t0 = DataRepository.TownProvider.GetByProvinceId(tm, entity.ProvinceId);
				Town t1 = DataRepository.TownProvider.GetByTownId(tm, entity.TownId);
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
				
				Town entity = mock.Copy() as Town;
				entity = (Town)mock.Clone();
				Assert.IsTrue(Town.ValueEquals(entity, mock), "Clone is not working");
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
				Town mock = CreateMockInstance(tm);
				bool result = DataRepository.TownProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				TownQuery query = new TownQuery();
			
				query.AppendEquals(TownColumn.TownId, mock.TownId.ToString());
				query.AppendEquals(TownColumn.RowNumber, mock.RowNumber.ToString());
				query.AppendEquals(TownColumn.AdminId, mock.AdminId.ToString());
				query.AppendEquals(TownColumn.ObjectId, mock.ObjectId.ToString());
				query.AppendEquals(TownColumn.ParentId, mock.ParentId.ToString());
				query.AppendEquals(TownColumn.ProvinceId, mock.ProvinceId.ToString());
				query.AppendEquals(TownColumn.TownName, mock.TownName.ToString());
				query.AppendEquals(TownColumn.Longitude, mock.Longitude.ToString());
				query.AppendEquals(TownColumn.Latitude, mock.Latitude.ToString());
				query.AppendEquals(TownColumn.Type, mock.Type.ToString());
				query.AppendEquals(TownColumn.CreateDate, mock.CreateDate.ToString());
				query.AppendEquals(TownColumn.CreateTime, mock.CreateTime.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(TownColumn.UpdateDate, mock.UpdateDate.ToString());
				if(mock.UpdateTime != null)
					query.AppendEquals(TownColumn.UpdateTime, mock.UpdateTime.ToString());
				query.AppendEquals(TownColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(TownColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(TownColumn.Active, mock.Active.ToString());
				query.AppendEquals(TownColumn.Deleted, mock.Deleted.ToString());
				
				TList<Town> results = DataRepository.TownProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Town Entity with mock values.
		///</summary>
		static public Town CreateMockInstance_Generated(TransactionManager tm)
		{		
			Town mock = new Town();
						
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.ParentId = (long)TestUtility.Instance.RandomNumber();
			mock.TownName = TestUtility.Instance.RandomString(124, false);;
			mock.Longitude = TestUtility.Instance.RandomString(10, false);;
			mock.Latitude = TestUtility.Instance.RandomString(10, false);;
			mock.Type = TestUtility.Instance.RandomNumber();
			mock.CreateDate = TestUtility.Instance.RandomDate();
			mock.CreateTime = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDate();
			mock.UpdateTime = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<Province> _collection0 = DataRepository.ProvinceProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.ProvinceId = _collection0[0].ProvinceId;
						
			}
		
			// create a temporary collection and add the item to it
			TList<Town> tempMockCollection = new TList<Town>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Town)mock;
		}
		
		
		///<summary>
		///  Update the Typed Town Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Town mock)
		{
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.ParentId = (long)TestUtility.Instance.RandomNumber();
			mock.TownName = TestUtility.Instance.RandomString(124, false);;
			mock.Longitude = TestUtility.Instance.RandomString(10, false);;
			mock.Latitude = TestUtility.Instance.RandomString(10, false);;
			mock.Type = TestUtility.Instance.RandomNumber();
			mock.CreateDate = TestUtility.Instance.RandomDate();
			mock.CreateTime = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDate();
			mock.UpdateTime = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<Province> _collection0 = DataRepository.ProvinceProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.ProvinceId = _collection0[0].ProvinceId;
			}
		}
		#endregion
    }
}
