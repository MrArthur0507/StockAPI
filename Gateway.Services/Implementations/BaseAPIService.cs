using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public abstract class BaseAPIService 
    {
        protected readonly IHttpClientFactory _clientFactory;
        protected readonly IConfigurationService _configService;
        protected IConfig config;
        protected HttpClient client;
        protected BaseAPIService(IHttpClientFactory clientFactory, IConfigurationService configService) {
            _clientFactory = clientFactory;
            _configService = configService;
            config = _configService.GetAppSettings();
        }
        protected async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            HttpResponseMessage response = await client.GetAsync(new Uri(client.BaseAddress, endpoint));
            return response;
        }

        protected async Task<HttpResponseMessage> PostAsync(string endpoint, Dictionary<string, string> parameters)
        {
            var encodedContent = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await client.PostAsync(new Uri(client.BaseAddress, endpoint), encodedContent);
            return response;
        }
        protected virtual async Task<string> HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
        }

        
    }
}
