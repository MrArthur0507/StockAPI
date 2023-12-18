using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker.Services.Implementation;
using Gateway.Services.Configuration.Interfaces;

namespace Gateway.Services.Configuration.Classes
{
    public class MessageConsumer : IMessageConsumer
    {
        private readonly IModel _channel;
        private readonly string _queueName = "message";

        public MessageConsumer()
        {
            var rabbitMqService = new RabbitMQConnectionFactory();
            _channel = rabbitMqService.CreateModel();

            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void StartListening()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Received message: {message}");
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        }
    }
}
