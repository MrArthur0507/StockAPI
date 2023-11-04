using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class RequestLogger : IRequestLogger
    {
        IConfig config;
        public RequestLogger(IConfigurationService configurationService) { 
            config = configurationService.GetAppSettings();
        }
        public void Log(string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(config.LogFilePath))
                {
                    writer.WriteLine($"{DateTime.Now} - {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging to file: {ex.Message}");
            }
        }
    }
}
