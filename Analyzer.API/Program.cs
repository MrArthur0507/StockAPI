using Analyzer.API.Services.Contracts;
using Analyzer.API.Services.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICurrentProfit, CurrentProfit>();
builder.Services.AddScoped<IPercentageChange, PercentageChange>();
builder.Services.AddScoped<IPortfolioRisk, PortfolioRisk>();
builder.Services.AddHttpClient();
//builder.Services.AddScoped<IPortfolioRisk, PortfolioRisk>();
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
