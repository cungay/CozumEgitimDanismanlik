﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Haziran 2019 Salı
	Important: Do not modify this file. Edit the file SchoolTest.cs instead.
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
    /// Provides tests for the and <see cref="School"/> objects (entity, collection and repository).
    /// </summary>
   public partial class SchoolTest
    {
    	// the School instance used to test the repository.
		protected School mock;
		
		// the TList<School> instance used to test the repository.
		protected TList<School> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the School Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock School entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SchoolProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.SchoolProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all School objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.SchoolProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.SchoolProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.SchoolProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all School children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.SchoolProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.SchoolProvider.DeepLoading += new EntityProviderBaseCore<School, SchoolKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.SchoolProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("School instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.SchoolProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock School entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				School mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SchoolProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.SchoolProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.SchoolProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock School entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (School)CreateMockInstance(tm);
				DataRepository.SchoolProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.SchoolProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.SchoolProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock School entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_School.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock School entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_School.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<School>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a School collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SchoolCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<School> mockCollection = new TList<School>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<School> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a School collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SchoolCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<School>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<School> mockCollection = (TList<School>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<School> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				School entity = CreateMockInstance(tm);
				bool result = DataRepository.SchoolProvider.Insert(tm, entity);
				
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
				School entity = CreateMockInstance(tm);
				bool result = DataRepository.SchoolProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				School t0 = DataRepository.SchoolProvider.GetBySchoolId(tm, entity.SchoolId);
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
				
				School entity = mock.Copy() as School;
				entity = (School)mock.Clone();
				Assert.IsTrue(School.ValueEquals(entity, mock), "Clone is not working");
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
				School mock = CreateMockInstance(tm);
				bool result = DataRepository.SchoolProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				SchoolQuery query = new SchoolQuery();
			
				query.AppendEquals(SchoolColumn.SchoolId, mock.SchoolId.ToString());
				query.AppendEquals(SchoolColumn.SchoolName, mock.SchoolName.ToString());
				query.AppendEquals(SchoolColumn.CorparationTypeId, mock.CorparationTypeId.ToString());
				query.AppendEquals(SchoolColumn.SchoolTypeId, mock.SchoolTypeId.ToString());
				if(mock.ProvinceId != null)
					query.AppendEquals(SchoolColumn.ProvinceId, mock.ProvinceId.ToString());
				if(mock.TownId != null)
					query.AppendEquals(SchoolColumn.TownId, mock.TownId.ToString());
				if(mock.Address != null)
					query.AppendEquals(SchoolColumn.Address, mock.Address.ToString());
				if(mock.Phone != null)
					query.AppendEquals(SchoolColumn.Phone, mock.Phone.ToString());
				if(mock.Fax != null)
					query.AppendEquals(SchoolColumn.Fax, mock.Fax.ToString());
				if(mock.WebAddress != null)
					query.AppendEquals(SchoolColumn.WebAddress, mock.WebAddress.ToString());
				if(mock.Notes != null)
					query.AppendEquals(SchoolColumn.Notes, mock.Notes.ToString());
				query.AppendEquals(SchoolColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(SchoolColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(SchoolColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(SchoolColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(SchoolColumn.Active, mock.Active.ToString());
				query.AppendEquals(SchoolColumn.Deleted, mock.Deleted.ToString());
				
				TList<School> results = DataRepository.SchoolProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed School Entity with mock values.
		///</summary>
		static public School CreateMockInstance_Generated(TransactionManager tm)
		{		
			School mock = new School();
						
			mock.SchoolName = TestUtility.Instance.RandomString(49, false);;
			mock.CorparationTypeId = TestUtility.Instance.RandomByte();
			mock.SchoolTypeId = TestUtility.Instance.RandomByte();
			mock.ProvinceId = TestUtility.Instance.RandomNumber();
			mock.TownId = TestUtility.Instance.RandomNumber();
			mock.Address = TestUtility.Instance.RandomString(249, false);;
			mock.Phone = TestUtility.Instance.RandomString(6, false);;
			mock.Fax = TestUtility.Instance.RandomString(6, false);;
			mock.WebAddress = TestUtility.Instance.RandomString(49, false);;
			mock.Notes = TestUtility.Instance.RandomString(2, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
		
			// create a temporary collection and add the item to it
			TList<School> tempMockCollection = new TList<School>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (School)mock;
		}
		
		
		///<summary>
		///  Update the Typed School Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, School mock)
		{
			mock.SchoolName = TestUtility.Instance.RandomString(49, false);;
			mock.CorparationTypeId = TestUtility.Instance.RandomByte();
			mock.SchoolTypeId = TestUtility.Instance.RandomByte();
			mock.ProvinceId = TestUtility.Instance.RandomNumber();
			mock.TownId = TestUtility.Instance.RandomNumber();
			mock.Address = TestUtility.Instance.RandomString(249, false);;
			mock.Phone = TestUtility.Instance.RandomString(6, false);;
			mock.Fax = TestUtility.Instance.RandomString(6, false);;
			mock.WebAddress = TestUtility.Instance.RandomString(49, false);;
			mock.Notes = TestUtility.Instance.RandomString(2, false);;
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
