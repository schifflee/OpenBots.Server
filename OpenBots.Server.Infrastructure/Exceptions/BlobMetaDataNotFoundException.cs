using System;
using System.IO;
using System.Runtime.Serialization;

namespace OpenBots.Server.Core.Exceptions
{
    /// <summary>
    /// Throw this exception when a blob(object/file ect..) cannot find in blob storage.
    /// </summary>
    public class BlobMetaDataNotFoundException : IOException
    {
        public BlobMetaDataNotFoundException()
        {
        }

        public BlobMetaDataNotFoundException(string message) : base(message)
        {
        }

        public BlobMetaDataNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BlobMetaDataNotFoundException(string message, int hresult) : base(message, hresult)
        {
        }

        protected BlobMetaDataNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
