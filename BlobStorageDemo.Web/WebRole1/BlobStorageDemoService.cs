using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;

namespace WebRole1
{
    public class BlobStorageDemoService
    {
        public CloudBlobContainer GetBlobStrorageDemoContainer()
        {
            string connString = "";
            string destContainer = "blobcontainerdemo";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContianer = blobClient.GetContainerReference(destContainer);
            if (blobContianer.CreateIfNotExists())
            {
                blobContianer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
            return blobContianer;
        }
    }
}