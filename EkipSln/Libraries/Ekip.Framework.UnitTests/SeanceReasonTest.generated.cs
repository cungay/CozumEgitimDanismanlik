﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 5 Şubat 2019 Salı
	Important: Do not modify this file. Edit the file SeanceReasonTest.cs instead.
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
    /// Provides tests for the and <see cref="SeanceReason"/> objects (entity, collection and repository).
    /// </summary>
   public partial class SeanceReasonTest
    {
    	// the SeanceReason instance used to test the repository.
		protected SeanceReason mock;
		
		// the TList<SeanceReason> instance used to test the repository.
		protected TList<SeanceReason> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the SeanceReason Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock SeanceReason entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SeanceReasonProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.SeanceReasonProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all SeanceReason objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.SeanceReasonProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.SeanceReasonProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.SeanceReasonProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all SeanceReason children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.SeanceReasonProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.SeanceReasonProvider.DeepLoading += new EntityProviderBaseCore<SeanceReason, SeanceReasonKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.SeanceReasonProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("SeanceReason instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.SeanceReasonProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock SeanceReason entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SeanceReason mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SeanceReasonProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.SeanceReasonProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.SeanceReasonProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock SeanceReason entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (SeanceReason)CreateMockInstance(tm);
				DataRepository.SeanceReasonProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.SeanceReasonProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.SeanceReasonProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock SeanceReason entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SeanceReason.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock SeanceReason entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SeanceReason.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<SeanceReason>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a SeanceReason collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SeanceReasonCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<SeanceReason> mockCollection = new TList<SeanceReason>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<SeanceReason> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a SeanceReason collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SeanceReasonCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<SeanceReason>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<SeanceReason> mockCollection = (TList<SeanceReason>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<SeanceReason> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SeanceReason entity = CreateMockInstance(tm);
				bool result = DataRepository.SeanceReasonProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<SeanceReason> t0 = DataRepository.SeanceReasonProvider.GetByReasonId(tm, entity.ReasonId, 0, 10);
				TList<SeanceReason> t1 = DataRepository.SeanceReasonProvider.GetBySeanceId(tm, entity.SeanceId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SeanceReason entity = CreateMockInstance(tm);
				bool result = DataRepository.SeanceReasonProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				SeanceReason t0 = DataRepository.SeanceReasonProvider.GetByRowId(tm, entity.RowId);
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
				
				SeanceReason entity = mock.Copy() as SeanceReason;
				entity = (SeanceReason)mock.Clone();
				Assert.IsTrue(SeanceReason.ValueEquals(entity, mock), "Clone is not working");
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
				SeanceReason mock = CreateMockInstance(tm);
				bool result = DataRepository.SeanceReasonProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				SeanceReasonQuery query = new SeanceReasonQuery();
			
				query.AppendEquals(SeanceReasonColumn.RowId, mock.RowId.ToString());
				if(mock.SeanceId != null)
					query.AppendEquals(SeanceReasonColumn.SeanceId, mock.SeanceId.ToString());
				if(mock.ReasonId != null)
					query.AppendEquals(SeanceReasonColumn.ReasonId, mock.ReasonId.ToString());
				
				TList<SeanceReason> results = DataRepository.SeanceReasonProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed SeanceReason Entity with mock values.
		///</summary>
		static public SeanceReason CreateMockInstance_Generated(TransactionManager tm)
		{		
			SeanceReason mock = new SeanceReason();
						
			
			//OneToOneRelationship
			Reason mockReasonByReasonId = ReasonTest.CreateMockInstance(tm);
			DataRepository.ReasonProvider.Insert(tm, mockReasonByReasonId);
			mock.ReasonId = mockReasonByReasonId.ReasonId;
			//OneToOneRelationship
			Seance mockSeanceBySeanceId = SeanceTest.CreateMockInstance(tm);
			DataRepository.SeanceProvider.Insert(tm, mockSeanceBySeanceId);
			mock.SeanceId = mockSeanceBySeanceId.SeanceId;
		
			// create a temporary collection and add the item to it
			TList<SeanceReason> tempMockCollection = new TList<SeanceReason>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (SeanceReason)mock;
		}
		
		
		///<summary>
		///  Update the Typed SeanceReason Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, SeanceReason mock)
		{
			
			//OneToOneRelationship
			Reason mockReasonByReasonId = ReasonTest.CreateMockInstance(tm);
			DataRepository.ReasonProvider.Insert(tm, mockReasonByReasonId);
			mock.ReasonId = mockReasonByReasonId.ReasonId;
					
			//OneToOneRelationship
			Seance mockSeanceBySeanceId = SeanceTest.CreateMockInstance(tm);
			DataRepository.SeanceProvider.Insert(tm, mockSeanceBySeanceId);
			mock.SeanceId = mockSeanceBySeanceId.SeanceId;
					
		}
		#endregion
    }
}
