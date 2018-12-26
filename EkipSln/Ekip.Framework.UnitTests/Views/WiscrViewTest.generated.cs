﻿
/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : 18 Aralık 2018 Salı
	Important: Do not modify this file. Edit the file WiscrViewTest.cs instead.
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
    /// Provides tests for the and <see cref="WiscrView"/> objects (entity, collection and repository).
    /// </summary>
    public partial class WiscrViewTest
    {
    	// the WiscrView instance used to test the repository.
		private WiscrView mock;
		
		// the VList<WiscrView> instance used to test the repository.
		private VList<WiscrView> mockCollection;		

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the WiscrView Entity with the {0} --", Ekip.Framework.Data.DataRepository.Provider.Name);
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
		/// Selects a page of WiscrView objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.WiscrViewProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.WiscrViewProvider.GetPaged():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Searches some WiscrView objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.WiscrViewProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
			
			System.Console.WriteLine("DataRepository.WiscrViewProvider.Find():");			
			System.Console.WriteLine(mockCollection);
					
		}
		 //Find
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock WiscrView entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_WiscrView.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(WiscrView)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mock); 
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock WiscrView entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_WiscrView.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(WiscrView)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			mock = (WiscrView) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a WiscrView collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_WiscrViewCollection.xml";
		
			VList<WiscrView> mockCollection = new VList<WiscrView>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<WiscrView>)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<WiscrView> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a WiscrView collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_WiscrViewCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<WiscrView>)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			VList<WiscrView> mockCollection = (VList<WiscrView>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<WiscrView> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed WiscrView Entity with mock values.
		///</summary>
		static public WiscrView CreateMockInstance()
		{		
			WiscrView mock = new WiscrView();
						
			mock.SeanceId = TestUtility.Instance.RandomNumber();
			mock.ClientId = TestUtility.Instance.RandomNumber();
			mock.CreateDate = TestUtility.Instance.RandomDateTime();
			mock.SeanceDate = TestUtility.Instance.RandomDate();
			mock.SeanceTime = TestUtility.Instance.RandomDateTime();
			mock.SeanceStatusId = TestUtility.Instance.RandomByte();
			mock.SeanceAdvisorId = TestUtility.Instance.RandomNumber();
			mock.SeanceAdvisorName = TestUtility.Instance.RandomString(24, false);;
			mock.TestDate = TestUtility.Instance.RandomDateTime();
			mock.TestAdvisorId = TestUtility.Instance.RandomNumber();
			mock.TestAdvisorName = TestUtility.Instance.RandomString(24, false);;
			mock.TotalVerbalScore = TestUtility.Instance.RandomNumber();
			mock.TotalPerformanceScore = TestUtility.Instance.RandomNumber();
			mock.TotalScore = TestUtility.Instance.RandomNumber();
		   return (WiscrView)mock;
		}
		

		#endregion
    }
}
