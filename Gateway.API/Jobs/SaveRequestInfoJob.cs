using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Quartz;
using System.Runtime.CompilerServices;

namespace Gateway.API.Jobs
{
    public class SaveRequestInfoJob : IJob
    {
        private readonly IRequestQueueService requestQueueService;
        public SaveRequestInfoJob(IRequestQueueService requestQueueService)
        {
            this.requestQueueService = requestQueueService;
        }
        public Task Execute(IJobExecutionContext ctx)
        {
            List<RequestInfo> requestsToSave = requestQueueService.DequeueAll();

            Console.Write("Executing!");
            foreach (var request in requestsToSave)
            {
                Console.WriteLine(request.RequestMethod);
            }
            return Task.CompletedTask;
        }

    }
}
