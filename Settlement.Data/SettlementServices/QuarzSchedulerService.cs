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

            
            //await scheduler.Start();

            
            //await Task.Delay(TimeSpan.FromDays(1));



            
            //await scheduler.Shutdown();

            //return null;


            // Define the job and tie it to our HelloWorldJob class
            IJobDetail job = JobBuilder.Create<HelloWorldJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run every day at midnight
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartAt(DateBuilder.TodayAt(0, 0))  // Start today at midnight
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(24)  // Repeat every 24 hours
                    .RepeatForever()
                )
                .Build();

            // Tell Quartz to schedule the job using our trigger
            await scheduler.ScheduleJob(job, trigger);

            // Start the scheduler
            await scheduler.Start();

            // Delay for 1 day (24 hours)
            await Task.Delay(TimeSpan.FromDays(1));

            // Shutdown the scheduler
            await scheduler.Shutdown();

            return null;
        }
        


    }
    public class HelloWorldJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            // Your job logic goes here
            Console.WriteLine("Hello, World!");
        }
    }
}
