﻿
using System;
using System.ComponentModel;

using Ekip.Framework.Entities;

namespace Ekip.Framework.Services
{
	/// <summary>
	/// The interface that each complex business unit of work processor will use.
	/// </summary>
	public abstract class ProcessorBase : IProcessor
	{
		private string processName = null;
		private ProcessorState currentProcessorState = ProcessorState.Unknown;
		
		/// <summary>
		///	Provides a List of Processors to execute business process logic in.
		/// </summary>
		///<value>A list of business rule processors to execute</value>
		public virtual IProcessorResult Process()
		{	
			throw new NotImplementedException();
		}
		
		/// <summary>
		///	Provides the current process result of it's operation.
		/// </summary>
		public abstract IProcessorResult ProcessResult {	get;	}
		
		
		/// <summary>
		///	Provides a name of the current processor to execute business process logic in.
		/// </summary>
		///<value>The name of the type of the processors to execute</value>
		public virtual string ProcessName
		{
			get{	
					if (processName == null)
						processName = this.GetType().FullName;
						
					return processName;	  
				}
			set{    
					if (!string.IsNullOrEmpty(processName))
						processName = value; 
				}
		}
				
		/// <summary>
		///	Provides the current process state of operation.
		/// </summary>
		public virtual ProcessorState CurrentProcessorState
		{
			get {	return currentProcessorState;	}
		}
		
		/// <summary>
		///	Provides the notification on the change of process state to interested parties.
		/// </summary>
		public virtual void ChangeProcessorState(ProcessorState newProcessorState)
		{
			if (newProcessorState == currentProcessorState)
				return;
			
			OnNotifyProcessorStateChanging(newProcessorState);
			currentProcessorState = newProcessorState; 
			
			if (ProcessResult != null)
				ProcessResult.FinalProcessorState = newProcessorState;
		}
		
		#region Events
		/// <summary>
		/// The ProcessorStateChanging event.
		/// </summary>
        [field: NonSerialized]
        public static event EventHandler<GenericStateChangedEventArgs<ProcessorState>> ProcessorStateChanging;
		
		/// <summary>
		/// The ProcessorStateChangingEventHandler event handler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public delegate void ProcessorStateChangingEventHandler(object sender, GenericStateChangedEventArgs<ProcessorState> e);
			
		/// <summary>
		/// Raises the ProcessorStateChanging event.
		/// </summary>
		/// <param name="newProcessorState"></param>
		public virtual void OnNotifyProcessorStateChanging(ProcessorState newProcessorState)
		{
			if (ProcessorStateChanging != null)
            {
                ProcessorStateChanging(this, new GenericStateChangedEventArgs<ProcessorState>(currentProcessorState, newProcessorState));
            }			
		}
        #endregion	
	}
}
