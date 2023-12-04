using Gateway.Services.Configuration.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SqliteProvider.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class FinalEmailValidator : IFinalEmailValidator
    {
        private readonly IApiEmailValidator _apiEmailValidator;
        private readonly IEmailRepository _emailRepository;

        public FinalEmailValidator(IApiEmailValidator apiEmailValidator, IEmailRepository emailRepository)
        {
            _apiEmailValidator= apiEmailValidator;
            _emailRepository= emailRepository;
        }

        public async Task<bool> IsValidEmail(string email)
        {
            int isValid = _emailRepository.IsEmailValid(email);
            Console.WriteLine(isValid);
            if (isValid == 0)
            {
                return false;
            } else if (isValid == 1)
            {
                return true;
            }


            if (await _apiEmailValidator.Validate(email))
            {

               // _emailRepository.AddBlacklistedEmail(email);
                return true;
            }

            return true;
        }
    }
}
