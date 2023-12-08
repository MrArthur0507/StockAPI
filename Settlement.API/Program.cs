using AccountAPI.Data.Models.Implementation;
using AccountAPI.Data.Models.Interfaces;
using Settlement.API.Controllers.SettlementServices;
using Settlement.Infrastructure.Middlewares;
using Settlement.Infrastructure.SettlementServices;
using Settlement.Services;
using SettlementContracts;
using SettlementServices;
using StockAPI.Database.Data;
using StockAPI.Database.Interfaces;
using StockAPI.Database.Services;
using Stocks.utils;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ApiAccountService>();
builder.Services.AddScoped<ApiStockService>();
builder.Services.AddScoped<URL_Maker>();
builder.Services.AddScoped<StockDataService>();
builder.Services.AddScoped<AccountInfoService>();
builder.Services.AddScoped<StockInfoService>();
builder.Services.AddScoped<GetStockPriceService>();
builder.Services.AddScoped<SqliteService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//public void Configure(IApplicationBuilder app)
//{
//    // Other middleware components...

//    // Use the custom CreditCheckMiddleware
//    app.UseMiddleware<CreditCheckMiddleware>();

//    // Endpoint routing middleware
//    app.UseRouting();

//    // Endpoint middleware
//    app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapControllerRoute(
//            name: "default",
//            pattern: "{controller=Home}/{action=Index}/{id?}");
//    });
//}

app.Run();
