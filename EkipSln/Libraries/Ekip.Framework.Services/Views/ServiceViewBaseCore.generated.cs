﻿#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Ekip.Framework.Entities;
using Ekip.Framework.Entities.Validation;
using Ekip.Framework.Data;
using Ekip.Framework.Data.Bases;

using Microsoft.Practices.EnterpriseLibrary.Logging;
#endregion

namespace Ekip.Framework.Services
{
	/// <summary>
	/// The interface that each component business domain service of the model implements.
	/// </summary>
	[CLSCompliant(true)]
	public abstract class ServiceViewBaseCore<Entity> : MarshalByRefObject, IComponentService, IEntityViewProvider<Entity>
        where Entity : new()
	{
		
		private IList<IProcessor> processorList = new List<IProcessor>();
		private ServiceResult serviceResult = null;
		private bool abortOnFailure = true;
		private int currentProcessorIndex = 0;
		
		/// <summary>
		///	Provides the beginning
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public virtual ServiceResult Execute()
		{
			return Execute(false);
		}
		
		/// <summary>
		///	Provides the beginning
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public virtual ServiceResult Execute(bool abortIfFailure)
		{
			AbortOnFailure = abortIfFailure;
			ServiceResult result = new ServiceResult();
		
		
			for(int i=0; i < ProcessorList.Count; i++)
			{
				currentProcessorIndex = i;
				
				if (ProcessorList[i] == null)
					throw new ArgumentNullException(string.Format("The process located at index {0} of the ProcessorList is null.", i));
					
				//Fire Process Starting Event
				OnProcessStarting((ProcessorBase)ProcessorList[i]);
				
				ProcessorList[i].ChangeProcessorState(ProcessorState.Running);
				IProcessorResult processResult = null;
				
				try
				{
					//Begin Process
					processResult = ProcessorList[i].Process();
				}
				catch(Exception exc)
				{
					Logger.Write(exc);
					result.ExceptionList.Add((ProcessorBase)ProcessorList[i], exc);
				}
				
				//if the processor didn't do cleanup, cleanup by default.
				if (ProcessorList[i].CurrentProcessorState == ProcessorState.Running)
					ProcessorList[i].ChangeProcessorState(processResult.Result ? ProcessorState.Completed : ProcessorState.Stopped);

				if (processResult != null)
				{
					//Add to Processor Result List
					result.ProcessorResultList.Add(processResult);
	
					//Add To Aggregated Broken Rules List
 					foreach(BrokenRulesList list in processResult.BrokenRulesLists.Values)
                        result.ProcessBrokenRuleLists.Add((ProcessorBase)ProcessorList[i], list);
				}
				
				//Fire Process Ending Event
				OnProcessEnded(ProcessorList[i] as ProcessorBase);

				if ((processResult == null || !processResult.Result) && AbortOnFailure)
					return result;

			}
			return result;
		}
		
		/// <summary>
		///	Provides a List of Processors to execute external business process logic in.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public virtual IList<IProcessor> ProcessorList 
		{
			get
				{
					return processorList;
				} 
			set
				{
					processorList = value;
				}
		}

		/// <summary>
		///	Provides a Notification Pattern of Process Results.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public virtual ServiceResult ServiceProcessResult
		{
			get{
				if (serviceResult == null)
					serviceResult = new ServiceResult();
				
				return serviceResult;
			}
		}

		/// <summary>
		///	Provides a way to terminate the Processor calls upon an exception. 
		/// </summary>
		///<value>bool value determining to stop once an exceptions been thrown. </value>		
		public virtual bool AbortOnFailure 
		{
			get
			{
				return abortOnFailure;
			} 
			set
			{
				abortOnFailure = value;
			} 
		}

		/// <summary>
		/// Current Processor being executed
		/// </summary>
		public virtual string CurrentProcessor
		{
			get {
					if (ProcessorList.Count > CurrentProcessorIndex)
						return ProcessorList[CurrentProcessorIndex].ProcessName;
					
					return null;
				}	
		}

		/// <summary>
		/// Current Number of Processes completed thus far.
		/// </summary>
		public virtual int ProcessCounter
		{
			get {return currentProcessorIndex + 1;}
		}
		
		/// <summary>
		/// Current index of the processor currently or last executed 
		/// </summary>
		public virtual int CurrentProcessorIndex
		{
			get {return currentProcessorIndex;}
		}
		
		/// <summary>
		/// Total Number of Processes currently enlisted in this service 
		/// </summary>
		public virtual int TotalProcesses
		{
			get {return ProcessorList.Count;}
		}
		
		#region Events
		/// <summary>
		///	Provides the notification on the change of process state to interested parties.
		/// </summary>
		public virtual void OnProcessStarting(ProcessorBase processor)
		{
			if (ProcessStarting != null)
				ProcessStarting(this, new ProcessorEventArgs(processor));
		}

		/// <summary>
		///	Provides the notification on the change of process state to interested parties.
		/// </summary>
		public virtual void OnProcessEnded(ProcessorBase processor)
		{
			if (ProcessEnded != null)
				ProcessEnded(this, new ProcessorEventArgs(processor));
		}
		
		/// <summary>
		/// Event to indicate that a processor has began.
		/// </summary>
		[field: NonSerialized]
		public event ProcessStartingHandler ProcessStarting;

		/// <summary>
		/// Event to indicate that a processor has ended.
		/// </summary>
		[field: NonSerialized]
		public event ProcessEndedHandler ProcessEnded;
	
		#endregion Events	

		#region IEntityViewProvider Implementation
		
        #region Get Methods

        /// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <remarks></remarks>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual VList<Entity> Get()
        {
            return Get(null, null, 0, int.MaxValue);
        }

        /// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <param name="start">Row number at which to start reading.</param>
        /// <param name="pageLength">Number of rows to return.</param>
        /// <remarks></remarks>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual VList<Entity> Get(int start, int pageLength)
        {
            return Get(null, null, start, pageLength);
        }

        /// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <param name="start">Row number at which to start reading.</param>
        /// <param name="pageLength">Number of rows to return.</param>
        /// <param name="count">The total number of rows in the data source.</param>
        /// <remarks></remarks>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual VList<Entity> Get(int start, int pageLength, out int count)
        {
            return Get(null, null, start, pageLength, out count);
        }

        /// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <param name="whereClause">.</param>
        /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
        /// <remarks></remarks>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual VList<Entity> Get(string whereClause, string orderBy)
        {
            return Get(whereClause, orderBy, 0, int.MaxValue);
        }


        /// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
        /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
        /// <param name="start">Row number at which to start reading.</param>
        /// <param name="pageLength">Number of rows to return.</param>
        /// <remarks></remarks>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public virtual VList<Entity> Get(string whereClause, string orderBy, int start, int pageLength)
        {
            int count;
            return Get(whereClause, orderBy, start, pageLength, out count);
        }

        /// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
        /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
        /// <param name="start">Row number at which to start reading.</param>
        /// <param name="pageLength">Number of rows to return.</param>
        /// <param name="count">The total number of rows in the data source.</param>
        /// <remarks></remarks>
        /// <returns>Returns a typed collection of Entity objects.</returns>
        public abstract VList<Entity> Get(string whereClause, string orderBy, int start, int pageLength, out int count);

        #endregion Get Methods
		
		#region GetAll Methods

        /// <summary>
        /// Gets All rows from the DataSource.
        /// </summary>
        /// <param name="start">Row number at which to start reading.</param>
        /// <param name="pageLength">Number of rows to return.</param>
        /// <param name="count">The total number of rows in the data source.</param>
        /// <remarks></remarks>
        /// <returns>Returns a typed collection of Entity objects.</returns>
       	public virtual VList<Entity> GetAll(int start, int pageLength, out int count)
		{
			throw new NotImplementedException();
		}

		#endregion GetAll Methods

		#region GetPaged Methods

		/// <summary>
        /// Gets a page of rows from the DataSource.
        /// </summary>
        /// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
        /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
        /// <param name="start">Row number at which to start reading.</param>
        /// <param name="pageLength">Number of rows to return.</param>
        /// <param name="count">Number of rows in the DataSource.</param>
        /// <returns>Returns a VList of Entity objects.</returns>
        public virtual VList<Entity> GetPaged(String whereClause, String orderBy, int start, int pageLength, out int count)
        {
            throw new NotImplementedException();
        }

		#endregion GetPaged Methods

		#region Find Methods
		
		/// <summary>
		/// Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public virtual VList<Entity> Find(IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			throw new NotImplementedException();
		}
		
		#endregion Find Methods

		#endregion IEntityViewProvider Implementation
	}
}
