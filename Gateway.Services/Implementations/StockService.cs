﻿using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IConfigurationService _config;
        public StockService(IConfigurationService config)
        {
            _config = config;
        }
    }
}