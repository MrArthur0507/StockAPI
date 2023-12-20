using Broker.API.Jobs;
using Broker.Services.Implementation;
using Broker.Services.Interfaces;
using Quartz;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMessageProducer, MessageProducer>();
builder.Services.AddSingleton<IRabbitMQConnectionFactory, RabbitMQConnectionFactory>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IAccountsGetter, AccountsGetter>();
builder.Services.AddScoped<IAccountsFinalGetter, AccountsFinalGetter>();
builder.Services.AddScoped<ISendFundsNotification, SendFundsNotification>();
builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("SendBalanceNotification");
    q.AddJob<SendBalanceNotificationJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("SendBalanceNotificationJob-trigger")
        .StartNow()
        //.WithCronSchedule("0 0 0 * * ?"))
        .WithCronSchedule("0/5 * * * * ?"));

});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
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
