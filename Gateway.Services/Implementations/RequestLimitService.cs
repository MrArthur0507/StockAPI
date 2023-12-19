using Gateway.Services.Interfaces;
using SqliteProvider.Models;
using SqliteProvider.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class RequestLimitService : IRequestLimitService
    {
        private readonly IRequestRepository _requestRepository;
        public RequestLimitService(IRequestRepository requestRepository) {
            _requestRepository = requestRepository;
        }
        public async Task<bool> IsIpRateLimitedAsync(string ipAddress)
        {
            
            var requestCount = await _requestRepository.GetRequestCountForIp(ipAddress, DateTime.UtcNow.AddMinutes(-1));
            return requestCount > 10;
        }

        public async Task LogRequestDetailsAsync(string ipAddress, DateTime requestTime)
        {
            await _requestRepository.AddRequest(ipAddress, requestTime);
        }
    }
}
