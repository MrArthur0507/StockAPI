
using Gateway.Domain.Models.DbRelated;
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
        private readonly ISqliteProviderConfiguration _sqliteProviderConfiguration;
        private readonly SqliteProviderSettings _settings;
        public DbInit(ITableInit tableInit, ISqliteProviderConfiguration configurationService) {
            _tableInit= tableInit;
            _sqliteProviderConfiguration = configurationService;
            _settings = _sqliteProviderConfiguration.GetSettings();
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
            using (File.Create(_settings.ConnectionString))
            {
            }
            _tableInit.CreateTables(_settings.ConnectionString);
            Console.WriteLine("Creating db;");

        }

        public bool DatabaseExists()
        {
            if (File.Exists(_settings.ConnectionString))
            {
                return true;
            }
            Console.WriteLine("Db dont exist");
            return false;
        }
    }
}
