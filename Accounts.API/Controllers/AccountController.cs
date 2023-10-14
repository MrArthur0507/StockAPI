using Microsoft.AspNetCore.Mvc;
using StockAPI.Database.Data;
using StockAPI.Database.Interfaces;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IDataManager _dataManager;
        public AccountController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [HttpGet]
        [Route("getAll")]
        public IActionResult StartDatabase()
        {
            _dataManager.Start();
            return Ok("Database created");
        }
    }
}
