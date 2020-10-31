using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace OpenBots.Server.Core.Exceptions
{
    /// <summary>
    /// Throw this exception when Blob storage is not found, in which we are uploading the objects.
    /// </summary>
    public class BlobStorageNotFoundException : IOException
    {
        public BlobStorageNotFoundException()
        {
        }

        public BlobStorageNotFoundException(string message) : base(message)
        {
        }

        public BlobStorageNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BlobStorageNotFoundException(string message, int hresult) : base(message, hresult)
        {
        }

        protected BlobStorageNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
