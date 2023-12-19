using Accounts.API.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Interfaces
{
    public interface INotificationService
    {

        public Task<int> CreateNotifcation(NotificationViewModel model);
    }
}
