using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Services.Interfaces
{
    public interface IRabbitMQService
    {
        public IModel CreateModel();
    }
}
