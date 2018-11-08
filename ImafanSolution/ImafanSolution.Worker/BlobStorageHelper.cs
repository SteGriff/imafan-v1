using ImafanSolution.Models;
using ImafanSolution.ViewModels;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImafanSolution.Worker
{
    public sealed class BlobStorageHelper : StorageHelper
    {
        private readonly CloudBlobClient _blobClient;

        public BlobStorageHelper()
            : base()
        {
            _blobClient = base.StorageAccount.CreateCloudBlobClient();
        }

        
        public Uri CreateBlob(MemoryStream stream, string eventKey)
        {
            return null;
        }


        
    }
}