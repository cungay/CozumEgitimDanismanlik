#region Using directives

using System;
using System.ComponentModel;

#endregion

namespace Ekip.Framework.Entities
{
    ///<summary>
    /// An object representation of the 'ClientAddress' table. [No description found the database]	
    ///</summary>
    /// <remarks>
    /// This file is generated once and will never be overwritten.
    /// </remarks>	
    [Serializable]
    [CLSCompliant(true)]
    public partial class ClientAddress : ClientAddressBase
    {
        #region Constructors

        ///<summary>
        /// Creates a new <see cref="ClientAddress"/> instance.
        ///</summary>
        public ClientAddress() : base() { }

        #endregion
    }

    [DefaultValue(0)]
    [Description("Adres Başlığı")]
    public enum AddressTitles
    {
        [Description("Belirtilmedi")]
        None = 0,

        [Description("Ev Adresi")]
        Home = 1,

        [Description("İş Adresi")]
        Job = 2,

        [Description("Diğer")]
        Other = 3
    }

    public class AddressComplexType
    {
        public int FileNumber { get; set; }

        public int AddressId { get; set; }
    }
}
