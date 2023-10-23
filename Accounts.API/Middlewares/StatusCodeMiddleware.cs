namespace Accounts.API.Middlewares
{
    public class StatusCodeMiddleware
    {
        private readonly RequestDelegate _next;
        public StatusCodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            await _next(context);
            var statusCode = context.Response.StatusCode;
           await HandlerError(statusCode, context);

        }
        private async Task HandlerError(int statusCode,HttpContext context)
        {
            if (statusCode == StatusCodes.Status400BadRequest)
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("There is already an account with this email.");
            }
            else if(statusCode==StatusCodes.Status401Unauthorized)
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Invalid email or password! Please try again.");
            }
        }
    }
}
