using Gateway.Services.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class AccountsConfig : BaseConfig,IAccountConfig
    {
        public string GetAll { get; set; }

        public string GetById { get; set; }

        public string ProfitById { get; set; }

        public string HistoryById { get; set; }

        public string CreateAccount { get; set; }

        public string DeleteAccount { get; set; }
    }
}
