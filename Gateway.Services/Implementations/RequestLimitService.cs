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
        private readonly int limitCount;
        private readonly int timePeriod;
        public RequestLimitService(IRequestRepository requestRepository, IConfiguration configuration) {
            _requestRepository = requestRepository;
            _configuration = configuration;
            string maxRequests = _configuration.GetRequiredSection("MaxRequestsForTimePeriod").Value;
            string time = _configuration.GetRequiredSection("RateLimitingTimePeriod").Value;
            limitCount = ConvertStringToInt(maxRequests);
            timePeriod = ConvertStringToInt(time);
        }
        public async Task<bool> IsIpRateLimitedAsync(string ipAddress)
        {
            
            var requestCount = await _requestRepository.GetRequestCountForIp(ipAddress, DateTime.UtcNow.AddMinutes(-timePeriod));
            return requestCount > limitCount;
        }

        public async Task LogRequestDetailsAsync(string ipAddress, DateTime requestTime)
        {
            await _requestRepository.AddRequest(ipAddress, requestTime);
        }

        private int ConvertStringToInt(string input)
        {
            int result = 0;
            try
            {
                result = Int32.Parse(input);
            }
            catch (FormatException ex)
            {

            }
            return result;
        }
    }
}
