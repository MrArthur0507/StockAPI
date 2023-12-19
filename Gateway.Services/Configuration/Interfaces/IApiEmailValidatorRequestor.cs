using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface IApiEmailValidatorRequestor
    {
        Task<string> MakeRequest(string email);
    }
}
