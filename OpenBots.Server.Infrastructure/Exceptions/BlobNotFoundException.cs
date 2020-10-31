using System;
using System.IO;
using System.Runtime.Serialization;

namespace OpenBots.Server.Core.Exceptions
{
    /// <summary>
    /// Throw this exception when a blob(object/file ect..) cannot find in blob storage.
    /// </summary>
    public class BlobNotFoundException : IOException
    {
        public BlobNotFoundException()
        {
        }

        public BlobNotFoundException(string message) : base(message)
        {
        }

        public BlobNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BlobNotFoundException(string message, int hresult) : base(message, hresult)
        {
        }

        protected BlobNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
