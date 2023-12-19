using Settlement.Infrastructure.SettlementContracts.AccountContracts;

namespace Settlement.Infrastructure.Models.AccountModels
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
