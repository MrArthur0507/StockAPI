using Gateway.Domain.Models.ApiRelated.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface ISettlementService
    {
        public Task<string> MakeTransaction(Transaction transaction);
    }
}
