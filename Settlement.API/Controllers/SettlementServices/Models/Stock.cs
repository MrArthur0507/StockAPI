using Settlement.API.Controllers.SettlementContracts;
using Settlement.API.Controllers.SettlementServices.Models;

namespace Settlement.API.Controllers.Data.Models
{
    public class Stock : BaseModel, IStock
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Stock()
        {
        }
        public Stock(string name, int quatnity, decimal price)
        {
            Name = name;
            Quantity = quatnity;
            Price = price;
        }
    }
}
