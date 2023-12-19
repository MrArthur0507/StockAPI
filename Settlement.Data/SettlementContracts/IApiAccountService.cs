using Settlement.Infrastructure.Models.AccountModels;

namespace Settlement.API.Controllers.SettlementContracts
{
    public interface IApiAccountService
    {
        public Task<Account> GetAccountByIdAsync(string id);
    }
}
