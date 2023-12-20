using Gateway.Domain.Models.ApiRelated.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        [Route("makeTransaction")]
        public async Task<IActionResult> MakeTransaction([FromQuery]Transaction transcation)
        {
            return Ok();
        }
    }
}
