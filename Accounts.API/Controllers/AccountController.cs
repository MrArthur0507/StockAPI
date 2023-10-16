using Accounts.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using StockAPI.Database.Data;
using StockAPI.Database.Interfaces;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IDataManager _dataManager;
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IDataManager dataManager,IAuthenticationService service)
        {
            _dataManager = dataManager;
            _authenticationService = service;
        }
        [HttpGet]
        [Route("getAll")]
        public IActionResult StartDatabase()
        {
            _dataManager.Start();
            return Ok("Database created");
        }
        [HttpPost("register")]

        public IActionResult Register(string username,string password,string email,decimal balance )
        {
            
            return StatusCode(_authenticationService.Register(username, password,email, balance));
        }
        [HttpPost("login")]
        public IActionResult Login(string email,string password)
        {
            return StatusCode(_authenticationService.Login(email,password));
        }
    }
}
