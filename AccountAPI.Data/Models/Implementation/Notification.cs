using AccountAPI.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Implementation
{
    public class Notification:BaseModel,INotification
    {

        public string Message { get; set; }
        public Account Account { get; set; }
        public string AccountId { get; set; }
        public Notification() { }
        public Notification(string message, string accountId)
        {
            Message = message;
            AccountId = accountId;
        }
    }
}
