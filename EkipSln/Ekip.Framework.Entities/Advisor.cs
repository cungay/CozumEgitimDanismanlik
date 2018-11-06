#region Using directives

using System;

#endregion

namespace Ekip.Framework.Entities
{
    ///<summary>
    /// An object representation of the 'Advisor' table. [No description found the database]	
    ///</summary>
    /// <remarks>
    /// This file is generated once and will never be overwritten.
    /// </remarks>	
    [Serializable]
    [CLSCompliant(true)]
    public partial class Advisor : AdvisorBase
    {
        #region Constructors

        ///<summary>
        /// Creates a new <see cref="Advisor"/> instance.
        ///</summary>
        public Advisor() : base() { }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}", String.IsNullOrWhiteSpace(Title) 
                ? FullName : string.Format("{0}{1}", Title, FullName));
        }
    }
}
