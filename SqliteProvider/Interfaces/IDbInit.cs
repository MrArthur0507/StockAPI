using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Interfaces
{
    public interface IDbInit
    {
        public void EnsureDbAndTablesCreated();


        public void CreateDb();


        public bool DatabaseExists();
        
    }
}
