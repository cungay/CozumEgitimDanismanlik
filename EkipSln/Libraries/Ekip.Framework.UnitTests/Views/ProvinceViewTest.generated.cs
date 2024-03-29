﻿
/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Haziran 2019 Salı
	Important: Do not modify this file. Edit the file ProvinceViewTest.cs instead.
*/
#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Ekip.Framework.Entities;
using Ekip.Framework.Data;

#endregion

namespace Ekip.Framework.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="ProvinceView"/> objects (entity, collection and repository).
    /// </summary>
    public partial class ProvinceViewTest
    {
    	// the ProvinceView instance used to test the repository.
		private ProvinceView mock;
		
		// the VList<ProvinceView> instance used to test the repository.
		private VList<ProvinceView> mockCollection;		

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the ProvinceView Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
        static private void CleanUp_Generated()
        {       	
			System.Console.WriteLine();
			System.Console.WriteLine();
        }
		
		/// <summary>
		/// Selects a page of ProvinceView objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.ProvinceViewProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.ProvinceViewProvider.GetPaged():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Searches some ProvinceView objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.ProvinceViewProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
			
			System.Console.WriteLine("DataRepository.ProvinceViewProvider.Find():");			
			System.Console.WriteLine(mockCollection);
					
		}
		 //Find
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ProvinceView entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_ProvinceView.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(ProvinceView)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mock); 
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock ProvinceView entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_ProvinceView.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(ProvinceView)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			mock = (ProvinceView) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ProvinceView collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_ProvinceViewCollection.xml";
		
			VList<ProvinceView> mockCollection = new VList<ProvinceView>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<ProvinceView>)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<ProvinceView> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a ProvinceView collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_ProvinceViewCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<ProvinceView>)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			VList<ProvinceView> mockCollection = (VList<ProvinceView>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<ProvinceView> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed ProvinceView Entity with mock values.
		///</summary>
		static public ProvinceView CreateMockInstance()
		{		
			ProvinceView mock = new ProvinceView();
						
			mock.Id = TestUtility.Instance.RandomNumber();
			mock.RowNumber = TestUtility.Instance.RandomNumber();
			mock.AdminId = (long)TestUtility.Instance.RandomNumber();
			mock.ObjectId = (long)TestUtility.Instance.RandomNumber();
			mock.ParentId = (long)TestUtility.Instance.RandomNumber();
			mock.PlateCode = TestUtility.Instance.RandomString(2, false);;
			mock.AreaId = TestUtility.Instance.RandomNumber();
			mock.PhoneCode = TestUtility.Instance.RandomString(3, false);;
			mock.ProvinceName = TestUtility.Instance.RandomString(124, false);;
			mock.Longitude = TestUtility.Instance.RandomString(10, false);;
			mock.Latitude = TestUtility.Instance.RandomString(10, false);;
			mock.Type = TestUtility.Instance.RandomNumber();
			mock.CreateDate = TestUtility.Instance.RandomDate();
			mock.CreateTime = TestUtility.Instance.RandomDateTime();
			mock.UpdateDate = TestUtility.Instance.RandomDate();
			mock.UpdateTime = TestUtility.Instance.RandomDateTime();
			mock.CreateUserId = TestUtility.Instance.RandomNumber();
			mock.UpdateUserId = TestUtility.Instance.RandomNumber();
			mock.Active = TestUtility.Instance.RandomBoolean();
			mock.Deleted = TestUtility.Instance.RandomBoolean();
			mock.AreaName = TestUtility.Instance.RandomString(24, false);;
		   return (ProvinceView)mock;
		}
		

		#endregion
    }
}
