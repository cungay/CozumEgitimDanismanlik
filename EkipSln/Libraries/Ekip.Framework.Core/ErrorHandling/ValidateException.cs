using System;
using System.Runtime.Serialization;
using Ekip.Framework.Core.Resources;

namespace Ekip.Framework.Core.ErrorHandling
{
    public class ValidateException : Exception
    {
        /// <summary>
        /// Just create the exception
        /// </summary>
        public ValidateException()
          : base(Messages.Validate_Error)
        {
        }

        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="entityKey">object name</param>
        public ValidateException(String message)
          : base(message)
        {
        }

        /// <summary>
        /// Create the exception with description and inner cause
        /// </summary>
        /// <param name="entityKey">object name</param>
        /// <param name="innerException">Exception inner cause</param>
        public ValidateException(String message, Exception innerException)
           : base(message, innerException)
        {
        }

        protected ValidateException(SerializationInfo info, StreamingContext context)
         : base(info, context)
        { }
    }
}
