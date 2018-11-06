#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Ekip.Framework.Entities;
using Ekip.Framework.Data;

#endregion

namespace Ekip.Framework.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="WiscrProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WiscrProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Wiscr, Ekip.Framework.Entities.WiscrKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.WiscrKey key)
		{
			return Delete(transactionManager, key.WiscrId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_wiscrId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _wiscrId)
		{
			return Delete(null, _wiscrId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wiscrId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _wiscrId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override Ekip.Framework.Entities.Wiscr Get(TransactionManager transactionManager, Ekip.Framework.Entities.WiscrKey key, int start, int pageLength)
		{
			return GetByWiscrId(transactionManager, key.WiscrId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Wiscr index.
		/// </summary>
		/// <param name="_wiscrId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wiscr"/> class.</returns>
		public Ekip.Framework.Entities.Wiscr GetByWiscrId(System.Int32 _wiscrId)
		{
			int count = -1;
			return GetByWiscrId(null,_wiscrId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wiscr index.
		/// </summary>
		/// <param name="_wiscrId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wiscr"/> class.</returns>
		public Ekip.Framework.Entities.Wiscr GetByWiscrId(System.Int32 _wiscrId, int start, int pageLength)
		{
			int count = -1;
			return GetByWiscrId(null, _wiscrId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wiscr index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wiscrId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wiscr"/> class.</returns>
		public Ekip.Framework.Entities.Wiscr GetByWiscrId(TransactionManager transactionManager, System.Int32 _wiscrId)
		{
			int count = -1;
			return GetByWiscrId(transactionManager, _wiscrId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wiscr index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wiscrId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wiscr"/> class.</returns>
		public Ekip.Framework.Entities.Wiscr GetByWiscrId(TransactionManager transactionManager, System.Int32 _wiscrId, int start, int pageLength)
		{
			int count = -1;
			return GetByWiscrId(transactionManager, _wiscrId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wiscr index.
		/// </summary>
		/// <param name="_wiscrId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wiscr"/> class.</returns>
		public Ekip.Framework.Entities.Wiscr GetByWiscrId(System.Int32 _wiscrId, int start, int pageLength, out int count)
		{
			return GetByWiscrId(null, _wiscrId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wiscr index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wiscrId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wiscr"/> class.</returns>
		public abstract Ekip.Framework.Entities.Wiscr GetByWiscrId(TransactionManager transactionManager, System.Int32 _wiscrId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Wiscr&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Wiscr&gt;"/></returns>
		public static TList<Wiscr> Fill(IDataReader reader, TList<Wiscr> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				Ekip.Framework.Entities.Wiscr c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Wiscr")
					.Append("|").Append((System.Int32)reader[((int)WiscrColumn.WiscrId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Wiscr>(
					key.ToString(), // EntityTrackingKey
					"Wiscr",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Wiscr();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.WiscrId = (System.Int32)reader[((int)WiscrColumn.WiscrId - 1)];
					c.GeneralRawScore = (reader.IsDBNull(((int)WiscrColumn.GeneralRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.GeneralRawScore - 1)];
					c.GeneralStandartScore = (reader.IsDBNull(((int)WiscrColumn.GeneralStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.GeneralStandartScore - 1)];
					c.SimilarityRawScore = (reader.IsDBNull(((int)WiscrColumn.SimilarityRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.SimilarityRawScore - 1)];
					c.SimilarityStandartScore = (reader.IsDBNull(((int)WiscrColumn.SimilarityStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.SimilarityStandartScore - 1)];
					c.ArithmeticRawScore = (reader.IsDBNull(((int)WiscrColumn.ArithmeticRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ArithmeticRawScore - 1)];
					c.ArithmeticStandartScore = (reader.IsDBNull(((int)WiscrColumn.ArithmeticStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ArithmeticStandartScore - 1)];
					c.WordRawScore = (reader.IsDBNull(((int)WiscrColumn.WordRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.WordRawScore - 1)];
					c.WordStandartScore = (reader.IsDBNull(((int)WiscrColumn.WordStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.WordStandartScore - 1)];
					c.JudgingRawScore = (reader.IsDBNull(((int)WiscrColumn.JudgingRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.JudgingRawScore - 1)];
					c.JudgingStandartScore = (reader.IsDBNull(((int)WiscrColumn.JudgingStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.JudgingStandartScore - 1)];
					c.SetOfNumbersRawScore = (reader.IsDBNull(((int)WiscrColumn.SetOfNumbersRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.SetOfNumbersRawScore - 1)];
					c.SetOfNumbersStandartScore = (reader.IsDBNull(((int)WiscrColumn.SetOfNumbersStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.SetOfNumbersStandartScore - 1)];
					c.ImageDefineRawScore = (reader.IsDBNull(((int)WiscrColumn.ImageDefineRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ImageDefineRawScore - 1)];
					c.ImageDefineStandartScore = (reader.IsDBNull(((int)WiscrColumn.ImageDefineStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ImageDefineStandartScore - 1)];
					c.ImageEditingRawScore = (reader.IsDBNull(((int)WiscrColumn.ImageEditingRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ImageEditingRawScore - 1)];
					c.ImageEditingStandartScore = (reader.IsDBNull(((int)WiscrColumn.ImageEditingStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ImageEditingStandartScore - 1)];
					c.CubesPatternRawScore = (reader.IsDBNull(((int)WiscrColumn.CubesPatternRawScore - 1)))?null:(System.String)reader[((int)WiscrColumn.CubesPatternRawScore - 1)];
					c.CubesPatternStandartScore = (reader.IsDBNull(((int)WiscrColumn.CubesPatternStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.CubesPatternStandartScore - 1)];
					c.PartsMergeRawScore = (reader.IsDBNull(((int)WiscrColumn.PartsMergeRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.PartsMergeRawScore - 1)];
					c.PartsMergeStandartScore = (reader.IsDBNull(((int)WiscrColumn.PartsMergeStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.PartsMergeStandartScore - 1)];
					c.PasswordRawScore = (reader.IsDBNull(((int)WiscrColumn.PasswordRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.PasswordRawScore - 1)];
					c.PasswordStandartScore = (reader.IsDBNull(((int)WiscrColumn.PasswordStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.PasswordStandartScore - 1)];
					c.MazesRawScore = (reader.IsDBNull(((int)WiscrColumn.MazesRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.MazesRawScore - 1)];
					c.MazesStandartScore = (reader.IsDBNull(((int)WiscrColumn.MazesStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.MazesStandartScore - 1)];
					c.TotalVerbalScore = (reader.IsDBNull(((int)WiscrColumn.TotalVerbalScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.TotalVerbalScore - 1)];
					c.TotalPerformanceScore = (reader.IsDBNull(((int)WiscrColumn.TotalPerformanceScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.TotalPerformanceScore - 1)];
					c.TotalScore = (reader.IsDBNull(((int)WiscrColumn.TotalScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.TotalScore - 1)];
					c.TestDate = (System.DateTime)reader[((int)WiscrColumn.TestDate - 1)];
					c.CreateDate = (System.DateTime)reader[((int)WiscrColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)WiscrColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)WiscrColumn.UpdateDate - 1)];
					c.UserId = (System.Int32)reader[((int)WiscrColumn.UserId - 1)];
					c.AdvisorId = (reader.IsDBNull(((int)WiscrColumn.AdvisorId - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.AdvisorId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Wiscr"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Wiscr"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Wiscr entity)
		{
			if (!reader.Read()) return;
			
			entity.WiscrId = (System.Int32)reader[((int)WiscrColumn.WiscrId - 1)];
			entity.GeneralRawScore = (reader.IsDBNull(((int)WiscrColumn.GeneralRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.GeneralRawScore - 1)];
			entity.GeneralStandartScore = (reader.IsDBNull(((int)WiscrColumn.GeneralStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.GeneralStandartScore - 1)];
			entity.SimilarityRawScore = (reader.IsDBNull(((int)WiscrColumn.SimilarityRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.SimilarityRawScore - 1)];
			entity.SimilarityStandartScore = (reader.IsDBNull(((int)WiscrColumn.SimilarityStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.SimilarityStandartScore - 1)];
			entity.ArithmeticRawScore = (reader.IsDBNull(((int)WiscrColumn.ArithmeticRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ArithmeticRawScore - 1)];
			entity.ArithmeticStandartScore = (reader.IsDBNull(((int)WiscrColumn.ArithmeticStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ArithmeticStandartScore - 1)];
			entity.WordRawScore = (reader.IsDBNull(((int)WiscrColumn.WordRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.WordRawScore - 1)];
			entity.WordStandartScore = (reader.IsDBNull(((int)WiscrColumn.WordStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.WordStandartScore - 1)];
			entity.JudgingRawScore = (reader.IsDBNull(((int)WiscrColumn.JudgingRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.JudgingRawScore - 1)];
			entity.JudgingStandartScore = (reader.IsDBNull(((int)WiscrColumn.JudgingStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.JudgingStandartScore - 1)];
			entity.SetOfNumbersRawScore = (reader.IsDBNull(((int)WiscrColumn.SetOfNumbersRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.SetOfNumbersRawScore - 1)];
			entity.SetOfNumbersStandartScore = (reader.IsDBNull(((int)WiscrColumn.SetOfNumbersStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.SetOfNumbersStandartScore - 1)];
			entity.ImageDefineRawScore = (reader.IsDBNull(((int)WiscrColumn.ImageDefineRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ImageDefineRawScore - 1)];
			entity.ImageDefineStandartScore = (reader.IsDBNull(((int)WiscrColumn.ImageDefineStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ImageDefineStandartScore - 1)];
			entity.ImageEditingRawScore = (reader.IsDBNull(((int)WiscrColumn.ImageEditingRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ImageEditingRawScore - 1)];
			entity.ImageEditingStandartScore = (reader.IsDBNull(((int)WiscrColumn.ImageEditingStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.ImageEditingStandartScore - 1)];
			entity.CubesPatternRawScore = (reader.IsDBNull(((int)WiscrColumn.CubesPatternRawScore - 1)))?null:(System.String)reader[((int)WiscrColumn.CubesPatternRawScore - 1)];
			entity.CubesPatternStandartScore = (reader.IsDBNull(((int)WiscrColumn.CubesPatternStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.CubesPatternStandartScore - 1)];
			entity.PartsMergeRawScore = (reader.IsDBNull(((int)WiscrColumn.PartsMergeRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.PartsMergeRawScore - 1)];
			entity.PartsMergeStandartScore = (reader.IsDBNull(((int)WiscrColumn.PartsMergeStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.PartsMergeStandartScore - 1)];
			entity.PasswordRawScore = (reader.IsDBNull(((int)WiscrColumn.PasswordRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.PasswordRawScore - 1)];
			entity.PasswordStandartScore = (reader.IsDBNull(((int)WiscrColumn.PasswordStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.PasswordStandartScore - 1)];
			entity.MazesRawScore = (reader.IsDBNull(((int)WiscrColumn.MazesRawScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.MazesRawScore - 1)];
			entity.MazesStandartScore = (reader.IsDBNull(((int)WiscrColumn.MazesStandartScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.MazesStandartScore - 1)];
			entity.TotalVerbalScore = (reader.IsDBNull(((int)WiscrColumn.TotalVerbalScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.TotalVerbalScore - 1)];
			entity.TotalPerformanceScore = (reader.IsDBNull(((int)WiscrColumn.TotalPerformanceScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.TotalPerformanceScore - 1)];
			entity.TotalScore = (reader.IsDBNull(((int)WiscrColumn.TotalScore - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.TotalScore - 1)];
			entity.TestDate = (System.DateTime)reader[((int)WiscrColumn.TestDate - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)WiscrColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)WiscrColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)WiscrColumn.UpdateDate - 1)];
			entity.UserId = (System.Int32)reader[((int)WiscrColumn.UserId - 1)];
			entity.AdvisorId = (reader.IsDBNull(((int)WiscrColumn.AdvisorId - 1)))?null:(System.Int32?)reader[((int)WiscrColumn.AdvisorId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Wiscr"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Wiscr"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Wiscr entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.WiscrId = (System.Int32)dataRow["WiscrID"];
			entity.GeneralRawScore = Convert.IsDBNull(dataRow["GeneralRawScore"]) ? null : (System.Int32?)dataRow["GeneralRawScore"];
			entity.GeneralStandartScore = Convert.IsDBNull(dataRow["GeneralStandartScore"]) ? null : (System.Int32?)dataRow["GeneralStandartScore"];
			entity.SimilarityRawScore = Convert.IsDBNull(dataRow["SimilarityRawScore"]) ? null : (System.Int32?)dataRow["SimilarityRawScore"];
			entity.SimilarityStandartScore = Convert.IsDBNull(dataRow["SimilarityStandartScore"]) ? null : (System.Int32?)dataRow["SimilarityStandartScore"];
			entity.ArithmeticRawScore = Convert.IsDBNull(dataRow["ArithmeticRawScore"]) ? null : (System.Int32?)dataRow["ArithmeticRawScore"];
			entity.ArithmeticStandartScore = Convert.IsDBNull(dataRow["ArithmeticStandartScore"]) ? null : (System.Int32?)dataRow["ArithmeticStandartScore"];
			entity.WordRawScore = Convert.IsDBNull(dataRow["WordRawScore"]) ? null : (System.Int32?)dataRow["WordRawScore"];
			entity.WordStandartScore = Convert.IsDBNull(dataRow["WordStandartScore"]) ? null : (System.Int32?)dataRow["WordStandartScore"];
			entity.JudgingRawScore = Convert.IsDBNull(dataRow["JudgingRawScore"]) ? null : (System.Int32?)dataRow["JudgingRawScore"];
			entity.JudgingStandartScore = Convert.IsDBNull(dataRow["JudgingStandartScore"]) ? null : (System.Int32?)dataRow["JudgingStandartScore"];
			entity.SetOfNumbersRawScore = Convert.IsDBNull(dataRow["SetOfNumbersRawScore"]) ? null : (System.Int32?)dataRow["SetOfNumbersRawScore"];
			entity.SetOfNumbersStandartScore = Convert.IsDBNull(dataRow["SetOfNumbersStandartScore"]) ? null : (System.Int32?)dataRow["SetOfNumbersStandartScore"];
			entity.ImageDefineRawScore = Convert.IsDBNull(dataRow["ImageDefineRawScore"]) ? null : (System.Int32?)dataRow["ImageDefineRawScore"];
			entity.ImageDefineStandartScore = Convert.IsDBNull(dataRow["ImageDefineStandartScore"]) ? null : (System.Int32?)dataRow["ImageDefineStandartScore"];
			entity.ImageEditingRawScore = Convert.IsDBNull(dataRow["ImageEditingRawScore"]) ? null : (System.Int32?)dataRow["ImageEditingRawScore"];
			entity.ImageEditingStandartScore = Convert.IsDBNull(dataRow["ImageEditingStandartScore"]) ? null : (System.Int32?)dataRow["ImageEditingStandartScore"];
			entity.CubesPatternRawScore = Convert.IsDBNull(dataRow["CubesPatternRawScore"]) ? null : (System.String)dataRow["CubesPatternRawScore"];
			entity.CubesPatternStandartScore = Convert.IsDBNull(dataRow["CubesPatternStandartScore"]) ? null : (System.Int32?)dataRow["CubesPatternStandartScore"];
			entity.PartsMergeRawScore = Convert.IsDBNull(dataRow["PartsMergeRawScore"]) ? null : (System.Int32?)dataRow["PartsMergeRawScore"];
			entity.PartsMergeStandartScore = Convert.IsDBNull(dataRow["PartsMergeStandartScore"]) ? null : (System.Int32?)dataRow["PartsMergeStandartScore"];
			entity.PasswordRawScore = Convert.IsDBNull(dataRow["PasswordRawScore"]) ? null : (System.Int32?)dataRow["PasswordRawScore"];
			entity.PasswordStandartScore = Convert.IsDBNull(dataRow["PasswordStandartScore"]) ? null : (System.Int32?)dataRow["PasswordStandartScore"];
			entity.MazesRawScore = Convert.IsDBNull(dataRow["MazesRawScore"]) ? null : (System.Int32?)dataRow["MazesRawScore"];
			entity.MazesStandartScore = Convert.IsDBNull(dataRow["MazesStandartScore"]) ? null : (System.Int32?)dataRow["MazesStandartScore"];
			entity.TotalVerbalScore = Convert.IsDBNull(dataRow["TotalVerbalScore"]) ? null : (System.Int32?)dataRow["TotalVerbalScore"];
			entity.TotalPerformanceScore = Convert.IsDBNull(dataRow["TotalPerformanceScore"]) ? null : (System.Int32?)dataRow["TotalPerformanceScore"];
			entity.TotalScore = Convert.IsDBNull(dataRow["TotalScore"]) ? null : (System.Int32?)dataRow["TotalScore"];
			entity.TestDate = (System.DateTime)dataRow["TestDate"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
			entity.UserId = (System.Int32)dataRow["UserID"];
			entity.AdvisorId = Convert.IsDBNull(dataRow["AdvisorID"]) ? null : (System.Int32?)dataRow["AdvisorID"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Wiscr"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Wiscr Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Wiscr entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByWiscrId methods when available
			
			#region SeanceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Seance>|SeanceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceCollection = DataRepository.SeanceProvider.GetByWiscrId(transactionManager, entity.WiscrId);

				if (deep && entity.SeanceCollection.Count > 0)
				{
					deepHandles.Add("SeanceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Seance>) DataRepository.SeanceProvider.DeepLoad,
						new object[] { transactionManager, entity.SeanceCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Wiscr object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Wiscr instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Wiscr Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Wiscr entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Seance>
				if (CanDeepSave(entity.SeanceCollection, "List<Seance>|SeanceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Seance child in entity.SeanceCollection)
					{
						if(child.WiscrIdSource != null)
						{
							child.WiscrId = child.WiscrIdSource.WiscrId;
						}
						else
						{
							child.WiscrId = entity.WiscrId;
						}

					}

					if (entity.SeanceCollection.Count > 0 || entity.SeanceCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SeanceProvider.Save(transactionManager, entity.SeanceCollection);
						
						deepHandles.Add("SeanceCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Seance >) DataRepository.SeanceProvider.DeepSave,
							new object[] { transactionManager, entity.SeanceCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region WiscrChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Wiscr</c>
	///</summary>
	public enum WiscrChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Wiscr</c> as OneToMany for SeanceCollection
		///</summary>
		[ChildEntityType(typeof(TList<Seance>))]
		SeanceCollection,
	}
	
	#endregion WiscrChildEntityTypes
	
	#region WiscrFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WiscrColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wiscr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WiscrFilterBuilder : SqlFilterBuilder<WiscrColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WiscrFilterBuilder class.
		/// </summary>
		public WiscrFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WiscrFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WiscrFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WiscrFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WiscrFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WiscrFilterBuilder
	
	#region WiscrParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WiscrColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wiscr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WiscrParameterBuilder : ParameterizedSqlFilterBuilder<WiscrColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WiscrParameterBuilder class.
		/// </summary>
		public WiscrParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WiscrParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WiscrParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WiscrParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WiscrParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WiscrParameterBuilder
	
	#region WiscrSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;WiscrColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wiscr"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WiscrSortBuilder : SqlSortBuilder<WiscrColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WiscrSqlSortBuilder class.
		/// </summary>
		public WiscrSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WiscrSortBuilder
	
} // end namespace
