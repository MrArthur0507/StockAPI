using SqliteProvider.Repositories;

namespace Gateway.API.Middlewares
{
    public class RequestLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        

        public RequestLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
       
        }

        public async Task Invoke(HttpContext context, IRequestRepository requestRepository)
        {
            IRequestRepository _requestRepository = requestRepository;
            string ipAddress = context.Connection.RemoteIpAddress?.ToString();


            DateTime timeOneMinuteAgo = DateTime.Now.AddMinutes(-1);
            _requestRepository.AddRequest(ipAddress, DateTime.Now);

            long requestCount = _requestRepository.GetRequestCountForIpAddressInTimeFrame(ipAddress, timeOneMinuteAgo);

            if (requestCount >= 10)
            {
                context.Response.StatusCode = 429; 
                await context.Response.WriteAsync("Too many requests from this IP. Try again later");
                return;
            }

            await _next(context);
        }
    }
}
