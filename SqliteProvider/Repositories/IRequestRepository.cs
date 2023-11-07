using SqliteProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Repositories
{
    public interface IRequestRepository
    {
        public void AddRequest(string ip, DateTime requestTime);

        public List<Request> GetAllRequests();

        public long GetRequestCountForIpAddressInTimeFrame(string ipAddress, DateTime timeOneMinuteAgo);
    }
}
