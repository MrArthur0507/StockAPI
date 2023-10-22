namespace Gateway.API.Middlewares
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            LogRequestDetails(context);

            
            await _next(context);
        }

        private void LogRequestDetails(HttpContext context)
        {
            string requestUrl = context.Request.Path;
            string requestMethod = context.Request.Method;
            
            

            
            Console.WriteLine($"Request URL: {requestUrl}");
            Console.WriteLine($"Request Method: {requestMethod}");
            
        }
    }
}
