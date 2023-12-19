using Gateway.Domain.Models.DbRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface IRequestInfoStorageService
    {
        void AddProcessedRequest(RequestInfo requestInfo);
        IEnumerable<RequestInfo> GetProcessedRequests();

        public void ClearList();
    }
}
