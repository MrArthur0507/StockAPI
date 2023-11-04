using Gateway.Services.Configuration.Classes;
using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
            
            IConfig settings = _configurationService.GetAppSettings();
            
            return Ok(settings);
        }

        [HttpGet]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any)]
        [Route("getAll")]
        public async Task<string> GetAllAccounts()
        {
            string result = await accountsService.GetAll();
            return result;
        }

        [HttpGet]
        [Route("getById")]
        public async Task<string> GetById(string id)
        {
            return await accountsService.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Register([FromQuery]string username, string password, string email, string balance)
        {
            
            return StatusCode(await accountsService.Register(username, password, email, balance));
        }

        [HttpPost]
        [Route("login")]
        public async Task<string> Login([FromQuery] string email, string password)
        {

            return await accountsService.Login(email, password);
        }
    }
}
