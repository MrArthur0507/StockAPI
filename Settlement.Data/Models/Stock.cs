using Settlement.API.Controllers.SettlementContracts;

namespace Settlement.Infrastructure.Models
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
