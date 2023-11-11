using Gateway.API.Middlewares;
using Gateway.Services.Configuration.Classes;
using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using SqliteProvider.Implementations;
using SqliteProvider.Interfaces;
using SqliteProvider.Repositories;
using System.Text;

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
builder.Services.AddAuthentication().AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY5Nzg2OTYyMCwiaWF0IjoxNjk3ODY5NjIwfQ.yE7D6Lj12wX7qUYNTXVYqJhMdPsU7TA9C8WVG4mCCY4")),
        };
    });
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
app.UseMiddleware<RequestLimitMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



app.Run();


