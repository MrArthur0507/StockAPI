using Gateway.Domain.Models.DbRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Interfaces
{
    public interface ISqliteProviderConfiguration
    {
        public SqliteProviderSettings GetSettings();
        

        public void EnsureConfigFileExists();
        
    }
}

