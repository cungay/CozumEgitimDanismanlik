﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekip.Framework.Core
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns a list of all the exception messages from the top-level
        /// exception down through all the inner exceptions. Useful for making
        /// logs and error pages easier to read when dealing with exceptions.
        /// Usage: Exception.Messages()
        /// </summary>
        public static IEnumerable<string> Messages(this Exception ex) {
            if (ex == null) { yield break; }
            yield return ex.Message;
            IEnumerable<Exception> innerExceptions = Enumerable.Empty<Exception>();
            if (ex is AggregateException && (ex as AggregateException).InnerExceptions.Any()) {
                innerExceptions = (ex as AggregateException).InnerExceptions;
            }
            else if (ex.InnerException != null) {
                innerExceptions = new Exception[] { ex.InnerException };
            }
            foreach (var innerEx in innerExceptions) {
                foreach (string msg in innerEx.Messages()) {
                    yield return msg;
                }
            }
        }
    }
}
