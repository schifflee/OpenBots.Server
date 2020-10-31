using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace OpenBots.Server.Core.Exceptions
{
    public class CannotGenerateBlobAddressException : IOException
    {
        public CannotGenerateBlobAddressException()
        {
        }

        public CannotGenerateBlobAddressException(string message) : base(message)
        {
        }

        public CannotGenerateBlobAddressException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CannotGenerateBlobAddressException(string message, int hresult) : base(message, hresult)
        {
        }

        protected CannotGenerateBlobAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
