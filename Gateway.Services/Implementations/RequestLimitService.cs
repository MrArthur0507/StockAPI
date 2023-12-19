using Gateway.Services.Interfaces;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        private readonly int limitTime;
        public RequestLimitService(IRequestRepository requestRepository, IConfiguration configuration) {
            _requestRepository = requestRepository;
            _configuration = configuration;
            string time = _configuration.GetRequiredSection("RateLimitingTimeInSecond").Value;
            try
            {
                Console.WriteLine(time);
                limitTime = Int32.Parse(time);
            }
            catch (FormatException ex)
            {
                
            }
            
        }
        public async Task<bool> IsIpRateLimitedAsync(string ipAddress)
        {
            
            var requestCount = await _requestRepository.GetRequestCountForIp(ipAddress, DateTime.UtcNow.AddMinutes(-1));
            return requestCount > limitTime;
        }

        public async Task LogRequestDetailsAsync(string ipAddress, DateTime requestTime)
        {
            await _requestRepository.AddRequest(ipAddress, requestTime);
        }
    }
}
