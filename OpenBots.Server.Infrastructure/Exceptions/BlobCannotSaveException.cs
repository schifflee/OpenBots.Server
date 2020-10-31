using System;
using System.IO;
using System.Runtime.Serialization;

namespace OpenBots.Server.Core.Exceptions
{
    /// <summary>
    /// Throw this exception when a Blob cannot be saved.
    /// </summary>
    public class BlobCannotSaveException : IOException
    {
        public BlobCannotSaveException()
        {
        }

        public BlobCannotSaveException(string message) : base(message)
        {
        }

        public BlobCannotSaveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BlobCannotSaveException(string message, int hresult) : base(message, hresult)
        {
        }

        protected BlobCannotSaveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
