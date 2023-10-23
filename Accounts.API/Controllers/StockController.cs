using AccountAPI.Data.Models.Implementation;
using Microsoft.AspNetCore.Mvc;
using StockAPI.Database.Interfaces;

namespace Accounts.API.Controllers
{

    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly IDataManager _dataManager;
        public StockController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [HttpGet]
        [Route("getAll")]
        public List<Stock> GetAll()
        {
            var res = _dataManager.SelectData<Stock>("Stock");
            return res;
        }
        [HttpGet]
        [Route("getById")]
        public Stock GetById(string id)
        {
            var res = _dataManager.SelectByID<Stock>("Stock",id);
            return res;
        }
    }
}
