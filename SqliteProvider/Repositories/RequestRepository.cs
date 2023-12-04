
using Gateway.Domain.Models.DbRelated;
using Microsoft.Data.Sqlite;
using SqliteProvider.Implementations;
using SqliteProvider.Interfaces;
using SqliteProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ISqliteProviderConfiguration _configService;
        private readonly SqliteProviderSettings config;
        public RequestRepository(ISqliteProviderConfiguration configurationService) {
            _configService = configurationService;
            config = _configService.GetSettings();
        }
        public void AddRequest(string ip, DateTime dateTime)
        {
            
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {config.ConnectionString}"))
                {
                    connection.Open();
                    SqliteCommand command = connection.CreateCommand();
                    string query = "INSERT INTO Requests (VisitorIp, RequestTime) VALUES (@ip, @time)";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@ip", ip);
                    command.Parameters.AddWithValue("@time", dateTime);
                    command.ExecuteNonQuery();
                    
                }
            
        }
        public List<Request> GetAllRequests()
        {
            List<Request> requests = new List<Request>();
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {config.ConnectionString}"))
            {
                    connection.Open();

                    SqliteCommand command = connection.CreateCommand();
                    string query = "SELECT * FROM Requests";
                    command.CommandText = query;
                    using(SqliteDataReader reader = command.ExecuteReader())
                    {
                    while (reader.Read())
                    {
                        Request request = new Request()
                        {
                            Id = (Convert.ToInt32(reader.GetString(0))),
                            IpAddress = reader.GetString(1),
                            RequestTime = DateTime.Parse(reader.GetString(2)),

                        };
                        requests.Add(request);
                    }
                    }
                
            }
            return requests;
        }

        public long GetRequestCountForIpAddressInTimeFrame(string ipAddress, DateTime timeSpan)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {config.ConnectionString}"))
            {
                connection.Open();

                string query = "SELECT COUNT(VisitorIp) FROM Requests WHERE VisitorIp = @ip AND RequestTime > @time";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ip", ipAddress);
                    command.Parameters.AddWithValue("@time", timeSpan);

                    return Convert.ToInt64(command.ExecuteScalar());
                }
            }
        }
    }
}
