using System;
using System.IO;
using System.Runtime.Serialization;

namespace OpenBots.Server.Core.Exceptions
{
    /// <summary>
    /// Throw this exception when a blob cannot be retrieved from its storage to memory.
    /// </summary>
    public class BlobCannotLoadException : IOException
    {
        public BlobCannotLoadException()
        {
        }

        public BlobCannotLoadException(string message) : base(message)
        {
        }

        public BlobCannotLoadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BlobCannotLoadException(string message, int hresult) : base(message, hresult)
        {
        }

        protected BlobCannotLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
