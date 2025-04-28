using TesterProject.BusinessLogic.TelegramBot;

namespace TesterWorkerService
{
    public class Worker(ILogger<Worker> logger, TelegramConnector telegramConnector) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;
        private readonly TelegramConnector _telegramConnector = telegramConnector;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("[Inicializando BOT]");

            try
            {
                TesterProject.BusinessEntities.TelegramResult? result = await _telegramConnector.InitializeBot();
                _logger.LogInformation("[Mensaje de BOT]: {Message}", result?.Message);

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Error en el servicio: {InnerException}]", ex.InnerException);
            }

            _logger.LogInformation("[BOT finalizado]");
        }
    }
}