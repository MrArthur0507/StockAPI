using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface IStockConfig : IBaseConfig
    {
        public string GetStockData { get; set; }
    }
}
