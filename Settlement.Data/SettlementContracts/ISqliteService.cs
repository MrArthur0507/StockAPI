using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.SettlementContracts
{
    public interface ISqliteService
    {
        private void CreateDb() {}

        private extern bool DatabaseExists();

        private void TableCreate(){}
    }
}
