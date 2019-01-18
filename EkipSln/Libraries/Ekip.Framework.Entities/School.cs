#region Using directives

using System;
using System.ComponentModel;

#endregion

namespace Ekip.Framework.Entities
{
    ///<summary>
    /// An object representation of the 'School' table. [No description found the database]	
    ///</summary>
    /// <remarks>
    /// This file is generated once and will never be overwritten.
    /// </remarks>	
    [Serializable]
    [CLSCompliant(true)]
    public partial class School : SchoolBase
    {
        #region Constructors

        ///<summary>
        /// Creates a new <see cref="School"/> instance.
        ///</summary>
        public School() : base() { }

        #endregion
    }

    [DefaultValue(0)]
    public enum ClassRoom
    {
        [Description("Belirtilmedi")]
        None = 0,
        [Description("Ana sınıfı")]
        MainClass = 9,
        [Description("İlkokul 1.Sınıf")]
        PrimaryFirst = 1,
        [Description("İlkokul 2.Sınıf")]
        PrimarySecond = 2,
        [Description("İlkokul 3.Sınıf")]
        PrimaryThird = 3,
        [Description("İlkokul 4.Sınıf")]
        PrimaryFourth = 4,
        [Description("İlkokul 5.Sınıf")]
        PrimaryFifth = 5,
        [Description("İlkokul 6.Sınıf")]
        PrimarySixth = 6,
        [Description("İlkokul 7.Sınıf")]
        PrimarySeventh = 7,
        [Description("İlkokul 8.Sınıf")]
        PrimaryEighth = 8,
        [Description("Lise 1")]
        HighSchoolFirst = 10,
        [Description("Lise 2")]
        HighSchoolSecond = 11,
        [Description("Lise 3")]
        HighSchoolThird = 12,
        [Description("Lise 4")]
        HighSchoolEighth = 13
    }

    [DefaultValue(0)]
    public enum SchoolType
    {
        [Description("Belirtilmedi")]
        None = 0,
        [Description("Devlet")]
        Married = 1,
        [Description("Özel")]
        Leave = 2,
    }
}
