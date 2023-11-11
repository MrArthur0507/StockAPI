using AccountAPI.Data.Models.Implementation;
using AccountAPI.Data.Models.Interfaces;
using Settlement.API.Controllers.SettlementServices;
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



//Database Services
builder.Services.AddSingleton<ITypeDictionary, TypeDictionary>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IDataInserter, DataInserter>();
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
builder.Services.AddSingleton<ITableService, TableService>();
builder.Services.AddSingleton<IDataSelector, DataSelector>();
builder.Services.AddSingleton<IDataConfiguration, DataConfiguration>();
builder.Services.AddSingleton<IDataManager, DataManager>();
builder.Services.AddSingleton<ISeed, Seed>();
//


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
