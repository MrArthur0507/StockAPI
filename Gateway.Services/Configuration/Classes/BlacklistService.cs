using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Configuration.Interfaces;
using SqliteProvider.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class BlacklistService : IBlacklistService
    {
        private readonly IEmailRepository _blacklistRepository;
        private readonly IApiEmailValidator _externalApiService;

        public BlacklistService(IEmailRepository blacklistRepository, IApiEmailValidator externalApiService)
        {
            _blacklistRepository = blacklistRepository;
            _externalApiService = externalApiService;
        }

        public async Task<bool> IsEmailValid(string email)
        {
            
            bool isLocalValid = await _blacklistRepository.IsEmailBlacklisted(email);

            if (isLocalValid)
            {
                return false; 
            }

            
            bool isExternalBlacklisted = await _externalApiService.Validate(email);

            if (isExternalBlacklisted)
            {
                await _blacklistRepository.AddEmailToBlacklist(new EmailValid() { Email = email, IsValid = isExternalBlacklisted});
            }

            return isExternalBlacklisted;
        }
    }
}

