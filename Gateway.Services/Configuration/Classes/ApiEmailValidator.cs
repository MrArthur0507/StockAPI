using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class ApiEmailValidator : IApiEmailValidator
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient client;
        IConfiguration configuration;
        private readonly IApiEmailDeserializer _apiEmailDeserializer;
        public ApiEmailValidator(IHttpClientFactory clientFactory, IConfiguration configuration, IApiEmailDeserializer apiEmailDeserializer)
        {
            _clientFactory = clientFactory;
            this.configuration= configuration;
            client = _clientFactory.CreateClient();
            _apiEmailDeserializer= apiEmailDeserializer;
        }

        public async Task<bool> Validate(string email)
        {
            client.BaseAddress = new Uri(configuration.GetValue<string>("EmailValidatorAPIUrl"));
            HttpResponseMessage response = await client.GetAsync($"/?email={email}&token={configuration.GetValue<string>("EmailValidatorAPIKey")}");
            string json = await response.Content.ReadAsStringAsync();
            EmailValid emailValid = _apiEmailDeserializer.Deserialize(json);
            if (emailValid.IsValid = true)
            {
                Console.WriteLine(json);
                return true;

            }
            return false;
            
        }
    }
}
