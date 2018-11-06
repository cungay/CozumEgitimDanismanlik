using System;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace AppFramework
{
    /// <summary>
    /// Contains information about a category
    /// </summary>
    public class CategoryInfo
    {
        public CategoryInfo(string name, int imageIndex)
        {
            Name = name;
            ImageIndex = imageIndex;
        }

        public string Name { get; }

        public int ImageIndex { get; }

        public int Index
        {
            get
            {
                for (int i = 0; i < CategoriesInfo.Instance.Count; i++)
                    if (CategoriesInfo.Instance[i] == this)
                        return i;
                return -1;
            }
        }
    }

    [ListBindable(false)]
    public class CategoriesInfo : CollectionBase
    {
        /// <summary>
        /// Create the static instance of the class
        /// </summary>
        static CategoriesInfo()
        {
            Instance = new CategoriesInfo();
        }

        public CategoryInfo this[int index]
        {
            get { return List[index] as CategoryInfo; }
        }

        public CategoryInfo this[string name]
        {
            get
            {
                for (int i = 0; i < Count; i++)
                    if (name.ToUpper() == this[i].Name.ToUpper())
                        return this[i];
                return null;
            }
        }

        /// <summary>
        /// Register the category in the system
        /// </summary>
        /// <param name="name"></param>
        /// <param name="imageIndex"></param>
        public static void Add(string name, int imageIndex)
        {
            CategoryInfo item = new CategoryInfo(name, imageIndex);
            Instance.List.Add(item);
        }

        public static void Add(string name)
        {
            Add(name, -1);
        }

        public static CategoriesInfo Instance { get; private set; }
    }

    /// <summary>
    /// Contains information about a module
    /// </summary>
    public class ModuleInfo
    {
        private Type moduleType = null;

        public ModuleInfo(string name, Type moduleType, CategoryInfo category, int imageIndex)
        {
            // throw exception if the module is not inherited from BaseModule class
            if (!moduleType.IsSubclassOf(typeof(BaseModule)))
                throw new ArgumentException("moduleClass has to be inherited from BaseModule");
            // if there is no any category yet, create the default one
            if (CategoriesInfo.Instance.Count == 0)
                CategoriesInfo.Add("Default");
            if (category == null)
                category = CategoriesInfo.Instance[0];
            this.Name = name;
            this.Category = category;
            this.ImageIndex = imageIndex;
            this.moduleType = moduleType;
            this.Module = null;
        }

        public CategoryInfo Category { get; }

        public int ImageIndex { get; }

        public string Name { get; }

        /// <summary>
        /// Show the module on the particular control
        /// </summary>
        /// <param name="control"></param>
        public void Show(Control control)
        {
            CreateModule();
            Module.Visible = false;
            Module.Parent = control;
            Module.Dock = DockStyle.Fill;
            Module.Visible = true;
        }

        /// <summary>
        /// Make the module invisible
        /// </summary>
        public void Hide()
        {
            if (Module != null)
                Module.Visible = false;
        }

        /// <summary>
        /// Create the module instance
        /// </summary>
        protected void CreateModule()
        {
            if (this.Module == null)
            {
                ConstructorInfo constructorInfoObj = moduleType.GetConstructor(Type.EmptyTypes);
                if (constructorInfoObj == null)
                    throw new ApplicationException(moduleType.FullName + " doesn't have public constructor with empty parameters");
                this.Module = constructorInfoObj.Invoke(null) as BaseModule;
            }
        }

        /// <summary>
        /// Module instance
        /// </summary>
        public BaseModule Module { get; private set; }
    }

    // The list of modules registered in the system
    [ListBindable(false)]
    public class ModuleInfoCollection : CollectionBase
    {
        ModuleInfo currentModule;
        // create the static instance of the class
        static ModuleInfoCollection()
        {
            Instance = new ModuleInfoCollection();
        }
        ModuleInfoCollection()
        {
            this.currentModule = null;
        }
        public ModuleInfo this[int index] { get { return List[index] as ModuleInfo; } }
        public ModuleInfo this[string name]
        {
            get
            {
                foreach (ModuleInfo info in this)
                    if (info.Name.Equals(name))
                        return info;
                return null;
            }
        }
        // Register the module in the system
        public static void Add(string name, Type moduleType, CategoryInfo category, int imageIndex)
        {
            ModuleInfo item = new ModuleInfo(name, moduleType, category, imageIndex);
            Instance.Add(item);
        }
        public static ModuleInfoCollection Instance { get; private set; }
        //Show the module on the particular control
        public static void ShowModule(ModuleInfo item, Control parent)
        {
            if (item == Instance.currentModule) return;
            if (Instance.currentModule != null)
                Instance.currentModule.Hide();
            item.Show(parent);
            Instance.currentModule = item;
            // update UI action objects
            item.Module.Actions.UpdateVisibility();
            item.Module.UpdateActions();
            item.Module.InitForm();
        }
        // return the currently showing module
        public static ModuleInfo CurrentModuleInfo { get { return Instance.currentModule; } }
        void Add(ModuleInfo value)
        {
            if (List.IndexOf(value) < 0)
                List.Add(value);
        }
    }
}