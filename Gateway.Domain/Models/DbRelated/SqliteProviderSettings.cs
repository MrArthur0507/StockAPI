using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Domain.Models.DbRelated
{
    public class SqliteProviderSettings
    {
        public string ConnectionString { get; set; }
        public bool CreateDatabaseIfNotExists { get; set; }
    }
}
