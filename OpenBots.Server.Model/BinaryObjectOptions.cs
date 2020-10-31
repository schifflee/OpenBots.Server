using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Model
{
    /// <summary>
    /// BinaryObjectOptions Configuration Model
    /// </summary>
    public class BinaryObjectOptions
    {
        /// <summary>
        /// Name of Configuration
        /// </summary>
        public const string BinaryObject = "BinaryObjects";
        public Guid Id { get; set; }
        /// <summary>
        /// Adapter Name (i.e. FileSystemAdapter, AzureBlobStorageAdapter)
        /// </summary>
        public string Adapter { get; set; }
        /// <summary>
        /// Path to store binary object
        /// </summary>
        public string Path { get; set; }
    }
}