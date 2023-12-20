using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Domain.Models.DbRelated
{
    public class RequestInfo
    {
        public DateTime Timestamp { get; set; }
        public string RequestMethod { get; set; }
    }
}
