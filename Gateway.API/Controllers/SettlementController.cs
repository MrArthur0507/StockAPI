using Gateway.Domain.Models.ApiRelated.Classes;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ISettlementService _settlementService;
        public TransactionController(ISettlementService settlementService)
        {
            _settlementService = settlementService;
        }
        [HttpPost]
        [Route("makeTransaction")]
        public async Task<string> MakeTransaction([FromQuery]Transaction transaction)
        {
            string response = await _settlementService.MakeTransaction(transaction);
            return response;
        }
    }
}
