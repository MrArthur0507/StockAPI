﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Interfaces
{
    public interface IDataDeleter
    {

        public void InsertData<T>(T data, string connectionString);
    }
}
