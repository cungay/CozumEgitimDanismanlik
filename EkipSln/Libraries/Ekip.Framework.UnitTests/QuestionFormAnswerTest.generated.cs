﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 13 Şubat 2019 Çarşamba
	Important: Do not modify this file. Edit the file QuestionFormAnswerTest.cs instead.
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
    /// Provides tests for the and <see cref="QuestionFormAnswer"/> objects (entity, collection and repository).
    /// </summary>
   public partial class QuestionFormAnswerTest
    {
    	// the QuestionFormAnswer instance used to test the repository.
		protected QuestionFormAnswer mock;
		
		// the TList<QuestionFormAnswer> instance used to test the repository.
		protected TList<QuestionFormAnswer> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the QuestionFormAnswer Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock QuestionFormAnswer entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.QuestionFormAnswerProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.QuestionFormAnswerProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all QuestionFormAnswer objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.QuestionFormAnswerProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.QuestionFormAnswerProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.QuestionFormAnswerProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all QuestionFormAnswer children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.QuestionFormAnswerProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.QuestionFormAnswerProvider.DeepLoading += new EntityProviderBaseCore<QuestionFormAnswer, QuestionFormAnswerKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.QuestionFormAnswerProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("QuestionFormAnswer instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.QuestionFormAnswerProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock QuestionFormAnswer entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				QuestionFormAnswer mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.QuestionFormAnswerProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.QuestionFormAnswerProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.QuestionFormAnswerProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock QuestionFormAnswer entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (QuestionFormAnswer)CreateMockInstance(tm);
				DataRepository.QuestionFormAnswerProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.QuestionFormAnswerProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.QuestionFormAnswerProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock QuestionFormAnswer entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormAnswer.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock QuestionFormAnswer entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormAnswer.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<QuestionFormAnswer>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a QuestionFormAnswer collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormAnswerCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<QuestionFormAnswer> mockCollection = new TList<QuestionFormAnswer>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<QuestionFormAnswer> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a QuestionFormAnswer collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_QuestionFormAnswerCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<QuestionFormAnswer>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<QuestionFormAnswer> mockCollection = (TList<QuestionFormAnswer>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<QuestionFormAnswer> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				QuestionFormAnswer entity = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormAnswerProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<QuestionFormAnswer> t0 = DataRepository.QuestionFormAnswerProvider.GetByClientId(tm, entity.ClientId, 0, 10);
				TList<QuestionFormAnswer> t1 = DataRepository.QuestionFormAnswerProvider.GetByQuestionId(tm, entity.QuestionId, 0, 10);
				TList<QuestionFormAnswer> t2 = DataRepository.QuestionFormAnswerProvider.GetByOptionId(tm, entity.OptionId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				QuestionFormAnswer entity = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormAnswerProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				QuestionFormAnswer t0 = DataRepository.QuestionFormAnswerProvider.GetByRowId(tm, entity.RowId);
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
				
				QuestionFormAnswer entity = mock.Copy() as QuestionFormAnswer;
				entity = (QuestionFormAnswer)mock.Clone();
				Assert.IsTrue(QuestionFormAnswer.ValueEquals(entity, mock), "Clone is not working");
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
				QuestionFormAnswer mock = CreateMockInstance(tm);
				bool result = DataRepository.QuestionFormAnswerProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				QuestionFormAnswerQuery query = new QuestionFormAnswerQuery();
			
				query.AppendEquals(QuestionFormAnswerColumn.RowId, mock.RowId.ToString());
				query.AppendEquals(QuestionFormAnswerColumn.ClientId, mock.ClientId.ToString());
				query.AppendEquals(QuestionFormAnswerColumn.QuestionId, mock.QuestionId.ToString());
				query.AppendEquals(QuestionFormAnswerColumn.OptionId, mock.OptionId.ToString());
				if(mock.Description != null)
					query.AppendEquals(QuestionFormAnswerColumn.Description, mock.Description.ToString());
				query.AppendEquals(QuestionFormAnswerColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(QuestionFormAnswerColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(QuestionFormAnswerColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(QuestionFormAnswerColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(QuestionFormAnswerColumn.Active, mock.Active.ToString());
				query.AppendEquals(QuestionFormAnswerColumn.Deleted, mock.Deleted.ToString());
				
				TList<QuestionFormAnswer> results = DataRepository.QuestionFormAnswerProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed QuestionFormAnswer Entity with mock values.
		///</summary>
		static public QuestionFormAnswer CreateMockInstance_Generated(TransactionManager tm)
		{		
			QuestionFormAnswer mock = new QuestionFormAnswer();
						
			mock.Description = TestUtility.Instance.RandomString(2, false);;
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
			QuestionForm mockQuestionFormByQuestionId = QuestionFormTest.CreateMockInstance(tm);
			DataRepository.QuestionFormProvider.Insert(tm, mockQuestionFormByQuestionId);
			mock.QuestionId = mockQuestionFormByQuestionId.QuestionId;
			//OneToOneRelationship
			QuestionFormOption mockQuestionFormOptionByOptionId = QuestionFormOptionTest.CreateMockInstance(tm);
			DataRepository.QuestionFormOptionProvider.Insert(tm, mockQuestionFormOptionByOptionId);
			mock.OptionId = mockQuestionFormOptionByOptionId.OptionId;
		
			// create a temporary collection and add the item to it
			TList<QuestionFormAnswer> tempMockCollection = new TList<QuestionFormAnswer>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (QuestionFormAnswer)mock;
		}
		
		
		///<summary>
		///  Update the Typed QuestionFormAnswer Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, QuestionFormAnswer mock)
		{
			mock.Description = TestUtility.Instance.RandomString(2, false);;
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
			QuestionForm mockQuestionFormByQuestionId = QuestionFormTest.CreateMockInstance(tm);
			DataRepository.QuestionFormProvider.Insert(tm, mockQuestionFormByQuestionId);
			mock.QuestionId = mockQuestionFormByQuestionId.QuestionId;
					
			//OneToOneRelationship
			QuestionFormOption mockQuestionFormOptionByOptionId = QuestionFormOptionTest.CreateMockInstance(tm);
			DataRepository.QuestionFormOptionProvider.Insert(tm, mockQuestionFormOptionByOptionId);
			mock.OptionId = mockQuestionFormOptionByOptionId.OptionId;
					
		}
		#endregion
    }
}
