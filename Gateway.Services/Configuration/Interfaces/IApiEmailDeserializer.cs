using Gateway.Domain.Models.DbRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface IApiEmailDeserializer
    {
        public EmailValid Deserialize(string json);
    }
}
