using Gateway.Services.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class AnalyzerConfig : BaseConfig, IAnalyzerConfig
    {
        public string CurrentProfit { get; set; }
        public string DailyReturnProfit { get; set; }
        public string PercentageChange { get; set; }
        public string PortfolioRisk { get; set; }


    }
}
