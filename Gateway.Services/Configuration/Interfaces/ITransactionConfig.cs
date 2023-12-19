using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface ITransactionConfig : IBaseConfig
    {
        public string GetTransactionForUser { get; set; }

        public string GetTransactionByStock { get; set; }
    }
}
