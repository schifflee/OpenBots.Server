using System;
using System.IO;
using System.Runtime.Serialization;

namespace OpenBots.Server.Core.Exceptions
{
    /// <summary>
    /// Throw this exception when a blob cannot be deleted from cloud.
    /// </summary>
    public class CannotDeleteBlobException : IOException
    {
        public CannotDeleteBlobException()
        {
        }

        public CannotDeleteBlobException(string message) : base(message)
        {
        }

        public CannotDeleteBlobException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CannotDeleteBlobException(string message, int hresult) : base(message, hresult)
        {
        }

        protected CannotDeleteBlobException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
