using Gateway.Domain.Models.ApiRelated.Classes;
using Gateway.Domain.Models.ApiRelated.Enums;
using Gateway.Services.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class SettlementService : ISettlementService
    {
        private readonly ISettlementAPIService _settlementService;

        public SettlementService(ISettlementAPIService settlementAPIService)
        {
            _settlementService = settlementAPIService;
        }
        public async Task<string> MakeTransaction(Transaction transaction)
        {
            string response = await _settlementService.MakeTransaction(transaction);
            return response;
        }
    }
}
