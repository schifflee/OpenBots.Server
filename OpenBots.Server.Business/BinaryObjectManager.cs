using Ionic.Zip;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OpenBots.Server.DataAccess.Repositories;
using OpenBots.Server.Model;
using OpenBots.Server.Model.Identity;
using OpenBots.Server.Security;
using OpenBots.Server.Model.SystemConfiguration;
using OpenBots.Server.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OpenBots.Server.Business
{
    public class BinaryObjectManager : BaseManager, IBinaryObjectManager
    {
        private readonly IBlobStorageAdapter blobStorageAdapter;
        private readonly IFileSystemAdapter fileSystemAdapter;
        private readonly ConfigurationValue options;
        private readonly IOrganizationMemberRepository organizationMemberRepository;
        private readonly IOrganizationManager organizationManager;
        private readonly ClaimsPrincipal _caller;
        private readonly IPersonEmailRepository personEmailRepository;
        public IConfiguration Configuration { get; }

        public BinaryObjectManager(
            IBlobStorageAdapter blobStorageAdapter,
            IFileSystemAdapter fileSystemAdapter,
            IHttpContextAccessor httpContextAccessor,
            IPersonEmailRepository personEmailRepository,
            IOrganizationMemberRepository organizationMemberRepository,
            IOrganizationManager organizationManager,
            IConfiguration configuration)
        {
            this.blobStorageAdapter = blobStorageAdapter;
            this.fileSystemAdapter = fileSystemAdapter;
            this.personEmailRepository = personEmailRepository;
            this.organizationMemberRepository = organizationMemberRepository;
            this.organizationManager = organizationManager;
            Configuration = configuration;
            _caller = ((httpContextAccessor.HttpContext != null) ? httpContextAccessor.HttpContext.User : new ClaimsPrincipal());
        }

        public string Upload(IFormFile file, string organizationId, string apiComponent)
        {
            string adapter = Configuration["BinaryObjects:Adapter"];
            if (adapter.Equals("FileSystemAdapter"))
            {
                string path = Configuration["BinaryObjects:Path"];
                string binaryObjectId = fileSystemAdapter.SaveFile(file, path, organizationId, apiComponent);
                return binaryObjectId;
            }
            return "Configuration for Azure Blob Storage is not set up yet.";
        }

        public void SaveEntity(IFormFile file, string filePath, string binaryObjectId, string organizationId, string apiComponent, string folder)
        {
            string storageProvider = string.Empty;
            string adapter = Configuration["BinaryObjects:Adapter"];
            if (adapter.Equals("FileSystemAdapter")) 
                storageProvider = Configuration["BinaryObjects:StorageProvider"];
                
            blobStorageAdapter.SaveEntity(file, filePath, binaryObjectId, organizationId, apiComponent, storageProvider, folder);
        }

        public async Task<FileObject> Download(string binaryObjectId)
        {
            return await blobStorageAdapter.FetchFile(binaryObjectId);
        }

        public void Update(IFormFile file, string organizationId, string apiComponent, Guid binaryObjectId)
        {
            string adapter = Configuration["BinaryObjects:Adapter"];
            if (adapter.Equals("FileSystemAdapter"))
            {
                string path = Configuration["BinaryObjects:Path"];
                fileSystemAdapter.UpdateFile(file, path, organizationId, apiComponent, binaryObjectId);
                
            }
        }

        public async Task<string> UpdateEntity(IFormFile file, string filePath, string binaryObjectId, string apiComponent, string folder)
        {
            await blobStorageAdapter.UpdateEntity(file, filePath, binaryObjectId, apiComponent, folder);
            return "Success";
        }

        public string GetOrganizationId()
        {
            string identity = _caller.Identity.Name;
            var personEmail = personEmailRepository.Find(null, q => q.Address.ToLower(null) == identity.ToLower(null))?.Items?.FirstOrDefault();
            string personId = personEmail.PersonId.ToString();
            var orgMember = organizationMemberRepository.Find(0, 1).Items.Where(q => q.PersonId.ToString() == personId).FirstOrDefault();
            string organizationId;
            if (orgMember == null)
                organizationId = organizationManager.GetDefaultOrganization().Id.ToString();
            else organizationId = orgMember.OrganizationId.ToString();

            return organizationId;
        }
    }
}