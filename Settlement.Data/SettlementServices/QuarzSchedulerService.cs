using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using Quartz.Impl;
using SettlementContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SettlementServices
{
    public class QuarzSchedulerService : IQuarzScheduler
    {
        public async Task<IActionResult> QuarzScheduler()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            
            await scheduler.Start();

            
            await Task.Delay(TimeSpan.FromDays(1));



            
            await scheduler.Shutdown();

            return null;
        }
        


    }
}
