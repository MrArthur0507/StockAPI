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
        public async Task<string> MakeTransaction()
        {
            return "OK";
        }
    }
}
