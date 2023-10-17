using AccountAPI.Data.Models.Implementation;
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
        private readonly IAccountService _accountService;
        public AccountController(IDataManager dataManager,IAuthenticationService service, IAccountService accountService)
        {
            _dataManager = dataManager;
            _authenticationService = service;
            _accountService = accountService;
        }
        [HttpGet]
        [Route("getAll")]
        public List<Account> GetAllAccounts()
        {
            return _accountService.GetAllAccount();
        }
        [HttpGet]
        [Route("getById")]
        public Account GetAccountById(string id)
        {
            return _accountService.GetAccountById(id);
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
