using Newtonsoft.Json;
//using Settlement.API.Controllers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settlement.Infrastructure.Models;

namespace SettlementServices
{
    public class ApiStockService
    {
        public async Task<String> GetStockByName(Stocks.Models.Stock stock)
        {
            try
            {
                ApiStockConnectionService connectionService = new ApiStockConnectionService();
                HttpResponseMessage response = await connectionService._httpClient.GetAsync($"https://localhost:5002/api/stocks?TimeSeries={stock.TimeSeries}&Symbol={stock.Symbol}&Interval={stock.Interval}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    //string account = JsonConvert.DeserializeObject<String>(jsonResponse);
                    return jsonResponse;
                }
                else
                {
                    throw new Exception($"Failed to retrieve stock. Status code: {response.StatusCode}");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
