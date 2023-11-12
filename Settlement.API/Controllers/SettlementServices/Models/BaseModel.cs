using Settlement.API.Controllers.SettlementContracts;
using StockAPI.Database.Helpers;

namespace Settlement.API.Controllers.SettlementServices.Models
{
    public class BaseModel : IBaseModel
    {
        public string Id { get; set; }
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
