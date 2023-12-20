namespace Settlement.Infrastructure.Models.AccountModels
{
    public class Transaction : BaseModel
    {
        public Account Account { get; set; }
        public Stock Stock { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Transaction()
        {

        }
        public Transaction(Account account, Stock stock, DateTime date, decimal price, int quantity)
        {
            Account = account;
            Stock = stock;
            Date = date;
            Price = price;
            Quantity = quantity;
        }
    }
}
