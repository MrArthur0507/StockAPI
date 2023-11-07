using Gateway.Services.Interfaces;
using System.Text;

namespace Gateway.API.Middlewares
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestLogger _logger;

        public RequestLogMiddleware(RequestDelegate next, IRequestLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            using (var reader = new StreamReader(context.Request.Body))
            {
                var requestBody = await reader.ReadToEndAsync();
                string logMessage = $" Path: {context.Request.Path}, Method: {context.Request.Method}, Body: {requestBody}";
                _logger.Log(logMessage);
            }

            await _next(context);
        }
    
}
}
