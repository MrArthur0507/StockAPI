using Gateway.Services.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class AccountsConfig : BaseConfig, IAccountConfig
    {
        public string GetAll { get; }

        public string GetById { get; }

        public string ProfitById { get; }

        public string HistoryById { get; }

        public string CreateAccount { get; }

        public string DeleteAccount { get; }
    }
}
