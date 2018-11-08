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
    public enum AddressTitles
    {
        [Description("BELİRTİLMEDİ")]
        None = 0,

        [Description("EV ADRESİ")]
        Home = 1,

        [Description("İŞ ADRESİ")]
        Job = 2,

        [Description("DİĞER")]
        Other = 3
    }
}
