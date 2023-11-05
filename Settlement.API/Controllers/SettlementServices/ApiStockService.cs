using Newtonsoft.Json;
using Settlement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementServices
{
    public class ApiStockService
    {
        public async Task<Stock> GetStockByName(string name)
        {
            try
            {
                ApiStockConnectionService connectionService = new ApiStockConnectionService();
                HttpResponseMessage response = await connectionService._httpClient.GetAsync($"");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Stock account = JsonConvert.DeserializeObject<Stock>(jsonResponse);
                    return account;
                }
                else
                {
                    throw new Exception($"Failed to retrieve account. Status code: {response.StatusCode}");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
