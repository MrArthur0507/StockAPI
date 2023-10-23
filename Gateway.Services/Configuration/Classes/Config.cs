using Gateway.Services.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class Config : IConfig
    {
        public IAccountConfig AccountConfig { get; set; } = new AccountsConfig();

        public IAnalyzerConfig AnalyzerConfig { get; set; } = new AnalyzerConfig();

        public IStockConfig StockConfig { get; set; } = new StockConfig();
    }
}
