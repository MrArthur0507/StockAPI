using AccountAPI.Data.Models.Implementation;
using Quartz;
using StockAPI.Database.Interfaces;

namespace Accounts.API.Jobs
{
    public class ChangeUserRole : IJob
    {
        private readonly IDataManager _dataManager;
        public ChangeUserRole(IDataManager dataManager )
        {
            _dataManager = dataManager;
        }
        public Task Execute(IJobExecutionContext ctx)
        {
            var users = _dataManager.SelectData<Account>("Accounts");
            foreach (var user in users)
            {
                ChangeRole(user);
            }
            Console.Write("Executing!");
            return Task.CompletedTask;
        }
        private void ChangeRole(Account account)
        {
            if (account.Balance<100)
            {
                account.UserType = "Normal";
            }
            else if(account.Balance<1000)
            {
                account.UserType = "Special";
            }
            else
            {
                account.UserType = "Premium";
            }
            _dataManager.UpdateData<Account>(account, account.Id);
        }
    }
}
