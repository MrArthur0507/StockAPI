using Gateway.API.Jobs;
using Gateway.API.Middlewares;
using Gateway.Services.Configuration.Classes;
using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using SqliteProvider.Implementations;
using SqliteProvider.Interfaces;
using SqliteProvider.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(5001));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IConfigurationService, ConfigurationService>();
builder.Services.AddSingleton<IConfig, Config>();
builder.Services.AddSingleton<IRequestLogger, RequestLogger>();
builder.Services.AddScoped<IAccountsService, AccountService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IBlacklistService, BlacklistService>();
builder.Services.AddScoped<IApiEmailValidatorRequestor,ApiEmailValidatorRequestor>();
builder.Services.AddSingleton<ITableInit, TableInit>();
builder.Services.AddSingleton<ISqliteProviderConfiguration, SqliteProviderConfiguration>();
builder.Services.AddSingleton<IDbInit, DbInit>();
builder.Services.AddScoped<IAccountAPIService, AccountAPIService>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IApiEmailDeserializer, ApiEmailDeserializer>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IApiEmailValidator, ApiEmailValidator>();
builder.Services.AddResponseCaching();
builder.Services.AddSingleton<IRequestQueueService, RequestQueueService>();
builder.Services.AddScoped<IRequestLimitService, RequestLimitService>();
builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("SaveRequestInfoJob");
    q.AddJob<SaveRequestInfoJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("SaveRequestInfoJob-trigger")
        .WithCronSchedule("0/5 * * * * ?"));

});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
builder.Services.AddAuthentication().AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("SymmetricKey"))),
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
app.UseMiddleware<RequestLogMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


