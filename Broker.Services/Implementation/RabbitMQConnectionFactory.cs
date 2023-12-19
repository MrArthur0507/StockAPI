using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker.Services.Interfaces;
using RabbitMQ.Client;
namespace Broker.Services.Implementation
{
    public class RabbitMQConnectionFactory : IRabbitMQConnectionFactory
    {
        private readonly string _hostName = "localhost";
        private readonly string _userName = "guest";
        private readonly string _password = "guest";

        

        public IConnection CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                Port = 5672,
                UserName = _userName,
                Password = _password
            };

            return factory.CreateConnection();
        }
    }
}
