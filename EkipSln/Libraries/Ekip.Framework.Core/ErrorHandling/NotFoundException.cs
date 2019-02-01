using Ekip.Framework.Core.Resources;
using System;

namespace Ekip.Framework.Core.ErrorHandling
{
    [Serializable]
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Just create the exception
        /// </summary>
        public NotFoundException()
          : base(SystemMessages.Record_NotFound)
        {
        }
    }
}
