using Gateway.Services.Interfaces;
using System.Text;

namespace Gateway.API.Middlewares
{
    public class RequestLimitingMiddleware
    {
        private readonly RequestDelegate _next;
       
        public RequestLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context, IRequestLimitService _requestLimitService)
        {
            string ip = context.Connection.RemoteIpAddress.ToString();
            _requestLimitService.LogRequestDetailsAsync(ip, DateTime.UtcNow);

            if (await _requestLimitService.IsIpRateLimitedAsync(ip)) {
                context.Response.StatusCode = 429;
                return;
            }

            
            await _next(context);
        }

    }
}
