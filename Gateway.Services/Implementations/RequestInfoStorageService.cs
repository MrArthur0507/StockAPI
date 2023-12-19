using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class RequestInfoStorageService : IRequestInfoStorageService
    {
        private readonly List<RequestInfo> _processedRequests = new List<RequestInfo>();

        public void AddProcessedRequest(RequestInfo requestInfo)
        {
            _processedRequests.Add(requestInfo);
        }

        public IEnumerable<RequestInfo> GetProcessedRequests()
        {
            return _processedRequests.ToList(); 
        }

        public void ClearList()
        {
            _processedRequests.Clear();
        }
    }
}
