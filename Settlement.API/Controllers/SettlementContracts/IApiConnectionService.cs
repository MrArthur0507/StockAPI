using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementContracts
{
    public interface IApiConnectionService
    {
        public HttpClient _httpClient { get; set; }
    }
}
