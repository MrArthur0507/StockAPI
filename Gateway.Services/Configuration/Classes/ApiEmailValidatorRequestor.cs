using Gateway.Services.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class ApiEmailValidatorRequestor : IApiEmailValidatorRequestor
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public ApiEmailValidatorRequestor(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<string> MakeRequest(string email)
        {
            using (HttpClient client = _clientFactory.CreateClient())
            {
                client.BaseAddress = new Uri(_configuration.GetValue<string>("EmailValidatorAPIUrl"));

                HttpResponseMessage response = await client.GetAsync($"/?email={email}&token={_configuration.GetValue<string>("EmailValidatorAPIKey")}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                
                return null;
            }
        }
    }
}
