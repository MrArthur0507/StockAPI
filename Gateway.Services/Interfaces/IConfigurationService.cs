using Gateway.Services.Configuration.Classes;
using Gateway.Services.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface IConfigurationService
    {
        public IConfig GetAppSettings();

        public void SaveAppSettings(IConfig appSettings);
    }
}
