using Gateway.Services.Interfaces;

namespace Gateway.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context, IRequestInfoStorageService _requestStorage)
        {
            _requestStorage.AddProcessedRequest(new Domain.Models.DbRelated.RequestInfo { RequestMethod = context.Request.Method, Timestamp = DateTime.UtcNow});

            await _next(context);
        }

    }
}

