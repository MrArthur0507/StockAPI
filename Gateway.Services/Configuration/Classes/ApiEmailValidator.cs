using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class ApiEmailValidator : IApiEmailValidator
    {
        private readonly IApiEmailValidatorRequestor _apiEmailValidationRequester;
        private readonly IApiEmailDeserializer _apiEmailDeserializer;

        public ApiEmailValidator(IApiEmailValidatorRequestor apiEmailValidationRequester, IApiEmailDeserializer apiEmailDeserializer)
        {
            _apiEmailValidationRequester = apiEmailValidationRequester;
            _apiEmailDeserializer = apiEmailDeserializer;
        }

        public async Task<bool> Validate(string email)
        {
            string json = await _apiEmailValidationRequester.MakeRequest(email);

            if (json != null)
            {
                EmailValid emailValid = _apiEmailDeserializer.Deserialize(json);

                if (emailValid != null && emailValid.IsValid)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
