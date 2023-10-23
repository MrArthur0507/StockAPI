﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Interfaces
{
    public interface IHttpClientFactory
    {
        public HttpClient GetAccountClient();

        public HttpClient GetAnalyzerClient();

        public HttpClient GetStockClient();
    }
}
