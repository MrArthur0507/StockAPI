using Gateway.Domain.Models.DbRelated;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;

namespace Gateway.API.Middlewares
{
    public class RequestQueueMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IRequestQueueService requestQueueService;

        public RequestQueueMiddleware(RequestDelegate next, IRequestQueueService requestQueueService)
        {
            this.next = next;
            this.requestQueueService = requestQueueService;
        }

        public async Task Invoke(HttpContext context)
        {
            
            var requestInfo = new RequestInfo
            {
                Timestamp = DateTime.Now,
                RequestMethod = context.Request.Method,
               
            };

            requestQueueService.Enqueue(requestInfo);

            
            await next(context);
        }
    }
}
