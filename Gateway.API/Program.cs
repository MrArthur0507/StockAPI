var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("StockService", client =>
{
    client.BaseAddress = new Uri("StockApiUrl:XXXX");
}
);
builder.Services.AddHttpClient("AnalyzerService", client =>
{
    client.BaseAddress = new Uri("AnalyzerApiUrl:XXXX");
}
);
builder.Services.AddHttpClient("AccountsService", client =>
{
    client.BaseAddress = new Uri("AccountsApiUrl:XXXX");
}
);
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
