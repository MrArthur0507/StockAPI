using Gateway.API.Middlewares;
using Gateway.Services.Configuration.Classes;
using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using SqliteProvider.Implementations;
using SqliteProvider.Interfaces;
using SqliteProvider.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<Gateway.Services.Configuration.Interfaces.IHttpClientFactory, HttpClientFactory>();
builder.Services.AddSingleton<IConfigurationService, ConfigurationService>();
builder.Services.AddSingleton<IConfig, Config>();
builder.Services.AddSingleton<IRequestLogger, RequestLogger>();
builder.Services.AddScoped<IAccountsService, AccountService>();
builder.Services.AddSingleton<IDbInit, DbInit>();
builder.Services.AddSingleton<ITableInit, TableInit>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>(sr => new DatabaseService("Data Source = iplog.db"));
builder.Services.AddScoped<IRequestRepository, RequestRepository>();

builder.Services.AddResponseCaching();
builder.Services.AddAuthentication().AddJwtBearer();
var app = builder.Build();
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var myDependency = services.GetRequiredService<IDbInit>();
    myDependency.EnsureDbAndTablesCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<RequestLimitingMiddleware>();

app.UseAuthorization();

app.MapControllers();



app.Run();


