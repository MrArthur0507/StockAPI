using Gateway.Domain.Models.DbRelated;
using Newtonsoft.Json;
using SqliteProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SqliteProvider.Implementations
{
    public class SqliteProviderConfiguration : ISqliteProviderConfiguration
    {
        private const string ConfigFileName = "sqliteconfig.json";

        public SqliteProviderSettings GetSettings()
        {
            EnsureConfigFileExists();

            try
            {
                string json = File.ReadAllText(ConfigFileName);
                return JsonConvert.DeserializeObject<SqliteProviderSettings>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading configuration", ex);
            }
        }

        public void EnsureConfigFileExists()
        {
            if (!File.Exists(ConfigFileName))
            {
                
                var defaultSettings = new SqliteProviderSettings
                {
                    ConnectionString = "Data Source=mydatabase.db;",
                    CreateDatabaseIfNotExists = true
                };

                string defaultJson = JsonConvert.SerializeObject(defaultSettings);
                File.WriteAllText(ConfigFileName, defaultJson);
            }
        }
    }
}
