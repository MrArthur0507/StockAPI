using Gateway.Domain.Models.DbRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Repositories
{
    public interface IEmailRepository
    {
        public Task<bool> IsEmailBlacklisted(string email);

        public Task AddEmailToBlacklist(EmailValid emailValid);
    }
}
