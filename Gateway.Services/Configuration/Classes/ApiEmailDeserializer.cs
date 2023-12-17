using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Configuration.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class ApiEmailDeserializer : IApiEmailDeserializer
    {
        public EmailValid Deserialize(string json)
        {
            EmailValid email = JsonConvert.DeserializeObject<EmailValid>(json);
            return email;
            
            
        }
    }
}
