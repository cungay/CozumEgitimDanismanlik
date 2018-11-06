using System;
using System.Linq;

namespace Ekip.Framework.Core
{
    public static class ExceptionExtensions
    {
        public static string GetaAllMessages(this Exception exception)
        {
            var messages = exception.FromHierarchy(ex => ex.InnerException)
                .Select(ex => ex.Message);
            return String.Join(Environment.NewLine, messages);
        }
    }
}
