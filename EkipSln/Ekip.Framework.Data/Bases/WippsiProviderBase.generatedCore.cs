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
	/// This class is the base class for any <see cref="WippsiProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WippsiProviderBaseCore : EntityProviderBase<Ekip.Framework.Entities.Wippsi, Ekip.Framework.Entities.WippsiKey>
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
		public override bool Delete(TransactionManager transactionManager, Ekip.Framework.Entities.WippsiKey key)
		{
			return Delete(transactionManager, key.WippsiId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_wippsiId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _wippsiId)
		{
			return Delete(null, _wippsiId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wippsiId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _wippsiId);		
		
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
		public override Ekip.Framework.Entities.Wippsi Get(TransactionManager transactionManager, Ekip.Framework.Entities.WippsiKey key, int start, int pageLength)
		{
			return GetByWippsiId(transactionManager, key.WippsiId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Wippsi index.
		/// </summary>
		/// <param name="_wippsiId"></param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wippsi"/> class.</returns>
		public Ekip.Framework.Entities.Wippsi GetByWippsiId(System.Int32 _wippsiId)
		{
			int count = -1;
			return GetByWippsiId(null,_wippsiId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wippsi index.
		/// </summary>
		/// <param name="_wippsiId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wippsi"/> class.</returns>
		public Ekip.Framework.Entities.Wippsi GetByWippsiId(System.Int32 _wippsiId, int start, int pageLength)
		{
			int count = -1;
			return GetByWippsiId(null, _wippsiId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wippsi index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wippsiId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wippsi"/> class.</returns>
		public Ekip.Framework.Entities.Wippsi GetByWippsiId(TransactionManager transactionManager, System.Int32 _wippsiId)
		{
			int count = -1;
			return GetByWippsiId(transactionManager, _wippsiId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wippsi index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wippsiId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wippsi"/> class.</returns>
		public Ekip.Framework.Entities.Wippsi GetByWippsiId(TransactionManager transactionManager, System.Int32 _wippsiId, int start, int pageLength)
		{
			int count = -1;
			return GetByWippsiId(transactionManager, _wippsiId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wippsi index.
		/// </summary>
		/// <param name="_wippsiId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wippsi"/> class.</returns>
		public Ekip.Framework.Entities.Wippsi GetByWippsiId(System.Int32 _wippsiId, int start, int pageLength, out int count)
		{
			return GetByWippsiId(null, _wippsiId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Wippsi index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wippsiId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Ekip.Framework.Entities.Wippsi"/> class.</returns>
		public abstract Ekip.Framework.Entities.Wippsi GetByWippsiId(TransactionManager transactionManager, System.Int32 _wippsiId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Wippsi&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Wippsi&gt;"/></returns>
		public static TList<Wippsi> Fill(IDataReader reader, TList<Wippsi> rows, int start, int pageLength)
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
				
				Ekip.Framework.Entities.Wippsi c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Wippsi")
					.Append("|").Append((System.Int32)reader[((int)WippsiColumn.WippsiId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Wippsi>(
					key.ToString(), // EntityTrackingKey
					"Wippsi",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Ekip.Framework.Entities.Wippsi();
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
					c.WippsiId = (System.Int32)reader[((int)WippsiColumn.WippsiId - 1)];
					c.GeneralRawScore = (reader.IsDBNull(((int)WippsiColumn.GeneralRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.GeneralRawScore - 1)];
					c.GeneralStandartScore = (reader.IsDBNull(((int)WippsiColumn.GeneralStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.GeneralStandartScore - 1)];
					c.SimilarityRawScore = (reader.IsDBNull(((int)WippsiColumn.SimilarityRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.SimilarityRawScore - 1)];
					c.SimilarityStandartScore = (reader.IsDBNull(((int)WippsiColumn.SimilarityStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.SimilarityStandartScore - 1)];
					c.ArithmeticRawScore = (reader.IsDBNull(((int)WippsiColumn.ArithmeticRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.ArithmeticRawScore - 1)];
					c.ArithmeticStandartScore = (reader.IsDBNull(((int)WippsiColumn.ArithmeticStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.ArithmeticStandartScore - 1)];
					c.WordRawScore = (reader.IsDBNull(((int)WippsiColumn.WordRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.WordRawScore - 1)];
					c.WordStandartScore = (reader.IsDBNull(((int)WippsiColumn.WordStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.WordStandartScore - 1)];
					c.UnderstandingRawScore = (reader.IsDBNull(((int)WippsiColumn.UnderstandingRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.UnderstandingRawScore - 1)];
					c.UnderstandingStandartScore = (reader.IsDBNull(((int)WippsiColumn.UnderstandingStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.UnderstandingStandartScore - 1)];
					c.SentencesRawScore = (reader.IsDBNull(((int)WippsiColumn.SentencesRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.SentencesRawScore - 1)];
					c.SentencesStandartScore = (reader.IsDBNull(((int)WippsiColumn.SentencesStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.SentencesStandartScore - 1)];
					c.ImageDefineRawScore = (reader.IsDBNull(((int)WippsiColumn.ImageDefineRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.ImageDefineRawScore - 1)];
					c.ImageDefineStandartScore = (reader.IsDBNull(((int)WippsiColumn.ImageDefineStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.ImageDefineStandartScore - 1)];
					c.AnimalHomesRawScore = (reader.IsDBNull(((int)WippsiColumn.AnimalHomesRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AnimalHomesRawScore - 1)];
					c.AnimalHomesStandartScore = (reader.IsDBNull(((int)WippsiColumn.AnimalHomesStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AnimalHomesStandartScore - 1)];
					c.GeometricShapeRawScore = (reader.IsDBNull(((int)WippsiColumn.GeometricShapeRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.GeometricShapeRawScore - 1)];
					c.GeometricShapeStandartScore = (reader.IsDBNull(((int)WippsiColumn.GeometricShapeStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.GeometricShapeStandartScore - 1)];
					c.BlocksPatternRawScore = (reader.IsDBNull(((int)WippsiColumn.BlocksPatternRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.BlocksPatternRawScore - 1)];
					c.BlocksPatternStandartScore = (reader.IsDBNull(((int)WippsiColumn.BlocksPatternStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.BlocksPatternStandartScore - 1)];
					c.AnimalHomesAgainRawScore = (reader.IsDBNull(((int)WippsiColumn.AnimalHomesAgainRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AnimalHomesAgainRawScore - 1)];
					c.AnimalHomesAgainStandartScore = (reader.IsDBNull(((int)WippsiColumn.AnimalHomesAgainStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AnimalHomesAgainStandartScore - 1)];
					c.MazesRawScore = (reader.IsDBNull(((int)WippsiColumn.MazesRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.MazesRawScore - 1)];
					c.MazesStandartScore = (reader.IsDBNull(((int)WippsiColumn.MazesStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.MazesStandartScore - 1)];
					c.TotalVerbalScore = (reader.IsDBNull(((int)WippsiColumn.TotalVerbalScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.TotalVerbalScore - 1)];
					c.TotalPerformanceScore = (reader.IsDBNull(((int)WippsiColumn.TotalPerformanceScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.TotalPerformanceScore - 1)];
					c.TotalScore = (reader.IsDBNull(((int)WippsiColumn.TotalScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.TotalScore - 1)];
					c.TestDate = (System.DateTime)reader[((int)WippsiColumn.TestDate - 1)];
					c.CreateDate = (System.DateTime)reader[((int)WippsiColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)WippsiColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)WippsiColumn.UpdateDate - 1)];
					c.UserId = (System.Int32)reader[((int)WippsiColumn.UserId - 1)];
					c.AdvisorId = (reader.IsDBNull(((int)WippsiColumn.AdvisorId - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AdvisorId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Wippsi"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Wippsi"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Ekip.Framework.Entities.Wippsi entity)
		{
			if (!reader.Read()) return;
			
			entity.WippsiId = (System.Int32)reader[((int)WippsiColumn.WippsiId - 1)];
			entity.GeneralRawScore = (reader.IsDBNull(((int)WippsiColumn.GeneralRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.GeneralRawScore - 1)];
			entity.GeneralStandartScore = (reader.IsDBNull(((int)WippsiColumn.GeneralStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.GeneralStandartScore - 1)];
			entity.SimilarityRawScore = (reader.IsDBNull(((int)WippsiColumn.SimilarityRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.SimilarityRawScore - 1)];
			entity.SimilarityStandartScore = (reader.IsDBNull(((int)WippsiColumn.SimilarityStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.SimilarityStandartScore - 1)];
			entity.ArithmeticRawScore = (reader.IsDBNull(((int)WippsiColumn.ArithmeticRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.ArithmeticRawScore - 1)];
			entity.ArithmeticStandartScore = (reader.IsDBNull(((int)WippsiColumn.ArithmeticStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.ArithmeticStandartScore - 1)];
			entity.WordRawScore = (reader.IsDBNull(((int)WippsiColumn.WordRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.WordRawScore - 1)];
			entity.WordStandartScore = (reader.IsDBNull(((int)WippsiColumn.WordStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.WordStandartScore - 1)];
			entity.UnderstandingRawScore = (reader.IsDBNull(((int)WippsiColumn.UnderstandingRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.UnderstandingRawScore - 1)];
			entity.UnderstandingStandartScore = (reader.IsDBNull(((int)WippsiColumn.UnderstandingStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.UnderstandingStandartScore - 1)];
			entity.SentencesRawScore = (reader.IsDBNull(((int)WippsiColumn.SentencesRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.SentencesRawScore - 1)];
			entity.SentencesStandartScore = (reader.IsDBNull(((int)WippsiColumn.SentencesStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.SentencesStandartScore - 1)];
			entity.ImageDefineRawScore = (reader.IsDBNull(((int)WippsiColumn.ImageDefineRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.ImageDefineRawScore - 1)];
			entity.ImageDefineStandartScore = (reader.IsDBNull(((int)WippsiColumn.ImageDefineStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.ImageDefineStandartScore - 1)];
			entity.AnimalHomesRawScore = (reader.IsDBNull(((int)WippsiColumn.AnimalHomesRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AnimalHomesRawScore - 1)];
			entity.AnimalHomesStandartScore = (reader.IsDBNull(((int)WippsiColumn.AnimalHomesStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AnimalHomesStandartScore - 1)];
			entity.GeometricShapeRawScore = (reader.IsDBNull(((int)WippsiColumn.GeometricShapeRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.GeometricShapeRawScore - 1)];
			entity.GeometricShapeStandartScore = (reader.IsDBNull(((int)WippsiColumn.GeometricShapeStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.GeometricShapeStandartScore - 1)];
			entity.BlocksPatternRawScore = (reader.IsDBNull(((int)WippsiColumn.BlocksPatternRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.BlocksPatternRawScore - 1)];
			entity.BlocksPatternStandartScore = (reader.IsDBNull(((int)WippsiColumn.BlocksPatternStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.BlocksPatternStandartScore - 1)];
			entity.AnimalHomesAgainRawScore = (reader.IsDBNull(((int)WippsiColumn.AnimalHomesAgainRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AnimalHomesAgainRawScore - 1)];
			entity.AnimalHomesAgainStandartScore = (reader.IsDBNull(((int)WippsiColumn.AnimalHomesAgainStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AnimalHomesAgainStandartScore - 1)];
			entity.MazesRawScore = (reader.IsDBNull(((int)WippsiColumn.MazesRawScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.MazesRawScore - 1)];
			entity.MazesStandartScore = (reader.IsDBNull(((int)WippsiColumn.MazesStandartScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.MazesStandartScore - 1)];
			entity.TotalVerbalScore = (reader.IsDBNull(((int)WippsiColumn.TotalVerbalScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.TotalVerbalScore - 1)];
			entity.TotalPerformanceScore = (reader.IsDBNull(((int)WippsiColumn.TotalPerformanceScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.TotalPerformanceScore - 1)];
			entity.TotalScore = (reader.IsDBNull(((int)WippsiColumn.TotalScore - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.TotalScore - 1)];
			entity.TestDate = (System.DateTime)reader[((int)WippsiColumn.TestDate - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)WippsiColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)WippsiColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)WippsiColumn.UpdateDate - 1)];
			entity.UserId = (System.Int32)reader[((int)WippsiColumn.UserId - 1)];
			entity.AdvisorId = (reader.IsDBNull(((int)WippsiColumn.AdvisorId - 1)))?null:(System.Int32?)reader[((int)WippsiColumn.AdvisorId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Ekip.Framework.Entities.Wippsi"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Wippsi"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Ekip.Framework.Entities.Wippsi entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.WippsiId = (System.Int32)dataRow["WippsiID"];
			entity.GeneralRawScore = Convert.IsDBNull(dataRow["GeneralRawScore"]) ? null : (System.Int32?)dataRow["GeneralRawScore"];
			entity.GeneralStandartScore = Convert.IsDBNull(dataRow["GeneralStandartScore"]) ? null : (System.Int32?)dataRow["GeneralStandartScore"];
			entity.SimilarityRawScore = Convert.IsDBNull(dataRow["SimilarityRawScore"]) ? null : (System.Int32?)dataRow["SimilarityRawScore"];
			entity.SimilarityStandartScore = Convert.IsDBNull(dataRow["SimilarityStandartScore"]) ? null : (System.Int32?)dataRow["SimilarityStandartScore"];
			entity.ArithmeticRawScore = Convert.IsDBNull(dataRow["ArithmeticRawScore"]) ? null : (System.Int32?)dataRow["ArithmeticRawScore"];
			entity.ArithmeticStandartScore = Convert.IsDBNull(dataRow["ArithmeticStandartScore"]) ? null : (System.Int32?)dataRow["ArithmeticStandartScore"];
			entity.WordRawScore = Convert.IsDBNull(dataRow["WordRawScore"]) ? null : (System.Int32?)dataRow["WordRawScore"];
			entity.WordStandartScore = Convert.IsDBNull(dataRow["WordStandartScore"]) ? null : (System.Int32?)dataRow["WordStandartScore"];
			entity.UnderstandingRawScore = Convert.IsDBNull(dataRow["UnderstandingRawScore"]) ? null : (System.Int32?)dataRow["UnderstandingRawScore"];
			entity.UnderstandingStandartScore = Convert.IsDBNull(dataRow["UnderstandingStandartScore"]) ? null : (System.Int32?)dataRow["UnderstandingStandartScore"];
			entity.SentencesRawScore = Convert.IsDBNull(dataRow["SentencesRawScore"]) ? null : (System.Int32?)dataRow["SentencesRawScore"];
			entity.SentencesStandartScore = Convert.IsDBNull(dataRow["SentencesStandartScore"]) ? null : (System.Int32?)dataRow["SentencesStandartScore"];
			entity.ImageDefineRawScore = Convert.IsDBNull(dataRow["ImageDefineRawScore"]) ? null : (System.Int32?)dataRow["ImageDefineRawScore"];
			entity.ImageDefineStandartScore = Convert.IsDBNull(dataRow["ImageDefineStandartScore"]) ? null : (System.Int32?)dataRow["ImageDefineStandartScore"];
			entity.AnimalHomesRawScore = Convert.IsDBNull(dataRow["AnimalHomesRawScore"]) ? null : (System.Int32?)dataRow["AnimalHomesRawScore"];
			entity.AnimalHomesStandartScore = Convert.IsDBNull(dataRow["AnimalHomesStandartScore"]) ? null : (System.Int32?)dataRow["AnimalHomesStandartScore"];
			entity.GeometricShapeRawScore = Convert.IsDBNull(dataRow["GeometricShapeRawScore"]) ? null : (System.Int32?)dataRow["GeometricShapeRawScore"];
			entity.GeometricShapeStandartScore = Convert.IsDBNull(dataRow["GeometricShapeStandartScore"]) ? null : (System.Int32?)dataRow["GeometricShapeStandartScore"];
			entity.BlocksPatternRawScore = Convert.IsDBNull(dataRow["BlocksPatternRawScore"]) ? null : (System.Int32?)dataRow["BlocksPatternRawScore"];
			entity.BlocksPatternStandartScore = Convert.IsDBNull(dataRow["BlocksPatternStandartScore"]) ? null : (System.Int32?)dataRow["BlocksPatternStandartScore"];
			entity.AnimalHomesAgainRawScore = Convert.IsDBNull(dataRow["AnimalHomesAgainRawScore"]) ? null : (System.Int32?)dataRow["AnimalHomesAgainRawScore"];
			entity.AnimalHomesAgainStandartScore = Convert.IsDBNull(dataRow["AnimalHomesAgainStandartScore"]) ? null : (System.Int32?)dataRow["AnimalHomesAgainStandartScore"];
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
		/// <param name="entity">The <see cref="Ekip.Framework.Entities.Wippsi"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Wippsi Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Ekip.Framework.Entities.Wippsi entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByWippsiId methods when available
			
			#region SeanceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Seance>|SeanceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SeanceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SeanceCollection = DataRepository.SeanceProvider.GetByWippsiId(transactionManager, entity.WippsiId);

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
		/// Deep Save the entire object graph of the Ekip.Framework.Entities.Wippsi object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Ekip.Framework.Entities.Wippsi instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Ekip.Framework.Entities.Wippsi Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Ekip.Framework.Entities.Wippsi entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.WippsiIdSource != null)
						{
							child.WippsiId = child.WippsiIdSource.WippsiId;
						}
						else
						{
							child.WippsiId = entity.WippsiId;
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
	
	#region WippsiChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Ekip.Framework.Entities.Wippsi</c>
	///</summary>
	public enum WippsiChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Wippsi</c> as OneToMany for SeanceCollection
		///</summary>
		[ChildEntityType(typeof(TList<Seance>))]
		SeanceCollection,
	}
	
	#endregion WippsiChildEntityTypes
	
	#region WippsiFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WippsiColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wippsi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WippsiFilterBuilder : SqlFilterBuilder<WippsiColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WippsiFilterBuilder class.
		/// </summary>
		public WippsiFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WippsiFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WippsiFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WippsiFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WippsiFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WippsiFilterBuilder
	
	#region WippsiParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WippsiColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wippsi"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WippsiParameterBuilder : ParameterizedSqlFilterBuilder<WippsiColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WippsiParameterBuilder class.
		/// </summary>
		public WippsiParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WippsiParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WippsiParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WippsiParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WippsiParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WippsiParameterBuilder
	
	#region WippsiSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;WippsiColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wippsi"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WippsiSortBuilder : SqlSortBuilder<WippsiColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WippsiSqlSortBuilder class.
		/// </summary>
		public WippsiSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WippsiSortBuilder
	
} // end namespace
