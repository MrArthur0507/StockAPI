using Broker.Services.Interfaces;
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
        private readonly IModel _channel;
        private readonly string _queueName = "message";

        public MessageProducer()
        {
            var rabbitMqService = new RabbitMQService();
            _channel = rabbitMqService.CreateModel();

            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
        }
    }
}
