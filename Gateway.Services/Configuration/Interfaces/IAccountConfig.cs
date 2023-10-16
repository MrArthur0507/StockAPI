using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface IAccountConfig
    {
        public string GetAll { get; }

        public string GetById { get; set; }

        public string ProfitById { get; set; }

        public string HistoryById { get; set; }

        public string CreateAccount { get; set; }

        public string DeleteAccount { get; set; }
    }
}
