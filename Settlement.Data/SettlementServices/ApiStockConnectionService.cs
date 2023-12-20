using SettlementContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementServices
{
    public class ApiStockConnectionService : IApiConnectionService
    {
        public HttpClient _httpClient { get; set; }

        public ApiStockConnectionService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5002");
        }
    }
}
