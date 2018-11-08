using ImafanSolution.Data;
using ImafanSolution.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImafanSolution.Worker
{
    public class Functions
    {
        private static readonly BlobStorageHelper _blobHelper = new BlobStorageHelper();
        private static readonly TableStorageHelper _tableHelper = new TableStorageHelper();
        private static readonly IQueueHelper<CloudQueueMessage> _queueHelper = new TableStorageQueueHelper();

        public static void ProcessQueueMessage([QueueTrigger("signin")] QueueMessage message, TextWriter log)
        {
            HandleMessage(message);
        }

        private static void HandleMessage(QueueMessage message)
        {
            switch (message.MessageType)
            {
                case QueueMessageType.SignIn:
                    HandleSignInMessage(message);
                    break;
            }
        }

        private static void HandleSignInMessage(QueueMessage message)
        {
            using (EventsContext context = new EventsContext())
            {
                var eventItem = context.Events.SingleOrDefault(e => e.Id == message.EventId);

                IEnumerable<string> names;//= _tableHelper.GetRegistrantNames(eventItem.EventKey);

                //TODO SG Get a real file stream
                using (MemoryStream stream = new MemoryStream())
                {
                    Uri documentUrl = _blobHelper.CreateBlob(stream, eventItem.EventKey);
                    eventItem.SignInDocumentUrl = documentUrl.AbsoluteUri;
                }

                context.SaveChanges();
            }
        }
    }
}
