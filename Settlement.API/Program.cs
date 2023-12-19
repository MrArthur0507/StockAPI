
using Settlement.API.Controllers.SettlementServices;
using Settlement.Infrastructure.SettlementServices;
using Settlement.Services;
using SettlementContracts;
using SettlementServices;

using System.Transactions;

using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Settlement.Infrastructure.SettlementServices.StockServices;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{});
builder.Services.AddScoped<ApiAccountService>();
builder.Services.AddScoped<ApiStockService>();
builder.Services.AddScoped<URL_Maker>();
builder.Services.AddScoped<StockDataService>();
builder.Services.AddScoped<AccountInfoService>();
builder.Services.AddScoped<StockInfoService>();
builder.Services.AddScoped<GetStockPriceService>();
builder.Services.AddScoped<SqliteService>();
builder.Services.AddScoped<CheckAccountCreditsService>();
builder.Services.AddScoped<SqliteAddTransactionsService>();
builder.Services.AddScoped<SqliteDeleteTransactionsService>();
builder.Services.AddScoped<SqliteGetTransactionsService>();
builder.Services.AddScoped<QuartzJobService>();


builder.Services.AddQuartz(q =>
{

    var jobKey = new JobKey("QuartzJobService");
    q.AddJob<QuartzJobService>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("QuartzJobService-trigger")
        .WithCronSchedule("0 0 0 * * ?"));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);



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

app.Run();
