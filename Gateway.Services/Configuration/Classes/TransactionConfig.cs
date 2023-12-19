using Gateway.Services.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class TransactionConfig : BaseConfig, ITransactionConfig
    {
        public string GetTransactionForUser { get; set; }

        public string GetTransactionByStock { get; set; }
    }
}
