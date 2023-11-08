using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using SqliteProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Implementations
{
    public class DbInit : IDbInit
    {
        private readonly ITableInit _tableInit;
        private readonly IConfigurationService _configService;
        private readonly IConfig _config;
        public DbInit(ITableInit tableInit, IConfigurationService configurationService) {
            _tableInit= tableInit;
            _configService= configurationService;
            _config = _configService.GetAppSettings();
        }

        public void EnsureDbAndTablesCreated()
        {
            if (!DatabaseExists())
            {
                CreateDb();
            }
        }

        public void CreateDb()
        {
            using (File.Create(_config.SqliteDbPath))
            {
            }
            _tableInit.CreateTables(_config.SqliteDbPath);
            Console.WriteLine("Creating db;");

        }

        public bool DatabaseExists()
        {
            if (File.Exists(_config.SqliteDbPath))
            {
                return true;
            }
            Console.WriteLine("Db dont exist");
            return false;
        }
    }
}
