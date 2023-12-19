using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Domain.Models.DbRelated
{
    public class EmailValid
    {
        public bool IsValid { get; set; }
        public int Score { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Reason { get; set; }
        public string Domain { get; set; }
        public bool Free { get; set; }
        public bool Role { get; set; }
        public bool Disposable { get; set; }
        public bool AcceptAll { get; set; }
        public bool Tag { get; set; }
        public string MXRecord { get; set; }
    }
}
