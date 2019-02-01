﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 1 Şubat 2019 Cuma
	Important: Do not modify this file. Edit the file WiscrTest.cs instead.
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
    /// Provides tests for the and <see cref="Wiscr"/> objects (entity, collection and repository).
    /// </summary>
   public partial class WiscrTest
    {
    	// the Wiscr instance used to test the repository.
		protected Wiscr mock;
		
		// the TList<Wiscr> instance used to test the repository.
		protected TList<Wiscr> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the Wiscr Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock Wiscr entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.WiscrProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.WiscrProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Wiscr objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.WiscrProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.WiscrProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.WiscrProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Wiscr children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.WiscrProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.WiscrProvider.DeepLoading += new EntityProviderBaseCore<Wiscr, WiscrKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.WiscrProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Wiscr instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.WiscrProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Wiscr entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Wiscr mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.WiscrProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.WiscrProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.WiscrProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Wiscr entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Wiscr)CreateMockInstance(tm);
				DataRepository.WiscrProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.WiscrProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.WiscrProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Wiscr entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Wiscr.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Wiscr entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Wiscr.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Wiscr>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Wiscr collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_WiscrCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Wiscr> mockCollection = new TList<Wiscr>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Wiscr> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Wiscr collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_WiscrCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Wiscr>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Wiscr> mockCollection = (TList<Wiscr>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Wiscr> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Wiscr entity = CreateMockInstance(tm);
				bool result = DataRepository.WiscrProvider.Insert(tm, entity);
				
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
				Wiscr entity = CreateMockInstance(tm);
				bool result = DataRepository.WiscrProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				Wiscr t0 = DataRepository.WiscrProvider.GetByWiscrId(tm, entity.WiscrId);
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
				
				Wiscr entity = mock.Copy() as Wiscr;
				entity = (Wiscr)mock.Clone();
				Assert.IsTrue(Wiscr.ValueEquals(entity, mock), "Clone is not working");
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
				Wiscr mock = CreateMockInstance(tm);
				bool result = DataRepository.WiscrProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				WiscrQuery query = new WiscrQuery();
			
				query.AppendEquals(WiscrColumn.WiscrId, mock.WiscrId.ToString());
				if(mock.SeanceId != null)
					query.AppendEquals(WiscrColumn.SeanceId, mock.SeanceId.ToString());
				if(mock.GeneralRawScore != null)
					query.AppendEquals(WiscrColumn.GeneralRawScore, mock.GeneralRawScore.ToString());
				if(mock.GeneralStandartScore != null)
					query.AppendEquals(WiscrColumn.GeneralStandartScore, mock.GeneralStandartScore.ToString());
				if(mock.SimilarityRawScore != null)
					query.AppendEquals(WiscrColumn.SimilarityRawScore, mock.SimilarityRawScore.ToString());
				if(mock.SimilarityStandartScore != null)
					query.AppendEquals(WiscrColumn.SimilarityStandartScore, mock.SimilarityStandartScore.ToString());
				if(mock.ArithmeticRawScore != null)
					query.AppendEquals(WiscrColumn.ArithmeticRawScore, mock.ArithmeticRawScore.ToString());
				if(mock.ArithmeticStandartScore != null)
					query.AppendEquals(WiscrColumn.ArithmeticStandartScore, mock.ArithmeticStandartScore.ToString());
				if(mock.WordRawScore != null)
					query.AppendEquals(WiscrColumn.WordRawScore, mock.WordRawScore.ToString());
				if(mock.WordStandartScore != null)
					query.AppendEquals(WiscrColumn.WordStandartScore, mock.WordStandartScore.ToString());
				if(mock.JudgingRawScore != null)
					query.AppendEquals(WiscrColumn.JudgingRawScore, mock.JudgingRawScore.ToString());
				if(mock.JudgingStandartScore != null)
					query.AppendEquals(WiscrColumn.JudgingStandartScore, mock.JudgingStandartScore.ToString());
				if(mock.SetOfNumbersRawScore != null)
					query.AppendEquals(WiscrColumn.SetOfNumbersRawScore, mock.SetOfNumbersRawScore.ToString());
				if(mock.SetOfNumbersStandartScore != null)
					query.AppendEquals(WiscrColumn.SetOfNumbersStandartScore, mock.SetOfNumbersStandartScore.ToString());
				if(mock.ImageDefineRawScore != null)
					query.AppendEquals(WiscrColumn.ImageDefineRawScore, mock.ImageDefineRawScore.ToString());
				if(mock.ImageDefineStandartScore != null)
					query.AppendEquals(WiscrColumn.ImageDefineStandartScore, mock.ImageDefineStandartScore.ToString());
				if(mock.ImageEditingRawScore != null)
					query.AppendEquals(WiscrColumn.ImageEditingRawScore, mock.ImageEditingRawScore.ToString());
				if(mock.ImageEditingStandartScore != null)
					query.AppendEquals(WiscrColumn.ImageEditingStandartScore, mock.ImageEditingStandartScore.ToString());
				if(mock.CubesPatternRawScore != null)
					query.AppendEquals(WiscrColumn.CubesPatternRawScore, mock.CubesPatternRawScore.ToString());
				if(mock.CubesPatternStandartScore != null)
					query.AppendEquals(WiscrColumn.CubesPatternStandartScore, mock.CubesPatternStandartScore.ToString());
				if(mock.PartsMergeRawScore != null)
					query.AppendEquals(WiscrColumn.PartsMergeRawScore, mock.PartsMergeRawScore.ToString());
				if(mock.PartsMergeStandartScore != null)
					query.AppendEquals(WiscrColumn.PartsMergeStandartScore, mock.PartsMergeStandartScore.ToString());
				if(mock.PasswordRawScore != null)
					query.AppendEquals(WiscrColumn.PasswordRawScore, mock.PasswordRawScore.ToString());
				if(mock.PasswordStandartScore != null)
					query.AppendEquals(WiscrColumn.PasswordStandartScore, mock.PasswordStandartScore.ToString());
				if(mock.MazesRawScore != null)
					query.AppendEquals(WiscrColumn.MazesRawScore, mock.MazesRawScore.ToString());
				if(mock.MazesStandartScore != null)
					query.AppendEquals(WiscrColumn.MazesStandartScore, mock.MazesStandartScore.ToString());
				if(mock.TotalVerbalScore != null)
					query.AppendEquals(WiscrColumn.TotalVerbalScore, mock.TotalVerbalScore.ToString());
				if(mock.TotalPerformanceScore != null)
					query.AppendEquals(WiscrColumn.TotalPerformanceScore, mock.TotalPerformanceScore.ToString());
				if(mock.TotalScore != null)
					query.AppendEquals(WiscrColumn.TotalScore, mock.TotalScore.ToString());
				if(mock.Notes != null)
					query.AppendEquals(WiscrColumn.Notes, mock.Notes.ToString());
				query.AppendEquals(WiscrColumn.TestDate, mock.TestDate.ToString());
				query.AppendEquals(WiscrColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(WiscrColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(WiscrColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(WiscrColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(WiscrColumn.Active, mock.Active.ToString());
				query.AppendEquals(WiscrColumn.Deleted, mock.Deleted.ToString());
				
				TList<Wiscr> results = DataRepository.WiscrProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Wiscr Entity with mock values.
		///</summary>
		static public Wiscr CreateMockInstance_Generated(TransactionManager tm)
		{		
			Wiscr mock = new Wiscr();
						
			mock.SeanceId = TestUtility.Instance.RandomNumber();
			mock.GeneralRawScore = TestUtility.Instance.RandomNumber();
			mock.GeneralStandartScore = TestUtility.Instance.RandomNumber();
			mock.SimilarityRawScore = TestUtility.Instance.RandomNumber();
			mock.SimilarityStandartScore = TestUtility.Instance.RandomNumber();
			mock.ArithmeticRawScore = TestUtility.Instance.RandomNumber();
			mock.ArithmeticStandartScore = TestUtility.Instance.RandomNumber();
			mock.WordRawScore = TestUtility.Instance.RandomNumber();
			mock.WordStandartScore = TestUtility.Instance.RandomNumber();
			mock.JudgingRawScore = TestUtility.Instance.RandomNumber();
			mock.JudgingStandartScore = TestUtility.Instance.RandomNumber();
			mock.SetOfNumbersRawScore = TestUtility.Instance.RandomNumber();
			mock.SetOfNumbersStandartScore = TestUtility.Instance.RandomNumber();
			mock.ImageDefineRawScore = TestUtility.Instance.RandomNumber();
			mock.ImageDefineStandartScore = TestUtility.Instance.RandomNumber();
			mock.ImageEditingRawScore = TestUtility.Instance.RandomNumber();
			mock.ImageEditingStandartScore = TestUtility.Instance.RandomNumber();
			mock.CubesPatternRawScore = TestUtility.Instance.RandomNumber();
			mock.CubesPatternStandartScore = TestUtility.Instance.RandomNumber();
			mock.PartsMergeRawScore = TestUtility.Instance.RandomNumber();
			mock.PartsMergeStandartScore = TestUtility.Instance.RandomNumber();
			mock.PasswordRawScore = TestUtility.Instance.RandomNumber();
			mock.PasswordStandartScore = TestUtility.Instance.RandomNumber();
			mock.MazesRawScore = TestUtility.Instance.RandomNumber();
			mock.MazesStandartScore = TestUtility.Instance.RandomNumber();
			mock.TotalVerbalScore = TestUtility.Instance.RandomNumber();
			mock.TotalPerformanceScore = TestUtility.Instance.RandomNumber();
			mock.TotalScore = TestUtility.Instance.RandomNumber();
			mock.Notes = TestUtility.Instance.RandomString(2, false);;
			mock.TestDate = TestUtility.Instance.RandomDateTime();
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
		
			// create a temporary collection and add the item to it
			TList<Wiscr> tempMockCollection = new TList<Wiscr>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Wiscr)mock;
		}
		
		
		///<summary>
		///  Update the Typed Wiscr Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Wiscr mock)
		{
			mock.SeanceId = TestUtility.Instance.RandomNumber();
			mock.GeneralRawScore = TestUtility.Instance.RandomNumber();
			mock.GeneralStandartScore = TestUtility.Instance.RandomNumber();
			mock.SimilarityRawScore = TestUtility.Instance.RandomNumber();
			mock.SimilarityStandartScore = TestUtility.Instance.RandomNumber();
			mock.ArithmeticRawScore = TestUtility.Instance.RandomNumber();
			mock.ArithmeticStandartScore = TestUtility.Instance.RandomNumber();
			mock.WordRawScore = TestUtility.Instance.RandomNumber();
			mock.WordStandartScore = TestUtility.Instance.RandomNumber();
			mock.JudgingRawScore = TestUtility.Instance.RandomNumber();
			mock.JudgingStandartScore = TestUtility.Instance.RandomNumber();
			mock.SetOfNumbersRawScore = TestUtility.Instance.RandomNumber();
			mock.SetOfNumbersStandartScore = TestUtility.Instance.RandomNumber();
			mock.ImageDefineRawScore = TestUtility.Instance.RandomNumber();
			mock.ImageDefineStandartScore = TestUtility.Instance.RandomNumber();
			mock.ImageEditingRawScore = TestUtility.Instance.RandomNumber();
			mock.ImageEditingStandartScore = TestUtility.Instance.RandomNumber();
			mock.CubesPatternRawScore = TestUtility.Instance.RandomNumber();
			mock.CubesPatternStandartScore = TestUtility.Instance.RandomNumber();
			mock.PartsMergeRawScore = TestUtility.Instance.RandomNumber();
			mock.PartsMergeStandartScore = TestUtility.Instance.RandomNumber();
			mock.PasswordRawScore = TestUtility.Instance.RandomNumber();
			mock.PasswordStandartScore = TestUtility.Instance.RandomNumber();
			mock.MazesRawScore = TestUtility.Instance.RandomNumber();
			mock.MazesStandartScore = TestUtility.Instance.RandomNumber();
			mock.TotalVerbalScore = TestUtility.Instance.RandomNumber();
			mock.TotalPerformanceScore = TestUtility.Instance.RandomNumber();
			mock.TotalScore = TestUtility.Instance.RandomNumber();
			mock.Notes = TestUtility.Instance.RandomString(2, false);;
			mock.TestDate = TestUtility.Instance.RandomDateTime();
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
