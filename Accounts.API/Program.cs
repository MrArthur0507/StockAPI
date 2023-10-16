using AccountAPI.Data.Models;
using StockAPI.Database.Data;
using StockAPI.Database.Interfaces;
using StockAPI.Database.Services;
using AccountAPI;
using AccountAPI.Data.Models.Interfaces;
using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ITypeDictionary, TypeDictionary>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IDataInserter, DataInserter>();
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
builder.Services.AddSingleton<ITableService, TableService>();
builder.Services.AddSingleton<IDataSelector, DataSelector>();
builder.Services.AddSingleton<IDataConfiguration, DataConfiguration>();
builder.Services.AddSingleton<IDataManager, DataManager>();
builder.Services.AddSingleton<ISeed, Seed>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
 void InitializeApplicationDbContext(WebApplication app)
{
    var dataManager = app.Services.GetRequiredService<IDataManager>();
    var seed = app.Services.GetRequiredService<ISeed>();

    var context = new ApplicationDbContext(dataManager,seed);
    context.Start();
    // Optionally, you can perform additional operations with the context here
}