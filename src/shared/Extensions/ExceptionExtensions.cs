using System;
using System.Text;

namespace Keycloak.Net.Shared.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Exception"/>
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Flatten and merges all inner exception messages
        /// </summary>
        public static string FlattenError(this Exception exception, bool stackTrace = false)
        {
            var builder = new StringBuilder();
            var count = 0;
            Exception currentException;
            var innerException = exception;

            do
            {
                // Append all inner exception messages
                currentException = innerException;
                builder.AppendLine($"{(count != 0 ? "-> " : string.Empty)}[{currentException.GetType().Name}]: {currentException.Message}");
                innerException = currentException.InnerException;
                count++;
            } while (innerException != null);

            if (stackTrace)
            {
                // include stack trace
                builder.AppendLine();
                builder.AppendLine("Stack Trace:");
                builder.AppendLine(exception.StackTrace);
            }

            return builder.ToString();
        }
    }
}
