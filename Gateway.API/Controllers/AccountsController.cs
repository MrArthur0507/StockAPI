using Gateway.Services.Configuration.Classes;
using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        public async Task<IActionResult> Login([FromQuery] string email, string password)
        {
            Response.Headers.Add("Set-Cookie", await accountsService.Login(email, password));
            Response.Headers.Add("Authorization", $"Bearer {await accountsService.Login(email, password)}");
            return Ok(await accountsService.Login(email, password));
        }

        [HttpPost]
        [Route("addMoney")]
        public async Task<string> AddMoney(string id, string baseCurrency, string amount)
        {
            
            return await accountsService.AddMoney(id,baseCurrency, amount);
        }

        [HttpGet]
        [Route("getNotifications")]
        public async Task<string> GetNotifications(string id)
        {

            return await accountsService.GetNotifications(id);
        }
    }
}
