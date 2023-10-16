using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface IConfig
    {
        public IAccountConfig AccountConfig { get; set; }

        public IAnalyzerConfig AnalyzerConfig { get; set; }

        public IStockConfig StockConfig { get; set; }
    }
}
