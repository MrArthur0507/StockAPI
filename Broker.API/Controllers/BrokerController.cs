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
        private readonly IAccountsFinalGetter _accountsGetter;
        public BrokerController(IMessageProducer messageProducer, IAccountsFinalGetter accountsGetter)
        {
            _messageProducer = messageProducer;
            _accountsGetter = accountsGetter;
        }

        [HttpPost]
        [Route("sendMessage")]
        public IActionResult Post([FromQuery]string message, string queue)
        {
            _messageProducer.SendMessage(queue, message);
            return Ok();
        }

        //[HttpGet]
        //[Route("getAccounts")]
        //public IActionResult GetAccounts()
        //{
        //    _accountsGetter.GetAccounts();
        //    return Ok();
        //}
    }
}
