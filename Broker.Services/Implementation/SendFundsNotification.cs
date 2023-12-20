using Broker.Models.DTO;
using Broker.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Services.Implementation
{
    public class SendFundsNotification : ISendFundsNotification
    {
        private readonly IAccountsFinalGetter _accountsGetter;
        private readonly IMessageProducer _messageProducer;
        public SendFundsNotification(IAccountsFinalGetter accountsGetter, IMessageProducer messageProducer) { 
            _accountsGetter= accountsGetter;
            _messageProducer= messageProducer;
        }
        public async Task SendNotification()
        {
            List<Account> accounts = await _accountsGetter.GetAccounts();

            foreach (var item in accounts)
            {
                if (item.balance < 100)
                {
                    Message message = new Message
                    {
                        RecieverEmail = item.email,
                        MessageContent = "Do you want to add funds to your account. Do it now"
                    };
                    string json = JsonConvert.SerializeObject(message);
                    _messageProducer.SendMessage("fundsNotification", json);
                }
            }
        }
    }
}
