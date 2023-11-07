using AccountAPI.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Implementation
{
    public class Stock : BaseModel, IStock
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Stock()
        { 
        }
        public Stock(string name,int quatnity,decimal price)
        {
            Name = name;
            Quantity = quatnity;
            Price = price;
        }
    }
}
