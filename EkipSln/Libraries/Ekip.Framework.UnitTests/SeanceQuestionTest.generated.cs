﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Haziran 2019 Salı
	Important: Do not modify this file. Edit the file SeanceQuestionTest.cs instead.
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
    /// Provides tests for the and <see cref="SeanceQuestion"/> objects (entity, collection and repository).
    /// </summary>
   public partial class SeanceQuestionTest
    {
    	// the SeanceQuestion instance used to test the repository.
		protected SeanceQuestion mock;
		
		// the TList<SeanceQuestion> instance used to test the repository.
		protected TList<SeanceQuestion> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the SeanceQuestion Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock SeanceQuestion entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SeanceQuestionProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.SeanceQuestionProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all SeanceQuestion objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.SeanceQuestionProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.SeanceQuestionProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.SeanceQuestionProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all SeanceQuestion children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.SeanceQuestionProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.SeanceQuestionProvider.DeepLoading += new EntityProviderBaseCore<SeanceQuestion, SeanceQuestionKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.SeanceQuestionProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("SeanceQuestion instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.SeanceQuestionProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock SeanceQuestion entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SeanceQuestion mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SeanceQuestionProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.SeanceQuestionProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.SeanceQuestionProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock SeanceQuestion entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (SeanceQuestion)CreateMockInstance(tm);
				DataRepository.SeanceQuestionProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.SeanceQuestionProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.SeanceQuestionProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock SeanceQuestion entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SeanceQuestion.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock SeanceQuestion entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SeanceQuestion.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<SeanceQuestion>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a SeanceQuestion collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SeanceQuestionCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<SeanceQuestion> mockCollection = new TList<SeanceQuestion>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<SeanceQuestion> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a SeanceQuestion collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SeanceQuestionCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<SeanceQuestion>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<SeanceQuestion> mockCollection = (TList<SeanceQuestion>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<SeanceQuestion> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SeanceQuestion entity = CreateMockInstance(tm);
				bool result = DataRepository.SeanceQuestionProvider.Insert(tm, entity);
				
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
				SeanceQuestion entity = CreateMockInstance(tm);
				bool result = DataRepository.SeanceQuestionProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				SeanceQuestion t0 = DataRepository.SeanceQuestionProvider.GetByQuestionId(tm, entity.QuestionId);
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
				
				SeanceQuestion entity = mock.Copy() as SeanceQuestion;
				entity = (SeanceQuestion)mock.Clone();
				Assert.IsTrue(SeanceQuestion.ValueEquals(entity, mock), "Clone is not working");
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
				SeanceQuestion mock = CreateMockInstance(tm);
				bool result = DataRepository.SeanceQuestionProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				SeanceQuestionQuery query = new SeanceQuestionQuery();
			
				query.AppendEquals(SeanceQuestionColumn.QuestionId, mock.QuestionId.ToString());
				query.AppendEquals(SeanceQuestionColumn.QuestionRef, mock.QuestionRef.ToString());
				query.AppendEquals(SeanceQuestionColumn.QuestionName, mock.QuestionName.ToString());
				query.AppendEquals(SeanceQuestionColumn.LineNumber, mock.LineNumber.ToString());
				query.AppendEquals(SeanceQuestionColumn.Status, mock.Status.ToString());
				
				TList<SeanceQuestion> results = DataRepository.SeanceQuestionProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed SeanceQuestion Entity with mock values.
		///</summary>
		static public SeanceQuestion CreateMockInstance_Generated(TransactionManager tm)
		{		
			SeanceQuestion mock = new SeanceQuestion();
						
			mock.QuestionRef = TestUtility.Instance.RandomString(10, false);;
			mock.QuestionName = TestUtility.Instance.RandomString(249, false);;
			mock.LineNumber = TestUtility.Instance.RandomNumber();
			mock.Status = TestUtility.Instance.RandomBoolean();
			
		
			// create a temporary collection and add the item to it
			TList<SeanceQuestion> tempMockCollection = new TList<SeanceQuestion>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (SeanceQuestion)mock;
		}
		
		
		///<summary>
		///  Update the Typed SeanceQuestion Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, SeanceQuestion mock)
		{
			mock.QuestionRef = TestUtility.Instance.RandomString(10, false);;
			mock.QuestionName = TestUtility.Instance.RandomString(249, false);;
			mock.LineNumber = TestUtility.Instance.RandomNumber();
			mock.Status = TestUtility.Instance.RandomBoolean();
			
		}
		#endregion
    }
}
