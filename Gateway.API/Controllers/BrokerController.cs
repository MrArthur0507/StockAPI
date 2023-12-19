using Gateway.Services.Configuration.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly IMessageConsumer _messageConsumer;

        public BrokerController(IMessageConsumer messageConsumer)
        {
            _messageConsumer = messageConsumer;
        }
        [HttpGet]
        public void Listen()
        {
            _messageConsumer.StartListening();
        }
    }
}
