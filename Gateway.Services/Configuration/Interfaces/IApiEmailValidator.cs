using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface IApiEmailValidator
    {
        public Task<bool> Validate(string email);
    }
}
