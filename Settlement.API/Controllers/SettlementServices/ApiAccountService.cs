using Newtonsoft.Json;
using Settlement.API.Controllers.Data.Models;
using Settlement.Data.Models;
using Settlement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SettlementServices
{
    public class ApiAccountService
    {
        public async Task<Account> GetAccountByIdAsync(string id)
        {
            try
            {
                ApiAccountConnectionService connectionService = new ApiAccountConnectionService();
                HttpResponseMessage response = await connectionService._httpClient.GetAsync($"https://localhost:7168/api/Account/getById/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Account account = JsonConvert.DeserializeObject<Account>(jsonResponse);
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
