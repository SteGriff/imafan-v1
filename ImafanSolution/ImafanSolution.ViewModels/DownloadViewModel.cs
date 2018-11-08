using ImafanSolution.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ImafanSolution.ViewModels
{
    public class DownloadViewModel
    {
        private readonly CloudStorageAccount _storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["Azure.Storage.ConnectionString"]);
        private readonly string _filename;

        public DownloadViewModel(string filename)
        {
            _filename = filename;
        }
                
        public async Task<DownloadPayload> GetStreamAsync()
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("pages");
            
            ICloudBlob blob = container.GetBlockBlobReference(_filename);
            Stream blobStream = await blob.OpenReadAsync();

            DownloadPayload payload = new DownloadPayload();
            payload.Stream = blobStream;
            payload.ContentType = blob.Properties.ContentType;
            return payload;
        }
        
        public DownloadPayload GetStream()
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("pages");

            ICloudBlob blob = container.GetBlockBlobReference(_filename);
            Stream blobStream = blob.OpenRead();
            
            DownloadPayload payload = new DownloadPayload();
            payload.Stream = blobStream;
            payload.ContentType = blob.Properties.ContentType;
            return payload;
        }

        public async Task<string> GetSecureUrl()
        {
            return await Task.FromResult<string>(String.Empty);
        }
    }
}