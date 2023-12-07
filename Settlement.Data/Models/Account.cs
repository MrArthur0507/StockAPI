using Settlement.API.Controllers.SettlementContracts;

namespace Settlement.Infrastructure.Models
{
    public class Account : BaseModel, IAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string Salt { get; set; }
        // public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        public Account()
        {
        }
        public Account(string username, string password, string email, decimal balance, string salt)
        {
            Username = username;
            Password = password;
            Email = email;
            Balance = balance;
            Salt = salt;
        }
    }
}
