using Serilog;
using Serilog.Extensions.Logging;
using TesterProject.BusinessLogic.TelegramBot;
using TesterProject.BusinessLogic.Interfaces.Telegram;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

Log.Logger = new LoggerConfiguration()
   .WriteTo.Console()
   .WriteTo.File("logs/worker-service.log", rollingInterval: RollingInterval.Day)
   .WriteTo.Debug()
#if WINDOWS
   .WriteTo.EventLog("TelegramBotService", manageEventSource: true)
#endif
   .Enrich.FromLogContext()
   .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new SerilogLoggerProvider(Log.Logger));

builder.Services.AddSingleton<ITelegramDatabaseInformation, TelegramDatabaseInformation>();
builder.Services.AddSingleton<TelegramConnector>();
builder.Services.AddHostedService<TesterWorkerService.Worker>();

builder.Services.Configure<HostOptions>(options => options.ServicesStartConcurrently = false);
builder.Services.AddWindowsService();

var app = builder.Build();

try
{
    Log.Information("Starting Worker Service...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Worker Service terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}
