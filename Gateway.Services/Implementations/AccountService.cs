using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;

namespace Gateway.Services.Implementations
{
    public class AccountService : IAccountsService
    {
        private readonly IAccountAPIService _accountApiService;

        private readonly IBlacklistService _blacklistService;
        public AccountService(IAccountAPIService accountApiService, IBlacklistService blacklistService)
        {
            _accountApiService = accountApiService;
            _blacklistService = blacklistService;
        }

        public async Task<string> GetAll() => await _accountApiService.GetAll();

        public async Task<string> GetById(string id) => await _accountApiService.GetById(id);

        public async Task<int> Register(string username, string password, string email, string balance)
        {
            if (await _blacklistService.IsEmailValid(email))
            {
                return await _accountApiService.Register(username, password, email, balance); 
            }
            return 401;
        }

        public async Task<string> Login(string email, string password) => await _accountApiService.Login(email, password);

        public async Task<string> AddMoney(string id, string baseCurrency, string quantity) => await _accountApiService.AddMoney(id, baseCurrency, quantity);

        public async Task<string> GetNotifications(string id) => await _accountApiService.GetNotifications(id);
    }
}
