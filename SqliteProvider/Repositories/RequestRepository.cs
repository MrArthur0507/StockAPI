
using Gateway.Domain.Models.DbRelated;
using Microsoft.Data.Sqlite;
using SqliteProvider.Implementations;
using SqliteProvider.Interfaces;
using SqliteProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ISqliteProviderConfiguration _configService;
        private readonly SqliteProviderSettings config;
        public RequestRepository(ISqliteProviderConfiguration configurationService)
        {
            _configService = configurationService;
            config = _configService.GetSettings();
        }


        public async Task<long> GetRequestCountForIp(string ipAddress, DateTime since)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {config.ConnectionString}"))
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Requests WHERE VisitorIp = @IpAddress AND RequestTime >= @Since";
                    command.Parameters.AddWithValue("@IpAddress", ipAddress);
                    command.Parameters.AddWithValue("@Since", since);
                    long requestCount = (long)command.ExecuteScalar();

                    return requestCount;
                }
            }
        }

        public async Task AddRequest(string ipAddress, DateTime time)
        {

            using (SqliteConnection connection = new SqliteConnection($"Data Source = {config.ConnectionString}"))
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Requests (VisitorIp, RequestTime) VALUES (@IpAddress, @RequestTime)";
                    command.Parameters.AddWithValue("@IpAddress", ipAddress);
                    command.Parameters.AddWithValue("@RequestTime", time);
                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task AddDetailedRequest(RequestInfo requestInfo)
        {
            if (requestInfo == null)
            {
                throw new ArgumentNullException(nameof(requestInfo));
            }

            using (var connection = new SqliteConnection($"Data Source = {config.ConnectionString}"))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO Requests (HttpMethod, Timestamp) VALUES (@HttpMethod, @Timestamp)";
                command.Parameters.AddWithValue("@HttpMethod", requestInfo.RequestMethod);
                command.Parameters.AddWithValue("@Timestamp", requestInfo.Timestamp);

                command.ExecuteNonQuery();
            }
        }
    }
}

