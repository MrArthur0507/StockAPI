using Broker.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Broker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly MessageProducer _messageProducer;

        public BrokerController()
        {
            _messageProducer = new MessageProducer();
        }

        [HttpPost]
        public IActionResult Post([FromBody] string message)
        {
            _messageProducer.SendMessage(message);
            return Ok();
        }
    }
}
