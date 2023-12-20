using Broker.Services.Interfaces;
using Quartz;

namespace Broker.API.Jobs
{
    public class SendBalanceNotificationJob : IJob
    {
        private readonly ISendFundsNotification _notificationSender;
        public SendBalanceNotificationJob(ISendFundsNotification notificationSender) {
            _notificationSender= notificationSender;
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _notificationSender.SendNotification();
            return Task.CompletedTask;
        }
    }
}
