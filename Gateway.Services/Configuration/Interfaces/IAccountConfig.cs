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

        public string GetById { get; }

        public string ProfitById { get; }

        public string HistoryById { get; }

        public string CreateAccount { get; }

        public string DeleteAccount { get; }
    }
}
