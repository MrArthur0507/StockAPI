using AccountAPI.Data.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.ViewModels
{
    public class NotificationViewModel
    {
        public string Message { get; set; }
        public string AccountId { get; set; }
    }
}
