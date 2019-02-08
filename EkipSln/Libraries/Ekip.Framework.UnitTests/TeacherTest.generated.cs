﻿

/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 5 Şubat 2019 Salı
	Important: Do not modify this file. Edit the file TeacherTest.cs instead.
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
    /// Provides tests for the and <see cref="Teacher"/> objects (entity, collection and repository).
    /// </summary>
   public partial class TeacherTest
    {
    	// the Teacher instance used to test the repository.
		protected Teacher mock;
		
		// the TList<Teacher> instance used to test the repository.
		protected TList<Teacher> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the Teacher Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock Teacher entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.TeacherProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.TeacherProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Teacher objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.TeacherProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.TeacherProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.TeacherProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Teacher children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.TeacherProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.TeacherProvider.DeepLoading += new EntityProviderBaseCore<Teacher, TeacherKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.TeacherProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Teacher instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.TeacherProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Teacher entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Teacher mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.TeacherProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.TeacherProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.TeacherProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Teacher entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Teacher)CreateMockInstance(tm);
				DataRepository.TeacherProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.TeacherProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.TeacherProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Teacher entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Teacher.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Teacher entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Teacher.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Teacher>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Teacher collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_TeacherCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Teacher> mockCollection = new TList<Teacher>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Teacher> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Teacher collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_TeacherCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Teacher>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Teacher> mockCollection = (TList<Teacher>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Teacher> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Teacher entity = CreateMockInstance(tm);
				bool result = DataRepository.TeacherProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<Teacher> t0 = DataRepository.TeacherProvider.GetBySchoolId(tm, entity.SchoolId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Teacher entity = CreateMockInstance(tm);
				bool result = DataRepository.TeacherProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				Teacher t0 = DataRepository.TeacherProvider.GetByTeacherId(tm, entity.TeacherId);
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
				
				Teacher entity = mock.Copy() as Teacher;
				entity = (Teacher)mock.Clone();
				Assert.IsTrue(Teacher.ValueEquals(entity, mock), "Clone is not working");
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
				Teacher mock = CreateMockInstance(tm);
				bool result = DataRepository.TeacherProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				TeacherQuery query = new TeacherQuery();
			
				query.AppendEquals(TeacherColumn.TeacherId, mock.TeacherId.ToString());
				query.AppendEquals(TeacherColumn.SchoolId, mock.SchoolId.ToString());
				if(mock.FirstName != null)
					query.AppendEquals(TeacherColumn.FirstName, mock.FirstName.ToString());
				if(mock.LastName != null)
					query.AppendEquals(TeacherColumn.LastName, mock.LastName.ToString());
				if(mock.Phone != null)
					query.AppendEquals(TeacherColumn.Phone, mock.Phone.ToString());
				if(mock.Gsm != null)
					query.AppendEquals(TeacherColumn.Gsm, mock.Gsm.ToString());
				if(mock.Email != null)
					query.AppendEquals(TeacherColumn.Email, mock.Email.ToString());
				query.AppendEquals(TeacherColumn.CreateDate, mock.CreateDate.ToString());
				if(mock.UpdateDate != null)
					query.AppendEquals(TeacherColumn.UpdateDate, mock.UpdateDate.ToString());
				query.AppendEquals(TeacherColumn.CreateUserId, mock.CreateUserId.ToString());
				if(mock.UpdateUserId != null)
					query.AppendEquals(TeacherColumn.UpdateUserId, mock.UpdateUserId.ToString());
				query.AppendEquals(TeacherColumn.Active, mock.Active.ToString());
				query.AppendEquals(TeacherColumn.Deleted, mock.Deleted.ToString());
				
				TList<Teacher> results = DataRepository.TeacherProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Teacher Entity with mock values.
		///</summary>
		static public Teacher CreateMockInstance_Generated(TransactionManager tm)
		{		
			Teacher mock = new Teacher();
						
			mock.FirstName = TestUtility.Instance.RandomString(49, false);;
			mock.LastName = TestUtility.Instance.RandomString(49, false);;
			mock.Phone = TestUtility.Instance.RandomString(6, false);;
			mock.Gsm = TestUtility.Instance.RandomString(6, false);;
			mock.Email = TestUtility.Instance.RandomString(24, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			//OneToOneRelationship
			School mockSchoolBySchoolId = SchoolTest.CreateMockInstance(tm);
			DataRepository.SchoolProvider.Insert(tm, mockSchoolBySchoolId);
			mock.SchoolId = mockSchoolBySchoolId.SchoolId;
		
			// create a temporary collection and add the item to it
			TList<Teacher> tempMockCollection = new TList<Teacher>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Teacher)mock;
		}
		
		
		///<summary>
		///  Update the Typed Teacher Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Teacher mock)
		{
			mock.FirstName = TestUtility.Instance.RandomString(49, false);;
			mock.LastName = TestUtility.Instance.RandomString(49, false);;
			mock.Phone = TestUtility.Instance.RandomString(6, false);;
			mock.Gsm = TestUtility.Instance.RandomString(6, false);;
			mock.Email = TestUtility.Instance.RandomString(24, false);;
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			
			//OneToOneRelationship
			School mockSchoolBySchoolId = SchoolTest.CreateMockInstance(tm);
			DataRepository.SchoolProvider.Insert(tm, mockSchoolBySchoolId);
			mock.SchoolId = mockSchoolBySchoolId.SchoolId;
					
		}
		#endregion
    }
}
