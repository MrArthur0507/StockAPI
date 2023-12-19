using Settlement.Infrastructure.SettlementContracts;
using Settlement.Infrastructure.SettlementContracts.AccountContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.Models.SettlementModels
{
    public class TransactionStorage : IBaseModel, ITransactionStorage
    {
        string IBaseModel.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AccountId { get; set; }
        public string Stock { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        

        public TransactionStorage()
        {

        }
        public TransactionStorage(string account, string stock, DateTime date, decimal price, int quantity)
        {
            AccountId = account;
            Stock = stock;
            Date = date;
            Price = price;
            Quantity = quantity;
        }
    }
}
