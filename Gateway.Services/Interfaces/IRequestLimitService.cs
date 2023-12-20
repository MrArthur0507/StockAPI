using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface IRequestLimitService
    {
        public Task<bool> IsIpRateLimitedAsync(string ipAddress);

        public Task LogRequestDetailsAsync(string ipAddress, DateTime requestTime);
    }
}
