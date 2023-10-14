using StockAPI.Database.Data;
using StockAPI.Database.Interfaces;
using StockAPI.Database.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ITypeDictionary, TypeDictionary>();
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
builder.Services.AddSingleton<ITableService, TableService>();
builder.Services.AddSingleton<IDataConfiguration, DataConfiguration>();
builder.Services.AddSingleton<IDataManager, DataManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
