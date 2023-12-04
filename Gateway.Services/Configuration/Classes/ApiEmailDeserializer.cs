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
            try
            {
                return JsonConvert.DeserializeObject<EmailValid>(json);
            }
            catch (JsonException ex)
            {
                
                throw new Exception("Error deserializing JSON response", ex);
            }
        }
    }
}
