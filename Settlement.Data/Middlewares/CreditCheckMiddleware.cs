using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.Middlewares
{
    public class CreditCheckMiddleware
    {
        //public CreditCheckMiddleware(RequestDelegate next) 
        //{
        //    _next = next;
        //}

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    if(context.User.Identity.IsAuthenticated)
        //    {
        //        bool hasEnoughCredits = CheckWallet();

        //        if(hasEnoughCredits)
        //        {
        //            context.Response.StatusCode = 400;
        //            context.Response.ContentType = "text/plain";
        //            await context.Response.WeiteAsync("Not enough funds");
        //            return;
        //        }
        //    }

        //    await _next(context);
        //}

        //private bool CheckWallet(string username)
        //{
        //    return true;
        //}
    }
}
