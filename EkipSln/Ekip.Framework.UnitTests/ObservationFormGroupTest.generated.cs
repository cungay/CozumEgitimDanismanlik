﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Aralık 2018 Salı
	Important: Do not modify this file. Edit the file ObservationFormGroupTest.cs instead.
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
    /// Provides tests for the and <see cref="ObservationFormGroup"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ObservationFormGroupTest
    {
    	// the ObservationFormGroup instance used to test the repository.
		protected ObservationFormGroup mock;
		
		// the TList<ObservationFormGroup> instance used to test the repository.
		protected TList<ObservationFormGroup> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the ObservationFormGroup Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ObservationFormGroup entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ObservationFormGroupProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ObservationFormGroupProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all ObservationFormGroup objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ObservationFormGroupProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ObservationFormGroupProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ObservationFormGroupProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all ObservationFormGroup children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ObservationFormGroupProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ObservationFormGroupProvider.DeepLoading += new EntityProviderBaseCore<ObservationFormGroup, ObservationFormGroupKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ObservationFormGroupProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ObservationFormGroup instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ObservationFormGroupProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock ObservationFormGroup entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ObservationFormGroup mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ObservationFormGroupProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ObservationFormGroupProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ObservationFormGroupProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock ObservationFormGroup entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ObservationFormGroup)CreateMockInstance(tm);
				DataRepository.ObservationFormGroupProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ObservationFormGroupProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ObservationFormGroupProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ObservationFormGroup entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormGroup.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock ObservationFormGroup entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormGroup.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ObservationFormGroup>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ObservationFormGroup collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormGroupCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<ObservationFormGroup> mockCollection = new TList<ObservationFormGroup>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ObservationFormGroup> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a ObservationFormGroup collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormGroupCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ObservationFormGroup>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ObservationFormGroup> mockCollection = (TList<ObservationFormGroup>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ObservationFormGroup> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ObservationFormGroup entity = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormGroupProvider.Insert(tm, entity);
				
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
				ObservationFormGroup entity = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormGroupProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				ObservationFormGroup t0 = DataRepository.ObservationFormGroupProvider.GetByGroupId(tm, entity.GroupId);
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
				
				ObservationFormGroup entity = mock.Copy() as ObservationFormGroup;
				entity = (ObservationFormGroup)mock.Clone();
				Assert.IsTrue(ObservationFormGroup.ValueEquals(entity, mock), "Clone is not working");
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
				ObservationFormGroup mock = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormGroupProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ObservationFormGroupQuery query = new ObservationFormGroupQuery();
			
				query.AppendEquals(ObservationFormGroupColumn.GroupId, mock.GroupId.ToString());
				query.AppendEquals(ObservationFormGroupColumn.GroupName, mock.GroupName.ToString());
				query.AppendEquals(ObservationFormGroupColumn.LineNumber, mock.LineNumber.ToString());
				
				TList<ObservationFormGroup> results = DataRepository.ObservationFormGroupProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed ObservationFormGroup Entity with mock values.
		///</summary>
		static public ObservationFormGroup CreateMockInstance_Generated(TransactionManager tm)
		{		
			ObservationFormGroup mock = new ObservationFormGroup();
						
			mock.GroupName = TestUtility.Instance.RandomString(124, false);;
			mock.LineNumber = TestUtility.Instance.RandomNumber();
			
		
			// create a temporary collection and add the item to it
			TList<ObservationFormGroup> tempMockCollection = new TList<ObservationFormGroup>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (ObservationFormGroup)mock;
		}
		
		
		///<summary>
		///  Update the Typed ObservationFormGroup Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ObservationFormGroup mock)
		{
			mock.GroupName = TestUtility.Instance.RandomString(124, false);;
			mock.LineNumber = TestUtility.Instance.RandomNumber();
			
		}
		#endregion
    }
}
