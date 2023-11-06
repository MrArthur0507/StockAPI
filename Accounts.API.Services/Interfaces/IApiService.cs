using AccountAPI.Data.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Interfaces
{
    public interface IApiService
    {
        public ApiModel Start();
        public decimal CalculateCurrencyAmount(decimal amount, string baseCurrency, ConverstionRate conversionRate);
    }
}
