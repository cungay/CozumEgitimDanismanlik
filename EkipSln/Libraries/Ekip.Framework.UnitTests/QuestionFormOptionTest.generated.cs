﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 13 Şubat 2019 Çarşamba
	Important: Do not modify this file. Edit the file QuestionFormOptionTest.cs instead.
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
    /// Provides tests for the and <see cref="QuestionFormOption"/> objects (entity, collection and repository).
    /// </summary>
   public partial class QuestionFormOptionTest
    {
    	// the QuestionFormOption instance used to test the repository.
		protected QuestionFormOption mock;
		
		// the TList<QuestionFormOption> instance used to test the repository.
		protected TList<QuestionFormOption> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the QuestionFormOption Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock QuestionFormOption entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.QuestionFormOptionProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.QuestionFormOptionProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all QuestionFormOption objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.QuestionFormOptionProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.QuestionFormOptionProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.QuestionFormOptionProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all QuestionFormOption children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.QuestionFormOptionProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.QuestionFormOptionProvider.DeepLoading += new EntityProviderBaseCore<QuestionFormOption, QuestionFormOptionKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.QuestionFormOptionProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("QuestionFormOption instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.QuestionFormOptionProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock QuestionFormOption entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				QuestionFormOption mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.QuestionFormOptionProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.QuestionFormOptionProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.QuestionFormOptionProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock QuestionFormOption entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (QuestionFormOption)CreateMockInstance(tm);
				DataRepository.QuestionFormOptionProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.QuestionFormOptionProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.QuestionFormOptionProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock QuestionFormOption entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormOption.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock QuestionFormOption entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormOption.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<QuestionFormOption>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a QuestionFormOption collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormOptionCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<QuestionFormOption> mockCollection = new TList<QuestionFormOption>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<QuestionFormOption> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a QuestionFormOption collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormOptionCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<QuestionFormOption>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<QuestionFormOption> mockCollection = (TList<QuestionFormOption>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<QuestionFormOption> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				QuestionFormOption entity = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormOptionProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<QuestionFormOption> t0 = DataRepository.QuestionFormOptionProvider.GetByQuestionId(tm, entity.QuestionId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				QuestionFormOption entity = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormOptionProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				QuestionFormOption t0 = DataRepository.QuestionFormOptionProvider.GetByOptionId(tm, entity.OptionId);
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
				
				QuestionFormOption entity = mock.Copy() as QuestionFormOption;
				entity = (QuestionFormOption)mock.Clone();
				Assert.IsTrue(QuestionFormOption.ValueEquals(entity, mock), "Clone is not working");
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
				QuestionFormOption mock = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormOptionProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				QuestionFormOptionQuery query = new QuestionFormOptionQuery();
			
				query.AppendEquals(QuestionFormOptionColumn.OptionId, mock.OptionId.ToString());
				query.AppendEquals(QuestionFormOptionColumn.QuestionId, mock.QuestionId.ToString());
				query.AppendEquals(QuestionFormOptionColumn.OptionName, mock.OptionName.ToString());
				query.AppendEquals(QuestionFormOptionColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(QuestionFormOptionColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(QuestionFormOptionColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(QuestionFormOptionColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(QuestionFormOptionColumn.Active, mock.Active.ToString());
				query.AppendEquals(QuestionFormOptionColumn.Deleted, mock.Deleted.ToString());
				
				TList<QuestionFormOption> results = DataRepository.QuestionFormOptionProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed QuestionFormOption Entity with mock values.
		///</summary>
		static public QuestionFormOption CreateMockInstance_Generated(TransactionManager tm)
		{		
			QuestionFormOption mock = new QuestionFormOption();
						
			mock.OptionName = TestUtility.Instance.RandomString(149, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<QuestionForm> _collection0 = DataRepository.QuestionFormProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.QuestionId = _collection0[0].QuestionId;
						
			}
		
			// create a temporary collection and add the item to it
			TList<QuestionFormOption> tempMockCollection = new TList<QuestionFormOption>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (QuestionFormOption)mock;
		}
		
		
		///<summary>
		///  Update the Typed QuestionFormOption Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, QuestionFormOption mock)
		{
			mock.OptionName = TestUtility.Instance.RandomString(149, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<QuestionForm> _collection0 = DataRepository.QuestionFormProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.QuestionId = _collection0[0].QuestionId;
			}
		}
		#endregion
    }
}
