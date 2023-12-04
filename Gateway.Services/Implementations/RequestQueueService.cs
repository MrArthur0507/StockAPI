using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class RequestQueueService : IRequestQueueService
    {
        private readonly Queue<RequestInfo> requestQueue = new Queue<RequestInfo>();

        public void Enqueue(RequestInfo requestInfo)
        {
            lock (requestQueue)
            {
                requestQueue.Enqueue(requestInfo);
            }
        }

        public List<RequestInfo> DequeueAll()
        {
            List<RequestInfo> requests = new List<RequestInfo>();

            lock (requestQueue)
            {
                while (requestQueue.Count > 0)
                {
                    requests.Add(requestQueue.Dequeue());
                }
            }

            return requests;
        }
    }
}
