using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using StockAPI.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Implementation
{
    public class NotificationService: INotificationService
    {
        private readonly IDataManager _dataManager;
        public NotificationService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public async Task<int> CreateNotifcation(NotificationViewModel model)
        {
            var notification = new Notification(model.Message,model.AccountId);
            _dataManager.InsertData(notification);
            return (int)HttpStatusCode.Created;
        }
    }
}
