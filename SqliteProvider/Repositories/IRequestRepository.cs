using Gateway.Domain.Models.DbRelated;
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
        public Task<long> GetRequestCountForIp(string ipAddress, DateTime since);
        public Task AddRequest(string ipAddress, DateTime time);

        public Task AddDetailedRequest(RequestInfo requestInfo);
    }
}
