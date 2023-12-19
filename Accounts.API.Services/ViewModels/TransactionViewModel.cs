using AccountAPI.Data.Models.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.ViewModels
{
    public class TransactionViewModel
    {
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string StockName { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public TransactionViewModel()
        {
        }

        public TransactionViewModel(string accountId, string stock,DateTime date, decimal price, int quantity)
        {
            AccountId = accountId;
            StockName = stock;
            Date = date;
            Price = price;
            Quantity = quantity;
        }
    }
}
