using ImafanSolution.Extensions;
using ImafanSolution.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;

namespace ImafanSolution.ViewModels
{
    public class FanPageViewModel
    {

        private readonly CloudStorageAccount _storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["Azure.Storage.ConnectionString"]);

        private readonly string _username;
        private readonly string _pagename;
        private readonly string _filename;
        private DownloadPayload _payload;

        public HtmlString Content { get; }

        public EditorViewModel EditorModel
        {
            get
            {
                if (CanEdit)
                {
                    return new EditorViewModel { Content = Content };
                }
                return new EditorViewModel();
            }
        }

        public bool CanEdit
        {
            get
            {
                var currentMember = HttpContext.Current.User.Identity.Name;
                return _username == currentMember;
            }
        }

        public FanPageViewModel(string username, string pagename)
        {
            _username = username;
            _pagename = pagename;
            _filename = GetFilename(username, pagename);

            try
            {
                _payload = GetPayload();
                Content = new HtmlString(_payload.Stream.ReadEntireStreamToString());
            }
            catch (Exception)
            {
                Content = new HtmlString("Oops! No such page!");
            }
        }

        private DownloadPayload GetPayload()
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
        
        private string GetFilename(string user, string page)
        {
            return user + "_" + page + ".htm";
        }

    }
}
