using Gateway.Domain.Models.ApiRelated.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Domain.Models.ApiRelated.Classes
{
    public class Transaction
    {
        public string AccountId { get; set; }
        public string StockName { get; set; }

        public TimeSeries TimeSeries { get; set; }

        public Interval Interval { get; set; }

        public int Quantity { get; set; } 
    }
}
