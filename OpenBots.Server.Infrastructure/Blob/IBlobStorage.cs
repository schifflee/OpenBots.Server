using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using OpenBots.Server.Model.Core;

namespace OpenBots.Server.Core
{
    /// <summary>
    /// Abstracts the Blob Storage technologies provided by Cloud Providers. Persistent storage for a object. 
    /// </summary>
    public interface IBlobStorage : IDisposable
    {
        /// <summary>
        /// Save the object by serializing and persiting it.
        /// If a Blob Name is not provided then method will created a new GUID key, which will return as Blob Name
        /// </summary>
        /// <typeparam name="T">Type of Object to Store</typeparam>
        /// <param name="objectToStore">Type of Object to Store</param>
        /// <param name="blobName">Unique Blob Name OR 
        ///                        If a Blob Name is not provided then method will created a new GUID key
        /// </param>
        /// <returns>Unique Blob Name</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BlobClientCannotInitializeException"></exception>
        /// <exception cref="BlobStorageNotFoundException"></exception>
        /// <exception cref="BlobCannotSaveException"></exception>
        Task<string> SaveAsync<T>(T objectToStore, string blobName = "");

        /// <summary>
        /// Retrieves the Blob and Deserializes the Object stored in Storage.
        /// </summary>
        /// <typeparam name="T">Type of Object to Retrieve</typeparam>
        /// <param name="blobName">Unique Blob Name</param>
        /// <returns> T Type Object </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BlobNotFoundException"></exception>
        /// <exception cref="BlobCannotLoadException"></exception>
        /// <exception cref="BlobStorageNotFoundException"></exception>
        Task<T> OpenAsync<T>(string blobName);

        /// <summary>
        /// Retrieves the Blob and Deserializes the Object stored in Storage.
        /// </summary>
        /// <typeparam name="T">Type of Object to Retrieve</typeparam>
        /// <param name="blobName">Unique Blob Name</param>
        /// <returns> T Type Object </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BlobNotFoundException"></exception>
        /// <exception cref="BlobCannotLoadException"></exception>
        /// <exception cref="BlobStorageNotFoundException"></exception>
        Task<MemoryStream> OpenStreamAsync<T>(string blobName);

        /// <summary>
        /// Save the Stream into cloud.
        /// If a Blob Name is not provided then method will created a new GUID key, which will return as Blob Name
        /// </summary>
        /// <param name="contentStream">Stream Object</param>
        /// <param name="blobName">Unique Blob Name  OR 
        ///If a Blob Name is not provided then method will created a new GUID key
        /// </param>
        /// <returns>Unique Blob Name </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BlobClientCannotInitializeException"></exception>
        /// <exception cref="BlobCannotSaveException"></exception>
        /// <exception cref="BlobStorageNotFoundException"></exception>
        Task<string> CreateAsync(Stream contentStream, string contentType, string blobName = "");


        /// <summary>
        /// Get the Blob Url/Address of Blob by Blob Name
        /// </summary>
        /// <param name="blobName">Unique Blob Name</param>
        /// <returns>Blob Url OR Address of Blob</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BlobNotFoundException"></exception>
        /// <exception cref="BlobCannotLoadException"></exception>
        /// <exception cref="BlobStorageNotFoundException"></exception>
        string GetAddressByName(string blobName);


        /// <summary>
        /// Delete the blob from cloud
        /// </summary>
        /// <param name="blobName">Blob Name which you want to delete</param>
        /// <returns>if blob is deleted from cloud then it will return 'true' else 'false'</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="BlobNotFoundException"></exception>
        /// <exception cref="BlobCannotDeletedException"></exception>
        /// <exception cref="BlobStorageNotFoundException"></exception>
        Task<bool> Delete(string blobName);

        /// <summary>
        /// Get the Bytes from the blob
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        Task<Byte[]> GetBlobBytesAsync(string blobName);

        /// <summary>
        /// Get the content type for the given blob
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        Task<string> GetContentType(string blobName);


        /// <summary>
        /// Get the Bytes from the blob
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        Task<Byte[]> GetBlobBytesAsync(StorageAddress storageAddress);

        /// <summary>
        /// Generate user temporary url for blob with id objectKey with expire time
        /// </summary>
        /// <returns></returns>
        Task<string> GeneratePreSignedURL(string objectKey, DateTime expireTime);

       // Task<CloudBlockBlob> GetBlockBlob(string blobName);

        /// <summary>
        /// download Blob File
        /// </summary>
        /// <returns>blob stream</returns>
        //Task<CloudBlockBlob> DownloadBlobFile(string blobUrl, string filePath);
    }
}
