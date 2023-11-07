using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface IConfig
    {
        public string LogFilePath { get; set; }

        public string SqliteDbPath { get; set; }
        public IAccountConfig AccountConfig { get; set; }

        public IAnalyzerConfig AnalyzerConfig { get; set; }

        public IStockConfig StockConfig { get; set; }
    }
}
