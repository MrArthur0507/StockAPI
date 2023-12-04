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
        public EmailRepository(ISqliteProviderConfiguration configurationService) {
            _configurationService = configurationService;
            _config = _configurationService.GetSettings();
        }
        public int IsEmailValid(string email)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {_config.ConnectionString}"))
            {
                connection.Open();
                string query = "SELECT IsValid FROM Emails WHERE Email = @email";
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@email", email);
                object result = Convert.ToInt32(command.ExecuteScalar());
                if (result != null)
                {
                    return Convert.ToInt32(result);
                } else
                {
                    return 3;
                }
            }
        }

        public void AddEmail(string email, bool isValid)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {_config.ConnectionString}"))
            {
                string query = "INSERT INTO Emails (Email, IsValid) VALUES (@Email, @IsValid)";
                SqliteCommand command = connection.CreateCommand(); 
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@IsValid", isValid);
                command.CommandText = query;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
