#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{
    ///<summary>
    /// An object representation of the 'Province' table. [No description found the database]	
    ///</summary>
    /// <remarks>
    /// This file is generated once and will never be overwritten.
    /// </remarks>	
    [Serializable]
    [CLSCompliant(true)]
    public partial class Province : ProvinceBase
    {
        #region Constructors

        ///<summary>
        /// Creates a new <see cref="Province"/> instance.
        ///</summary>
        public Province() : base() { }

        #endregion
        
        public ProvinceArea Area
        {
            get { return (ProvinceArea)AreaId; }
            set { AreaId = (int)value; }
        }
        
        public override string ToString()
        {
            return string.Format("{0} | {1}", PlateCode, ProvinceName);
        }
    }

    public enum ProvinceArea
    {
        [System.ComponentModel.Description("Belirtilmedi")]
        None = 0,
        [System.ComponentModel.Description("Akdeniz")]
        Akdeniz = 1,
        [System.ComponentModel.Description("Ege")]
        Ege = 2,
        [System.ComponentModel.Description("Marmara")]
        Marmara = 3,
        [System.ComponentModel.Description("Karadeniz")]
        Karadeniz = 4,
        [System.ComponentModel.Description("İç Anadolu")]
        Ic_Anadolu = 5,
        [System.ComponentModel.Description("Doğu Anadolu")]
        Dogu_Anadolu = 6,
        [System.ComponentModel.Description("Güneydoğu Anadolu")]
        Guneydogu_Anadolu = 7
    }
}
