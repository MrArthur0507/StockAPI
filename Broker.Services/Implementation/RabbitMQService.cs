using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker.Services.Interfaces;
using RabbitMQ.Client;
namespace Broker.Services.Implementation
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConnection _connection;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost", 
                Port = 5672,             
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
        }

        public IModel CreateModel()
        {
            return _connection.CreateModel();
        }
    }
}
