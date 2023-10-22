using Gateway.Services.Configuration.Classes;
using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Text.Json;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IAccountsService accountsService;
        public AccountsController(IConfigurationService configurationService, IAccountsService accountsService)
        {
            _configurationService = configurationService;
            this.accountsService = accountsService;
        }

        [HttpGet]
        [Route("getConfig")]
        public IActionResult GetConfig()
        {
            // Only for testing purposes
            IConfig settings = _configurationService.GetAppSettings();
            return Ok(settings);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var jsonData = await accountsService.GetPlayers();
            return Ok(jsonData);
        }

        [HttpGet]
        [Route("getById")]
        public IActionResult GetAccountById(string id)
        {
            return Ok();
        }


        [HttpPost("register")]
        public IActionResult Register(string username, string password, string email, decimal balance)
        {
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            return Ok();
        }
    }
}
