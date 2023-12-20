using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Models.DTO
{
    public class Message
    {
        public string RecieverEmail { get; set; }

        public string MessageContent { get; set; }
    }
}
