using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Interfaces
{
    public interface ITableInit
    {
        public void CreateTables(string connectionString);
    }
}
