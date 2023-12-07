
namespace Settlement.API.Controllers.SettlementContracts
{
    public interface IAccount : IBaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string Salt { get; set; }
        //public ICollection<Stock> Stocks { get; set; }
    }
}
