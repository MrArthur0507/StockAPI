using Gateway.Services.Configuration.Classes;
using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        public AccountsController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        [Route("getConfig")]
        public IActionResult GetConfig()
        {
            // Only for testing purposes
            IConfig settings = _configurationService.GetAppSettings();

            

            return Ok(settings);

        }
    }
}
