using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using StockAPI.Database.Data;
using StockAPI.Database.Interfaces;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountService _accountService;
        public AccountController(IAuthenticationService service, IAccountService accountService)
        {
            _authenticationService = service;
            _accountService = accountService;
        }
        [HttpGet]
        [Route("getAll")]
        public List<User> GetAllAccounts()
        {
            return _accountService.GetAllAccount();
        }
        [HttpGet]
        [Route("getById")]
        public User GetAccountById(string id)
        {
            return _accountService.GetAccountById(id);
        }
        [HttpPost("register")]
        public IActionResult Register(string username,string password,string email )
        {
            return StatusCode(_authenticationService.Register(username, password,email));
        }
        [HttpPost("login")]
        public IActionResult Login(string email,string password)
        {
            return Json(_authenticationService.Login(email,password));
        }
        [HttpGet("checkToken")]
        public IActionResult CheckToken(string token)
        {
            return StatusCode(_authenticationService.CheckToken(token));
        }
        [HttpGet("changeName")]
        public IActionResult ChangeName(string id)
        {
            _accountService.Test(id);
            return Ok();
        }
        [HttpPost("addMoney")]
        public IActionResult AddMoney(string id, string baseCurrency, decimal amount)
        {
            return StatusCode(_accountService.AddMoney(id, baseCurrency, amount));
        }
        [HttpPost("getAllNotifications")]
        public IActionResult GetNotifications(string id)
        {
            if (id!=null)
            {
                var res = _accountService.GetAllNotification(id);
                return Ok(new {Data=res});
            }
            return BadRequest("invalid user id");
        }
    }
}
