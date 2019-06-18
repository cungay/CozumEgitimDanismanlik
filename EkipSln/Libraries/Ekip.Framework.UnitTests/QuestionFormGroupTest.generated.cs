﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Haziran 2019 Salı
	Important: Do not modify this file. Edit the file QuestionFormGroupTest.cs instead.
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
    /// Provides tests for the and <see cref="QuestionFormGroup"/> objects (entity, collection and repository).
    /// </summary>
   public partial class QuestionFormGroupTest
    {
    	// the QuestionFormGroup instance used to test the repository.
		protected QuestionFormGroup mock;
		
		// the TList<QuestionFormGroup> instance used to test the repository.
		protected TList<QuestionFormGroup> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the QuestionFormGroup Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock QuestionFormGroup entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.QuestionFormGroupProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.QuestionFormGroupProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all QuestionFormGroup objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.QuestionFormGroupProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.QuestionFormGroupProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.QuestionFormGroupProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all QuestionFormGroup children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.QuestionFormGroupProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.QuestionFormGroupProvider.DeepLoading += new EntityProviderBaseCore<QuestionFormGroup, QuestionFormGroupKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.QuestionFormGroupProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("QuestionFormGroup instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.QuestionFormGroupProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock QuestionFormGroup entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				QuestionFormGroup mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.QuestionFormGroupProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.QuestionFormGroupProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.QuestionFormGroupProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock QuestionFormGroup entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (QuestionFormGroup)CreateMockInstance(tm);
				DataRepository.QuestionFormGroupProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.QuestionFormGroupProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.QuestionFormGroupProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock QuestionFormGroup entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormGroup.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock QuestionFormGroup entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormGroup.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<QuestionFormGroup>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a QuestionFormGroup collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormGroupCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<QuestionFormGroup> mockCollection = new TList<QuestionFormGroup>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<QuestionFormGroup> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a QuestionFormGroup collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormGroupCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<QuestionFormGroup>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<QuestionFormGroup> mockCollection = (TList<QuestionFormGroup>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<QuestionFormGroup> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				QuestionFormGroup entity = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormGroupProvider.Insert(tm, entity);
				
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
				QuestionFormGroup entity = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormGroupProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				QuestionFormGroup t0 = DataRepository.QuestionFormGroupProvider.GetByGroupId(tm, entity.GroupId);
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
				
				QuestionFormGroup entity = mock.Copy() as QuestionFormGroup;
				entity = (QuestionFormGroup)mock.Clone();
				Assert.IsTrue(QuestionFormGroup.ValueEquals(entity, mock), "Clone is not working");
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
				QuestionFormGroup mock = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormGroupProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				QuestionFormGroupQuery query = new QuestionFormGroupQuery();
			
				query.AppendEquals(QuestionFormGroupColumn.GroupId, mock.GroupId.ToString());
				query.AppendEquals(QuestionFormGroupColumn.GroupName, mock.GroupName.ToString());
				query.AppendEquals(QuestionFormGroupColumn.LineNumber, mock.LineNumber.ToString());
				query.AppendEquals(QuestionFormGroupColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(QuestionFormGroupColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(QuestionFormGroupColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(QuestionFormGroupColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(QuestionFormGroupColumn.Active, mock.Active.ToString());
				query.AppendEquals(QuestionFormGroupColumn.Deleted, mock.Deleted.ToString());
				
				TList<QuestionFormGroup> results = DataRepository.QuestionFormGroupProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed QuestionFormGroup Entity with mock values.
		///</summary>
		static public QuestionFormGroup CreateMockInstance_Generated(TransactionManager tm)
		{		
			QuestionFormGroup mock = new QuestionFormGroup();
						
			mock.GroupName = TestUtility.Instance.RandomString(124, false);;
			mock.LineNumber = TestUtility.Instance.RandomNumber();
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
		
			// create a temporary collection and add the item to it
			TList<QuestionFormGroup> tempMockCollection = new TList<QuestionFormGroup>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (QuestionFormGroup)mock;
		}
		
		
		///<summary>
		///  Update the Typed QuestionFormGroup Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, QuestionFormGroup mock)
		{
			mock.GroupName = TestUtility.Instance.RandomString(124, false);;
			mock.LineNumber = TestUtility.Instance.RandomNumber();
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
