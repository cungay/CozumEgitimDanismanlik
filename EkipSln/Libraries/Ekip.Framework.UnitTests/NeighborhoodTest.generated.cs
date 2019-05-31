﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 13 Şubat 2019 Çarşamba
	Important: Do not modify this file. Edit the file NeighborhoodTest.cs instead.
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
    /// Provides tests for the and <see cref="Neighborhood"/> objects (entity, collection and repository).
    /// </summary>
   public partial class NeighborhoodTest
    {
    	// the Neighborhood instance used to test the repository.
		protected Neighborhood mock;
		
		// the TList<Neighborhood> instance used to test the repository.
		protected TList<Neighborhood> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the Neighborhood Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock Neighborhood entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.NeighborhoodProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.NeighborhoodProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Neighborhood objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.NeighborhoodProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.NeighborhoodProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.NeighborhoodProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Neighborhood children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.NeighborhoodProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.NeighborhoodProvider.DeepLoading += new EntityProviderBaseCore<Neighborhood, NeighborhoodKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.NeighborhoodProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Neighborhood instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.NeighborhoodProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Neighborhood entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Neighborhood mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.NeighborhoodProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.NeighborhoodProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.NeighborhoodProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Neighborhood entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Neighborhood)CreateMockInstance(tm);
				DataRepository.NeighborhoodProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.NeighborhoodProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.NeighborhoodProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Neighborhood entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Neighborhood.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Neighborhood entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Neighborhood.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Neighborhood>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Neighborhood collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_NeighborhoodCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Neighborhood> mockCollection = new TList<Neighborhood>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Neighborhood> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Neighborhood collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_NeighborhoodCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Neighborhood>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Neighborhood> mockCollection = (TList<Neighborhood>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Neighborhood> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Neighborhood entity = CreateMockInstance(tm);
				bool result = DataRepository.NeighborhoodProvider.Insert(tm, entity);
				
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
				Neighborhood entity = CreateMockInstance(tm);
				bool result = DataRepository.NeighborhoodProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				TList<Neighborhood> t0 = DataRepository.NeighborhoodProvider.GetByTownId(tm, entity.TownId);
				Neighborhood t1 = DataRepository.NeighborhoodProvider.GetByNeighborhoodId(tm, entity.NeighborhoodId);
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
				
				Neighborhood entity = mock.Copy() as Neighborhood;
				entity = (Neighborhood)mock.Clone();
				Assert.IsTrue(Neighborhood.ValueEquals(entity, mock), "Clone is not working");
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
				Neighborhood mock = CreateMockInstance(tm);
				bool result = DataRepository.NeighborhoodProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				NeighborhoodQuery query = new NeighborhoodQuery();
			
				query.AppendEquals(NeighborhoodColumn.NeighborhoodId, mock.NeighborhoodId.ToString());
				query.AppendEquals(NeighborhoodColumn.AdminId, mock.AdminId.ToString());
				query.AppendEquals(NeighborhoodColumn.ObjectId, mock.ObjectId.ToString());
				query.AppendEquals(NeighborhoodColumn.ParentId, mock.ParentId.ToString());
				query.AppendEquals(NeighborhoodColumn.RowNumber, mock.RowNumber.ToString());
				query.AppendEquals(NeighborhoodColumn.TownId, mock.TownId.ToString());
				query.AppendEquals(NeighborhoodColumn.NeighborhoodName, mock.NeighborhoodName.ToString());
				query.AppendEquals(NeighborhoodColumn.Longitude, mock.Longitude.ToString());
				query.AppendEquals(NeighborhoodColumn.Latitude, mock.Latitude.ToString());
				query.AppendEquals(NeighborhoodColumn.Type, mock.Type.ToString());
				query.AppendEquals(NeighborhoodColumn.CreateDate, mock.CreateDate.ToString());
				query.AppendEquals(NeighborhoodColumn.CreateTime, mock.CreateTime.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(NeighborhoodColumn.UpdateDate, mock.UpdateDate.ToString());
				if(mock.UpdateTime != null)
					query.AppendEquals(NeighborhoodColumn.UpdateTime, mock.UpdateTime.ToString());
				query.AppendEquals(NeighborhoodColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(NeighborhoodColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(NeighborhoodColumn.Active, mock.Active.ToString());
				query.AppendEquals(NeighborhoodColumn.Deleted, mock.Deleted.ToString());
				
				TList<Neighborhood> results = DataRepository.NeighborhoodProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Neighborhood Entity with mock values.
		///</summary>
		static public Neighborhood CreateMockInstance_Generated(TransactionManager tm)
		{		
			Neighborhood mock = new Neighborhood();
						
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.ParentId = (long)TestUtility.Instance.RandomNumber();
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.NeighborhoodName = TestUtility.Instance.RandomString(124, false);;
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
			TList<Town> _collection0 = DataRepository.TownProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.TownId = _collection0[0].TownId;
						
			}
		
			// create a temporary collection and add the item to it
			TList<Neighborhood> tempMockCollection = new TList<Neighborhood>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Neighborhood)mock;
		}
		
		
		///<summary>
		///  Update the Typed Neighborhood Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Neighborhood mock)
		{
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.ParentId = (long)TestUtility.Instance.RandomNumber();
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.NeighborhoodName = TestUtility.Instance.RandomString(124, false);;
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
			TList<Town> _collection0 = DataRepository.TownProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.TownId = _collection0[0].TownId;
			}
		}
		#endregion
    }
}
