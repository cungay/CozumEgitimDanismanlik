﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 15 Ocak 2019 Salı
	Important: Do not modify this file. Edit the file ObservationFormTest.cs instead.
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
    /// Provides tests for the and <see cref="ObservationForm"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ObservationFormTest
    {
    	// the ObservationForm instance used to test the repository.
		protected ObservationForm mock;
		
		// the TList<ObservationForm> instance used to test the repository.
		protected TList<ObservationForm> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the ObservationForm Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock ObservationForm entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ObservationFormProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ObservationFormProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all ObservationForm objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ObservationFormProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ObservationFormProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ObservationFormProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all ObservationForm children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ObservationFormProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ObservationFormProvider.DeepLoading += new EntityProviderBaseCore<ObservationForm, ObservationFormKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ObservationFormProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("ObservationForm instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ObservationFormProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock ObservationForm entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ObservationForm mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ObservationFormProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ObservationFormProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ObservationFormProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock ObservationForm entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (ObservationForm)CreateMockInstance(tm);
				DataRepository.ObservationFormProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ObservationFormProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ObservationFormProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ObservationForm entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationForm.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock ObservationForm entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationForm.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<ObservationForm>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ObservationForm collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<ObservationForm> mockCollection = new TList<ObservationForm>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<ObservationForm> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a ObservationForm collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ObservationFormCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<ObservationForm>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<ObservationForm> mockCollection = (TList<ObservationForm>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<ObservationForm> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ObservationForm entity = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<ObservationForm> t0 = DataRepository.ObservationFormProvider.GetByGroupId(tm, entity.GroupId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				ObservationForm entity = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				ObservationForm t0 = DataRepository.ObservationFormProvider.GetByQuestionId(tm, entity.QuestionId);
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
				
				ObservationForm entity = mock.Copy() as ObservationForm;
				entity = (ObservationForm)mock.Clone();
				Assert.IsTrue(ObservationForm.ValueEquals(entity, mock), "Clone is not working");
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
				ObservationForm mock = CreateMockInstance(tm);
				bool result = DataRepository.ObservationFormProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ObservationFormQuery query = new ObservationFormQuery();
			
				query.AppendEquals(ObservationFormColumn.QuestionId, mock.QuestionId.ToString());
				if(mock.GroupId != null)
					query.AppendEquals(ObservationFormColumn.GroupId, mock.GroupId.ToString());
				if(mock.QuestionRef != null)
					query.AppendEquals(ObservationFormColumn.QuestionRef, mock.QuestionRef.ToString());
				query.AppendEquals(ObservationFormColumn.QuestionName, mock.QuestionName.ToString());
				query.AppendEquals(ObservationFormColumn.LineNumber, mock.LineNumber.ToString());
				query.AppendEquals(ObservationFormColumn.Status, mock.Status.ToString());
				query.AppendEquals(ObservationFormColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(ObservationFormColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(ObservationFormColumn.Active, mock.Active.ToString());
				query.AppendEquals(ObservationFormColumn.Deleted, mock.Deleted.ToString());
				
				TList<ObservationForm> results = DataRepository.ObservationFormProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed ObservationForm Entity with mock values.
		///</summary>
		static public ObservationForm CreateMockInstance_Generated(TransactionManager tm)
		{		
			ObservationForm mock = new ObservationForm();
						
			mock.QuestionRef = TestUtility.Instance.RandomString(10, false);;
			mock.QuestionName = TestUtility.Instance.RandomString(249, false);;
			mock.LineNumber = TestUtility.Instance.RandomNumber();
			mock.Status = TestUtility.Instance.RandomBoolean();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<ObservationFormGroup> _collection0 = DataRepository.ObservationFormGroupProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.GroupId = _collection0[0].GroupId;
						
			}
		
			// create a temporary collection and add the item to it
			TList<ObservationForm> tempMockCollection = new TList<ObservationForm>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (ObservationForm)mock;
		}
		
		
		///<summary>
		///  Update the Typed ObservationForm Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, ObservationForm mock)
		{
			mock.QuestionRef = TestUtility.Instance.RandomString(10, false);;
			mock.QuestionName = TestUtility.Instance.RandomString(249, false);;
			mock.LineNumber = TestUtility.Instance.RandomNumber();
			mock.Status = TestUtility.Instance.RandomBoolean();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<ObservationFormGroup> _collection0 = DataRepository.ObservationFormGroupProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.GroupId = _collection0[0].GroupId;
			}
		}
		#endregion
    }
}