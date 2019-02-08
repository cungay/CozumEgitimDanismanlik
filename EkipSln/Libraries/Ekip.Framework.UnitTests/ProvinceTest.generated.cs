﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 5 Şubat 2019 Salı
	Important: Do not modify this file. Edit the file ProvinceTest.cs instead.
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
    /// Provides tests for the and <see cref="Province"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ProvinceTest
    {
    	// the Province instance used to test the repository.
		protected Province mock;
		
		// the TList<Province> instance used to test the repository.
		protected TList<Province> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the Province Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock Province entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ProvinceProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ProvinceProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Province objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ProvinceProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ProvinceProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ProvinceProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Province children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ProvinceProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ProvinceProvider.DeepLoading += new EntityProviderBaseCore<Province, ProvinceKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ProvinceProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Province instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ProvinceProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Province entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Province mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ProvinceProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ProvinceProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ProvinceProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Province entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Province)CreateMockInstance(tm);
				DataRepository.ProvinceProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ProvinceProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ProvinceProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Province entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Province.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Province entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Province.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Province>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Province collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProvinceCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Province> mockCollection = new TList<Province>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Province> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Province collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProvinceCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Province>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Province> mockCollection = (TList<Province>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Province> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Province entity = CreateMockInstance(tm);
				bool result = DataRepository.ProvinceProvider.Insert(tm, entity);
				
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
				Province entity = CreateMockInstance(tm);
				bool result = DataRepository.ProvinceProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				Province t0 = DataRepository.ProvinceProvider.GetByProvinceName(tm, entity.ProvinceName);
				Province t1 = DataRepository.ProvinceProvider.GetByProvinceId(tm, entity.ProvinceId);
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
				
				Province entity = mock.Copy() as Province;
				entity = (Province)mock.Clone();
				Assert.IsTrue(Province.ValueEquals(entity, mock), "Clone is not working");
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
				Province mock = CreateMockInstance(tm);
				bool result = DataRepository.ProvinceProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ProvinceQuery query = new ProvinceQuery();
			
				query.AppendEquals(ProvinceColumn.ProvinceId, mock.ProvinceId.ToString());
				query.AppendEquals(ProvinceColumn.RowNumber, mock.RowNumber.ToString());
				query.AppendEquals(ProvinceColumn.AdminId, mock.AdminId.ToString());
				query.AppendEquals(ProvinceColumn.ObjectId, mock.ObjectId.ToString());
				query.AppendEquals(ProvinceColumn.ParentId, mock.ParentId.ToString());
				query.AppendEquals(ProvinceColumn.PlateCode, mock.PlateCode.ToString());
				query.AppendEquals(ProvinceColumn.AreaId, mock.AreaId.ToString());
				query.AppendEquals(ProvinceColumn.PhoneCode, mock.PhoneCode.ToString());
				query.AppendEquals(ProvinceColumn.ProvinceName, mock.ProvinceName.ToString());
				query.AppendEquals(ProvinceColumn.Longitude, mock.Longitude.ToString());
				query.AppendEquals(ProvinceColumn.Latitude, mock.Latitude.ToString());
				query.AppendEquals(ProvinceColumn.Type, mock.Type.ToString());
				query.AppendEquals(ProvinceColumn.CreateDate, mock.CreateDate.ToString());
				query.AppendEquals(ProvinceColumn.CreateTime, mock.CreateTime.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(ProvinceColumn.UpdateDate, mock.UpdateDate.ToString());
				if(mock.UpdateTime != null)
					query.AppendEquals(ProvinceColumn.UpdateTime, mock.UpdateTime.ToString());
				query.AppendEquals(ProvinceColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(ProvinceColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(ProvinceColumn.Active, mock.Active.ToString());
				query.AppendEquals(ProvinceColumn.Deleted, mock.Deleted.ToString());
				
				TList<Province> results = DataRepository.ProvinceProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Province Entity with mock values.
		///</summary>
		static public Province CreateMockInstance_Generated(TransactionManager tm)
		{		
			Province mock = new Province();
						
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.ParentId = (long)TestUtility.Instance.RandomNumber();
			mock.PlateCode = TestUtility.Instance.RandomString(2, false);;
			mock.AreaId = TestUtility.Instance.RandomNumber();
			mock.PhoneCode = TestUtility.Instance.RandomString(3, false);;
			mock.ProvinceName = TestUtility.Instance.RandomString(124, false);;
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
			
		
			// create a temporary collection and add the item to it
			TList<Province> tempMockCollection = new TList<Province>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Province)mock;
		}
		
		
		///<summary>
		///  Update the Typed Province Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Province mock)
		{
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.ParentId = (long)TestUtility.Instance.RandomNumber();
			mock.PlateCode = TestUtility.Instance.RandomString(2, false);;
			mock.AreaId = TestUtility.Instance.RandomNumber();
			mock.PhoneCode = TestUtility.Instance.RandomString(3, false);;
			mock.ProvinceName = TestUtility.Instance.RandomString(124, false);;
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
			
		}
		#endregion
    }
}
