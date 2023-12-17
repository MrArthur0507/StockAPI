using AccountAPI.Data.Models;
using StockAPI.Database.Data;
using StockAPI.Database.Interfaces;
using StockAPI.Database.Services;
using AccountAPI;
using AccountAPI.Data.Models.Interfaces;
using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.Implementation;
using Accounts.API.Middlewares;
using StockAPI.Database.Helpers;
using StockApiRepDB.Interfaces;
using StockApiRepDB.Services;
using StockApiRepDB.Data;
using StockApiRepDB;
using Quartz;
using Accounts.API.Jobs;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<ITypeDictionary, TypeDictionary>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IApiService, ApiService>();
builder.Services.AddSingleton<IDataInserter, DataInserter>();
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
builder.Services.AddSingleton<ITableService, TableService>();
builder.Services.AddSingleton<IDataSelector, DataSelector>();
builder.Services.AddSingleton<IDataConfiguration, DataConfiguration>();
builder.Services.AddSingleton<IDataManager, DataManager>();
builder.Services.AddSingleton<ISeed, Seed>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITransactionService,TransactionService>();
builder.Services.AddScoped<INotificationService,NotificationService>();
builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("ChangeUserRoleJob");
    q.AddJob<ChangeUserRole>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("ChangeUserRoleJob-trigger")
        .WithCronSchedule("0 0 0 * *  ?"));

});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


//Services for the repository pattern db
builder.Services.AddSingleton<IRepDataService, DataService>();
builder.Services.AddSingleton<IUnitOfWork,UnitOfWork>();
builder.Services.AddSingleton<IRepDataManager, RepDataManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
InitializeApplicationDbContext(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<IPRestrictionMiddleware>();
app.UseAuthorization();
app.UseMiddleware<HeaderMiddleware>();
app.UseMiddleware<StatusCodeMiddleware>();

app.MapControllers();
app.Run();
  void InitializeApplicationDbContext(WebApplication app)
{
   var dataManager = app.Services.GetRequiredService<IDataManager>();
   var seed = app.Services.GetRequiredService<ISeed>();
   var context = new ApplicationDbContext(dataManager,seed);
   context.Start();
  

}