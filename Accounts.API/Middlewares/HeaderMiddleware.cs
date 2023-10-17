namespace Accounts.API.Middlewares
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("ApiName", "StockAPI");
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
