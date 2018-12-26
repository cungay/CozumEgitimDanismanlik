﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Aralık 2018 Salı
	Important: Do not modify this file. Edit the file ObservationFormAnswerTest.cs instead.
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
    /// Provides tests for the and <see cref="ObservationFormAnswer"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ObservationFormAnswerTest
    {
    	// the ObservationFormAnswer instance used to test the repository.
		protected ObservationFormAnswer mock;
		
		// the TList<ObservationFormAnswer> instance used to test the repository.
		protected TList<ObservationFormAnswer> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the ObservationFormAnswer Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ObservationFormAnswer entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ObservationFormAnswerProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ObservationFormAnswerProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all ObservationFormAnswer objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ObservationFormAnswerProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ObservationFormAnswerProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ObservationFormAnswerProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all ObservationFormAnswer children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ObservationFormAnswerProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ObservationFormAnswerProvider.DeepLoading += new EntityProviderBaseCore<ObservationFormAnswer, ObservationFormAnswerKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ObservationFormAnswerProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ObservationFormAnswer instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ObservationFormAnswerProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock ObservationFormAnswer entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ObservationFormAnswer mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ObservationFormAnswerProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ObservationFormAnswerProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ObservationFormAnswerProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock ObservationFormAnswer entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ObservationFormAnswer)CreateMockInstance(tm);
				DataRepository.ObservationFormAnswerProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ObservationFormAnswerProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ObservationFormAnswerProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ObservationFormAnswer entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormAnswer.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock ObservationFormAnswer entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormAnswer.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ObservationFormAnswer>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ObservationFormAnswer collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormAnswerCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<ObservationFormAnswer> mockCollection = new TList<ObservationFormAnswer>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ObservationFormAnswer> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a ObservationFormAnswer collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormAnswerCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ObservationFormAnswer>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ObservationFormAnswer> mockCollection = (TList<ObservationFormAnswer>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ObservationFormAnswer> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ObservationFormAnswer entity = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormAnswerProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<ObservationFormAnswer> t0 = DataRepository.ObservationFormAnswerProvider.GetByClientId(tm, entity.ClientId, 0, 10);
				TList<ObservationFormAnswer> t1 = DataRepository.ObservationFormAnswerProvider.GetByQuestionId(tm, entity.QuestionId, 0, 10);
				TList<ObservationFormAnswer> t2 = DataRepository.ObservationFormAnswerProvider.GetByOptionId(tm, entity.OptionId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ObservationFormAnswer entity = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormAnswerProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				ObservationFormAnswer t0 = DataRepository.ObservationFormAnswerProvider.GetByRowId(tm, entity.RowId);
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
				
				ObservationFormAnswer entity = mock.Copy() as ObservationFormAnswer;
				entity = (ObservationFormAnswer)mock.Clone();
				Assert.IsTrue(ObservationFormAnswer.ValueEquals(entity, mock), "Clone is not working");
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
				ObservationFormAnswer mock = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormAnswerProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ObservationFormAnswerQuery query = new ObservationFormAnswerQuery();
			
				query.AppendEquals(ObservationFormAnswerColumn.RowId, mock.RowId.ToString());
				query.AppendEquals(ObservationFormAnswerColumn.ClientId, mock.ClientId.ToString());
				query.AppendEquals(ObservationFormAnswerColumn.QuestionId, mock.QuestionId.ToString());
				query.AppendEquals(ObservationFormAnswerColumn.OptionId, mock.OptionId.ToString());
				if(mock.Description != null)
					query.AppendEquals(ObservationFormAnswerColumn.Description, mock.Description.ToString());
				query.AppendEquals(ObservationFormAnswerColumn.CreateOn, mock.CreateOn.ToString());
				if(mock.UpdateOn != null)
					query.AppendEquals(ObservationFormAnswerColumn.UpdateOn, mock.UpdateOn.ToString());
				
				TList<ObservationFormAnswer> results = DataRepository.ObservationFormAnswerProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed ObservationFormAnswer Entity with mock values.
		///</summary>
		static public ObservationFormAnswer CreateMockInstance_Generated(TransactionManager tm)
		{		
			ObservationFormAnswer mock = new ObservationFormAnswer();
						
			mock.Description = TestUtility.Instance.RandomString(2, false);;
			mock.CreateOn = TestUtility.Instance.RandomDateTime();
			mock.UpdateOn = TestUtility.Instance.RandomDateTime();
			
			//OneToOneRelationship
			Client mockClientByClientId = ClientTest.CreateMockInstance(tm);
			DataRepository.ClientProvider.Insert(tm, mockClientByClientId);
			mock.ClientId = mockClientByClientId.ClientId;
			//OneToOneRelationship
			ObservationForm mockObservationFormByQuestionId = ObservationFormTest.CreateMockInstance(tm);
			DataRepository.ObservationFormProvider.Insert(tm, mockObservationFormByQuestionId);
			mock.QuestionId = mockObservationFormByQuestionId.QuestionId;
			//OneToOneRelationship
			ObservationFormOption mockObservationFormOptionByOptionId = ObservationFormOptionTest.CreateMockInstance(tm);
			DataRepository.ObservationFormOptionProvider.Insert(tm, mockObservationFormOptionByOptionId);
			mock.OptionId = mockObservationFormOptionByOptionId.OptionId;
		
			// create a temporary collection and add the item to it
			TList<ObservationFormAnswer> tempMockCollection = new TList<ObservationFormAnswer>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (ObservationFormAnswer)mock;
		}
		
		
		///<summary>
		///  Update the Typed ObservationFormAnswer Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ObservationFormAnswer mock)
		{
			mock.Description = TestUtility.Instance.RandomString(2, false);;
			mock.CreateOn = TestUtility.Instance.RandomDateTime();
			mock.UpdateOn = TestUtility.Instance.RandomDateTime();
			
			//OneToOneRelationship
			Client mockClientByClientId = ClientTest.CreateMockInstance(tm);
			DataRepository.ClientProvider.Insert(tm, mockClientByClientId);
			mock.ClientId = mockClientByClientId.ClientId;
					
			//OneToOneRelationship
			ObservationForm mockObservationFormByQuestionId = ObservationFormTest.CreateMockInstance(tm);
			DataRepository.ObservationFormProvider.Insert(tm, mockObservationFormByQuestionId);
			mock.QuestionId = mockObservationFormByQuestionId.QuestionId;
					
			//OneToOneRelationship
			ObservationFormOption mockObservationFormOptionByOptionId = ObservationFormOptionTest.CreateMockInstance(tm);
			DataRepository.ObservationFormOptionProvider.Insert(tm, mockObservationFormOptionByOptionId);
			mock.OptionId = mockObservationFormOptionByOptionId.OptionId;
					
		}
		#endregion
    }
}
