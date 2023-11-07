<<<<<<< HEAD
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

=======
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
//Services for the repository pattern db
builder.Services.AddSingleton<IRepDataService, DataService>();
builder.Services.AddSingleton<IUnitOfWork,UnitOfWork>();
builder.Services.AddSingleton<IRepDataManager, RepDataManager>();
>>>>>>> 4c7a8688902c8248ef1c607a0850c2ecde831b24
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
<<<<<<< HEAD

=======
app.UseMiddleware<IPRestrictionMiddleware>();
>>>>>>> 4c7a8688902c8248ef1c607a0850c2ecde831b24
app.UseAuthorization();

app.MapControllers();
<<<<<<< HEAD

app.Run();
=======
app.Run();
/*
 * THIS TOO!
 * void InitializeApplicationDbContext(WebApplication app)
{
   var dataManager = app.Services.GetRequiredService<IDataManager>();
   var seed = app.Services.GetRequiredService<ISeed>();

   var context = new ApplicationDbContext(dataManager,seed);
   context.Start();

}*/
void InitializeApplicationDbContext(WebApplication app)
{

    var dataManager = app.Services.GetRequiredService<IRepDataManager>();
    var context = new RepAppDbContext(dataManager);
    context.Start();

}
>>>>>>> 4c7a8688902c8248ef1c607a0850c2ecde831b24
