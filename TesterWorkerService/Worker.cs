using TesterProject.BusinessLogic.TelegramBot;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly TelegramConnector _telegramConnector;

    public Worker(ILogger<Worker> logger, TelegramConnector telegramConnector)
    {
        _logger = logger;
        _telegramConnector = telegramConnector;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("[Inicializando BOT]");

        try
        {
            var result = await _telegramConnector.InitializeBot();
            _logger.LogInformation(message: $"[Mensaje de BOT]: {result?.Message}");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[Error en el servicio: {ex.InnerException}]");
        }

        _logger.LogInformation("[BOT finalizado]");
    }
}