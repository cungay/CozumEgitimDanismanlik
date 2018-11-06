using System;
using System.Collections;
using DevExpress.XtraBars;

namespace AppFramework
{
    /// <summary>
    /// The abstract Action class
    /// </summary>
    public abstract class Action
    {
        public Action(object control)
        {
            this.Control = control;
        }

        /// <summary>
        /// If true the action is implemented in the particular module and UI object is visible
        /// If false the action is not implemented and UI object is invisible
        /// </summary>
        public abstract bool Visible { get; set; }

        /// <summary>
        /// Enabled state of the UI object
        /// </summary>
        public abstract bool Enabled { get; set; }

        /// <summary>
        /// True if the UI control in the down/pushed state
        /// </summary>
        public virtual bool IsDown { get { return false; } set { } }

        /// <summary>
        /// The link to the UI control
        /// </summary>
        protected object Control { get; }

        /// <summary>
        /// The action identifying code
        /// </summary>
        internal protected object Key { get; set; }

        public object EditValue
        {
            get { return ((BarEditItem)Control).EditValue; }
            set { ((BarEditItem)Control).EditValue = value; }
        }
    }

    public delegate void ActionModuleHandler(object key, object sender, EventArgs e);

    /// <summary>
    /// The action manager class
    /// It is created in every module
    /// There is the static hashtable of registered global actions. 
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// The global action list
        /// </summary>
        private static Hashtable registeredActions = null;

        /// <summary>
        /// The list of supported actions in the particular module
        /// </summary>
        private Hashtable supportedActions = null;

        static Actions()
        {
            registeredActions = new Hashtable();
        }

        /// <summary>
        /// Register the global action. The key is the action identifying code
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public static void RegisterAction(object key, Action action)
        {
            // If there is already action with the same identifying code, thow exception
            if (registeredActions[key] != null)
                throw new ApplicationException(string.Format("There is already register action with the key '{0}'.", key));
            // Add action into the static hash table
            registeredActions.Add(key, action);
            action.Key = key;
        }

        /// <summary>
        /// For the currently showing module
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void PerformAction(object key, object sender, EventArgs e)
        {
            if (ModuleInfoCollection.CurrentModuleInfo != null)
            {
                BaseModule module = ModuleInfoCollection.CurrentModuleInfo.Module;
                // call perform action for the currenlty showing module
                module.Actions.PerformModuleAction(key, sender, e);
                module.UpdateActions();
            }
        }
        public static void PerformAction(Action action, object sender, EventArgs e)
        {
            PerformAction(action.Key, sender, e);
        }

        /// <summary>
        /// This event will be handled in the BaseModule class
        /// </summary>
        public event ActionModuleHandler OnPerformModuleAction = null;

        /// <summary>
        /// Create the hashtable of the supported actions in the current module
        /// </summary>
        public Actions()
        {
            supportedActions = new Hashtable();
        }

        /// <summary>
        /// Tell that the action will be supported
        /// Provide actionHandler parameter if you want to perform the operation
        /// on the action in the separate method
        /// If the actionHandler is null, Actions.PerformAction method will be called
        /// Please look at PerformModuleAction method
        /// </summary>
        /// <param name="key"></param>
        /// <param name="actionHandler"></param>
        public void AddSupportedAction(object key, ActionModuleHandler actionHandler)
        {
            if (!registeredActions.ContainsKey(key))
                new Exception(string.Format("The action key '{0}' is incorrect", key));
            this.supportedActions.Add(key, actionHandler);
        }

        public void AddSupportedAction(object key)
        {
            AddSupportedAction(key, null);
        }

        /// <summary>
        /// Remove the action from the supported action list
        /// </summary>
        /// <param name="key"></param>
        public void RemoveSupportedActions(object key)
        {
            supportedActions.Remove(key);
        }

        public Action this[object key]
        {
            get
            {
                if (!supportedActions.ContainsKey(key))
                    return null;
                else return registeredActions[key] as Action;
            }
        }

        /// <summary>
        /// Make UI controls binded with supported actions visible
        /// and UI contorls binded with non-supported actions invisible
        /// </summary>
        public void UpdateVisibility()
        {
            foreach (object key in Actions.registeredActions.Keys)
                ((Action)Actions.registeredActions[key]).Visible = this.supportedActions.ContainsKey(key);
        }

        /// <summary>
        /// It is called on clicking UI controls binded with actions
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PerformModuleAction(object key, object sender, EventArgs e)
        {
            object handler = this.supportedActions[key];
            if (handler != null)
                ((ActionModuleHandler)handler)(key, sender, e);
            else
            {
                if (OnPerformModuleAction != null)
                    OnPerformModuleAction(key, sender, e);
            }
        }
    }
}