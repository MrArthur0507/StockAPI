using AccountAPI.Data.Models.ApiModels;
using Accounts.API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Implementation
{
    public class ApiService:IApiService
    {

        private readonly IConfiguration _configuration;
        private readonly string _url;
        public ApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = (string)_configuration.GetSection("ApiSettings").GetSection("key").Value;
        }
        public ApiModel Start()
        {
            return GetApi();
        }
        private ApiModel GetApi()
        {

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(_url);
                    ApiModel test = JsonConvert.DeserializeObject<ApiModel>(json);
                    Console.WriteLine(test.conversion_rates.BGN);
                    return test;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public decimal CalculateCurrencyAmount(decimal amount, string baseCurrency, ConverstionRate conversionRate)
        {
            var baseCurrProp = typeof(ConverstionRate).GetProperty(baseCurrency.ToUpper());

            if (baseCurrProp == null)
            {
                Console.WriteLine("Invalid currency code.");
                return 0;
            }
            var usdAmount = amount / (decimal)baseCurrProp.GetValue(conversionRate);
            Console.WriteLine($"Amount in USD: {usdAmount}");
            return usdAmount;
        }
    }
}

