using Gateway.Domain.Models.DbRelated;
using Microsoft.Data.Sqlite;
using SqliteProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ISqliteProviderConfiguration _configurationService;
        private SqliteProviderSettings _config;
        public EmailRepository(ISqliteProviderConfiguration configurationService)
        {
            _configurationService = configurationService;
            _config = _configurationService.GetSettings();
        }
        public async Task<bool> IsEmailBlacklisted(string email)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {_config.ConnectionString}"))
            {
                connection.Open();


                using (SqliteCommand command = new SqliteCommand(
                    "SELECT IsValid FROM Emails WHERE Email = @Email;",
                    connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    object result = await command.ExecuteScalarAsync();

                    if (result != null && result != DBNull.Value)
                    {
                        return (long)result == 1;
                    }

                    return false;
                }
            }
        }

        public async Task AddEmailToBlacklist(EmailValid emailValid)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {_config.ConnectionString}"))
            {
                connection.Open();


                using (SqliteCommand command = new SqliteCommand(
                    "INSERT OR IGNORE INTO Emails (Email, IsValid) VALUES (@Email, @IsValid);",
                    connection))
                {
                    command.Parameters.AddWithValue("@Email", emailValid.Email);
                    command.Parameters.AddWithValue("@IsValid", emailValid.IsValid ? 1 : 0);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
