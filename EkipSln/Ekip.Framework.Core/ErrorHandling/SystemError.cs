using Ekip.Framework.Core.Resources;
using System;


namespace Ekip.Framework.Core.ErrorHandling
{
    public class SystemError : Exception
    {
        /// <summary>
        /// Just create the exception
        /// </summary>
        public SystemError()
          : base(Messages.System_Error)
        {
        }

        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="entityKey">object name</param>
        public SystemError(String message)
          : base(string.Format("<u>{0}</u>", message))
        {
        }

        /// <summary>
        /// Create the exception with description and inner cause
        /// </summary>
        /// <param name="entityKey">object name</param>
        /// <param name="innerException">Exception inner cause</param>
        public SystemError(String message, Exception innerException)
          : base(string.Format("<u>{0}</u><br />{1}", message, innerException.Message))
        {
        }
    }
}
