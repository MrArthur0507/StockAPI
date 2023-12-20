using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Quartz;
using SqliteProvider.Repositories;
using System.Runtime.CompilerServices;

namespace Gateway.API.Jobs
{
    public class SaveRequestInfoJob : IJob
    {
        private readonly IRequestInfoStorageService _storageService;

        private readonly IRequestRepository _requestRepository;
        
        public SaveRequestInfoJob(IRequestInfoStorageService storageService, IRequestRepository requestRepository)
        {
            _storageService = storageService;
            _requestRepository = requestRepository;
        }
        public Task Execute(IJobExecutionContext ctx)
        {
            List<RequestInfo> requestsToSave = _storageService.GetProcessedRequests().ToList();
            
            foreach (var request in requestsToSave)
            {
                _requestRepository.AddDetailedRequest(request);
            }
            _storageService.ClearList();
            return Task.CompletedTask;
        }

    }
}
