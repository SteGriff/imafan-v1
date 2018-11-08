using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace ImafanSolution.Worker
{
    public abstract class StorageHelper
    {
        protected readonly CloudStorageAccount StorageAccount;

        public StorageHelper()
        {
            this.StorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
        }
    }
}
