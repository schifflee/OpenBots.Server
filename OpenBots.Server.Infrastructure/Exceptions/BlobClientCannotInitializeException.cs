using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace OpenBots.Server.Core.Exceptions
{
    /// <summary>
    /// Throw this exception when a blob client object is not created
    /// </summary>
    public class BlobClientCannotInitializeException : IOException
    {
        public BlobClientCannotInitializeException()
        {
        }

        public BlobClientCannotInitializeException(string message) : base(message)
        {
        }

        public BlobClientCannotInitializeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BlobClientCannotInitializeException(string message, int hresult) : base(message, hresult)
        {
        }

        protected BlobClientCannotInitializeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
