using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementServices
{
    public class QuarzSchedulerService
    {
        public static async Task Main(string[] args)
        {
            //ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            //IScheduler scheduler = await schedulerFactory.GetScheduler();

            //await scheduler.Start();


            //IJobDetail job = JobBuilder.Create<MyScheduledJob>()
            //    .WithIdentity("myJob", "group1")
            //    .Build();


            //DateTimeOffset tomorrow = DateTimeOffset.Now.AddDays(1);
            //DateTimeOffset scheduledTime = new DateTimeOffset(
            //    tomorrow.Year, tomorrow.Month, tomorrow.Day, 12, 0, 0, tomorrow.Offset);

            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("myTrigger", "group1")
            //    .StartAt(scheduledTime)
            //    .Build();


            //await scheduler.ScheduleJob(job, trigger);

        }
        

    }
}
