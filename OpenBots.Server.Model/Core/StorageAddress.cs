using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Model.Core
{
    /// <summary>
    /// Defines Protocol that will be used to Save or Retrieve an Object
    /// </summary>
    public enum StorageProtocolType
    {
        Unknown = 0,
        File = 1,
        Http = 2,
        Https = 3,
        Ftp = 4,
        Sftp = 5,
        Email = 6,
        Blob = 101,
        Table = 102,
        Entity = 103,
    }

    /// <summary>
    /// A Uri like Schema that us used to define how and where the object has been stored.
    /// eg: Blob://defaultBlob/blobFolder/BlobFile.txt - This is what BlobStorage will use 
    /// </summary>
    public class StorageAddress
    {
        public StorageAddress()
        {
        }

        /// <summary>
        /// Initializes StorageAddress with a Uri String
        /// </summary>
        /// <param name="uriAddress"></param>
        public StorageAddress(string uriAddress)
        {
            Uri uri = new Uri(uriAddress);
            Protocol = (StorageProtocolType)Enum.Parse(typeof(StorageProtocolType), uri.Scheme, true);
            Parameter = uri.Query.Trim('/');
            StorageService = uri.Host;
            Address = uri.PathAndQuery.Substring(uri.Query.Length).Trim('/');
        }


        /// <summary>
        /// Initializes StorageAddress with a Uri Object
        /// </summary>
        /// <param name="addressUri"></param>
        public StorageAddress(Uri addressUri)
        {
            Protocol = (StorageProtocolType)Enum.Parse(typeof(StorageProtocolType), addressUri.Scheme, true);
            Parameter = addressUri.Query.Trim('/');
            StorageService = addressUri.Host;
            Address = addressUri.PathAndQuery.Substring(addressUri.Query.Length).Trim('/');
        }

        public StorageAddress(StorageProtocolType protocol, string service, string address, string parameter)
        {
            Protocol = protocol;
            StorageService = service ?? throw new ArgumentNullException(nameof(service));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
        }

        public StorageProtocolType Protocol { get; set; }
        public string StorageService { get; set; }
        public string Address { get; set; }
        public string Parameter { get; set; }

        public Uri ToUri()
        {
            return new Uri(ToString());
        }

        public override string ToString()
        {
            return string.Format("{0}://{1}/{2}?{3}", Protocol, StorageService, Address, Parameter);
        }
    }
}
