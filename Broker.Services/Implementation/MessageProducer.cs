using Broker.Services.Interfaces;
using Broker.Services.Tools;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Services.Implementation
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IRabbitMQConnectionFactory _connectionFactory;
        private readonly ILogger logger;
        public MessageProducer(IRabbitMQConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        
        public void SendMessage(string queueName, string message)
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                byte[] body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

                logger.Log($"Sent '{message}' to {queueName}");
            }
        }
    }
}
