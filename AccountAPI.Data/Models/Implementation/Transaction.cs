using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Implementation
{
    public class Transaction:BaseModel
    {
        [Required]
        public string AccountId { get; set; }
        public Account Account { get; set; }
        [Required]

        public string StockName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Transaction()
        {

        }
        public Transaction(string accountId, string stock, DateTime date, decimal price, int quantity)
        {
            AccountId = accountId;
            StockName= stock;
            Date = date;
            Price = price;
            Quantity = quantity;
            Account = null;
        }
    }
}
