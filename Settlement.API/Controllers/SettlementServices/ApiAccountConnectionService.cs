using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using SettlementContracts;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Settlement.Services
{
    public class ApiAccountConnectionService : IApiConnectionService
    {
        public HttpClient _httpClient { get; set; }

        public ApiAccountConnectionService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7168/api/Account");
        }

    }
}
