namespace Settlement.Infrastructure.SettlementContracts.AccountContracts
{
    public interface IStock : IBaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
