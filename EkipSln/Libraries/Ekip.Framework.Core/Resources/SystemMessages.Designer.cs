﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ekip.Framework.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SystemMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SystemMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ekip.Framework.Core.Resources.SystemMessages", typeof(SystemMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ekip Norma Razon Aile Danışmanlık Merkezi.
        /// </summary>
        public static string Default_Caption {
            get {
                return ResourceManager.GetString("Default_Caption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dosya bulunamadı..
        /// </summary>
        public static string File_NotFound_Caption {
            get {
                return ResourceManager.GetString("File_NotFound_Caption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} numaralı dosya sistemde bulunamadı. Aradığınız dosyanın sistemde olduğunu düşünüyorsanız, sistem yöneticisi ile irtibata geçebilirsiniz..
        /// </summary>
        public static string File_NotFound_Content {
            get {
                return ResourceManager.GetString("File_NotFound_Content", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} numaralı dosya değiştirildi..
        /// </summary>
        public static string FileChanged_Caption {
            get {
                return ResourceManager.GetString("FileChanged_Caption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;b&gt;{0}&lt;/b&gt; numaralı dosyada bir yada birden fazla değişiklik yapıldığı tespit edildi.&lt;br&gt;&lt;br&gt;Değişiklikleri kaydetmek istiyor musunuz ?.
        /// </summary>
        public static string FileChanged_Content {
            get {
                return ResourceManager.GetString("FileChanged_Content", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sistem Hatası.
        /// </summary>
        public static string System_Error_Caption {
            get {
                return ResourceManager.GetString("System_Error_Caption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sistem bir ya da birden fazla hata ile karşılaştı..
        /// </summary>
        public static string System_Error_Content {
            get {
                return ResourceManager.GetString("System_Error_Content", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bir ya da birden fazla veri giriş hatası bulundu..
        /// </summary>
        public static string Validate_Error_Caption {
            get {
                return ResourceManager.GetString("Validate_Error_Caption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;u&gt;İşleme devam edilemiyor. Lütfen formu kontrol edin.&lt;/u&gt;.
        /// </summary>
        public static string Validate_Error_Content {
            get {
                return ResourceManager.GetString("Validate_Error_Content", resourceCulture);
            }
        }
    }
}
