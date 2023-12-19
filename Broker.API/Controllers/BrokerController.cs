using Broker.Services.Implementation;
using Broker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Broker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;

        public BrokerController(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult Post([FromQuery]string message, string queue)
        {
            _messageProducer.SendMessage(queue, message);
            return Ok();
        }
    }
}
