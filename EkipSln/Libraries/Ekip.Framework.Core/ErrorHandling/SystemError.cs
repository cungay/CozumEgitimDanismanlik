using System;
using System.Runtime.Serialization;
using Ekip.Framework.Core.Resources;

namespace Ekip.Framework.Core.ErrorHandling
{
    [Serializable()]
    public class SystemError : Exception, ISerializable
    {
        #region Fields

        private string caption = null;

        #endregion

        #region Properties

        public string Caption
        {
            get { return SystemMessages.System_Error_Caption; }
            set { caption = value; }
        }

        #endregion

        public SystemError(string message = null)
             : base(SystemMessages.System_Error_Content)
        {
        }

        public SystemError(string message, Exception innerException)
            : base(SystemMessages.System_Error_Content, innerException)
        {
        }
    }
}
